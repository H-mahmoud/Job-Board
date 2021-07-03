using Job_Board.Models;
using Job_Board.Models.enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Job_Board.ViewModel
{
    public class CreateJobViewModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Range(1, 20)]
        public int Vacancy { get; set; } = 1;

        [Required]
        public double Salary { get; set; }

        [Required]
        [DisplayName("Category")]
        public string CategoryId { get; set; }

        [Required]
        [DisplayName("Job Nature")]
        public JobNature JobNature { get; set; }
    }

    public class MyJobsViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public JobNature JobNature { get; set; }
        public string Location { get; set; }
        public DateTime PublishedAt { get; set; }
        public string ProfilePicture { get; set; }
        public int Count { get; set; }
        public bool? IsAccepted { get; set; }
    }

    public class ApplyViewModel {
        public string JobId { get; set; }
    }
}
