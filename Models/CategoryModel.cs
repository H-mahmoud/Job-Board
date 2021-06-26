using System;
using System.Collections.Generic;

namespace Job_Board.Models
{
    public class CategoryModel
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public virtual ICollection<JobModel> jobs { get; set; }
    }
}
