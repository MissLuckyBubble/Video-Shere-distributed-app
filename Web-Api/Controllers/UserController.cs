using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System.Web.Http;

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

        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            return Json(service.GetById(id));
        }
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            if (service.Delete(id))
            {
                return Json("Delete was successful");
            }
            else return Json("Delete was not successful");
        }

        [HttpPost]
        public IHttpActionResult PostUser(UserDTO userDTO)
        {
            if (service.Save(userDTO))
            {
                return Json("The post was successful");
            }
            else return Json("The post was not successful");
        }

        [HttpPut]
        public IHttpActionResult EditUser(UserDTO userDTO)
        {
            if (service.Update(userDTO))
            {
                return Json("The update was successful");
            }
            else return Json("The update was not successful");
        }
    }
}