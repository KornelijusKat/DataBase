using System;
using System.Collections.Generic;


namespace DataBase
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Lecture> LectureList { get; set; }
        public virtual ICollection<Student> StudentList { get; set; }
        public Department(Guid id, string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public override string ToString()
        {
            return $"Id = {Id} Name = {Name}";
        }
        public Department()
        {
        }
    }
}
