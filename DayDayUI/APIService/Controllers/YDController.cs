using DayDayWinForm.Tools;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Routing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DayDayWinForm.APIService.Controllers
{
    [RoutePrefix("EAPService")]
    public class YDController : ApiController
    {
        [HttpPost,Route("DeviceHeartbeat")]
        public IHttpActionResult DeviceHeartbeat(Request_DeviceHeartbeat request)
        {
            App.LogMessage($"【{request.machine_code}】-心跳");
            return Json(new Response()
            {
                code = 0,
                msg = ""
            });
        }
        [HttpPost,Route("DeviceAlarmReport")]
        public IHttpActionResult DeviceAlarmReport(Request_DeviceAlarmReport request)
        {
            string type = request.alarm_staus == 1 ? "发生" : "复位";
            App.LogMessage($"【{request.machine_code}】-报警{type} ---- "+ request.alarm_des);

            return Json(new Response()
            {
                code = 0,
                msg = ""
            });
        }
        [HttpPost,Route("DeviceDataReport")]
        public IHttpActionResult DeviceDataReport(Request_DeviceDataReport request)
        {
            App.LogMessage($"【{request.machine_code}】-水："+ request.water_used+"，电："+request.electricity_used);

            return Json(new Response()
            {
                code = 0,
                msg = ""
            });
        }
        [HttpPost,Route("DeviceStatusReport")]
        public IHttpActionResult DeviceStatusReport(Request_DeviceStatusReport request)
        {
            App.LogMessage($"【{request.machine_code}】-设备状态改变："+ request.status_code+request.status_name);

            return Json(new Response()
            {
                code = 0,
                msg = ""
            });
        }
        [HttpPost,Route("DeviceCraftReportExt")]
        public IHttpActionResult DeviceCraftReportExt(Request_DeviceCraftReportExt request)
        {
            App.LogMessage($"【{request.machine_code}】-结批："+ request.details[0].lot_num);

            return Json(new Response()
            {
                code = 0,
                msg = ""
            });
        }
    }
    public class Request_DeviceCraftReportExt
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string machine_code { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<Details> details { get; set; }
    }
    public class Details
    {
        /// <summary>
        /// 批次号
        /// </summary>
        public string lot_num { get; set; }
        /// <summary>
        /// PanelID
        /// </summary>
        public string panel_id { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<ParamInfo> paramList { get; set; }
    }
    public class ParamInfo
    {
        /// <summary>
        /// 参数编码
        /// </summary>
        public string item_code { get; set; }
        /// <summary>
        /// 参数描述
        /// </summary>
        public string item_des { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string item_value { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string uom { get; set; }
        /// <summary>
        /// 是否合格，1：合格，2不合格
        /// </summary>
        public string is_ok { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string create_time { get; set; }
    }
    public class Request_DeviceStatusReport
    {
        public string machine_code { get; set; }
        public string status_code { get; set; }
        public string status_name { get; set; }
        public string create_time { get; set; }
    }
    public class Request_DeviceHeartbeat
    {
        public string machine_code { get; set; }
        public string create_time { get; set; }
    }
    public class Request_DeviceAlarmReport
    {
        public string machine_code { get; set; }
        public string alarm_code { get; set; }
        public string alarm_des { get; set; }
        public int alarm_level { get; set; }
        public int alarm_staus { get; set; }
        public string create_time { get; set; }
    }
    public class Request_DeviceDataReport
    {
        public string machine_code { get; set; }
        /// <summary>
        /// 设备用水量，单位：吨
        /// </summary>
        public string water_used { get; set; }
        /// <summary>
        /// 设备DI用水量，单位：吨
        /// </summary>
        public string di_water_used { get; set; }
        /// <summary>
        /// 设备用电量，单位：度
        /// </summary>
        public string electricity_used { get; set; }
        public string create_time { get; set; }
    }
}

