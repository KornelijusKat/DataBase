using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DataBase
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Department Department { get; set; }
        public Guid DepartmentId { get; set; }
        public virtual ICollection<Lecture> LectureList { get; set; }    
        public Student(Guid id, string name, Guid departmentId)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
        }
        public override string ToString()
        {
            return $"ID = {Id} Name = {Name}";
        }
        public Student()
        {

        }
    }
}
