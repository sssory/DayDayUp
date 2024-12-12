using System.Net.Http;
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
        public IHttpActionResult getctl()
        {
            var str = "[{\"scbh\":\"P63794A\",\"bjcd\":\"21.90\",\"bjkd\":\"17.90\",\"yjmctl\":\"51.55% \",\"hxmctl\":\"50.28% \",\"bjlx\":\"fcxb\", \"ef\":\"LC-A\"}]";
            var response = new HttpResponseMessage
            {

                Content = new StringContent(str, System.Text.Encoding.UTF8, "application/json"),
                StatusCode = System.Net.HttpStatusCode.OK
            };
            return ResponseMessage(response);
        }
    }
    public class Response
    {
        public int code { get; set; }
        public string msg { get; set; }
    }
}

