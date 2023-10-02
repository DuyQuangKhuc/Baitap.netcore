using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

class CanBo
{
    public string HoTen { get; set; }
    public int Tuổi { get; set; }
    public string GioiTinh { get; set; }
    public string DiaChi { get; set; }

}


class CongNhan : CanBo
{
    public int Bac { get; set; }


}


class KySu : CanBo
{
    public string NganhDaoTao { get; set; }


}


class NhanVien : CanBo
{
    public string CongViec { get; set; }


}


class QLCB
{
    List<CanBo> danhSachCanBo;

    public QLCB()
    {
        danhSachCanBo = new List<CanBo>();
    }

    public void ThemMoiCanBo(CanBo canBo)
    {
        danhSachCanBo.Add(canBo);
    }

    public void TimKiemTheoHoTen(string hoTen)
    {
        Console.OutputEncoding = Encoding.UTF8;
        bool found = false;
        foreach (CanBo canBo in danhSachCanBo)
        {
            if (canBo.HoTen.ToLower().Contains(hoTen.ToLower()))
            {
                found = true;
                if (canBo is CongNhan)
                {
                    Console.WriteLine("Cán bộ là công nhân:");
                    CongNhan congNhan = canBo as CongNhan;
                    Console.WriteLine($"Họ tên: {congNhan.HoTen}");
                    Console.WriteLine($"Tuổi: {congNhan.Tuổi}");
                    Console.WriteLine($"Giới tính: {congNhan.GioiTinh}");
                    Console.WriteLine($"Địa chỉ: {congNhan.DiaChi}");
                    Console.WriteLine($"Bậc: {congNhan.Bac}");
                }
                else if (canBo is KySu)
                {
                    Console.WriteLine("Cán bộ là kĩ sư:");
                    KySu kySu = canBo as KySu;
                    Console.WriteLine($"Họ tên: {kySu.HoTen}");
                    Console.WriteLine($"Tuổi: {kySu.Tuổi}");
                    Console.WriteLine($"Giới tính: {kySu.GioiTinh}");
                    Console.WriteLine($"Địa chỉ: {kySu.DiaChi}");
                    Console.WriteLine($"Ngành đào tạo: {kySu.NganhDaoTao}");
                }
                else if (canBo is NhanVien)
                {
                    Console.WriteLine("Can bo la nhan vien:");
                    NhanVien nhanVien = canBo as NhanVien;
                    Console.WriteLine($"Họ tên: {nhanVien.HoTen}");
                    Console.WriteLine($"Tuổi: {nhanVien.Tuổi}");
                    Console.WriteLine($"Giới tính: {nhanVien.GioiTinh}");
                    Console.WriteLine($"Địa chỉ: {nhanVien.DiaChi}");
                    Console.WriteLine($"Công việc: {nhanVien.CongViec}");
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Không tìm thấy cán bộ này!");
        }
    }

    public void HienThiDanhSachCanBo()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Danh sách cán bộ:");
        foreach (CanBo canBo in danhSachCanBo)
        {
            if (canBo is CongNhan)
            {
                Console.WriteLine("Cong nhan:");
                CongNhan congNhan = canBo as CongNhan;
                Console.WriteLine($"Họ tên: {congNhan.HoTen}");
                Console.WriteLine($"Tuổi: {congNhan.Tuổi}");
                Console.WriteLine($"Giới tính: {congNhan.GioiTinh}");
                Console.WriteLine($"Địa chỉ: {congNhan.DiaChi}");
                Console.WriteLine($"Bậc: {congNhan.Bac}");
            }
            else if (canBo is KySu)
            {
                Console.WriteLine("Ky su:");
                KySu kySu = canBo as KySu;
                Console.WriteLine($"Họ tên: {kySu.HoTen}");
                Console.WriteLine($"Tuổi: {kySu.Tuổi}");
                Console.WriteLine($"Giới tính: {kySu.GioiTinh}");
                Console.WriteLine($"Địa chỉ: {kySu.DiaChi}");
                Console.WriteLine($"Ngành đào tạo: {kySu.NganhDaoTao}");
            }
            else if (canBo is NhanVien)
            {
                Console.WriteLine("Nhan vien:");
                NhanVien nhanVien = canBo as NhanVien;
                Console.WriteLine($"Họ tên: {nhanVien.HoTen}");
                Console.WriteLine($"Tuổi: {nhanVien.Tuổi}");
                Console.WriteLine($"Giới tính: {nhanVien.GioiTinh}");
                Console.WriteLine($"Địa chỉ: {nhanVien.DiaChi}");
                Console.WriteLine($"Công việc: {nhanVien.CongViec}");
            }
            Console.WriteLine();
        }

    }
}

class Program
{
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
    static string GetValidateGioiTinh()
    {
        string name = "";

        try
        {
            Console.Write("Giới tính(nam/nu/khac): ");
            name = Console.ReadLine();
            if (name.ToLower() != "nam" && name.ToLower() != "nu" && name.ToLower() != "khac")
            {
                throw new Exception("Giới tính không hợp lệ!");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Mời nhập lại .");
            return GetValidateGioiTinh(); // Yêu cầu nhập lại tên khi ngoại lệ xảy ra
        }

        return name;
    }
    static string GetValidateDiaChi()
    {
        string name = "";

        try
        {
            Console.Write("Địa chỉ: ");
            name = Console.ReadLine();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Mời nhập lại.");
            return GetValidateDiaChi(); // Yêu cầu nhập lại tên khi ngoại lệ xảy ra
        }

        return name;
    }
    static int GetValidAge()
    {
        int number;

        try
        {
            Console.Write("Tuổi: ");
            number = int.Parse(Console.ReadLine());
            if (number < 0 || number > 100)
            {
                throw new Exception("Tuổi không hợp lệ!");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Mời nhập lại.");
            return GetValidAge(); // Yêu cầu nhập lại tên khi ngoại lệ xảy ra
        }

        return number;
    }
    static int GetValidNumber()
    {
        int number;

        try
        {

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
    static void Main(string[] args)
    {
        QLCB quanLyCanBo = new QLCB();
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Thêm mới cán bộ");
            Console.WriteLine("2. Tìm kiếm theo cán bộ");
            Console.WriteLine("3. Danh sách");
            Console.WriteLine("4. Thoát");
            Console.Write("Vui lòng chọn từ (1-4): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("----- Nhập khối -----");
                        Console.Write("Loại cán bộ (1: Khối A, 2: Khối B, 3: Khối C): ");
                        Console.Write("Nhập loại cán bộ: ");
                        int loaiCanBo = GetValidNumber();
                        string hoTen = GetValidName();
                        int Tuổi = GetValidAge();
                        string gioiTinh = GetValidateGioiTinh();
                        string diaChi = GetValidateDiaChi();
                        switch (loaiCanBo)
                        {
                            case 1:

                                Console.Write("Bậc: ");
                                int bac = int.Parse(Console.ReadLine());
                                CongNhan congNhan = new CongNhan()
                                {
                                    HoTen = hoTen,
                                    Tuổi = Tuổi,
                                    GioiTinh = gioiTinh,
                                    DiaChi = diaChi,
                                    Bac = bac
                                };
                                quanLyCanBo.ThemMoiCanBo(congNhan);
                                break;
                            case 2:
                                Console.Write("Ngành đào tạo: ");
                                string nganhDaoTao = Console.ReadLine();
                                KySu kySu = new KySu()
                                {
                                    HoTen = hoTen,
                                    Tuổi = Tuổi,
                                    GioiTinh = gioiTinh,
                                    DiaChi = diaChi,
                                    NganhDaoTao = nganhDaoTao
                                };
                                quanLyCanBo.ThemMoiCanBo(kySu);
                                break;
                            case 3:
                                Console.Write("Công việc: ");
                                string congViec = Console.ReadLine();
                                NhanVien nhanVien = new NhanVien()
                                {
                                    HoTen = hoTen,
                                    Tuổi = Tuổi,
                                    GioiTinh = gioiTinh,
                                    DiaChi = diaChi,
                                    CongViec = congViec
                                };
                                quanLyCanBo.ThemMoiCanBo(nhanVien);
                                break;
                            default:
                                Console.WriteLine("Hãy lựa chọn đúng.");
                                break;
                        }
                        Console.WriteLine("Thêm mới thành công.");
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("----- Tìm kiếm theo Họ tên -----");
                        Console.Write("Họ tên cần tìm: ");
                        string tenCanTim = Console.ReadLine();
                        quanLyCanBo.TimKiemTheoHoTen(tenCanTim);
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("----- Hiển thị danh sách cán bộ -----");
                        quanLyCanBo.HienThiDanhSachCanBo();
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("----- Thoát khỏi chương trình -----");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        Console.WriteLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Lua chon khong hop le.");
                Console.WriteLine();
            }
        }
    }
}