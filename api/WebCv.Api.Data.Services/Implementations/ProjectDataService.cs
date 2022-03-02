using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCv.Api.Data.Entities;
using WebCv.Api.Data.Services.Interfaces;

namespace WebCv.Api.Data.Services.Implementations
{
    public class ProjectDataService : IProjectDataService
    {

        private readonly WebCvContext _webCvContext;

        public ProjectDataService(WebCvContext context)
        {
            _webCvContext = context;
        }

        public Project Add(Project entity)
        {
            var result = AddAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<Project> AddAsync(Project entity)
        {
            await _webCvContext.Projects.AddAsync(entity);
            await _webCvContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<Project> Get()
        {
            var result = GetAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public Project Get(Guid id)
        {
            var result = GetAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<IEnumerable<Project>> GetAsync()
        {
            var result = await _webCvContext.Projects.ToArrayAsync();
            return result;
        }

        public async Task<Project> GetAsync(Guid id)
        {
            var result = await _webCvContext.Projects.FindAsync(id);
            if (result != null)
            {
                _webCvContext.Entry(result).State = EntityState.Detached;
            }
            return result;
        }

        public Project Remove(Project entity)
        {
            var result = RemoveAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<Project> RemoveAsync(Project entity)
        {
            _webCvContext.Projects.Remove(entity);
            await _webCvContext.SaveChangesAsync();
            return entity;
        }

        public Project Update(Project entity)
        {
            var result = UpdateAsync(entity).ConfigureAwait(false).GetAwaiter().GetResult();
            return result;
        }

        public async Task<Project> UpdateAsync(Project entity)
        {
            _webCvContext.Entry(entity).State = EntityState.Modified;
            await _webCvContext.SaveChangesAsync();
            return entity;
        }
    }
}
