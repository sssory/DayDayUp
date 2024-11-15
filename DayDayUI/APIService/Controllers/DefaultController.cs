using System.Web.Http;

namespace DayDayWinForm.APIService.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpPost]
        public IHttpActionResult POST()
        {
            return Json(new Response()
            {
                code = 0,
                msg = ""
            });
        }
        [HttpGet]
        public IHttpActionResult GET()
        {
            return Json(new Response() {
                code=0,
                msg=""
            });
        }
    }
    public class Response
    {
        public int code { get; set; }
        public string msg { get; set; }
    }
}

