using Job_Board.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Job_Board.Models
{
    public class JobModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime PublishedAt { get; set; }
        public int Vacancy { get; set; }
        public double Salary { get; set; }
        public JobNature JobNature { get; set; }
        public bool? IsAccepted { get; set; }

        public string? CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }

        public string RecruterId { get; set; }
        public virtual UserModel Recruter { get; set; }
    }
}
