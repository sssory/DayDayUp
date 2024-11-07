using System.Web.Http;

namespace DayDayUI.APIService.Controllers
{
    public class WServiceController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Feedback(Feedback feedback)
        {

            Feedback_Response response = new Feedback_Response();
            response.code = 200;
            response.msg = "success";
            response.LH = feedback.LH;
            response.CZYH = feedback.CZYH;
            response.result = new Feedback_result_Response();
            response.result.GJCD_MM = 550;
            response.result.GJKD_MM = 500;
            response.result.PDBKD_MM = 666;
            response.result.DDMJ_Q = 100;
            response.result.DDMJ_H = 100;
            response.result.DDXL = 1;
            response.result.CSSD = 0.35f;
            response.result.TGDLMD = 16;
            response.result.SDGDLMD = 25;
            response.result.XGDLMD = 18;
            response.result.BH = 1.9f;
            
            response.result.DLXS_TG_1_2 = 1;
            response.result.DLXS_TG_3_6 = 1;
            response.result.DLXS_TG_7_12 = 1;
            response.result.DLXS_TG_13_16 = 1;
            response.result.DLXS_TG_17_18 = 1;
            
            response.result.PLPL_TG_1_2 = 20;
            response.result.PLPL_TG_3_6 = 20;
            response.result.PLPL_TG_7_12 = 20;
            response.result.PLPL_TG_13_16 = 20;
            response.result.PLPL_TG_17_18 = 20;
            response.result.SDGPLPL = 50;
            response.result.XGPLPL = 50;
            response.result.GYXZ = 1;
             
            return Json(response);
        }
    }
    public class Feedback_Response
    {
        public int code { get; set; }
        public string msg { get; set; }
        public string CZYH { get; set; }
        public string LH { get; set; }
        public Feedback_result_Response result { get; set; }
    }

    public class Feedback_result_Response
    {
        public int GJCD_MM { get; set; }
        public int GJKD_MM { get; set; }
        public int PDBKD_MM { get; set; }
        public float DDXL { get; set; }
        public float CSSD { get; set; }
        public float TGDLMD { get; set; }
        public float BH { get; set; }
        public float DLXS_TG_1_2 { get; set; }
        public float DLXS_TG_3_6 { get; set; }
        public float DLXS_TG_7_12 { get; set; }
        public float DLXS_TG_13_16 { get; set; }
        public float DLXS_TG_17_18 { get; set; }
        public int PLPL_TG_1_2 { get; set; }
        public int PLPL_TG_3_6 { get; set; }
        public int PLPL_TG_7_12 { get; set; }
        public int PLPL_TG_13_16 { get; set; }
        public int PLPL_TG_17_18 { get; set; }
        public float SDGDLMD { get; set; }
        public int SDGPLPL { get; set; }
        public float XGDLMD { get; set; }
        public int XGPLPL { get; set; }
        public int GYXZ { get; set; }
        public int DDMJ_Q { get; set; }
        public int DDMJ_H { get; set; }

    }

    public class Feedback
    {
        public string GDH { get; set; }
        public string SBBH { get; set; }
        public string CZYH { get; set; }
        public string SJC { get; set; }
        public string GCH { get; set; }
        public string LH { get; set; }
        public string Extend1 { get; set; }
        public string Extend2 { get; set; }
        public string Extend3 { get; set; }
        public string Extend4 { get; set; }
    }


}


