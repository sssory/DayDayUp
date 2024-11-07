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
    public partial class ServiceYDControl : UserControl
    {
        public ServiceYDControl()
        {
            InitializeComponent();
        }

        private void ServiceYDControl_Load(object sender, EventArgs e)
        {
            txt_json.Text = @"{
    ""request_uuid"": """",
    ""request_time"": ""2022-04-01 12:11:19"",
    ""request_attr"": """",
    ""up_sys_name"": ""DEV"",
    ""func_code"": ""AisRecvEapTask"",
    ""line_code"": """",
    ""machine_code"": ""F2_IL01L_TEST_001"",
    ""task_list"": [
        {
            ""lot_num"": ""lot001"",
            ""material_code"": """",
            ""lot_index"": """",
            ""port"": ""A"",
            ""recipe_code"": ""recipe001"",
            ""plan_count"": 100,
            ""pallet_num"": """",
            ""pallet_length"": ""600"",
            ""pallet_width"": ""600"",
            ""pallet_height"": ""30"",
            ""between_times"": """",
            ""firstcheck_count"": """",
            ""spotcheck_count"": """",
            ""pdb_start_count"": """",
            ""pdb_end_count"": """",
            ""pdb_between_count"": """",
            ""panel_list"": """",
            ""fp_flag"": """",
            ""fp_count"": """",
            ""target_sb_port_cod"": """",
            ""change_recipe_flag"": """",
            ""mi"": [
                {
                    ""item_name"": ""P001"",
                    ""item_value"": ""1"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P002"",
                    ""item_value"": ""1"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P003"",
                    ""item_value"": ""0.9"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P004"",
                    ""item_value"": ""0.2"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P005"",
                    ""item_value"": ""0.2"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P006"",
                    ""item_value"": ""1"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P007"",
                    ""item_value"": ""1"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P008"",
                    ""item_value"": ""1"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P009"",
                    ""item_value"": ""1"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P010"",
                    ""item_value"": ""1"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P011"",
                    ""item_value"": ""1"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P012"",
                    ""item_value"": ""1"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P013"",
                    ""item_value"": ""66"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P014"",
                    ""item_value"": ""55"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P015"",
                    ""item_value"": ""60"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P016"",
                    ""item_value"": ""65"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P017"",
                    ""item_value"": ""70"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P018"",
                    ""item_value"": ""75"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P019"",
                    ""item_value"": ""80"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                },{
                    ""item_name"": ""P020"",
                    ""item_value"": ""85"",
                    ""item_type"": """",
                    ""recipe"": """",
                    ""machine_type"": """"
                }
            ]
        }
    ]
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
                AppMessage.Logmsg("发生错误："+ex.Message);
            }
            
        }

    }
}
