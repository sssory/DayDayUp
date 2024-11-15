using System.Collections.Generic;
using System.Web.Http;


namespace DayDayWinForm.APIService.Controllers
{
    public class MLBrowningController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetWorkOrderInfo(Request request)
        {
            return Json(new Result_Common()
            {
                status_code = 200,
                message = "",
                cp_rev = "",
                lot = "",
                bk = "18",
                zmctl = "70",
                fmctl = "70",
                sbmctmj = "1982.2",
                xbmctmj = "1982.2",
                zctmj = "4.85",
                mlxsd = "4.0",
                zhwd1 = "34.5",
                zhwd2 = "34.5"
            });
        }
        [HttpPost]
        public IHttpActionResult Warning(RequestWarning request_Datacollect)
        {
            return Json(new MLBrowningResponse()
            {
                status_code = 202,
                message = "数据库操作异常",
            });
        }
        [HttpPost]
        public IHttpActionResult StatusChange(RequestStatusChange request_Datacollect)
        {
            return Json(new MLBrowningResponse()
            {
                status_code = 202,
                message = "11111",
            });
        }
        [HttpPost]
        public IHttpActionResult UploadData(Request_Datacollect request_Datacollect)
        {
            return Json(new Result_Common()
            {
                status_code = 200,
                message = "",
            });
        }
        public class MLBrowningResponse
        {
            public int status_code { get; set; }
            public string message { get; set; }

        }
        public class RequestWarning
        {
            public string mach_code { get; set; }
            public string wo { get; set; }
            public int wo_num { get; set; }
            public string ex_grade { get; set; }
            public string ex_code { get; set; }
            public string ex_desc { get; set; }
            public string ex_time { get; set; }
            public string op_name { get; set; }
        }
        public class RequestStatusChange
        {

            public string mach_code { get; set; }
            public string wo { get; set; }
            public int wo_num { get; set; }
            public string status { get; set; }
            public string c_time { get; set; }
            public string op_name { get; set; }

        }
        public class Request_Datacollect
        {

            public string wo { get; set; }
            public string mach_no { get; set; }
            public Parameter parameters { get; set; }
        }
        public class Parameter
        {


            public string ft2 { get; set; }

            public string speed { get; set; }

            public string acid_temp_set { get; set; }

            public string acid_temp_value { get; set; }

            public string acid_square_set { get; set; }

            public string acid_square_value { get; set; }

            public string acid_time_set { get; set; }

            public string acid_time_value { get; set; }

            public string acid_auto_status { get; set; }

            public string alkali_temp_set { get; set; }

            public string alkali_temp_value { get; set; }

            public string alkali_square_set { get; set; }

            public string alkali_square_value { get; set; }

            public string alkali_time_set { get; set; }

            public string alkali_time_value { get; set; }

            public string alkali_auto_status { get; set; }

            public string pre_temp_set { get; set; }

            public string pre_temp_value { get; set; }

            public string pre_ph_value { get; set; }

            public string pre_square_set { get; set; }

            public string pre_square_value { get; set; }

            public string pre_time_set { get; set; }

            public string pre_time_value { get; set; }

            public string pre_auto_status { get; set; }

            public string browning_temp_set { get; set; }

            public string browning_temp_value { get; set; }

            public string browning_square_set { get; set; }

            public string browning_square_value { get; set; }

            public string browning_h2o2_set { get; set; }

            public string browning_h2o2_value { get; set; }

            public string browning_h2so4_set { get; set; }

            public string browning_h2so4_value { get; set; }

            public string browning_water_set { get; set; }

            public string browning_water_value { get; set; }

            public string browning_time_set { get; set; }

            public string browning_time_value { get; set; }

            public string browning_h2o2_time_set { get; set; }

            public string browning_h2o2_time_value { get; set; }

            public string browning_h2so4_time_set { get; set; }

            public string browning_h2so4_time_value { get; set; }

            public string browning_last_value { get; set; }

            public string dry_temp1_set { get; set; }

            public string dry_temp1_value { get; set; }

            public string dry_temp2_set { get; set; }

            public string dry_temp2_value { get; set; }

            public string dry_wind1_set { get; set; }

            public string dry_wind1_value { get; set; }

            public string dry_wind2_set { get; set; }

            public string dry_wind2_value { get; set; }

            public string dry_wind3_set { get; set; }

            public string dry_wind3_value { get; set; }
        }
        public class Request
        {
            string wo; string mach_code; string op_name;


        }
        public class Result_Common
        {
            public int status_code { get; set; }
            public string message { get; set; }
            public string cp_rev { get; set; }
            public string lot { get; set; }
            public string bk { get; set; }
            public string zmctl { get; set; }
            public string fmctl { get; set; }
            public string sbmctmj { get; set; }
            public string xbmctmj { get; set; }
            public string mlxsd { get; set; }
            public string zctmj { get; set; }
            public string zhwd1 { get; set; }
            public string zhwd2 { get; set; }
        }
    }
  
 
}

