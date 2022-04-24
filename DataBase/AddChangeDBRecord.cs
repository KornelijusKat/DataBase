using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBase
{
    class AddChangeDBRecord
    {
        public QuerryServices ShowList = new QuerryServices();
        public void AddDepartment()
        {
            using var dbContext = new ProjectContext();
            Console.WriteLine("Enter name of New Department");
            var department = new Department(Guid.NewGuid(), Convert.ToString(Console.ReadLine()));
            department.LectureList = new List<Lecture>();
            department.StudentList = new List<Student>();
            Console.WriteLine("Add how many students?");
            int studentAmount = Console.ReadLine().IntValidation();
            for (var x = 0; x < studentAmount; x++)
            {
                Console.WriteLine("Input student Name");
                string name = Convert.ToString(Console.ReadLine());
                department.StudentList.Add(new Student(Guid.NewGuid(), name, department.Id));
            }
            Console.WriteLine("Add how many Lectures?");
            int lectureAmount = Console.ReadLine().IntValidation();
            for (var x = 0; x < lectureAmount; x++)
            {
                Console.WriteLine("Input lecture Name");
                string name = Convert.ToString(Console.ReadLine());
                department.LectureList.Add(new Lecture(Guid.NewGuid(), name));
            }
            dbContext.Departments.Add(department);
            dbContext.SaveChanges();
        }
        public void CreateAndAddStudentsAndLecturesToExistingDepartment()
        {
            using var dbContext = new ProjectContext();
            Console.WriteLine("Enter Department Id");
            var department = dbContext.Departments.Include(x => x.LectureList).Include(x => x.StudentList).SingleOrDefault(Dep => Dep.Id == Console.ReadLine().GuidValidation());
            Console.WriteLine("Add how many students?");
            int studentAmount = Console.ReadLine().IntValidation();
            for (var x = 0; x < studentAmount; x++)
            {           
                Console.WriteLine("input student name");
                var student = new Student(Guid.NewGuid(), Console.ReadLine(), department.Id);             
                department.StudentList.Add(student);
            }
            Console.WriteLine("Add how many Lectures?");
            int lectureAmount = Console.ReadLine().IntValidation();
            for (var x = 0; x < lectureAmount; x++)
            {
                Console.WriteLine("Input Lecture Name");
                var lecture = new Lecture(Guid.NewGuid(), Console.ReadLine());
                dbContext.Lectures.Add(lecture);
                department.LectureList.Add(lecture);
            }
            dbContext.SaveChanges();
        }
        public void CreateLectureAndAssignDepartment()
        {
            using var dbContext = new ProjectContext();
            {
                Console.WriteLine("Input New Lecture Name");
                var lecture = new Lecture(Guid.NewGuid(), Console.ReadLine());
                Console.WriteLine("Input department Id");
                var department = dbContext.Departments.Include(x => x.LectureList).SingleOrDefault(Dep => Dep.Id == Console.ReadLine().GuidValidation());
                if (lecture.DepartmentList == null)
                {
                    lecture.DepartmentList = new List<Department>();
                }
                dbContext.Lectures.Add(lecture);
                department.LectureList.Add(lecture);
                dbContext.SaveChanges();
            }
        }
        public void ChangeStudentDepartment()
        {
            using var dbContext = new ProjectContext();
            Console.WriteLine("Id of student");
            var student = dbContext.Students.SingleOrDefault(Dep => Dep.Id == Console.ReadLine().GuidValidation());
            student.DepartmentId = Console.ReadLine().GuidValidation();
            dbContext.SaveChanges();
        }
        public void CreateStudent()
        {
            using var dbContext = new ProjectContext();
            {
                Console.WriteLine("Enter Student name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter department Id");
                var department = dbContext.Departments.Include(x => x.StudentList).SingleOrDefault(Dep => Dep.Id == Console.ReadLine().GuidValidation());
                var student = new Student { Name = name, Id = Guid.NewGuid(), DepartmentId = department.Id };
                if (student.LectureList == null)
                {
                    student.LectureList = new List<Lecture>();
                }
                Console.WriteLine("Input Lecture Amount");
                int input = int.Parse(Console.ReadLine());
                for (var x = 0; x < input; x++)
                {
                    Console.WriteLine("Input Lecture Id");
                    var lecture = dbContext.Lectures.SingleOrDefault(Dep => Dep.Id == Console.ReadLine().GuidValidation());
                    student.LectureList.Add(lecture);
                }
                dbContext.Students.Add(student);
                dbContext.SaveChanges();
            }
        }
      public void AssignLecturesToStudent()
        {
            using var dbContext = new ProjectContext();
            Console.WriteLine("Input student Id");
            var student = dbContext.Students.Include(x => x.LectureList).SingleOrDefault(Dep => Dep.Id == Console.ReadLine().GuidValidation());
            Console.WriteLine("input lecture Id");
            var lecture = dbContext.Lectures.SingleOrDefault(Dep => Dep.Id == Console.ReadLine().GuidValidation());
            if (student.LectureList == null)
            {
                student.LectureList = new List<Lecture>();
            }
            student.LectureList.Add(lecture);
            dbContext.SaveChanges();
        }
    }
}
