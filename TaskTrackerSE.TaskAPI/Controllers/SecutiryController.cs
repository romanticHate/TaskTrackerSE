using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerSE.Core.DTOs;
using TaskTrackerSE.Core.Entities;
using TaskTrackerSE.Core.Enumerations;
using TaskTrackerSE.Core.Interfaces;
using TaskTrackerSE.Infrastructure.Interfaces;
using TaskTrackerSE.TaskAPI.Response;

namespace TaskTrackerSE.TaskAPI.Controllers
{
    //[Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordService passwordService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(SecurityDto securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);

            security.Password = _passwordService.Hash(security.Password);
            await _securityService.RegisterUser(security);

            securityDto = _mapper.Map<SecurityDto>(security);
            var response = new ApiResponse<SecurityDto>(securityDto);
            return Ok(response);
        }

    }
}
