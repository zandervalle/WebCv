using System;

namespace WebCv.Api.Data.Entities
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string[] UsedTechnologies { get; set; }
    }
}
