
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SchoolApplication.Models
{
    public class Student// : ApplicationUsers
    {
        // password come back later
        [Required]
        [DisplayName("Student Name")]
        
        public  string Name { get; set; }

        [Key]
        public  int Id { get; set; }

        //[Required]
       // public  string Email { get; set; }
        //[Required]
        //public  string Phone { get ; set; }
        public string Department { get; set; }
        [Required]
        // [Range(250000,100000000000,ErrorMessage="FSDIHSDIHFLI")] is also okay but in my implementation this is fine
        public decimal Price { get; set; }

        //public int Discount { get; }

        private Dictionary<string, decimal> grades;
        public DateTime LastModified { get; set; }

        private void InitDictionary() 
        {
            grades = new Dictionary<string, decimal>
            {
                {"Math",0 },
                {"Science",0},
                {"Language",0 },
                {"History",0 },
                {"Sports",0 }
            };
        }
        public Student() 
        {
            InitDictionary();
        }
        public decimal Gpa() 
        {
            decimal total = 0;
            int subjectCount = 0;

            foreach (string key in grades.Keys)
            {
                if (grades[key] > 0)
                {
                    total += grades[key];
                    subjectCount++;
                }
            }

            if (subjectCount > 0)
            {
                decimal average = total / subjectCount;

                return average;
            }

            return 0; // No valid subjects,
        }
        internal Dictionary<string, decimal> GetGrades()
        {
            return grades;
        }
       




    }}
