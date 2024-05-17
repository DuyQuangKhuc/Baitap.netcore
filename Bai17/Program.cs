using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

// Lớp SinhVien chứa thông tin chung của sinh viên
class SinhVien : KetQuaHocTap
{
    public string MaSV { get; set; }
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public int NamVaoHoc { get; set; }
    public double DiemDauVao { get; set; }
    public List<KetQuaHocTap> DanhSachKetQua { get; set; }

    public SinhVien() { }

    public SinhVien(string maSV, string hoTen, DateTime ngaySinh, int namVaoHoc, double diemDauVao, string tenHocKy, double diemTrungBinh) : base(tenHocKy, diemTrungBinh)
    {
        MaSV = maSV;
        HoTen = hoTen;
        NgaySinh = ngaySinh;
        NamVaoHoc = namVaoHoc;
        DiemDauVao = diemDauVao;
        DanhSachKetQua = new List<KetQuaHocTap>();
    }

    public SinhVien(SinhVien sv)
    {
        MaSV = sv.MaSV;
        HoTen = sv.HoTen;
        NgaySinh = sv.NgaySinh;
        NamVaoHoc = sv.NamVaoHoc;
        DiemDauVao = sv.DiemDauVao;
        DanhSachKetQua = new List<KetQuaHocTap>(sv.DanhSachKetQua);
    }
    
    static string GetValidName()
    {
        string name = "";

        try
        {
            Console.Write("Họ và tên: ");
            name = Console.ReadLine();

            // Kiểm tra tên có nằm trong khoảng từ 3 đến 20 ký tự không
            if (name.Length < 2 || name.Length > 100)
            {
                throw new Exception("Độ dài tên không chính xác!");
            }
            foreach (char c in name)
            {
                if (!Char.IsLetter(c)) // Kiểm tra xem các kí tự có phải là chữ không
                {
                    throw new Exception("Tên không thể chứa kí tự đặc biệt");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Mới nhập lại.");
            return GetValidName(); // Yêu cầu nhập lại tên khi ngoại lệ xảy ra
        }

        return name;
    }
    
   
   
    static int GetValidNumber()
    {
        int number;

        try
        {
            Console.WriteLine("Nhập năm vào học: ");
            number = int.Parse(Console.ReadLine());

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Mời nhập lại.");
            return GetValidNumber(); // Yêu cầu nhập lại tên khi ngoại lệ xảy ra
        }

        return number;
    }
    static DateTime ValidDate(string a)
    {
        DateTime date;
        while (true)
        {
            Console.Write("Nhập ngày tháng năm sinh (dd/MM/yyyy): ");
            string input = Console.ReadLine();


            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
            {
                break;
            }
            else
            {
                Console.WriteLine("Sai định dạng ngày/tháng/năm.");
            }
        }
        return date;
    }
    public override void NhapThongTin()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.WriteLine("Nhập mã sinh viên: ");
        MaSV = Console.ReadLine();

        HoTen = GetValidName();

        NgaySinh = ValidDate("Nhập ngày sinh (dd/mm/yyyy): ");

       
        NamVaoHoc = GetValidNumber();

        DiemDauVao = KetQuaHocTap.GetValidPoint("Nhập điểm đầu vào:");
        base.NhapThongTin();
    }

    public override void XuatThongTin()
    {
        Console.WriteLine("Mã sinh viên: " + MaSV);
        Console.WriteLine("Họ tên: " + HoTen);
        Console.WriteLine("Ngày sinh: " + NgaySinh.ToString("dd/MM/yyyy"));
        Console.WriteLine("Năm vào học: " + NamVaoHoc);
        Console.WriteLine("Điểm đầu vào: " + DiemDauVao);
        base.XuatThongTin();
    }

    public bool LaSinhVienChinhQuy()
    {
        return true;
    }


}

class SinhVienTaiChuc : SinhVien
{
    public string NoiLienKet { get; set; }

    public SinhVienTaiChuc() { }

    public SinhVienTaiChuc(string maSV, string hoTen, DateTime ngaySinh, int namVaoHoc, double diemDauVao, string tenHocKy, double diemTrungBinh, string noiLienKet)
        : base(maSV, hoTen, ngaySinh, namVaoHoc, diemDauVao, tenHocKy, diemTrungBinh)
    {
        NoiLienKet = noiLienKet;
    }

    public SinhVienTaiChuc(SinhVienTaiChuc sv)
        : base(sv)
    {
        NoiLienKet = sv.NoiLienKet;
    }

    public override void NhapThongTin()
    {
        base.NhapThongTin();
        Console.InputEncoding = Encoding.UTF8;
        Console.WriteLine("Nhập nơi liên kết đào tạo: ");
        NoiLienKet = Console.ReadLine();
    }

    public override void XuatThongTin()
    {
        base.XuatThongTin();
        Console.WriteLine("Nơi liên kết đào tạo: " + NoiLienKet);
    }
                 

}

// Lớp Khoa chứa thông tin về khoa và danh sách sinh viên đang theo học hello
class Khoa
{
    public string TenKhoa { get; set; }
    public List<SinhVien> DanhSachSinhVien { get; set; }

    public Khoa()
    {
        DanhSachSinhVien = new List<SinhVien>();
    }

    public void ThemSinhVien(SinhVien sv)
    {
        DanhSachSinhVien.Add(sv);
    }

    public int TongSoSinhVienChinhQuy()
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
        SinhVien sinhVienMax = null;
        double maxDiemDauVao = 0;
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            if (sv.DiemDauVao > maxDiemDauVao)
            {
                maxDiemDauVao = sv.DiemDauVao;
                sinhVienMax = sv;
            }
        }
        return sinhVienMax;
    }

    public List<SinhVienTaiChuc> LayDanhSachSinhVienTaiChuc(string noiLienKet)
    {
        List<SinhVienTaiChuc> danhSachSinhVienTaiChuc = new List<SinhVienTaiChuc>();
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            if (sv is SinhVienTaiChuc)
            {
                SinhVienTaiChuc svTaiChuc = (SinhVienTaiChuc)sv;
                if (svTaiChuc.NoiLienKet == noiLienKet)
                {
                    danhSachSinhVienTaiChuc.Add(svTaiChuc);
                }
            }
        }
        return danhSachSinhVienTaiChuc;
    }

    public List<SinhVien> DanhSachSinhVienDiemTBHon8(string tenHocKy)
    {
        List<SinhVien> dsSinhVienDiemTBHon8 = new List<SinhVien>();
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            if (DiemTrungBinhHocKy(tenHocKy) >= 8.0)
            {
                dsSinhVienDiemTBHon8.Add(sv);
            }
        }
        return dsSinhVienDiemTBHon8;
    }
    public double DiemTrungBinhHocKy(string tenHocKy)
    {
        foreach (SinhVien ketQua in DanhSachSinhVien)
        {
            if (ketQua.TenHocKy.ToLower() == tenHocKy.ToLower())
            {
                return ketQua.DiemTrungBinh;
            }
        }
        return 0;
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

// Lớp KetQuaHocTap chứa thông tin về kết quả học tập của sinh viên
public class KetQuaHocTap
{
    public string TenHocKy { get; set; }
    public double DiemTrungBinh { get; set; }

    public KetQuaHocTap() { }

    public KetQuaHocTap(string tenHocKy, double diemTrungBinh)
    {
        TenHocKy = tenHocKy;
        DiemTrungBinh = diemTrungBinh;
    }
     public static double GetValidPoint(string s)
    {
        double number;

        try
        {
            Console.WriteLine(s);
            number = double.Parse(Console.ReadLine());
            if (number < 0 || number > 10)
            {
                throw new Exception("Điểm không hợp lệ!");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Mời nhập lại.");
            return GetValidPoint(s); // Yêu cầu nhập lại tên khi ngoại lệ xảy ra
        }

        return number;
    }
    public virtual void NhapThongTin()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.WriteLine("Tên học kì: ");
        TenHocKy = Console.ReadLine();

        Console.WriteLine("Điểm trung bình: ");
        DiemTrungBinh = GetValidPoint("Nhập điểm trung bình: ");


    }

    public virtual void XuatThongTin()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Tên học kì: " + TenHocKy);

        Console.WriteLine("Điểm trung bình: " + DiemTrungBinh);
    }

    // Lớp SinhVienComparer để sắp xếp danh sách sinh viên
}
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
    static void Main()
    {
        Khoa khoa = new Khoa();
        int choice;
        do
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("----- Quản lý sinh viên -----");
            Console.WriteLine("1. Thêm sinh viên");
            Console.WriteLine("2. Hiển thị thông tin sinh viên");
            Console.WriteLine("3. Tính tổng số sinh viên chính quy");
            Console.WriteLine("4. Tìm sinh viên có điểm đầu vào cao nhất");
            Console.WriteLine("5. Hiển thị danh sách sinh viên tại chức tại nơi liên kết đào tạo");
            Console.WriteLine("6. Hiển thị danh sách sinh viên có điểm trung bình từ 8.0 trở lên");
            Console.WriteLine("7. Tìm sinh viên có điểm trung bình cao nhất");
            Console.WriteLine("8. Sắp xếp danh sách sinh viên");
            Console.WriteLine("9. Thống kê số lượng sinh viên theo năm vào học");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("---------------------------------");

            Console.WriteLine("Nhập lựa chọn: ");
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Chọn loại sinh viên (1: Chính quy, 2: Tại chức): ");
                    int type;
                    int.TryParse(Console.ReadLine(), out type);

                    SinhVien sv;
                    if (type == 1)
                    {
                        sv = new SinhVien();
                    }
                    else
                    {
                        sv = new SinhVienTaiChuc();
                    }

                    sv.NhapThongTin();
                    khoa.ThemSinhVien(sv);
                    Console.WriteLine("Thêm sinh viên thành công!");
                    break;
                case 2:
                    Console.WriteLine("Nhập mã sinh viên: ");
                    string maSV = Console.ReadLine();

                    SinhVien sinhVien = khoa.DanhSachSinhVien.Find(sv => sv.MaSV == maSV);
                    if (sinhVien != null)
                    {
                        sinhVien.XuatThongTin();
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy sinh viên!");
                    }
                    break;
                case 3:
                    int tongSinhVienChinhQuy = khoa.TongSoSinhVienChinhQuy();
                    Console.WriteLine("Tổng số sinh viên chính quy: " + tongSinhVienChinhQuy);
                    break;
                case 4:
                    SinhVien sinhVienMaxDiemDauVao = khoa.TimSinhVienDiemDauVaoCaoNhat();
                    Console.WriteLine("Sinh viên có điểm đầu vào cao nhất: ");
                    sinhVienMaxDiemDauVao.XuatThongTin();
                    break;
                case 5:
                    Console.WriteLine("Nhập nơi liên kết đào tạo: ");
                    string noiLienKet = Console.ReadLine();

                    List<SinhVienTaiChuc> danhSachSinhVienTaiChuc = khoa.LayDanhSachSinhVienTaiChuc(noiLienKet);
                    Console.WriteLine("Danh sách sinh viên tại chức tại nơi liên kết đào tạo: ");
                    foreach (SinhVienTaiChuc svtc in danhSachSinhVienTaiChuc)
                    {
                        svtc.XuatThongTin();
                    }
                    break;
                case 6:
                    Console.WriteLine("Học kì: ");
                    string namhoc = Console.ReadLine();
                    List<SinhVien> danhSachSinhVienDiemCao = khoa.DanhSachSinhVienDiemTBHon8(namhoc);
                    Console.WriteLine("Danh sách sinh viên có điểm trung bình từ 8.0 trở lên: ");
                    foreach (SinhVien sv2 in danhSachSinhVienDiemCao)
                    {
                        sv2.XuatThongTin();
                    }
                    break;
                case 7:
                    SinhVien sinhVienMaxDiemTrungBinh = khoa.SinhVienDiemTBHocKyCaoNhat();
                    Console.WriteLine("Sinh viên có điểm trung bình cao nhất: ");
                    sinhVienMaxDiemTrungBinh.XuatThongTin();
                    break;
                case 8:
                    khoa.SapXepSinhVien();
                    Console.WriteLine("Danh sách sinh viên sau sắp xếp: ");
                    foreach (SinhVien sv1 in khoa.DanhSachSinhVien)
                    {
                        sv1.XuatThongTin();
                    }
                    break;
                case 9:
                    Dictionary<int, int> thongKe = khoa.ThongKeSoLuongSinhVienTheoNamVaoHoc();
                    Console.WriteLine("Thống kê sinh viên theo năm học ");
                    foreach (KeyValuePair<int, int> kvp in thongKe)
                    {
                        Console.WriteLine("Nam " + kvp.Key + ": " + kvp.Value);
                    }
                    break;
                case 0:
                    Console.WriteLine("Thoát chương trình!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        } while (choice != 0);
    }
}