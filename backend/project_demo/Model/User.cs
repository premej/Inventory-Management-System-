using System.ComponentModel.DataAnnotations;

namespace project_demo.Model
{
    public class User
    {
        [Key]
        public int USerId { get; set; }

        [Required(ErrorMessage ="username is required")]
        [StringLength(20,ErrorMessage ="username cannot exceed 20 char")]
        public string Username { get; set; }

        [Required(ErrorMessage = "password is required")]
        [StringLength(20, ErrorMessage = "password cannot exceed 20 char")]
        public string Password { get; set; }

        public bool IsApproved { get; set; }
        //[Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

     
    }
}
