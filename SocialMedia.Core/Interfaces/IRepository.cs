using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete (int id);
        Task<T> GetById(int id);
    }
}
