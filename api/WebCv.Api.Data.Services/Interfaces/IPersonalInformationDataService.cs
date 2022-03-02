using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCv.Api.Data.Entities;

namespace WebCv.Api.Data.Services.Interfaces
{
    public interface IPersonalInformationDataService
    {
        public Task<IEnumerable<PersonalInformation>> GetAsync();
        public IEnumerable<PersonalInformation> Get();
        public Task<PersonalInformation> GetAsync(Guid id);
        public PersonalInformation Get(Guid id);
        public Task<PersonalInformation> AddAsync(PersonalInformation entity);
        public PersonalInformation Add(PersonalInformation entity);
        public Task<PersonalInformation> UpdateAsync(PersonalInformation entity);
        public PersonalInformation Update(PersonalInformation entity);
        public Task<PersonalInformation> RemoveAsync(PersonalInformation entity);
        public PersonalInformation Remove(PersonalInformation entity);
    }
}
