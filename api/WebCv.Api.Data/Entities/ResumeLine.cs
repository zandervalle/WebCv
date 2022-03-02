using System;
using System.Collections.Generic;

namespace WebCv.Api.Data.Entities
{
    public class ResumeLine
    {
        public Guid ResumeLineId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
