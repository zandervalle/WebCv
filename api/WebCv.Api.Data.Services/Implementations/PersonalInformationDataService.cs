using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCv.Api.Data.Entities;
using WebCv.Api.Data.Services.Interfaces;

namespace WebCv.Api.Data.Services.Implementations
{
    public class PersonalInformationDataService : IPersonalInformationDataService
    {
        private readonly WebCvContext _webCvContext;

        public PersonalInformationDataService(WebCvContext context)
        {
            _webCvContext = context;
        }

        public PersonalInformation Add(PersonalInformation entity)
        {
            var result = AddAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<PersonalInformation> AddAsync(PersonalInformation entity)
        {
            await _webCvContext.PersonalInformation.AddAsync(entity);
            await _webCvContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<PersonalInformation> Get()
        {
            var result = GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public PersonalInformation Get(Guid id)
        {
            var result = GetAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<IEnumerable<PersonalInformation>> GetAsync()
        {
            var result = await _webCvContext.PersonalInformation.ToArrayAsync();
            return result;
        }

        public async Task<PersonalInformation> GetAsync(Guid id)
        {
            var result = await _webCvContext.PersonalInformation.FindAsync(id);
            if (result != null)
            {
                _webCvContext.Entry(result).State = EntityState.Detached;
            }
            return result;
        }

        public PersonalInformation Remove(PersonalInformation entity)
        {
            var result = RemoveAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<PersonalInformation> RemoveAsync(PersonalInformation entity)
        {
            _webCvContext.PersonalInformation.Remove(entity);
            await _webCvContext.SaveChangesAsync();
            return entity;
        }

        public PersonalInformation Update(PersonalInformation entity)
        {
            var result = UpdateAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<PersonalInformation> UpdateAsync(PersonalInformation entity)
        {
            _webCvContext.Entry(entity).State = EntityState.Modified;
            await _webCvContext.SaveChangesAsync();
            return entity;
        }
    }
}
