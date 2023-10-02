using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

// Abstract class Employee
abstract class Employee
{
    public string ID { get; set; }
    public string FullName { get; set; }
    public DateTime Birthday { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int Employee_type { get; set; }
    public static int Employee_count { get; set; }

    public Employee(string id, string fullName, DateTime birthday, string phone, string email, int employeeType)
    {
        ID = id;
        FullName = fullName;
        Birthday = birthday;
        Phone = phone;
        Email = email;
        Employee_type = employeeType;
        Employee_count++;
    }

    public abstract void ShowInfo();
}

class Experience : Employee
{
    public int ExpInYear { get; set; }
    public string ProSkill { get; set; }

    public Experience(string id, string fullName, DateTime birthday, string phone, string email, int expInYear, string proSkill)
        : base(id, fullName, birthday, phone, email, 0)
    {
        ExpInYear = expInYear;
        ProSkill = proSkill;
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Thông tin nhân viên có kinh nghiệm:");
        Console.WriteLine("ID: " + ID);
        Console.WriteLine("Họ và tên: " + FullName);
        Console.WriteLine("Ngày tháng năm sinh: " + Birthday.ToShortDateString());
        Console.WriteLine("Điện thoại: " + Phone);
        Console.WriteLine("Email: " + Email);
        Console.WriteLine("Số năm kinh nghiệm: " + ExpInYear);
        Console.WriteLine("Kĩ năng: " + ProSkill);
    }
}


class Fresher : Employee
{
    public DateTime Graduation_date { get; set; }
    public string Graduation_rank { get; set; }
    public string Education { get; set; }

    public Fresher(string id, string fullName, DateTime birthday, string phone, string email, DateTime graduationDate, string graduationRank, string education)
        : base(id, fullName, birthday, phone, email, 1)
    {
        Graduation_date = graduationDate;
        Graduation_rank = graduationRank;
        Education = education;
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Thông tin nhân viên mới ra trường:");
        Console.WriteLine("ID: " + ID);
        Console.WriteLine("Họ và tên: " + FullName);
        Console.WriteLine("Ngày tháng năm sinh: " + Birthday.ToShortDateString());
        Console.WriteLine("Điện thoại: " + Phone);
        Console.WriteLine("Email: " + Email);
        Console.WriteLine("Ngày tốt nghiệp: " + Graduation_date.ToShortDateString());
        Console.WriteLine("Thứ hạng: " + Graduation_rank);
        Console.WriteLine("Trường đại học: " + Education);
    }
}


class Intern : Employee
{
    public string Majors { get; set; }
    public int Semester { get; set; }
    public string University_name { get; set; }

    public Intern(string id, string fullName, DateTime birthday, string phone, string email, string majors, int semester, string universityName)
        : base(id, fullName, birthday, phone, email, 2)
    {
        Majors = majors;
        Semester = semester;
        University_name = universityName;
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Thông tin nhân viên thực tập:");
        Console.WriteLine("ID: " + ID);
        Console.WriteLine("Họ và tên: " + FullName);
        Console.WriteLine("Ngày tháng năm sinh: " + Birthday.ToShortDateString());
        Console.WriteLine("Điện thoại: " + Phone);
        Console.WriteLine("Email: " + Email);
        Console.WriteLine("Ngành: " + Majors);
        Console.WriteLine("Kì học: " + Semester);
        Console.WriteLine("Tên trường đại học: " + University_name);
    }
}

// Certificate class
class Certificate
{
    public int CertificatedID { get; set; }
    public string CertificateName { get; set; }
    public string CertificateRank { get; set; }
    public DateTime CertificatedDate { get; set; }

    public Certificate(int certificatedID, string certificateName, string certificateRank, DateTime certificatedDate)
    {
        CertificatedID = certificatedID;
        CertificateName = certificateName;
        CertificateRank = certificateRank;
        CertificatedDate = certificatedDate;
    }
}
class Program
{
    static List<Employee> employees = new List<Employee>();

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        int choice = 0;
        do
        {
            Console.WriteLine("1. Thêm nhân viên");
            Console.WriteLine("2. Sửa nhân viên");
            Console.WriteLine("3. Xóa nhân viên");
            Console.WriteLine("4. Tìm kiếm nhân viên thực tập");
            Console.WriteLine("5. Tìm kiếm nhân viên có kinh nghiệm");
            Console.WriteLine("6. Tìm kiếm nhân viên mới ra trường");
            Console.WriteLine("7. Thoát");
            Console.Write("Lựa chọn: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    EditEmployee();
                    break;
                case 3:
                    DeleteEmployee();
                    break;
                case 4:
                    FindAllInternEmployees();
                    break;
                case 5:
                    FindAllExperienceEmployees();
                    break;
                case 6:
                    FindAllFresherEmployees();
                    break;
                case 7:
                    Console.WriteLine("Thoát!");
                    break;
                default:
                    Console.WriteLine("Vui lòng nhập lại đúng lựa chọn.");
                    break;
            }

        } while (choice != 7);
    }

    static bool ValidateEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
    }

    static bool ValidatePhoneNumber(string phoneNumber)
    {
        string pattern = @"^\d{10}$";
        return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, pattern);
    }
    static bool IsValidString(string input)
    {

        string pattern = @"[^A-Z0-9]+";

        return System.Text.RegularExpressions.Regex.IsMatch(input, pattern);
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

    static string GetStringWithValidation(string message, Func<string, bool> validationFunc)// delegate
    {
        string input;
        bool isValid;
        do
        {
            Console.Write(message);
            input = Console.ReadLine();
            isValid = validationFunc(input);
            if (!isValid)
            {
                Console.Write("Sai định dạng. Hãy thử lại. ");
            }
        } while (!isValid);

        return input;
    }
    static DateTime checkdate(string a)
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
    public static int ReadInteger()
    {
        while (true)
        {
            try
            {
                Console.Write("Nhập một số: ");
                int number = Convert.ToInt32(Console.ReadLine());
                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Số không đúng.Vui lòng nhập lại");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Số quá lớn. ");
            }
        }
    }

    public static string GetEmail()
    {
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        while (true)
        {
            try
            {
                Console.WriteLine("Nhập email:");
                string email = Console.ReadLine();

                // Kiểm tra xem email có hợp lệ hay không
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, pattern))
                {
                    throw new Exception("Sai định dạng email!");
                }

                return email;
            }
            catch (Exception exception)
            {
                Console.Write("Lỗi: " + exception.Message);
                Console.Write("Vui lòng nhập lại email.");
            }
        }
    }

    static void AddEmployee()
    {
        Console.WriteLine("Nhập thông tin nhân viên:");

        string id = GetStringWithValidation("Nhập an ID: ", IsValidString);
        bool alreadyExists = employees.Any(x => x.ID.ToLower() == id.ToLower());
        if (alreadyExists)
        {
            Console.WriteLine("ID không tồn tại");
            return;
        }

        string email = GetStringWithValidation("Nhập email: ", ValidateEmail);

        string fullname = GetValidName();

        DateTime birthday = checkdate("Nhập ngày sinh (dd/MM/yyyy): ");


        string phone = GetStringWithValidation("Nhập điện thoại: ", ValidatePhoneNumber);



        Console.Write("Loại nhân viên (0: Có kinh nghiệm, 1: Mới ra trường, 2: Thực tập): ");
        int employeeType = int.Parse(Console.ReadLine());

        switch (employeeType)
        {
            case 0:
                Console.Write("Số năm kinh nghiệm: ");
                int expInYear = int.Parse(Console.ReadLine());

                Console.Write("Kĩ năng: ");
                string proSkill = Console.ReadLine();


                employees.Add(new Experience(id, fullname, birthday, phone, email, expInYear, proSkill));


                break;
            case 1:
                DateTime graduationDate = checkdate("Ngày tốt nghiệp (dd/MM/yyyy): ");

                Console.Write("Thứ hạng: ");
                string graduationRank = Console.ReadLine();

                Console.Write("Tốt nghiệp trường: ");
                string education = Console.ReadLine();
                break;
        }
    }

    static void EditEmployee()
    {
        Console.Write("Nhập ID nhân viên: ");
        string id = GetStringWithValidation("Nhập ID nhân viên để chỉnh sửa: ", IsValidString);

        Employee employee = employees.Find(emp => emp.ID.Equals(id));
        if (employee != null)
        {
            Console.WriteLine("Nhập thông tin nhân viên mới:");
            string fullname = GetValidName();
            string email = GetStringWithValidation("Nhập a email: ", ValidateEmail);

            DateTime birthday = checkdate("Nhập ngày tháng năm sinh (dd/MM/yyyy): ");


            string phone = GetStringWithValidation("Nhập điện thoại: ", ValidatePhoneNumber);


            employee.FullName = fullname;
            employee.Birthday = birthday;
            employee.Phone = phone;
            employee.Email = email;

            Console.WriteLine("Cập nhận thông tin thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy nhân viên.");
        }
    }

    static void DeleteEmployee()
    {

        string id = GetStringWithValidation("Nhập ID của nhân viên để xóa: ", IsValidString);
        Employee employee = employees.Find(emp => emp.ID.Equals(id));
        if (employee != null)
        {
            employees.Remove(employee);
            Console.WriteLine("Xóa thông tin thành công.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy nhân viên.");
        }
    }

    static void FindAllInternEmployees()
    {
        Console.WriteLine("Danh sách nhân viên thực tập:");
        foreach (Employee employee in employees)
        {
            if (employee is Intern)
            {
                employee.ShowInfo();
                Console.WriteLine("-------------------------");
            }
        }
    }

    static void FindAllExperienceEmployees()
    {
        Console.WriteLine("Danh sách nhân viên có kinh nghiệm:");
        foreach (Employee employee in employees)
        {
            if (employee is Experience)
            {
                employee.ShowInfo();
                Console.WriteLine("-------------------------");
            }
        }
    }

    static void FindAllFresherEmployees()
    {
        Console.WriteLine("Danh sách nhân viên mới ra trường:");
        foreach (Employee employee in employees)
        {
            if (employee is Fresher)
            {
                employee.ShowInfo();
                Console.WriteLine("-------------------------");
            }
        }
    }
}