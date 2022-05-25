using ApplicationService.DTOs;
using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

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

        [HttpGet]
        public IHttpActionResult GetVideo(int id)
        {
            return Json(service.GetById(id));
        }
        [HttpDelete]
        public IHttpActionResult DeleteVideo(int id)
        {
            if (service.Delete(id))
            {
                return Json("Delete was successful");
            }
            else return Json("Delete was not successful");
        }

        [HttpPost]
        public IHttpActionResult PostVideo(VideoDTO videoDTO)
        {
            if (service.Save(videoDTO))
            {
                return Json("The post was successful");
            }
            else return Json("The post was not successful");
        }

        [HttpPut]
        public IHttpActionResult EditVideo(VideoDTO videoDTO)
        {
            if (service.Update(videoDTO))
            {
                return Json("The update was successful");
            }
            else return Json("The update was not successful");
        }
    }
}