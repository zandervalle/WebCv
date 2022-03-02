using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCv.Api.Data.Entities;
using WebCv.Api.Data.Services.Interfaces;

namespace WebCv.Api.Data.Services.Implementations
{
    public class ResumeLineDataService : IResumeLineDataService
    {

        private readonly WebCvContext _webCvContext;

        public ResumeLineDataService(WebCvContext context)
        {
            _webCvContext = context;
        }

        public ResumeLine Add(ResumeLine entity)
        {
            var result = AddAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<ResumeLine> AddAsync(ResumeLine entity)
        {
            await _webCvContext.ResumeLines.AddAsync(entity);
            await _webCvContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<ResumeLine> Get()
        {
            var result = GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public ResumeLine Get(Guid id)
        {
            var result = GetAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<IEnumerable<ResumeLine>> GetAsync()
        {
            var result = await _webCvContext.ResumeLines.ToArrayAsync();
            return result;
        }

        public async Task<ResumeLine> GetAsync(Guid id)
        {
            var result = await _webCvContext.ResumeLines.FindAsync(id);
            if (result != null)
            {
                _webCvContext.Entry(result).State = EntityState.Detached;
            }
            return result;
        }

        public ResumeLine Remove(ResumeLine entity)
        {
            var result = RemoveAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<ResumeLine> RemoveAsync(ResumeLine entity)
        {
            _webCvContext.ResumeLines.Remove(entity);
            await _webCvContext.SaveChangesAsync();
            return entity;
        }

        public ResumeLine Update(ResumeLine entity)
        {
            var result = UpdateAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<ResumeLine> UpdateAsync(ResumeLine entity)
        {
            _webCvContext.Entry(entity).State = EntityState.Modified;
            await _webCvContext.SaveChangesAsync();
            return entity;
        }
    }
}
