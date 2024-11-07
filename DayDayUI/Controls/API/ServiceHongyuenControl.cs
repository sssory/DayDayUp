using DayDayUI.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayDayUI.Controls
{
    public partial class ServiceHongyuenControl : UserControl
    {
        public ServiceHongyuenControl()
        {
            InitializeComponent();
        }

        private void ServiceYDControl_Load(object sender, EventArgs e)
        {
            txt_json.Text = @"{
    ""code"": ""0000"",
    ""data"": {
        ""partnumber"": ""NFR4G4429 / A1"",
        ""pfCode"": ""G5化清参数示例"",
        ""pfName"": ""G5化清参数示例"",
        ""pfVersion"": ""v1"",
        ""formula"": ""Y"",
        ""paraList"": [
            {
                ""pCode"": ""P004"",
                ""pName"": ""板宽"",
                ""pType"": 1,
                ""pValue"": ""250"",
                ""fileName"": null,
                ""upperLimit"": 610,
                ""lowerLimit"": 250,
                ""specUpperLimit"": 650,
                ""specLowerLimit"": 250,
                ""unitCode"": ""mm   "",
                ""unitName"": ""毫米                ""
            },
            {
                ""pCode"": ""YZ001"",
                ""pName"": ""输送速度1设定值"",
                ""pType"": 1,
                ""pValue"": ""2"",
                ""fileName"": null,
                ""upperLimit"": 2,
                ""lowerLimit"": 2,
                ""specUpperLimit"": 2,
                ""specLowerLimit"": 2,
                ""unitCode"": ""m/min"",
                ""unitName"": ""米每分""
            },
            {
                ""pCode"": ""YZ002"",
                ""pName"": ""输送速度2设定值"",
                ""pType"": 1,
                ""pValue"": ""2"",
                ""fileName"": null,
                ""upperLimit"": 2,
                ""lowerLimit"": 2,
                ""specUpperLimit"": 2,
                ""specLowerLimit"": 2,
                ""unitCode"": ""m/min"",
                ""unitName"": ""米每分""
            },
            {
                ""pCode"": ""YZ003"",
                ""pName"": ""加压水洗1频率设定值"",
                ""pType"": 1,
                ""pValue"": ""117"",
                ""fileName"": null,
                ""upperLimit"": 117,
                ""lowerLimit"": 117,
                ""specUpperLimit"": 117,
                ""specLowerLimit"": 117,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ004"",
                ""pName"": ""微蚀1A频率设定值"",
                ""pType"": 1,
                ""pValue"": ""117"",
                ""fileName"": null,
                ""upperLimit"": 117,
                ""lowerLimit"": 117,
                ""specUpperLimit"": 117,
                ""specLowerLimit"": 117,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ005"",
                ""pName"": ""微蚀1B频率设定值"",
                ""pType"": 1,
                ""pValue"": ""41"",
                ""fileName"": null,
                ""upperLimit"": 41,
                ""lowerLimit"": 41,
                ""specUpperLimit"": 41,
                ""specLowerLimit"": 41,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ006"",
                ""pName"": ""微蚀2A频率设定值"",
                ""pType"": 1,
                ""pValue"": ""113"",
                ""fileName"": null,
                ""upperLimit"": 113,
                ""lowerLimit"": 113,
                ""specUpperLimit"": 113,
                ""specLowerLimit"": 113,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ007"",
                ""pName"": ""微蚀2B频率设定值"",
                ""pType"": 1,
                ""pValue"": ""140"",
                ""fileName"": null,
                ""upperLimit"": 140,
                ""lowerLimit"": 140,
                ""specUpperLimit"": 140,
                ""specLowerLimit"": 140,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ008"",
                ""pName"": ""微蚀2循环频率设定值"",
                ""pType"": 1,
                ""pValue"": ""120"",
                ""fileName"": null,
                ""upperLimit"": 120,
                ""lowerLimit"": 120,
                ""specUpperLimit"": 120,
                ""specLowerLimit"": 120,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ009"",
                ""pName"": ""水刀浸洗1&2频率设定值"",
                ""pType"": 1,
                ""pValue"": ""40"",
                ""fileName"": null,
                ""upperLimit"": 40,
                ""lowerLimit"": 40,
                ""specUpperLimit"": 40,
                ""specLowerLimit"": 40,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ010"",
                ""pName"": ""加压水洗2频率设定值"",
                ""pType"": 1,
                ""pValue"": ""116"",
                ""fileName"": null,
                ""upperLimit"": 116,
                ""lowerLimit"": 116,
                ""specUpperLimit"": 116,
                ""specLowerLimit"": 116,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ011"",
                ""pName"": ""水刀浸洗3&4频率设定值"",
                ""pType"": 1,
                ""pValue"": ""40"",
                ""fileName"": null,
                ""upperLimit"": 40,
                ""lowerLimit"": 40,
                ""specUpperLimit"": 40,
                ""specLowerLimit"": 40,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ012"",
                ""pName"": ""加压水洗3频率设定值"",
                ""pType"": 1,
                ""pValue"": ""115"",
                ""fileName"": null,
                ""upperLimit"": 115,
                ""lowerLimit"": 115,
                ""specUpperLimit"": 115,
                ""specLowerLimit"": 115,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ013"",
                ""pName"": ""强风吹干频率设定值"",
                ""pType"": 1,
                ""pValue"": ""400"",
                ""fileName"": null,
                ""upperLimit"": 400,
                ""lowerLimit"": 400,
                ""specUpperLimit"": 400,
                ""specLowerLimit"": 400,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ014"",
                ""pName"": ""风刀赶水频率设定值"",
                ""pType"": 1,
                ""pValue"": ""400"",
                ""fileName"": null,
                ""upperLimit"": 400,
                ""lowerLimit"": 400,
                ""specUpperLimit"": 400,
                ""specLowerLimit"": 400,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ015"",
                ""pName"": ""抗氧化频率设定值"",
                ""pType"": 1,
                ""pValue"": ""122"",
                ""fileName"": null,
                ""upperLimit"": 122,
                ""lowerLimit"": 122,
                ""specUpperLimit"": 122,
                ""specLowerLimit"": 122,
                ""unitCode"": ""HZ"",
                ""unitName"": ""赫兹""
            },
            {
                ""pCode"": ""YZ016"",
                ""pName"": ""微蚀1温度设定值"",
                ""pType"": 1,
                ""pValue"": ""25"",
                ""fileName"": null,
                ""upperLimit"": 27,
                ""lowerLimit"": 23,
                ""specUpperLimit"": 27,
                ""specLowerLimit"": 23,
                ""unitCode"": ""度"",
                ""unitName"": ""摄氏温度            ""
            },
            {
                ""pCode"": ""YZ017"",
                ""pName"": ""微蚀2温度设定值"",
                ""pType"": 1,
                ""pValue"": ""25"",
                ""fileName"": null,
                ""upperLimit"": 27,
                ""lowerLimit"": 23,
                ""specUpperLimit"": 27,
                ""specLowerLimit"": 23,
                ""unitCode"": ""度"",
                ""unitName"": ""摄氏温度            ""
            },
            {
                ""pCode"": ""YZ018"",
                ""pName"": ""抗氧化温度设定值"",
                ""pType"": 1,
                ""pValue"": ""33"",
                ""fileName"": null,
                ""upperLimit"": 35,
                ""lowerLimit"": 31,
                ""specUpperLimit"": 35,
                ""specLowerLimit"": 31,
                ""unitCode"": ""度"",
                ""unitName"": ""摄氏温度            ""
            },
            {
                ""pCode"": ""YZ019"",
                ""pName"": ""热风吹干温度设定值"",
                ""pType"": 1,
                ""pValue"": ""85"",
                ""fileName"": null,
                ""upperLimit"": 90,
                ""lowerLimit"": 80,
                ""specUpperLimit"": 90,
                ""specLowerLimit"": 80,
                ""unitCode"": ""度"",
                ""unitName"": ""摄氏温度            ""
            },
            {
                ""pCode"": ""YZ020"",
                ""pName"": ""添加模式选择"",
                ""pType"": 2,
                ""pValue"": ""计板长"",
                ""fileName"": null,
                ""upperLimit"": 0,
                ""lowerLimit"": 0,
                ""specUpperLimit"": 0,
                ""specLowerLimit"": 0,
                ""unitCode"": ""无"",
                ""unitName"": ""-""
            },
            {
                ""pCode"": ""YZ021"",
                ""pName"": ""添加方式选择"",
                ""pType"": 2,
                ""pValue"": ""true"",
                ""fileName"": null,
                ""upperLimit"": 0,
                ""lowerLimit"": 0,
                ""specUpperLimit"": 0,
                ""specLowerLimit"": 0,
                ""unitCode"": ""无"",
                ""unitName"": ""-""
            },
            {
                ""pCode"": ""YZ022"",
                ""pName"": ""微蚀硫酸添加"",
                ""pType"": 1,
                ""pValue"": ""0"",
                ""fileName"": null,
                ""upperLimit"": 0,
                ""lowerLimit"": 0,
                ""specUpperLimit"": 0,
                ""specLowerLimit"": 0,
                ""unitCode"": ""无"",
                ""unitName"": ""-""
            },
            {
                ""pCode"": ""YZ023"",
                ""pName"": ""微蚀双氧水添加"",
                ""pType"": 1,
                ""pValue"": ""1500"",
                ""fileName"": null,
                ""upperLimit"": 1500,
                ""lowerLimit"": 1500,
                ""specUpperLimit"": 1500,
                ""specLowerLimit"": 1500,
                ""unitCode"": ""Inch "",
                ""unitName"": ""英寸                ""
            },
            {
                ""pCode"": ""YZ024"",
                ""pName"": ""微蚀DI水添加"",
                ""pType"": 1,
                ""pValue"": ""0"",
                ""fileName"": null,
                ""upperLimit"": 0,
                ""lowerLimit"": 0,
                ""specUpperLimit"": 0,
                ""specLowerLimit"": 0,
                ""unitCode"": ""无"",
                ""unitName"": ""-""
            },
            {
                ""pCode"": ""YZ025"",
                ""pName"": ""抗氧化添加"",
                ""pType"": 1,
                ""pValue"": ""0"",
                ""fileName"": null,
                ""upperLimit"": 0,
                ""lowerLimit"": 0,
                ""specUpperLimit"": 0,
                ""specLowerLimit"": 0,
                ""unitCode"": ""无"",
                ""unitName"": ""-""
            },
            {
                ""pCode"": ""YZ026"",
                ""pName"": ""抗氧化DI水添加"",
                ""pType"": 1,
                ""pValue"": ""0"",
                ""fileName"": null,
                ""upperLimit"": 0,
                ""lowerLimit"": 0,
                ""specUpperLimit"": 0,
                ""specLowerLimit"": 0,
                ""unitCode"": ""无"",
                ""unitName"": ""-""
            }
        ],
        ""assistanceList"": [
            {
                ""pCode"": ""myPnlNum"",
                ""pName"": ""pnl数量"",
                ""pType"": 1,
                ""pValue"": ""90"",
                ""fileName"": null,
                ""upperLimit"": 180,
                ""lowerLimit"": 0,
                ""specUpperLimit"": 180,
                ""specLowerLimit"": 0,
                ""unitCode"": ""SHEET"",
                ""unitName"": ""张                  ""
            }
        ]
    },
    ""other"": null
}";
        }
        private async void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                await HttpSend.SendPostAsync(txt_url.Text.Trim(), HttpSend.DefaultContent(txt_json.Text.Trim()));
                AppMessage.Logmsg("下发成功");
            }
            catch (Exception ex)
            {
                AppMessage.Logmsg("发生错误：" + ex.Message);
            }

        }

    }
}
