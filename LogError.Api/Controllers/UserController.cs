using AutoMapper;
using LogError.Api.Security;
using LogError.Domain.DTO;
using LogError.Domain.Entities;
using LogError.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogError.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly Auth _auth;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor, IMapper mapper, Auth auth)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _auth = auth;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] AddUserDTO userDTO)
        {
            try
            {
                if(!ModelState.IsValid)
                    throw new ArgumentNullException("O usuário é obrigatório");

                var user =  _mapper.Map<UserDTO>(_userService.Save(_mapper.Map<User>(userDTO)));

                return Ok(user);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{email}")]
        public ActionResult<UserDTO> Get(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new ArgumentNullException("O email é obrigatório");
                }

                var userClaims = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;

                var _user = JsonConvert.DeserializeObject<UserDTO>(userClaims);

                var user = _mapper.Map<UserDTO>(_userService.GetUser(email));

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        public ActionResult<string> Auth([FromBody] AuthDTO authDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentNullException("O dados invalidos");
            }

            var user = _mapper.Map<UserDTO>(_userService.Auth(authDTO.Email, authDTO.Password));

            return _auth.GerarToken(user);
        }
    }
}
