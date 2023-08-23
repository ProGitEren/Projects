using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace SchoolApplication.Models
{
    public class Registerer //: ApplicationUsers
    {
        [Key]
        public  int Id { get; set; }

        [Required]
        public  string Name { get; set; }

        //[Required]
        //public  string Email { get; set; }

        //[Required]
        //public  string Phone { get; set; }

        [Required]
        private Dictionary<Student,int> discounts;

        public Registerer()
        {
        
        }

    }
}
