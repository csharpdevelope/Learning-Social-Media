using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.InfraStructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostsAsync()
        {
            var posts = await _postRepository.GetPosts();
            var postDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            return Ok(postDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostAsync([FromRoute] int id)
        {
            var posts = await _postRepository.GetPost(id);
            var postDto = _mapper.Map<PostDto>(posts);
            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost([FromBody] PostDto postDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var post = _mapper.Map<Post>(postDto);
            await _postRepository.InsertPost(post);
            return Ok(post);
        }
    }
}
