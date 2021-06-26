using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Board.ViewModel
{
    public class AllJobsViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string JobNature { get; set; }
        public string Location { get; set; }
        public DateTime PublishedAt { get; set; }
        public string PublisherImage { get; set; }
    }
    public class JobDetailsViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Vacancy { get; set; }
        public double Salary { get; set; }
        public string Category { get; set; }
        public string JobNature { get; set; }
        public string Location { get; set; }
        public DateTime PublishedAt { get; set; }
        public string PublisherImage { get; set; }

    }
}
