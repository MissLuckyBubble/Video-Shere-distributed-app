using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System.Web.Http;

namespace Web_Api.Controllers
{
    public class CommentController : ApiController
    {
        private CommentManagmentService service = new CommentManagmentService();

        [HttpGet]
        public IHttpActionResult GetAllComments()
        {
            return Json(service.Get());
        }

        [HttpGet]
        public IHttpActionResult GetComment(int id)
        {
            return Json(service.GetById(id));
        }
        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {
            if (service.Delete(id))
            {
                return Json("Delete was successful");
            }
            else return Json("Delete was not successful");
        }

        [HttpPost]
        public IHttpActionResult PostComment(CommentDTO CommentDTO)
        {
            if (service.Save(CommentDTO))
            {
                return Json("The post was successful");
            }
            else return Json("The post was NOT successful");
        }

        [HttpPut]
        public IHttpActionResult EditComment(CommentDTO CommentDTO)
        {
            if (service.Update(CommentDTO))
            {
                return Json("The update was successful");
            }
            else return Json("The update was not successful");
        }
    }
}