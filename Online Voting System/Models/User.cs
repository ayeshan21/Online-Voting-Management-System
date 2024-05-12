using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_Voting_System.Models
{
    public class User
    {
        //login
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name {  get; set; }

        [Required(ErrorMessage = "Mobile no. is required")]
        [StringLength(20)]
        public string Mobile { get; set; }

        [Key]
        [Required(ErrorMessage = "NID is required")]
        public double n_id { get; set; }

        [Required(ErrorMessage ="Password is requied and it should be combination of digits,letter and special character")]
        [StringLength(20, ErrorMessage ="Password should be not more than 20 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password should be matched with password")]
        [Compare("Password", ErrorMessage = "Confirm password did not matched")]
        public string Confirm_password { get; set; }

        [Required(ErrorMessage = "Please select your role")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public int Votes { get; set; } = 0;
        public bool HasVoted { get; set; } = false;
        [Required]
        public string PhotoURL { get; set; }

        [Required]
        public string Sign_photoURL { get; set; }
    }
}
