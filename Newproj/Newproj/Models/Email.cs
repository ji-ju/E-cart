using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Newproj.Models
{
    public class Email
    {
        public static string Send(string Subject, string Body, string Email, bool IsHtml, string AttachmentPath)
        {
            try
            {
                string GmailAccount = "onlinehomeservicesproject@gmail.com";
                string GmailPassword = "online@services";
                string ToEmails ="onlinehomeservicesproject@gmail.com,"+Email;


                MailMessage myMail = new MailMessage(GmailAccount, ToEmails);
                myMail.Subject = Subject;
                myMail.IsBodyHtml = IsHtml;
                myMail.Body = Body;
                // myMail.Email = Email;
                if (!string.IsNullOrEmpty(AttachmentPath))
                {
                    Attachment myAttachment = new Attachment(AttachmentPath);
                    myMail.Attachments.Add(myAttachment);
                    myMail.Priority = MailPriority.High;
                }
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(GmailAccount, GmailPassword);
                smtp.Send(myMail);
                return "";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}
