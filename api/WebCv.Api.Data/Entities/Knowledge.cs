using System;
using System.ComponentModel.DataAnnotations;

namespace WebCv.Api.Data.Entities
{
    public class Knowledge
    {
        public Guid KnowledgeId { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string KnowledgeName { get; set; }

        public byte Rating { get; set; }
    }
}
