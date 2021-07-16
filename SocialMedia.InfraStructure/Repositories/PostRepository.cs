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
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;

        public PostRepository(SocialMediaContext socialMediaContext)
        {
            _context = socialMediaContext;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            //var posts = Enumerable.Range(1, 10).Select(x => new Post
            //{
            //    PostId = x,
            //    Description = $"Description {x}",
            //    Date = DateTime.UtcNow,
            //    Image = $"https://misapis.com/{x}",
            //    UserId = x * 2
            //});

            var posts = await _context.Posts.ToArrayAsync();

            return posts;
        }
    }
}
