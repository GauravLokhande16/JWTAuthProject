using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using NewCrudApi.Data;
using NewCrudApi.Models;
using NewCrudApi.Models.Dto;

namespace NewCrudApi.Controllers
{


    [Route("/api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            if (UsersData.userList.Count == 0)
            {
                return BadRequest();
            }
            return Ok(_db.Users.ToList());
        }

        [HttpGet("{id:int}",Name ="GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> GetUserById (int id)
        {
            if(id < 0)
            {
                return NotFound();
            }
            var user = _db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> CreateUser([FromBody] UserDto userDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //   return BadRequest();
            //}

            if (_db.Users.FirstOrDefault(u => u.Name.ToLower() == userDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomeError", "User Already Exists!");
                return BadRequest(ModelState);
            }
            if(userDTO == null)
            {
                return BadRequest(userDTO);
            }
            if(userDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            UsersModel model = new()
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Designation = userDTO.Designation,
                CreatedDate = DateTime.Now
            };
            _db.Users.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetUser", new {id = userDTO.Id}, userDTO);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUserById(int id,[FromBody] UserDto userDto) 
        { 
            if(id != userDto.Id)
            {
                return BadRequest();
            }
            //var user = UsersData.userList.FirstOrDefault(u => u.Id == id);

            //if(user == null)
            //{
            //    return NoContent();
            //}
            //user.Id = id;
            //user.Name = userDto.Name;
            UsersModel model = new()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Designation = userDto.Designation,
            };
            _db.Users.Add(model);
            _db.SaveChanges();
            return Ok(UsersData.userList);
        }

        [HttpPatch("{id}",Name="UpdatePartialUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePartailUserInfo(int id, JsonPatchDocument<UserDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var user = UsersData.userList.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NoContent();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            patchDto.ApplyTo(user, ModelState);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteUserById (int id)
        {
            if( id < 0)
            {
                return NotFound();
            }
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return BadRequest("User not found!");
            }
            _db.Users.Remove(user);
            _db.SaveChanges();

            return NoContent();
        }

    }
}
