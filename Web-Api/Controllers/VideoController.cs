using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web_Api.Messages;

namespace Web_Api.Controllers
{
    public class VideoController : ApiController
    {
        private VideoManagmentService service = new VideoManagmentService();

        [HttpGet]
        public IHttpActionResult GetAllVideos()
        {
            return Json(service.Get());
        }

        [Route("api/video/{id}")]
        [HttpGet]
        public IHttpActionResult GetVideo(int id)
        {
            return Json(service.GetById(id));
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteVideo(int id)
        {
            ResponseMessages response = new ResponseMessages();
            if (service.Delete(id))
            {
                response.Code = 200;
                response.Body = "The Video is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "This Video is not deleted.";
            }
            return Json(response);
        }
        [Authorize]
        [HttpPost]
        public IHttpActionResult PostVideo(VideoDTO videoDTO)
        {
            ResponseMessages response = new ResponseMessages();
            if (videoDTO.Id > 0) {
                if (service.Update(videoDTO))
                {
                    response.Code = 200;
                    response.Body = "Video is updated.";
                }
                else
                {
                    response.Code = 500;
                    response.Body = "The update was not successful.";
                }
            }
            else
            {
                if (service.Save(videoDTO))
                {
                    response.Code = 200;
                    response.Body = "The post was successful";
                }
                else {
                    response.Code = 500;
                    response.Body = "The post was not successful";
                }
            }
            return Json(response);
        }

      /*  [HttpPut]
        public IHttpActionResult EditVideo(VideoDTO videoDTO)
        {
            if (service.Update(videoDTO))
            {
                return Json("The update was successful");
            }
            else return Json("The update was not successful");
        }*/
    }
}