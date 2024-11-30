using System.Net.Http;
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
        [HttpGet]
        public IHttpActionResult GetProductionTask(string lotID)
        {
            string str1 = @"{
	""reqID"": ""0123456789abcdef0123456789abcdef"",
	""success"": true,
	""code"": 200,
	""message"": ""成功"",
	""data"": {
		""eqpID"": ""M-JOO-KI-001"",
		""priority"": 0,
		""prodTaskID"": ""0123456789abcdef0123456789abcdef"",
		""lot"": ""A88JJ-IKKI-00A-001"",
		""partNumber"": ""A88JJ-IKKI2"",
		""clearLine"": 0,
		""count"": 100,
		""jobArg"": [
			{
				""name"": ""BoardHeight"",
				""value"": ""600"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": null,
				""remark"": ""板长""
			},
			{
				""name"": ""BoardWidth"",
				""value"": ""500"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": null,
				""remark"": ""板宽""
			},
			{
				""name"": ""PlatingEfficiency"",
				""value"": ""0.30"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": null,
				""remark"": ""电镀效率""
			},
			{
				""name"": ""TransferSpeed"",
				""value"": ""1"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": null,
				""remark"": ""传送速度""
			},
			{
				""name"": ""AmpereDensity"",
				""value"": ""30.00"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": null,
				""remark"": ""电流密度""
			},
			{
				""name"": ""DummyBoardWidth"",
				""value"": ""600"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""min"",
				""remark"": ""陪镀板宽度""
			},
			{
				""name"": ""PowerOutputRatio1_2"",
				""value"": ""1.00"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""电流系数1-2""
			},
			{
				""name"": ""PowerOutputRatio3_14"",
				""value"": ""1.00"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""电流系数3-14""
			},
			{
				""name"": ""PowerOutputRatio15_30"",
				""value"": ""1.00"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""电流系数15_30""
			},
			{
				""name"": ""PowerOutputRatio31_40"",
				""value"": ""1.00"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""电流系数31_40""
			},
			{
				""name"": ""PowerOutputRatio41-42"",
				""value"": ""1.00"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""电流系数41-42""
			},
			{
				""name"": ""HzPump1_2"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率1_2""
			},
			{
				""name"": ""HzPump3_14"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率3_14""
			},
			{
				""name"": ""HzPump15_30"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率15_30""
			},
			{
				""name"": ""HzPump31_40"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率31_40""
			},
			{
				""name"": ""HzPump41_42"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率41_42""
			}
		],
		""dataTime"": ""2021/12/20 20:12:22""
	}
}";

			string str2 = @"{
	""reqID"": ""0123456789abcdef0123456789abcdef"",
	""success"": true,
	""code"": 200,
	""message"": ""成功"",
	""data"": {
		""eqpID"": ""M-JOO-KI-001"",
		""priority"": 0,
		""prodTaskID"": ""0123456789abcdef0123456789abcdef"",
		""lot"": ""A88JJ-IKKI-00A-001"",
		""partNumber"": ""A88JJ-IKKI1"",
		""clearLine"": 0,
		""count"": 100,
		""jobArg"": [
			{
				""name"": ""BoardHeight"",
				""value"": ""600"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": null,
				""remark"": ""板长""
			},
			{
				""name"": ""BoardWidth"",
				""value"": ""500"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": null,
				""remark"": ""板宽""
			},
			{
				""name"": ""PlatingEfficiency"",
				""value"": ""0.30"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": null,
				""remark"": ""电镀效率""
			},
			{
				""name"": ""TransferSpeed"",
				""value"": ""1"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": null,
				""remark"": ""传送速度""
			},
			{
				""name"": ""AmpereDensity"",
				""value"": ""3.00"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": null,
				""remark"": ""电流密度""
			},
			{
				""name"": ""DummyBoardWidth"",
				""value"": ""600"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""min"",
				""remark"": ""陪镀板宽度""
			},
			{
				""name"": ""PlatingThickness"",
				""value"": ""0.20"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""min"",
				""remark"": ""镀铜厚度""
			},
			{
				""name"": ""HzPump1_6"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率1_6""
			},
			{
				""name"": ""HzPump7_12"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率7_12""
			},
			{
				""name"": ""HzPump13_18"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率13_18""
			},
			{
				""name"": ""HzPump19_24"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率19_24""
			},
			{
				""name"": ""HzPump25_30"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率25_30""
			},
			{
				""name"": ""HzPump31_36"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率31_36""
			},
			{
				""name"": ""HzPump37_42"",
				""value"": ""50"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": ""喷流频率37_42""
			},
			{
				""name"": ""WaveRecipe"",
				""value"": ""recp123"",
				""code"": null,
				""maxValue"": null,
				""minValue"": null,
				""units"": ""kg"",
				""remark"": """"
			}
		],
		""dataTime"": ""2021/12/20 20:12:22""
	}
}";

			string str = str1;
			if (lotID=="2")
			{
				str = str2;
			}
            var response = new HttpResponseMessage
            {

                Content = new StringContent(str, System.Text.Encoding.UTF8, "application/json"),
                StatusCode = System.Net.HttpStatusCode.OK
            };
            return ResponseMessage(response);
        }
    }
}

