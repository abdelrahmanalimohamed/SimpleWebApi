using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Abstraction;

namespace SimpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers Users;

        public UserController(IUsers _users)
        {
            this.Users = _users;
        }

        [Route("~/api/InsertUser/{name}")]
        [HttpPost]
        public async Task<ActionResult> InsertUser(string name)
        {
            try
            {
                if (name == null)
                {
                    return BadRequest();
                }
                else
                {
                    var created_user = await Users.Insert(name);
                    int checking = int.Parse(created_user);
                    if (checking > 0 )
                    {

                        return StatusCode(StatusCodes.Status201Created,
                     "Successfully creating new user record");
                    }
                    else
                    {

                        return StatusCode(StatusCodes.Status400BadRequest,
                     "Error in creating new user record");
                    }
                }

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new user record");
            }
        }

        [Route("~/api/updateuser/{id}/{name}")]
        [HttpPut]
        public async Task<ActionResult> UpdateUser(int id , string name )
        {
            try
            {
                if (id == 0 || name == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(await Users.Update(id, name));
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        [Route("~/api/allusers")]
        [HttpGet]
        public async Task<ActionResult> AllUsers()
        {
            try
            {
                return Ok( await Users.ReadAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
              "Error in getting user records");
            }
        }

        [Route("~/api/user/{id}")]
        [HttpGet]
        public async Task<ActionResult> getuser(int id)
        {
            try
            {
                return Ok(await Users.ReadUser(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
              "Error in getting user records");
            }
        }


        [Route("~/api/deleteuser/{id}")]
        [HttpDelete]
        public async Task<ActionResult> deleteuser(int id)
        {
            try
            {
                return Ok(await Users.Delete(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
              "Error in deleting user record");
            }
        }
    }
}
