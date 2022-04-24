using System;
using System.Collections.Generic;


namespace DataBase
{
    public class Lecture
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Department> DepartmentList { get; set; }
        public virtual ICollection<Student> StudentList { get; set; }
        public Lecture(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Lecture()
        {
        }
        public override string ToString()
        {
            return $"Id = {Id} Name = {Name}";
        }
    }
}
