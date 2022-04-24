using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace DataBase
{
    class QuerryServices
    {
        public void ShowDepartmentStudents()
        {
            using var dbContext = new ProjectContext();
            Console.WriteLine("Write Id of Department");
            var department = dbContext.Departments.Where(Dep => Dep.Id == Console.ReadLine().GuidValidation()).Include(q => q.StudentList).FirstOrDefault();
            foreach (var x in department.StudentList)
            {
                Console.WriteLine(x);
            }
        }
        public void ShowDepartmentLectures()
        {
            using var dbContext = new ProjectContext();
            Console.WriteLine("Write Id of Department");
            var department = dbContext.Departments.Where(Dep => Dep.Id == Console.ReadLine().GuidValidation()).Include(q => q.LectureList).FirstOrDefault();
            foreach (var x in department.LectureList)
            {
                Console.WriteLine(x);
            }
        }
        public void ShowStudentLectures()
        {
            Console.WriteLine("Enter Id of student");
            using var dbContext = new ProjectContext();
            var student = dbContext.Students.Where(Dep => Dep.Id == Console.ReadLine().GuidValidation()).Include(q => q.LectureList).FirstOrDefault();
            foreach (var x in student.LectureList)
            {
                Console.WriteLine(x);
            }
        }
        public void ShowDepartments()
        {
            using var dbContext = new ProjectContext();
            var Deparments = dbContext.Departments.ToList();
            Deparments.ForEach(Console.WriteLine);
        }
        public void ShowLectures()
        {
            using var dbContext = new ProjectContext();
            var lectures = dbContext.Lectures.ToList();
            lectures.ForEach(Console.WriteLine);
        }
        public void ShowStudents()
        {
            using var dbContext = new ProjectContext();
            var students = dbContext.Students.ToList();
            students.ForEach(Console.WriteLine);
        }
    }
}
