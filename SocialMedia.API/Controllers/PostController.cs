using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.API.Response;
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

        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostsAsync()
        {
            var posts = await _postService.GetPosts();
            var postDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            var response = new ApiResponse<IEnumerable<PostDto>>(postDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostAsync([FromRoute] int id)
        {
            var posts = await _postService.GetPost(id);
            var postDto = _mapper.Map<PostDto>(posts);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost([FromBody] PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postService.InsertPost(post);

            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost([FromRoute] int id, [FromBody] PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;
            var result = await _postService.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            var result = await _postService.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
