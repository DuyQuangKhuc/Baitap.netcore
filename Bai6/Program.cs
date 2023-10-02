using System;
using System.Collections.Generic;
using System.Text;

class HocSinh
{
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public string QueQuan { get; set; }

    public HocSinh(string hoTen, int tuoi, string queQuan)
    {
        HoTen = hoTen;
        Tuoi = tuoi;
        QueQuan = queQuan;
    }
    public HocSinh()
    {

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

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<HocSinh> danhSachHocSinh = new List<HocSinh>();


        HocSinh hs1 = new HocSinh("Nguyen Van A", 18, "Hanoi");
        danhSachHocSinh.Add(hs1);

        HocSinh hs2 = new HocSinh("Tran Thi B", 20, "Hanoi");
        danhSachHocSinh.Add(hs2);

        HocSinh hs3 = new HocSinh("Le Van C", 23, "Da Nang");
        danhSachHocSinh.Add(hs3);

        HocSinh hs4 = new HocSinh("Pham Thi D", 23, "Da Nang");
        danhSachHocSinh.Add(hs4);
        while (true)
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Thêm mới học sinh");
            Console.WriteLine("2. Tìm kiếm số học sinh 20 tuổi");
            Console.WriteLine("3. Số lượng học sinh có tuổi là 23 và quê ở Da Nang");
            Console.WriteLine("4. Thoát");
            Console.Write("Vui lòng chọn từ (1-4): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        HocSinh hs = new HocSinh();
                        string name = GetValidName();
                        int age = GetValidAge();
                        Console.Write("Địa chỉ: ");
                        string address = Console.ReadLine();

                        danhSachHocSinh.Add(new HocSinh(name, age, address));
                        break;
                    case 3:
                        int count = 0;
                        foreach (var hocSinh in danhSachHocSinh)
                        {
                            if (hocSinh.Tuoi == 23 && hocSinh.QueQuan == "Da Nang")
                            {
                                count++;
                            }
                        }
                        Console.WriteLine("Số lượng học sinh có tuổi là 23 và quê ở Da Nang: {0}", count);
                        break;

                    case 2:
                        Console.WriteLine("Các học sinh 20 tuổi:");
                        foreach (var hocSinh in danhSachHocSinh)
                        {
                            if (hocSinh.Tuoi == 20)
                            {
                                Console.WriteLine("Họ tên: {0}", hocSinh.HoTen);
                                Console.WriteLine("Tuổi: {0}", hocSinh.Tuoi);
                                Console.WriteLine("Quê quán: {0}", hocSinh.QueQuan);
                                Console.WriteLine();
                            }
                        }
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
                Console.WriteLine("Lựa chọn không họp lệ.");
            }
        }
    }
}