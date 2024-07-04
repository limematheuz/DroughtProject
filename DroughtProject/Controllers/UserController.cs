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

        [HttpPost]
        public async Task<ActionResult<int>> CreateUsers(CreateUserDto createUserDto)
        {
            var userCreate = _mapper.Map<Users>(createUserDto);
            var userId = await _repository.CreateUsers(userCreate);
            return Ok(userId);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateUsers(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var existUser = await _repository.ExistUser(id);
            if (!existUser)
            {
                return NotFound();
            }

            var user = _mapper.Map<Users>(updateUserDto);
            var userUpdate = await _repository.UpdateUsers(user);
            if (user == null)
            {
                return NotFound(id);
            }

            return Ok(userUpdate);
        }
    }
}
