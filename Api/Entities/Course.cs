using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public string Difficulty { get; set; }
        public string Status { get; set; }

        public List<CourseStudent> CourseStudent { get; set; }
    }
}