using System;

namespace WebCv.Api.Data.Entities
{
    public class PersonalInformation
    {
        public int PersonalInformationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string BirthTown { get; set; }
        public string LinkedInUrl { get; set; }
        public string XingUrl { get; set; }

        public PersonalInformation()
        {
            PersonalInformationId = 1;
        }
    }
}
