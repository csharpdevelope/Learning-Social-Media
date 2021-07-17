using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
            return true;
        }

        public IEnumerable<Post> GetPosts(PostQueryFilter filter)
        {
            var posts = _unitOfWork.PostRepository.GetAll();
            if (filter.UserId != null)
            {
                posts = posts.Where(x => x.UserId == filter.UserId);
            }
            if (filter.Date != null)
            {
                posts = posts.Where(x => x.Date.ToShortDateString() == filter.Date?.ToShortDateString());
            }
            if (filter.Description != null)
            {
                posts = posts.Where(x => x.Description.ToLower().Contains(filter.Description.ToLower()));
            }

            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task InsertPost(Post post)
        
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);

            if (user == null)
            {
                throw new BusinessException("User doesn't exist");
            }
            var userPost = await _unitOfWork.PostRepository.GetPostByUser(post.UserId);
            if (userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(x=>x.Date).LastOrDefault();
                if ((lastPost.Date - DateTime.Now).TotalDays < 7)
                {
                    throw new BusinessException("You are not able to publish the post"); 
                }
            }

            if (post.Description.Contains("Sexo"))
                throw new BusinessException("Content not allowed");

            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public bool UpdatePost(Post post)
        {
            _unitOfWork.PostRepository.Update(post);
            return true;
        }
    }
}
