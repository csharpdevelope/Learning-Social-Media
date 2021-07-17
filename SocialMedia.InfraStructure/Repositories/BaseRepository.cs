using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.InfraStructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.InfraStructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _context;
        private readonly DbSet<T> _entites;
        public BaseRepository(SocialMediaContext context)
        {
            _context = context;
            _entites = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entites.ToArrayAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entites.FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _entites.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Add(T entity)
        {
            _entites.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entites.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
