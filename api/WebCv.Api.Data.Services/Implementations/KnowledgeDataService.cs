using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCv.Api.Data.Entities;
using WebCv.Api.Data.Services.Interfaces;

namespace WebCv.Api.Data.Services.Implementations
{
    public class KnowledgeDataService : IKnowledgeDataService
    {
        private readonly WebCvContext _webCvContext;

        public KnowledgeDataService(WebCvContext context)
        {
            _webCvContext = context;
        }

        public Knowledge Add(Knowledge entity)
        {
            var result = AddAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<Knowledge> AddAsync(Knowledge entity)
        {
            await _webCvContext.Knowledges.AddAsync(entity);
            await _webCvContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<Knowledge> Get()
        {
            var result = GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public Knowledge Get(Guid id)
        {
            var result = GetAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<IEnumerable<Knowledge>> GetAsync()
        {
            var result = await _webCvContext.Knowledges.ToArrayAsync();
            return result;
        }

        public async Task<Knowledge> GetAsync(Guid id)
        {
            var result = await _webCvContext.Knowledges.FindAsync(id);
            if (result != null)
            {
                _webCvContext.Entry(result).State = EntityState.Detached;
            }
            return result;
        }

        public Knowledge Remove(Knowledge entity)
        {
            var result = RemoveAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<Knowledge> RemoveAsync(Knowledge entity)
        {
            _webCvContext.Knowledges.Remove(entity);
            await _webCvContext.SaveChangesAsync();
            return entity;
        }

        public Knowledge Update(Knowledge entity)
        {
            var result = UpdateAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<Knowledge> UpdateAsync(Knowledge entity)
        {
            _webCvContext.Entry(entity).State = EntityState.Modified;
            await _webCvContext.SaveChangesAsync();
            return entity;
        }
    }
}
