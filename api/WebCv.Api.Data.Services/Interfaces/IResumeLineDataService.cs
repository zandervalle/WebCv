using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCv.Api.Data.Entities;

namespace WebCv.Api.Data.Services.Interfaces
{
    public interface IResumeLineDataService
    {
        public Task<IEnumerable<ResumeLine>> GetAsync();
        public IEnumerable<ResumeLine> Get();
        public Task<ResumeLine> GetAsync(Guid id);
        public ResumeLine Get(Guid id);
        public Task<ResumeLine> AddAsync(ResumeLine entity);
        public ResumeLine Add(ResumeLine entity);
        public Task<ResumeLine> UpdateAsync(ResumeLine entity);
        public ResumeLine Update(ResumeLine entity);
        public Task<ResumeLine> RemoveAsync(ResumeLine entity);
        public ResumeLine Remove(ResumeLine entity);
    }
}
