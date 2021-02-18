using System;

namespace WIUT.DAL
{
    public class Course
    {
        public int Id { get; set; }
        

        private string _name;
        public string Name { 
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Course Name cannot be empty!");
                }
                _name = value;
            }
        }

        public Course()
        {

        }

        public Course(string name)
        {
            Name = name; 
        }
    }
}
