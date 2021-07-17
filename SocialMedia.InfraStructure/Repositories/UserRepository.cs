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
    public class UserRepository : IUserRepository
    {
        private readonly SocialMediaContext _context;

        public UserRepository(SocialMediaContext socialMediaContext)
        {
            _context = socialMediaContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var posts = await _context.Users.ToArrayAsync();

            return posts;
        }

        public async Task<User> GetUser(int id)
        {
            var post = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
            return post;
        }
    }
}
