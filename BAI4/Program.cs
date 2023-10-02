using System;
using System.Collections.Generic;
using System.Text;

class Nguoi
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public string NgheNghiep { get; set; }
    public string SoCMND { get; set; }
}


class HoGiaDinh
{
    public int SoThanhVien { get; set; }
    public string SoNha { get; set; }
    public List<Nguoi> ThanhVien { get; set; }

    public HoGiaDinh()
    {
        ThanhVien = new List<Nguoi>();
    }
}


class KhuPho
{
    public List<HoGiaDinh> DanhSachHoGiaDinh { get; set; }

    public KhuPho()
    {
        DanhSachHoGiaDinh = new List<HoGiaDinh>();
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
    
    public void NhapThongTin(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Nhập thông tin hộ gia đình thứ {0}:", i + 1);
            HoGiaDinh hoGiaDinh = new HoGiaDinh();

            Console.Write("Số thành viên trong gia đình: ");
            hoGiaDinh.SoThanhVien = GetValidNumber();

            Console.Write("Số nhà: ");
            hoGiaDinh.SoNha = Console.ReadLine();

            for (int j = 0; j < hoGiaDinh.SoThanhVien; j++)
            {
                Console.WriteLine("Thông tin thành viên thứ {0}:", j + 1);
                Nguoi nguoi = new Nguoi();

                nguoi.HoTen = GetValidName();

                nguoi.Tuoi = GetValidAge();


                Console.Write("Nghề nghiệp: ");

                nguoi.NgheNghiep = Console.ReadLine();

                Console.Write("Số CMND: ");
                nguoi.SoCMND = Console.ReadLine();

                hoGiaDinh.ThanhVien.Add(nguoi);
            }

            DanhSachHoGiaDinh.Add(hoGiaDinh);
        }
    }

    public void HienThiThongTin()
    {
        Console.WriteLine("Thông tin các hộ gia đình trong khu phố:");
        foreach (var hoGiaDinh in DanhSachHoGiaDinh)
        {
            Console.WriteLine("Số nhà: {0}", hoGiaDinh.SoNha);
            Console.WriteLine("Số thành viên: {0}", hoGiaDinh.SoThanhVien);
            Console.WriteLine("Danh sách thành viên:");

            foreach (var nguoi in hoGiaDinh.ThanhVien)
            {
                Console.WriteLine("Họ tên: {0}", nguoi.HoTen);
                Console.WriteLine("Tuổi: {0}", nguoi.Tuoi);
                Console.WriteLine("Nghề nghiệp: {0}", nguoi.NgheNghiep);
                Console.WriteLine("Số CMND: {0}", nguoi.SoCMND);
                Console.WriteLine();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Nhập số hộ dân: ");
        int n = int.Parse(Console.ReadLine());

        KhuPho khuPho = new KhuPho();
        khuPho.NhapThongTin(n);
        khuPho.HienThiThongTin();

        Console.ReadLine();
    }
}