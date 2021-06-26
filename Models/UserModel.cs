using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Job_Board.Models
{
    public class UserModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string JobTitle { get; set; }
        public string LinkedInUrl { get; set; }

        public virtual ICollection<JobModel> MyJobs { get; set; }
    }
}

