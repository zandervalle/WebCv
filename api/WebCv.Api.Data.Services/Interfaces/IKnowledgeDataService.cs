using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCv.Api.Data.Entities;

namespace WebCv.Api.Data.Services.Interfaces
{
    public interface IKnowledgeDataService
    {
        public Task<IEnumerable<Knowledge>> GetAsync();
        public IEnumerable<Knowledge> Get();
        public Task<Knowledge> GetAsync(Guid id);
        public Knowledge Get(Guid id);
        public Task<Knowledge> AddAsync(Knowledge entity);
        public Knowledge Add(Knowledge entity);
        public Task<Knowledge> UpdateAsync(Knowledge entity);
        public Knowledge Update(Knowledge entity);
        public Task<Knowledge> RemoveAsync(Knowledge entity);
        public Knowledge Remove(Knowledge entity);
    }
}
