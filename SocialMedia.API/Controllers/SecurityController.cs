using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.API.Response;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _serviceService;
        private readonly IMapper _mapper;

        public SecurityController(ISecurityService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost([FromBody] SecurityDto securityDto)
        {
            var post = _mapper.Map<Security>(securityDto);
            await _serviceService.RegisterUser(post);

            securityDto = _mapper.Map<SecurityDto>(post);
            var response = new ApiResponse<SecurityDto>(securityDto);
            return Ok(response);
        }
    }
}
