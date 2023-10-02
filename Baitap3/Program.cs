using System;
using System.Collections.Generic;
using System.Text;

class Student
{
    public string SBD { get; set; }
    public string Ten { get; set; }

    public string Diachi { get; set; }

    public string Uutien { get; set; }
}
class KhoiA : Student{
    public double Toan { get; set; }
    public double Ly { get; set;}

    public double Hoa { get; set;}

}
class KhoiB : Student
{
    public double Toan { get; set; }
    public double Hoa { get; set; }

    public double Sinh { get; set; }

}
class KhoiC : Student
{
    public double Van  { get; set; }
    public double Su { get; set; }

    public double Dia { get; set; }

}
class QLBD
{
    List<Student> danhSachSinhVien;

    public QLBD()
    {
        danhSachSinhVien = new List<Student>();
    }

    public void ThemMoiHocSinh(Student canBo)
    {
        danhSachSinhVien.Add(canBo);
    }

    public void TimKiemTheoSBD(string sbd)
    {
        bool found = false;
        foreach (Student student in danhSachSinhVien)
        {
            if (student.SBD.ToLower() == sbd.ToLower())
            {
                found = true;
                if (student is KhoiA)
                {
                    Console.WriteLine("Sinh viên khối A:");
                    KhoiA studentkhoiA = student as KhoiA;
                    Console.WriteLine($"SBD: {studentkhoiA.SBD}");
                    Console.WriteLine($"Tên: {studentkhoiA.Ten}");
                    Console.WriteLine($"Địa chỉ: {studentkhoiA.Diachi}");
                    Console.WriteLine($"Ưu tiên: {studentkhoiA.Uutien}");
                    Console.WriteLine($"Diem toan: {studentkhoiA.Toan}");
                    Console.WriteLine($"Diem ly: {studentkhoiA.Ly}");
                    Console.WriteLine($"Diem hoa: {studentkhoiA.Hoa}");
                }
                else if (student is KhoiB)
                {
                    Console.WriteLine("Sinh viên khối B:");
                    KhoiB studentkhoiB = student as KhoiB;
                    Console.WriteLine($"SBD: {studentkhoiB.SBD}");
                    Console.WriteLine($"Tên: {studentkhoiB.Ten}");
                    Console.WriteLine($"Địa chỉ: {studentkhoiB.Diachi}");
                    Console.WriteLine($"Ưu tiên: {studentkhoiB.Uutien}");
                    Console.WriteLine($"Diem toan: {studentkhoiB.Toan}");
                    Console.WriteLine($"Diem Hoa: {studentkhoiB.Hoa}");
                    Console.WriteLine($"Diem Sinh: {studentkhoiB.Sinh}");
                }
                else if (student is KhoiC)
                {
                    Console.WriteLine("Sinh viên khối C:");
                    KhoiC studentkhoiC = student as KhoiC;
                    Console.WriteLine($"SBD: {studentkhoiC.SBD}");
                    Console.WriteLine($"Tên: {studentkhoiC.Ten}");
                    Console.WriteLine($"Địa chỉ: {studentkhoiC.Diachi}");
                    Console.WriteLine($"Ưu tiên: {studentkhoiC.Uutien}");
                    Console.WriteLine($"Diem Van: {studentkhoiC.Van}");
                    Console.WriteLine($"Diem Su: {studentkhoiC.Su}");
                    Console.WriteLine($"Diem Dia: {studentkhoiC.Dia}");
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Không tìm thấy cán bộ có họ tên này!");
        }
    }

    public void HienThidanhSachSinhVien()
    {
        Console.WriteLine("Danh sách cán bộ:");
        foreach (Student student in danhSachSinhVien)
        {
            if (student is KhoiA)
            {
                Console.WriteLine("Sinh viên khối A:");
                KhoiA studentkhoiA = student as KhoiA;
                Console.WriteLine($"SBD: {studentkhoiA.SBD}");
                Console.WriteLine($"Tên: {studentkhoiA.Ten}");
                Console.WriteLine($"Địa chỉ: {studentkhoiA.Diachi}");
                Console.WriteLine($"Ưu tiên: {studentkhoiA.Uutien}");
                Console.WriteLine($"Diem toan: {studentkhoiA.Toan}");
                Console.WriteLine($"Diem ly: {studentkhoiA.Ly}");
                Console.WriteLine($"Diem hoa: {studentkhoiA.Hoa}");
            }
            else if (student is KhoiB)
            {
                Console.WriteLine("Sinh viên khối B:");
                KhoiB studentkhoiB = student as KhoiB;
                Console.WriteLine($"SBD: {studentkhoiB.SBD}");
                Console.WriteLine($"Tên: {studentkhoiB.Ten}");
                Console.WriteLine($"Địa chỉ: {studentkhoiB.Diachi}");
                Console.WriteLine($"Ưu tiên: {studentkhoiB.Uutien}");
                Console.WriteLine($"Diem toan: {studentkhoiB.Toan}");
                Console.WriteLine($"Diem Hoa: {studentkhoiB.Hoa}");
                Console.WriteLine($"Diem Sinh: {studentkhoiB.Sinh}");
            }
            else if (student is KhoiC)
            {
                Console.WriteLine("Sinh viên khối C:");
                KhoiC studentkhoiC = student as KhoiC;
                Console.WriteLine($"SBD: {studentkhoiC.SBD}");
                Console.WriteLine($"Tên: {studentkhoiC.Ten}");
                Console.WriteLine($"Địa chỉ: {studentkhoiC.Diachi}");
                Console.WriteLine($"Ưu tiên: {studentkhoiC.Uutien}");
                Console.WriteLine($"Diem Van: {studentkhoiC.Van}");
                Console.WriteLine($"Diem Su: {studentkhoiC.Su}");
                Console.WriteLine($"Diem Dia: {studentkhoiC.Dia}");
            }
        }

    }
}
class Program
{
    static double GetValidPoint()
    {
        double number;

        try
        {
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
            return GetValidPoint(); // Yêu cầu nhập lại tên khi ngoại lệ xảy ra
        }

        return number;
    }
    static string GetValidName()
    {
        string name = "";

        try
        {
            name = Console.ReadLine();

            if (name.Length < 2 || name.Length > 100)
            {
                throw new Exception("Độ dài tên không chính xác!");
            }
            foreach (char c in name)
            {
                if (!Char.IsLetter(c))
                {
                    throw new ArgumentException("Tên không thể chứa kí tự đặc biệt");
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
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        QLBD quanLySinhVien = new QLBD();

        while (true)
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Thêm mới học sinh");
            Console.WriteLine("2. Tìm kiếm học sinh theo số báo danh");
            Console.WriteLine("3. Danh sách");
            Console.WriteLine("4. Thoát");
            Console.Write("Vui lòng chọn chức năng (1-4): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("----- Thêm mới cán bộ -----");
                        Console.Write("Khối (1: Khoi A, 2: Khoi B, 3: Khoi C): ");
                        int chonkhoi = int.Parse(Console.ReadLine());
                        Console.Write("SBD: ");
                        string sbd = Console.ReadLine();
                        Console.Write("Tên: ");
                        string ten = GetValidName();
                        Console.Write("Địa chỉ: ");
                        string diachi = Console.ReadLine();
                        Console.Write("Ưu tiên: ");
                        string uutien = Console.ReadLine();

                        switch (chonkhoi)
                        {
                            case 1:
                                Console.WriteLine("Nhập thông tin khối A: ");
                                Console.Write("Toán: ");
                                double toanA = GetValidPoint();
                                Console.Write("Lý: ");
                                double lyA = GetValidPoint();
                                Console.Write("Hóa: ");
                                double hoaA = GetValidPoint();
                                KhoiA khoiA = new KhoiA()
                                {
                                    SBD = sbd,
                                    Ten = ten,
                                    Diachi = diachi,
                                    Uutien = uutien,
                                    Toan = toanA,
                                    Ly = lyA,
                                    Hoa = hoaA   

                                };
                                quanLySinhVien.ThemMoiHocSinh(khoiA);
                                break;
                            case 2:
                                Console.WriteLine("Nhập thông tin khối B: ");
                                Console.Write("Toán: ");
                                double toanB = GetValidPoint();
                                Console.Write("Hóa: ");
                                double hoaB = GetValidPoint();
                                Console.Write("Sinh: ");
                                double sinhB = GetValidPoint();
                                KhoiB khoiB = new KhoiB()
                                {
                                    SBD = sbd,
                                    Ten = ten,
                                    Diachi = diachi,
                                    Uutien = uutien,
                                    Toan = toanB,
                                    Hoa = hoaB,
                                    Sinh = sinhB
                                   
                                };
                                quanLySinhVien.ThemMoiHocSinh(khoiB);
                                break;
                            case 3:
                                Console.WriteLine("Nhập thông tin khối C: ");
                                Console.Write("Van: ");
                                double van = GetValidPoint();
                                Console.Write("Su: ");
                                double su = GetValidPoint();
                                Console.Write("Dia: ");
                                double dia = GetValidPoint();
                                KhoiC khoiC = new KhoiC()
                                {
                                    SBD = sbd,
                                    Ten = ten,
                                    Diachi = diachi,
                                    Uutien = uutien,
                                    Van = van,
                                    Su = su,
                                    Dia = dia

                                };
                                quanLySinhVien.ThemMoiHocSinh(khoiC);
                                break;
                            default:
                                Console.WriteLine("Hãy lựa chọn đúng.");
                                break;
                        }
                        Console.WriteLine("Thêm mới sinh viên thành công.");
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("----- Tìm kiếm theo họ tên -----");
                        Console.Write("Nhập họ tên cần tìm: ");
                        string sbdcantim = Console.ReadLine();
                        quanLySinhVien.TimKiemTheoSBD(sbdcantim);
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("----- Hiển thị danh sách sinh viên -----");
                        quanLySinhVien.HienThidanhSachSinhVien();
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
                Console.WriteLine("Lựa chọn không hợp lệ.");
                Console.WriteLine();
            }
        }

    }
}