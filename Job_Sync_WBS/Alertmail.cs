using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Job_Sync_WBS
{
    class Alertmail
    {
        public static string _SMTPServer = ConfigurationSettings.AppSettings["SMTPServer"];
        public static string _SMTPPort = ConfigurationSettings.AppSettings["SMTPPort"];
        public static string _SMTPEnableSSL = ConfigurationSettings.AppSettings["SMTPEnableSSL"];
        public static string _SMTPUser = ConfigurationSettings.AppSettings["SMTPUser"];
        public static string _SMTPPassword = ConfigurationSettings.AppSettings["SMTPPassword"];
        public static string _DisplayName = ConfigurationSettings.AppSettings["DisplayName"];
        public static void sendEmail(string Body, string MailTo, string subject)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential basicCredential = new NetworkCredential(_SMTPUser, _SMTPPassword);
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress(_SMTPUser, _DisplayName);

                smtpClient.Host = _SMTPServer;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                smtpClient.EnableSsl = Convert.ToBoolean(_SMTPEnableSSL);
                smtpClient.Port = Convert.ToInt32(_SMTPPort);

                message.From = fromAddress;
                //message.CC = sCc;
                message.Subject = subject;

                //Set IsBodyHtml to true means you can send HTML email.
                message.IsBodyHtml = true;

                message.Priority = MailPriority.High;
                message.Body = Body;
                string[] mail = MailTo.Split(',');
                foreach (string s in mail)
                {
                    if (s != "")
                    {
                        message.Bcc.Add(new MailAddress(s));
                    }
                }
                message.Sender = fromAddress;
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
