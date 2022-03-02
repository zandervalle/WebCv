using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCv.Api.Data.Entities;

namespace WebCv.Api.Data.Services.Interfaces
{
    public interface IProjectDataService
    {
        public Task<IEnumerable<Project>> GetAsync();
        public IEnumerable<Project> Get();
        public Task<Project> GetAsync(Guid id);
        public Project Get(Guid id);
        public Task<Project> AddAsync(Project entity);
        public Project Add(Project entity);
        public Task<Project> UpdateAsync(Project entity);
        public Project Update(Project entity);
        public Task<Project> RemoveAsync(Project entity);
        public Project Remove(Project entity);
    }
}
