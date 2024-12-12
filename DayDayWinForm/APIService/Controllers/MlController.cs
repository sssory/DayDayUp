using System.Collections.Generic;
using System.Web.Http;

namespace DayDayWinForm.APIService.Controllers
{
    public class MlController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetMLZH_Info(Request request)
        {
            return Json(new Response1()
            {
                data=new data("1.06", ""),
                success = "true",
                msg = "HME52411A1,該料號藥水類型與機台設定藥水不匹配"
            });
        }
    }
    public class Request
    {
        public string WO;
        public string MACNO;


    }

    public class Response1
    {
        public data data;
        public string msg;
        public string success;
    }
    public class data {
        public string SQFT;
        public string Attention;

        public data(string sQFT, string attention)
        {
            SQFT = sQFT;
            Attention = attention;
        }
    }
}

