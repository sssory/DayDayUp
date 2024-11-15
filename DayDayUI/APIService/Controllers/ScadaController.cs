using System.Web.Http;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DayDayWinForm.APIService.Controllers
{
    public class ScadaController : ApiController
    {
        [HttpPost]
        public IHttpActionResult UserLogin(object obj)
        {
            return Json(new {
                reqID="",
                success=true,
                code=200,
                message="成功",
                data = new {
                    code=1,
                    remark="操作员"
                }
            });
        }
    }
}

