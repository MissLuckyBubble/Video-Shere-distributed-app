using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System.Web.Http;
using Web_Api.Messages;

namespace Web_Api.Controllers
{
    public class UserController : ApiController
    {
        private UserManagmentService service = new UserManagmentService();

        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            return Json(service.Get());
        }


        [Authorize]
        [Route("api/user/{id}")]
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            return Json(service.GetById(id));
        }

        [Authorize]
        [Route("api/user/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            ResponseMessages response = new ResponseMessages();
            if (service.Delete(id))
            {
                response.Code = 200;
                response.Body = "User is deleted.";
            }
            else {
                response.Code = 500;
                response.Body = "User is not deleted.";
            }

            return Json(response);
        }

        [HttpPost]
        public IHttpActionResult PostUser(UserDTO userDTO)
        {
         
            ResponseMessages response = new ResponseMessages();
            if (userDTO.Id > 0)
            {
                if (service.Update(userDTO))
                {
                    response.Code = 200;
                    response.Body = "User is update.";
                }
                else
                {
                    response.Code = 500;
                    response.Body = "The update was not successful.";
                }
            }
            else
            {
                if (service.Save(userDTO))
                {
                    response.Code = 200;
                    response.Body = "The post was successful";
                }
                else
                {
                    response.Code = 500;
                    response.Body = "The post was not successful";
                }
            }
            return Json(response);
        }

      /*  [HttpPut]
        public IHttpActionResult EditUser(UserDTO userDTO)
        {
            if (service.Update(userDTO))
            {
                return Json("The update was successful");
            }
            else return Json("The update was not successful");
        }*/
    }
}