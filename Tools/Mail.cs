using System.Net.Mail;

namespace Common
{
    public class Mail
    {
        const string displayName = "SFJ";//别名
        const string userName = "15367308740@163.com";// 发送端账号  
        const string password = "DLPTITBKPHTHRUJH";//授权码
        const string host = "smtp.163.com";//邮件服务器smtp.163.com表示网易邮箱服务器
        const int prot = 587;// 邮件服务器端口  
        public string title { get; set; }
        public string content { get; set; }
        public string addressee { get; set; }
        public Mail(string _title,string _content,string _addressee)
        {
            title = _title;
            content = _content;
            addressee = _addressee;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        public bool SendMail()
        {

            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式    
            client.Host = host;
            //client.Port = prot; //指定端口
            client.UseDefaultCredentials = true;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(userName, password);//发送端账号、授权码

            try
            {
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.From = new MailAddress(userName, displayName);
                msg.To.Add(addressee);//收件人
                msg.Subject = title;//邮件标题   
                msg.Body = content;//邮件内容   
                msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码   
                msg.IsBodyHtml = true;//是否是HTML邮件   
                msg.Priority = MailPriority.High;//邮件优先级   
                client.Send(msg);
                return true;

            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }
    }
}
