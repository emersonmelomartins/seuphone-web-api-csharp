using Microsoft.Extensions.Options;
using Seuphone.Api.Data;
using Seuphone.Api.Helpers;
using Seuphone.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Seuphone.Api.Services
{
    public class MailService
    {
        private SeuphoneApiContext _context;
        private readonly AppSettings _appSettings;
        public string SenderMail { get; set; } = "seuphone@emersonmelomartins.dev.br";
        public string SenderPassword { get; set; } = "MindTech1";
        public string SenderServer { get; set; } = "emersonmelomartins.dev.br";
        public int SenderPort { get; set; } = 587;


        public MailService(IOptions<AppSettings> appSettings, SeuphoneApiContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }
        public void CreateOrderMail(Order order, Stream pdf, string recipientMail)
        {
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SenderMail);
                    mail.To.Add(recipientMail);
                    mail.Subject = $"Seuphone - Pedido {order.Id}";
                    mail.Body = $"<h1>Pedido {order.Id} criado com sucesso!</h1> <p>Seu pedido foi criado com sucesso, " +
                        $"em anexo você terá as informações do mesmo.</p> <p>Você pode consultar seu pedido em nosso site na seção " +
                        $"'Pedidos' na página 'Meus Dados'.</p>";
                    mail.IsBodyHtml = true;
                    mail.Attachments.Add(new Attachment(pdf, $"seuphone-pedido-{order.Id}.pdf"));

                    using (SmtpClient smtp = new SmtpClient(SenderServer, SenderPort))
                    {
                        //smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(SenderMail, SenderPassword);
                        //smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public void CreateUserMail(User user)
        {
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SenderMail);
                    mail.To.Add(user.Email);
                    mail.Subject = $"Seuphone - Usuário criado com sucesso!";
                    mail.Body = $"<h1>Usuário criado com sucesso!</h1>" +
                        $"<p>Olá, {user.Name}</p>" +
                        $"<p>Seu usuário foi criado com sucesso e agora você pode acessa-lo em nosso site.</p>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(SenderServer, SenderPort))
                    {
                        //smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(SenderMail, SenderPassword);
                        //smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public void ResetUserPasswordMail(User user, string newPassword)
        {
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(SenderMail);
                    mail.To.Add(user.Email);
                    mail.Subject = $"Seuphone - Redefinição de senha";
                    mail.Body = $"<h1>Sua senha foi redefinida.</h1>" +
                        $"<p>Olá, {user.Name}</p>" +
                        $"<p>Sua senha foi redefinida.</p>" +
                        $"<p>Sua nova senha é: <b>{newPassword}</b>.</p>" +
                        $"<p>Recomendamos que você entre em nosso site e troque sua senha de acordo com seu gosto.</p>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(SenderServer, SenderPort))
                    {
                        //smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(SenderMail, SenderPassword);
                        //smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

    }
}
