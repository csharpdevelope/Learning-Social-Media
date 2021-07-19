using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.API.Response;
using SocialMedia.Core.CustomEntity;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enumerations;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilter;
using SocialMedia.InfraStructure.Interfaces;
using SocialMedia.InfraStructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocialMedia.API.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public PostController(IPostService postService, IMapper mapper, IUriService uriService)
        {
            _postService = postService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet(Name = nameof(GetPostsAsync))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPostsAsync([FromQuery] PostQueryFilter filter)
        {
            var posts = _postService.GetPosts(filter);
            var postDto = _mapper.Map<IEnumerable<PostDto>>(posts);

            var metadata = new MetaData
            {
                TotalCount = posts.TotalCount,
                PageSize = posts.PageSize,
                CurrentPage = posts.CurrentPage,
                TotalPage = posts.TotalPage,
                HasNextPage = posts.HasNextPage,
                HasPreviousPage = posts.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginationUri(filter, Url.RouteUrl(nameof(GetPostsAsync))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUri(filter, Url.RouteUrl(nameof(GetPostsAsync))).ToString()
            };
            var response = new ApiResponse<IEnumerable<PostDto>>(postDto)
            {
                Meta = metadata
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

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
        public IActionResult PutPost([FromRoute] int id, [FromBody] PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;
            var result = _postService.UpdatePost(post);
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
