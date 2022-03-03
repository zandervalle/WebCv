using System;
using WebCv.Api.Data.Entities;

namespace WebCv.Api.ViewModels
{
    public class PersonalInfoViewModel
    {
        public PersonalInfoViewModel() { }
        public PersonalInfoViewModel(PersonalInformation personalInformation)
        {
            FirstName = personalInformation.FirstName;
            LastName = personalInformation.LastName;
            LinkedInUrl = personalInformation.LinkedInUrl;
            XingUrl = personalInformation.XingUrl;
            
            if (personalInformation.BirthDay.HasValue)
            {
                var age = DateTime.Today.Year - personalInformation.BirthDay.Value.Year;
                if (new DateTime(DateTime.Today.Year, personalInformation.BirthDay.Value.Month, personalInformation.BirthDay.Value.Day) > DateTime.Today)
                {
                    age--;
                }
                Age = age;
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string LinkedInUrl { get; set; }
        public string XingUrl { get; set; }

    }
}
