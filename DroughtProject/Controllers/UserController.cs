using AutoMapper;
using DroughtProject.DTO;
using DroughtProject.Models;
using DroughtProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DroughtProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;

        public UserController(IUsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersDto>>> GetAllUsers()
        {
            var usersList = await _repository.GetAllUsers();
            return Ok(_mapper.Map<List<UsersDto>>(usersList));
        }
    }
}
