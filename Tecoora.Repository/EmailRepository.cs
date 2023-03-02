using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecoora.IRepository;
using Tecoora.Models;
using Tecoora.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Tecoora.Repository
{
    public class EmailRepository : IEmailRepository
    {

        private readonly TecooraContext _context;

        public EmailRepository(TecooraContext context)
        {
            _context = context;
        }

        public async Task<List<Email>> getEmailList()
        {
            var result = await _context.Emails.ToListAsync();
            return result;
        }

       
        public async Task<Email> sendEmail(Email email)
        {
            email.IsSuccess = false;
            await _context.Emails.AddAsync(email);
            await _context.SaveChangesAsync();

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(email.ToEmail);
            mail.CC.Add("ruchikamperera@outlook.com");
            mail.From = new MailAddress("tecoora.visaweb@gmail.com", "Tecoora Visa App", System.Text.Encoding.UTF8);
            mail.Subject = "";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Body = email.Content;
            //string path = AppManage.requestimagePath + "\\" + this.ImageName;
            //Attachment data = new Attachment(
            //             path);
            //// your path may look like Server.MapPath("~/file.ABC")
            //mail.Attachments.Add(data);


            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("tecoora.visaweb@gmail.com", "ntauwxltjrqykraf");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                email.IsSuccess = true;
                _context.Update(email);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }


            return email;
        }
    }
}
