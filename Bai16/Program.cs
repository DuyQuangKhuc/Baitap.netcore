using System;
using System.Collections.Generic;

class Student
{
    public string StudentID { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public int YearOfEnrollment { get; set; }
    public double EntranceScore { get; set; }
    public List<AcademicResult> AcademicResults { get; set; }

    public Student(string studentID, string fullName, DateTime birthDate, int yearOfEnrollment, double entranceScore)
    {
        StudentID = studentID;
        FullName = fullName;
        BirthDate = birthDate;
        YearOfEnrollment = yearOfEnrollment;
        EntranceScore = entranceScore;
        AcademicResults = new List<AcademicResult>();
    }

    public void AddAcademicResult(string semester, double gpa)
    {
        AcademicResult result = new AcademicResult(semester, gpa);
        AcademicResults.Add(result);
    }

    public void ShowInfo()
    {
        Console.WriteLine("Student Information:");
        Console.WriteLine("Student ID: " + StudentID);
        Console.WriteLine("Full Name: " + FullName);
        Console.WriteLine("Birth Date: " + BirthDate.ToShortDateString());
        Console.WriteLine("Year of Enrollment: " + YearOfEnrollment);
        Console.WriteLine("Entrance Score: " + EntranceScore);
        Console.WriteLine("Academic Results:");
        foreach (var result in AcademicResults)
        {
            Console.WriteLine("Semester: " + result.Semester);
            Console.WriteLine("GPA: " + result.GPA);
        }
    }
}

class FullTimeStudent : Student
{
    public FullTimeStudent(string studentID, string fullName, DateTime birthDate, int yearOfEnrollment, double entranceScore)
        : base(studentID, fullName, birthDate, yearOfEnrollment, entranceScore)
    {
    }
}

class PartTimeStudent : Student
{
    public string TrainingLocation { get; set; }

    public PartTimeStudent(string studentID, string fullName, DateTime birthDate, int yearOfEnrollment, double entranceScore, string trainingLocation)
        : base(studentID, fullName, birthDate, yearOfEnrollment, entranceScore)
    {
        TrainingLocation = trainingLocation;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine("Training Location: " + TrainingLocation);
    }
}

class Department
{
    public string DepartmentName { get; set; }
    public List<Student> Students { get; set; }

    public Department(string departmentName)
    {
        DepartmentName = departmentName;
        Students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public void ShowStudents()
    {
        Console.WriteLine("Students in " + DepartmentName + ":");
        foreach (var student in Students)
        {
            Console.WriteLine("Student ID: " + student.StudentID);
            Console.WriteLine("Full Name: " + student.FullName);
        }
    }
}

class AcademicResult
{
    public string Semester { get; set; }
    public double GPA { get; set; }

    public AcademicResult(string semester, double gpa)
    {
        Semester = semester;
        GPA = gpa;
    }
}

class Program
{
    static string GetValidName()
    {
        string name = "";

        try
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            // Kiểm tra tên có nằm trong khoảng từ 3 đến 20 ký tự không
            if (name.Length < 4)
            {
                throw new Exception("Invalid name length!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Please enter a valid name.");
            return GetValidName();
        }

        return name;
    }
    static void Main(string[] args)
    {

        FullTimeStudent fullTimeStudent = new FullTimeStudent("FT001", "long", new DateTime(2000, 1, 1), 2020, 8.5);
        fullTimeStudent.AddAcademicResult("Semester 1", 3.2);
        fullTimeStudent.AddAcademicResult("Semester 2", 3.5);


        PartTimeStudent partTimeStudent = new PartTimeStudent("PT001", "hoang", new DateTime(2001, 2, 2), 2021, 7.8, "Đồng Nai");
        partTimeStudent.AddAcademicResult("Semester 1", 3.6);
        partTimeStudent.AddAcademicResult("Semester 2", 3.9);


        Department department = new Department("Computer Science");
        department.AddStudent(fullTimeStudent);
        department.AddStudent(partTimeStudent);


        department.ShowStudents();


        fullTimeStudent.ShowInfo();

        partTimeStudent.ShowInfo();
    }
}