using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Board.Models
{
    public class UserJob
    {
        public string UserId { get; set; }
        public virtual UserModel User { get; set;}

        public string JobId { get; set; }
        public virtual JobModel Job { get; set; }
    }
}
