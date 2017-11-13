using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace MFU.Utils
{
    public static class Email
    {
        public static void Send(string to, string subject, string body)
        {
            SmtpClient client = new SmtpClient();
            client.Port = UtilsAppSetting.MailPort;
            client.Host = UtilsAppSetting.MailHost;
            client.EnableSsl = true;
            client.Timeout = UtilsAppSetting.MailTimeout;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(UtilsAppSetting.MailCredentialsUser, UtilsAppSetting.MailCredentialsPassword);

            MailMessage mm = new MailMessage(UtilsAppSetting.MailDonotReply, to, subject, body);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
    }
}
