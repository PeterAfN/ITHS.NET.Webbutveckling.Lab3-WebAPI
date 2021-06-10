using System.Collections.Generic;

namespace Api.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        public List<CourseStudent> CourseStudent { get; set; }
    }
}