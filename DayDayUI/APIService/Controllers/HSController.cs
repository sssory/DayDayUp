using DayDayWinForm.Tools;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Routing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DayDayWinForm.APIService.Controllers
{
    [RoutePrefix("api/PD")]
    public class HSController : ApiController
    {
        [HttpGet,Route("getPDSKXS")]
        public IHttpActionResult getPDSKXS(string P_CP_REV,string P_LINE,string P_MachineNo)
        {
            App.LogMessage($"【getPDSKXS】-{P_CP_REV}");
            return Json(new PDSKXS()
            {
                SKXS = "11.18",
                PenYaUp = "2.2",
                PenYaDown = "1.8",
                PenYaUp2 = "2.2",
                PenYaDown2 = "1.8",
                success = true,
                message = "成功",
            });

        }
    }

    class PDSKXS
    {
        public string SKXS { get; set; }//蝕刻線速
        public string PenYaUp { get; set; }//上噴壓
        public string PenYaDown { get; set; }//下噴壓
        public string PenYaUp2 { get; set; }//上噴壓2
        public string PenYaDown2 { get; set; }//下噴壓2
        public bool success { get; set; }//下噴壓2
        public string message { get; set; }//下噴壓2

    }
}

