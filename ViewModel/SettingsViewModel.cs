using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Job_Board.ViewModel
{
    public class SettingsViewModel
    {
        [DisplayName("Profile Picture")]
        public IFormFile ProfilePicture { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [DisplayName("LinkedIn Profile Url")]
        [Url]
        public string LinkInUrl { get; set; }
    }
}
