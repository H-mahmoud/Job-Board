using Job_Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Board.ViewModel
{
    public class DashboardViewModel
    {
        public int TotalPosts { get; set; }
        public int TotalPending { get; set; }
        public int TotalUsers { get; set; }

        public IEnumerable<JobModel> RecentPosts { get; set; }
    }
}
