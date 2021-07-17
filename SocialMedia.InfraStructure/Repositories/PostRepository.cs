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
            var posts = await _context.Posts.ToArrayAsync();

            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(e=> e.Id == id);
            return post;
        }

        public async Task InsertPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            var currentPost = await GetPost(post.Id);
            currentPost.Date = post.Date;
            currentPost.Description = post.Description;
            currentPost.Image = post.Image;
            currentPost.UserId = post.UserId;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePost(int id)
        {
            var current = await GetPost(id);

            _context.Posts.Remove(current);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
