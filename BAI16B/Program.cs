using System;
using System.Collections.Generic;

// Lớp SinhVien
class SinhVien
{
    public string MaSinhVien { get; set; }
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public int NamVaoHoc { get; set; }
    public double DiemDauVao { get; set; }
    public List<KetQuaHocTap> DanhSachKetQua { get; set; }

    public SinhVien()
    {
        DanhSachKetQua = new List<KetQuaHocTap>();
    }

    public SinhVien(string maSV, string hoTen, DateTime ngaySinh, int namVaoHoc, double diemDauVao)
    {
        MaSinhVien = maSV;
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        NamVaoHoc = namVaoHoc;
        DiemDauVao = diemDauVao;
        DanhSachKetQua = new List<KetQuaHocTap>();
    }

    public SinhVien(SinhVien sv)
    {
        MaSinhVien = sv.MaSinhVien;
        HoTen = sv.HoTen;
        NgaySinh = sv.NgaySinh;
        NamVaoHoc = sv.NamVaoHoc;
        DiemDauVao = sv.DiemDauVao;
        DanhSachKetQua = new List<KetQuaHocTap>(sv.DanhSachKetQua);
    }



    public void XuatThongTin()
    {
        Console.WriteLine("Thong tin sinh vien:");
        Console.WriteLine("Ma sinh vien: " + MaSinhVien);
        Console.WriteLine("Ho ten: " + HoTen);
        Console.WriteLine("Ngay sinh: " + NgaySinh.ToString("dd/MM/yyyy"));
        Console.WriteLine("Nam vao hoc: " + NamVaoHoc);
        Console.WriteLine("Diem dau vao: " + DiemDauVao);
    }

    public bool LaSinhVienChinhQuy()
    {
        return DiemDauVao >= 8.0;
    }

    public double DiemTrungBinhHocKy(string tenHocKy)
    {
        foreach (KetQuaHocTap ketQua in DanhSachKetQua)
        {
            if (ketQua.TenHocKy == tenHocKy)
            {
                return ketQua.DiemTrungBinh;
            }
        }
        return 0;
    }
}

// Lớp SinhVienTaiChuc kế thừa từ lớp SinhVien
class SinhVienTaiChuc : SinhVien
{
    public string NoiLienKetDaoTao { get; set; }

    public SinhVienTaiChuc()
    {
    }

    public SinhVienTaiChuc(string maSV, string hoTen, DateTime ngaySinh, int namVaoHoc, double diemDauVao, string noiLienKetDaoTao)
        : base(maSV, hoTen, ngaySinh, namVaoHoc, diemDauVao)
    {
        NoiLienKetDaoTao = noiLienKetDaoTao;
    }

    public SinhVienTaiChuc(SinhVienTaiChuc sv)
        : base(sv)
    {
        NoiLienKetDaoTao = sv.NoiLienKetDaoTao;
    }

    public new void NhapThongTin()
    {
        //base.NhapThongTin();
        Console.Write("Noi lien ket dao tao: ");
        NoiLienKetDaoTao = Console.ReadLine();
    }

    public new void XuatThongTin()
    {
        base.XuatThongTin();
        Console.WriteLine("Noi lien ket dao tao: " + NoiLienKetDaoTao);
    }
}

// Lớp Khoa
class Khoa
{
    public string TenKhoa { get; set; }

    public List<SinhVien> DanhSachSinhVien { get; set; }

    public Khoa()
    {
        DanhSachSinhVien = new List<SinhVien>();
    }

    public Khoa(string tenKhoa)
    {

        TenKhoa = tenKhoa;
        DanhSachSinhVien = new List<SinhVien>();
    }

    public void ThemSinhVien(SinhVien sv)
    {
        DanhSachSinhVien.Add(sv);
    }

    public int TongSinhVienChinhQuy()
    {
        int count = 0;
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            if (sv.LaSinhVienChinhQuy())
            {
                count++;
            }
        }
        return count;
    }

    public SinhVien TimSinhVienDiemDauVaoCaoNhat()
    {
        SinhVien svMax = null;
        double maxDiem = 0;
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            if (sv.DiemDauVao > maxDiem)
            {
                maxDiem = sv.DiemDauVao;
                svMax = sv;
            }
        }
        return svMax;
    }

    public List<SinhVienTaiChuc> DanhSachSinhVienTaiChuc(string noiLienKet)
    {
        List<SinhVienTaiChuc> dsSinhVienTaiChuc = new List<SinhVienTaiChuc>();
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            if (sv is SinhVienTaiChuc && ((SinhVienTaiChuc)sv).NoiLienKetDaoTao == noiLienKet)
            {
                dsSinhVienTaiChuc.Add((SinhVienTaiChuc)sv);
            }
        }
        return dsSinhVienTaiChuc;
    }

    public List<SinhVien> DanhSachSinhVienDiemTBHon8(string tenHocKy)
    {
        List<SinhVien> dsSinhVienDiemTBHon8 = new List<SinhVien>();
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            if (sv.DiemTrungBinhHocKy(tenHocKy) >= 8.0)
            {
                dsSinhVienDiemTBHon8.Add(sv);
            }
        }
        return dsSinhVienDiemTBHon8;
    }

    public SinhVien SinhVienDiemTBHocKyCaoNhat()
    {
        SinhVien svMax = null;
        double maxDiem = 0;
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            foreach (KetQuaHocTap ketQua in sv.DanhSachKetQua)
            {
                if (ketQua.DiemTrungBinh > maxDiem)
                {
                    maxDiem = ketQua.DiemTrungBinh;
                    svMax = sv;
                }
            }
        }
        return svMax;
    }

    public void SapXepSinhVien()
    {
        DanhSachSinhVien.Sort(new SinhVienComparer());
    }

    public Dictionary<int, int> ThongKeSoLuongSinhVienTheoNamVaoHoc()
    {
        Dictionary<int, int> thongKe = new Dictionary<int, int>();
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            if (thongKe.ContainsKey(sv.NamVaoHoc))
            {
                thongKe[sv.NamVaoHoc]++;
            }
            else
            {
                thongKe[sv.NamVaoHoc] = 1;
            }
        }
        return thongKe;
    }
}

// Lớp KetQuaHocTap
class KetQuaHocTap
{
    public string TenHocKy { get; set; }
    public double DiemTrungBinh { get; set; }

    public KetQuaHocTap()
    {
    }

    public KetQuaHocTap(string tenHocKy, double diemTrungBinh)
    {
        TenHocKy = tenHocKy;
        DiemTrungBinh = diemTrungBinh;
    }
}

// Lớp SinhVienComparer để sắp xếp danh sách sinh viên
class SinhVienComparer : IComparer<SinhVien>
{
    public int Compare(SinhVien sv1, SinhVien sv2)
    {
        // Sắp xếp tăng dần theo loại sinh viên (chính quy trước, tại chức sau)
        if (sv1.LaSinhVienChinhQuy() && !sv2.LaSinhVienChinhQuy())
        {
            return -1;
        }
        else if (!sv1.LaSinhVienChinhQuy() && sv2.LaSinhVienChinhQuy())
        {
            return 1;
        }
        else
        {
            // Sắp xếp giảm dần theo năm vào học
            return sv2.NamVaoHoc.CompareTo(sv1.NamVaoHoc);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Khoa khoa = new Khoa("Khoa CNTT");

        SinhVien sv1 = new SinhVien("SV001", "Nguyen Van A", new DateTime(2000, 1, 1), 2020, 8.5);
        sv1.DanhSachKetQua.Add(new KetQuaHocTap("HK1", 8.5));
        sv1.DanhSachKetQua.Add(new KetQuaHocTap("HK2", 9.0));
        khoa.ThemSinhVien(sv1);

        SinhVien sv2 = new SinhVienTaiChuc("SV002", "Tran Thi B", new DateTime(2001, 2, 2), 2019, 7.8, "Dong Nai");
        sv2.DanhSachKetQua.Add(new KetQuaHocTap("HK1", 7.5));
        sv2.DanhSachKetQua.Add(new KetQuaHocTap("HK2", 8.0));
        khoa.ThemSinhVien(sv2);

        SinhVien sv3 = new SinhVien("SV003", "Le Van C", new DateTime(2002, 3, 3), 2020, 7.2);
        sv3.DanhSachKetQua.Add(new KetQuaHocTap("HK1", 7.0));
        sv3.DanhSachKetQua.Add(new KetQuaHocTap("HK2", 7.5));
        khoa.ThemSinhVien(sv3);

        SinhVien sv4 = new SinhVienTaiChuc("SV004", "Pham Thi D", new DateTime(2001, 4, 4), 2019, 8.2, "Ca Mau");
        sv4.DanhSachKetQua.Add(new KetQuaHocTap("HK1", 8.0));
        sv4.DanhSachKetQua.Add(new KetQuaHocTap("HK2", 8.5));
        khoa.ThemSinhVien(sv4);

        Console.WriteLine("\n-----------------------------------------------------------------------\n");

        Console.WriteLine("Tong so sinh vien chinh quy: " + khoa.TongSinhVienChinhQuy());

        Console.WriteLine("\n-----------------------------------------------------------------------\n");

        SinhVien svMaxDiemDauVao = khoa.TimSinhVienDiemDauVaoCaoNhat();
        Console.WriteLine("Sinh vien co diem dau vao cao nhat: ");
        svMaxDiemDauVao.XuatThongTin();
        Console.WriteLine("\n-----------------------------------------------------------------------\n");

        List<SinhVienTaiChuc> dsSinhVienTaiChuc = khoa.DanhSachSinhVienTaiChuc("Dong Nai");
        Console.WriteLine("Danh sach sinh vien tai chuc tai Dong Nai: ");
        foreach (SinhVienTaiChuc sv in dsSinhVienTaiChuc)
        {
            sv.XuatThongTin();
        }
        Console.WriteLine("\n-----------------------------------------------------------------------\n");

        List<SinhVien> dsSinhVienDiemTBHon8 = khoa.DanhSachSinhVienDiemTBHon8("HK2");
        Console.WriteLine("Danh sach sinh vien co diem trung binh hon 8.0 trong HK2: ");
        foreach (SinhVien sv in dsSinhVienDiemTBHon8)
        {
            sv.XuatThongTin();
        }
        Console.WriteLine("\n-----------------------------------------------------------------------\n");

        SinhVien svMaxDiemTBHocKy = khoa.SinhVienDiemTBHocKyCaoNhat();
        Console.WriteLine("Sinh vien co diem trung binh hoc ky cao nhat: ");
        svMaxDiemTBHocKy.XuatThongTin();

        Console.WriteLine("\n-----------------------------------------------------------------------\n");
        khoa.SapXepSinhVien();
        Console.WriteLine("Danh sach sinh vien sau khi sap xep: ");
        foreach (SinhVien sv in khoa.DanhSachSinhVien)
        {
            sv.XuatThongTin();
        }
        Console.WriteLine("\n-----------------------------------------------------------------------\n");

        Dictionary<int, int> thongKe = khoa.ThongKeSoLuongSinhVienTheoNamVaoHoc();
        Console.WriteLine("Thong ke so luong sinh vien theo nam vao hoc: ");
        foreach (KeyValuePair<int, int> kvp in thongKe)
        {
            Console.WriteLine("Nam " + kvp.Key + ": " + kvp.Value);
        }

    }
}