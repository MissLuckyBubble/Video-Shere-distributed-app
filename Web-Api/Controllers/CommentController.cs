using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System.Web.Http;
using Web_Api.Messages;

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
        [Route("api/comment/{id}")]
        public IHttpActionResult GetComment(int id)
        {
            return Json(service.GetById(id));
        }

        [Authorize]
        [Route("api/comment/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {
            ResponseMessages response = new ResponseMessages();
            if (service.Delete(id))
            {
                response.Code = 200;
                response.Body = "Comment is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Comment is not deleted.";
            }

            return Json(response);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult PostComment(CommentDTO CommentDTO)
        {
            ResponseMessages response = new ResponseMessages();
            if (CommentDTO.Id > 0)
            {

                if (service.Update(CommentDTO))
                {
                    response.Code = 200;
                    response.Body = "Comment is updated.";
                }
                else
                {
                    response.Code = 500;
                    response.Body = "Comment is not updated.";
                }
            }
            else
            {
                if (service.Save(CommentDTO))
                {
                    response.Code = 200;
                    response.Body = "Comment is saved.";
                }
                else
                {
                    response.Code = 500;
                    response.Body = "Comment is not saved.";
                }
            }
            return Json(response);
        }

        [Authorize]
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