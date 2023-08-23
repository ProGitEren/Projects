using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Models
{
    public enum teacherType 
    {
        Advanced,
        Professor,
        HeadofDepartment,
        Deputy
    };
    public enum lectureType 
    
    {
        Math,
        Science,
        Language,
        History,
        Sports
    };
    public class Teacher //: ApplicationUsers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        //[Required]
        //public string Email { get; set; }
        //[Required]
        //public string Phone { get; set; }

        //private decimal Salary; security needed later on

        [Required]
        public teacherType Type { get; set; }
        [Required]
        public lectureType lecture { get; set; }

        public DateTime LastModified { get; set; } = DateTime.Now;
        public void setGrade(Student student, decimal newgrade) 
        {
            if (student.GetGrades().ContainsKey(lecture.ToString()))
            {
                student.GetGrades()[lecture.ToString()] = newgrade;
            }
            else 
            {
                throw new Exception("Not valid lecture type");
            }
        }
  
    }
}
