using System.Collections;
using CrudApi.Data;
using CrudApi.Models;
using CrudApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<UserDto>> getUsers()
        {
            if(UserStore.userList.Count == 0)
            {
                return NoContent();
            }
            if(UserStore.userList == null)
            {
                return BadRequest();
            }
            return Ok(UserStore.userList);
        }

        [HttpGet("{id:int}", Name ="GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> getUserById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = UserStore.userList.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDto>  createUser([FromBody]UserDto userDto)
        {
            if(UserStore.userList.FirstOrDefault(u => u.Name.ToLower() == userDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "User Already exists!");
                return BadRequest(ModelState);
            }
            if (userDto == null)
            {
                return BadRequest(userDto);
            }
            if(userDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            userDto.Id = UserStore.userList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            UserStore.userList.Add(userDto);

            return CreatedAtRoute("GetUser",new {id = userDto.Id},userDto);

        }



 
    }
}
