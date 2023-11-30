﻿using Focus.Business.Models;
using System;

using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;


namespace Focus.Business
{
    public class SendEmail : ISendEmail
    {
        private string EmailFrom = "no-reply@techqode.com";
        private string EmailFromPassword = "S+m-i5ccugxz";
        private string Host = "mail.techqode.com";
        private string SmtpServer = "mail.techqode.com";
        private string LocalHost = "http://localhost:8080/";
        private int Port = 465;
        private readonly IConfiguration Configuration;

        public SendEmail(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Task SendEmailAsync(SendEmailDto emailDto, string UserName, string Id, string appLink)
        {
            try
            {
                
                var sb = new StringBuilder();
                if (emailDto.Subject == "Password Reset")
                {
                    //var pathWithFolderName = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Attachment/noblelogowithicon.png");
                    sb.Append("<div>");
                    sb.Append("<h2 style='font-family:Helvetica;text-align: left;'>Reset Noble-POS User</h2>");
                    //sb.Append("<img src="+ pathWithFolderName + " style='text-align: right;'/>");
                    sb.Append("</div>");
                    sb.Append("<div>");
                    sb.Append("<h4 style='font-family:Helvetica;text-align: center;'>Hello " + UserName + " ,</h4>");
                    sb.Append("</br>");
                    sb.Append("<p style='font-family:Helvetica;text-align: center;'>We're sending you this email because you requested for password reset.</p>");
                    sb.Append("</br>");
                    sb.Append("<p style='font-family:Helvetica;text-align: center;'>Click on this link to create a new password.</p>");
                    sb.Append("</br>");
                    sb.Append("</div>");
                    sb.Append("</br>");
                    sb.Append("<div style='text-align: center;'>");
                    sb.Append("<a href=" + appLink + "/ResetPassword?id=" + Id + " style='background-color: #1e6eca !important;border: none;color: white;padding: 10px 28px;text-align: center;text-decoration: none;display: inline-block;font-size: 16px;margin: 4px 2px;cursor: pointer;border-radius: 30px;' target='_blank' type='button'>Reset Password</a>");
                    sb.Append("</div>");
                    emailDto.Body = sb.ToString();
                }
                if (emailDto.Subject == "Create Password")
                {
                    //var pathWithFolderName = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Attachment/noblelogowithicon.png");
                    sb.Append("<div>");
                    sb.Append("<h2 style='font-family:Helvetica;text-align: left;'>New Password for Noble-POS</h2>");
                    //sb.Append("<img src="+ pathWithFolderName + " style='text-align: right;'/>");
                    sb.Append("</div>");
                    sb.Append("<div>");
                    sb.Append("<h4 style='font-family:Helvetica;text-align: center;'>Hello " + UserName + " ,</h4>");
                    sb.Append("</br>");
                    sb.Append("<p style='font-family:Helvetica;text-align: center;'>We're sending you this email because you requested for new password.</p>");
                    sb.Append("</br>");
                    sb.Append("<p style='font-family:Helvetica;text-align: center;'>Click on this link to create a new password.</p>");
                    sb.Append("</br>");
                    sb.Append("</div>");
                    sb.Append("</br>");
                    sb.Append("<div style='text-align: center;'>");
                    sb.Append("<a href=" + appLink + "/NewPassword?id=" + Id + " style='background-color: #1e6eca !important;border: none;color: white;padding: 10px 28px;text-align: center;text-decoration: none;display: inline-block;font-size: 16px;margin: 4px 2px;cursor: pointer;border-radius: 30px;' target='_blank' type='button'>Create Password</a>");
                    sb.Append("</div>");
                    emailDto.Body = sb.ToString();
                }

                if(emailDto.Subject == "User Name and Password For Login")
                {
                    string path = Configuration.GetSection("frontend").GetSection("IpAndServerAddress").Value;

                    sb.Append("<div>");
                    sb.Append("<h2 style='font-family:Helvetica;text-align: left;'>New User for Noble-POS</h2>");
                    //sb.Append("<img src="+ pathWithFolderName + " style='text-align: right;'/>");
                    sb.Append("</div>");
                    sb.Append("<div>");
                    sb.Append("<h4 style='font-family:Helvetica;text-align: center;'>Hello " + emailDto.UserName + " ,</h4>");
                    sb.Append("</br>");
                    sb.Append("<p style='font-family:Helvetica;text-align: center;'>We're sending you this email because you're our new Employee.</p>");
                    sb.Append("</br>");                    
                    sb.Append("<p style='font-family:Helvetica;text-align: center;'>Your Login And Password Is</p>");
                    sb.Append("<p style='font-family:Helvetica;text-align: center;'>Your Email:-"+ emailDto.YourEmail + "</p>");
                    sb.Append("<p style='font-family:Helvetica;text-align: center;'>Your Password:- "+ emailDto.Password + "</p>");
                    sb.Append("<p style='font-family:Helvetica;text-align: center;'>Click on this link to go on our Login Page.</p>");
                    sb.Append("</div>");
                    sb.Append("</br>");
                    sb.Append("<div style='text-align: center;'>");
                    sb.Append("<a href='"+ path + "/'  style='background-color: #1e6eca !important;border: none;color: white;padding: 10px 28px;text-align: center;text-decoration: none;display: inline-block;font-size: 16px;margin: 4px 2px;cursor: pointer;border-radius: 30px;' target='_blank' type='button'>Go To Login</a>");
                    sb.Append("</div>");
                }
                //if (emailDto.Subject == "Password Reset")
                //{
                //    var logoPath = "https://www.logodesign.net/assets/images/new-ui/logo-category-illustration-logo.png";

                //    var pathWithFolderName = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Attachment/noblelogowithicon.png");
                //    sb.Append("<body style='background-color: #e9ecef;'>");
                //    sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%'>");

                //    start logo
                //    sb.Append("<tr>");
                //    sb.Append("<td style='background-color: #e9ecef;' align='center'>");
                //    sb.Append("<table  border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>");
                //    sb.Append("<tr>");
                //    sb.Append("<td align='center' valign='top' style='padding: 36px 24px;'>");
                //    sb.Append("<a  href='#' target='_blank' style='display: inline-block;'>");

                //    sb.Append("<img src='" + logoPath + "' alt='Logo' border='0' width='48' style='display: block; width: 48px; max-width: 48px; min-width: 48px; '>");

                //    sb.Append("</a>");
                //    sb.Append("</td>");
                //    sb.Append("</tr>");
                //    sb.Append("</table>");
                //    sb.Append("</td>");
                //    sb.Append("</tr>");

                //    start here
                //    sb.Append("<tr>");
                //    sb.Append("<td style='background-color: #e9ecef;' align='center'>");
                //    sb.Append("<table  border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>");
                //    sb.Append("<tr>");
                //    sb.Append("<td align='left' bgcolor='#ffffff' style='padding: 36px 24px 0; border-top: 3px solid #d4dadf;'>");

                //    sb.Append("<h1  style='margin: 0; font-size: 32px; font-weight: 700; letter-spacing: -1px; line-height: 48px; '> Confirm Your Email Address </h1>");

                //    sb.Append("</td>");
                //    sb.Append("</tr>");
                //    sb.Append("</table>");
                //    sb.Append("</td>");
                //    sb.Append("</tr>");


                //    start copy block
                //    sb.Append("<tr>");
                //    sb.Append("<td style='background-color: #e9ecef;' align='center'>");
                //    sb.Append("<table  border='0' cellpadding='0' cellspacing='0' width='100%' style='max-width: 600px;'>");

                //    sb.Append("<tr>");
                //    sb.Append("<td align='left' bgcolor='#ffffff' style='padding: 24px; font-size: 16px; line-height: 24px;'>");
                //    sb.Append("<p style='margin: 0;'>Tap the button below to confirm your email address. If you didn't create an account with <a href='https://sendgrid.com'>Paste</a>, you can safely delete this email.</p>");
                //    sb.Append("</td>");
                //    sb.Append("</tr>");

                //    sb.Append("<tr>");
                //    sb.Append("<td align='left' bgcolor='#ffffff'>");
                //    sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%'>");
                //    sb.Append("<tr>");
                //    sb.Append("<td align='center' bgcolor='#ffffff' style='padding: 12px;'>");
                //    sb.Append("<table border='0' cellpadding='0' cellspacing='0'>");
                //    sb.Append("<tr>");
                //    sb.Append("<td align='center' bgcolor='#1a82e2' style='border-radius: 30px;'>");
                //    sb.Append("<a href='#' target='_blank' style='display: inline-block; padding: 16px 36px;  font-size: 16px; color: #ffffff; text-decoration: none; border-radius: 6px;'>Do Something Sweet</a>");

                //    sb.Append("</td>");
                //    sb.Append("</tr>");
                //    sb.Append("</table>");
                //    sb.Append("</td>");
                //    sb.Append("</tr>");
                //    sb.Append("</table>");
                //    sb.Append("</td>");
                //    sb.Append("</tr>");

                //    sb.Append("<tr>");
                //    sb.Append("<td align='left' bgcolor='#ffffff' style='padding: 24px; font-size: 16px; line-height: 24px;'>");
                //    sb.Append("<p style='margin: 0;'>If that doesn't work, copy and paste the following link in your browser:</p>");
                //    sb.Append("<p style='margin: 0; '><a href='https://sendgrid.com' target='_blank'>https://same-link-as-button.url/xxx-xxx-xxxx</a></p>");
                //    sb.Append("</td>");
                //    sb.Append("</tr>");

                //    sb.Append("<tr>");
                //    sb.Append("<td align='left' bgcolor='#ffffff' style='padding: 24px; font-size: 16px; line-height: 24px; border-bottom: 3px solid #d4dadf'>");
                //    sb.Append("<p style='margin: 0; '>Cheers,<br> Paste</p>");
                //    sb.Append("</td>");
                //    sb.Append("</tr>");

                //    sb.Append("</table>");
                //    sb.Append("</td>");
                //    sb.Append("</tr>");

                //    sb.Append("</table>");
                //    sb.Append("</body>");
                //    emailDto.Body = sb.ToString();
                //}



                InternetAddressList list = new InternetAddressList();
                list.Add(new MailboxAddress("Noble POS ERP", emailDto.EmailTo));

                EmailMessage message = new EmailMessage
                {
                    Sender = new MailboxAddress("Noble POS ERP", EmailFrom),
                    Reciever = list,
                    Subject = emailDto.Subject,
                    Content = sb.ToString()
                };
                var mimeMessage = CreateMimeMessageFromEmailMessage(message);
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Connect(SmtpServer,
                        Port, true);
                    smtpClient.Authenticate(EmailFrom,
                        EmailFromPassword);
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                }
                return Task.FromResult(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }

        public Task SendInvoiceEmailLinkAsync(EmailCompose emailCompose)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("<!DOCTYPE html>");
                sb.Append("<body>");
                sb.Append("<div style='text-align: center'>");

                sb.Append("<p style='font-size:14px;'>" + emailCompose.Description + "</p>");
                if (!string.IsNullOrEmpty(emailCompose.EmailPath))
                {
                    sb.Append("<h4>I hope you’re well. Please click button to view your " + emailCompose.ButtonName + "</h4>");
                    sb.Append("<a style='background: #1977cc; border: 0; padding: 13px 35px; color: #fff; border-radius: 50px; text-decoration: none; letter-spacing: 1px; font-size: 17px; '  href='" + emailCompose.EmailPath + "'> View " + emailCompose.ButtonName + "</a>");
                    sb.Append("<h5>If button not working then click on below link</h5>");
                    sb.Append("<a href='" + emailCompose.EmailPath + "'>" + emailCompose.EmailPath + "</a>");
                }
                sb.Append("</div>");
                sb.Append("</body>");

                InternetAddressList list = new InternetAddressList();
                foreach (var emailAddress in emailCompose.EmailTo)
                {
                    list.Add(new MailboxAddress(emailCompose.CompanyName, emailAddress.Cc));
                }

                EmailMessage message = new EmailMessage
                {
                    Sender = new MailboxAddress(emailCompose.CompanyName, EmailFrom),
                    Reciever = list,
                    Subject = emailCompose.Subject,
                    Content = sb.ToString()
                };
                var mimeMessage = CreateMimeMessageFromEmailMessage(message);
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Connect(SmtpServer,
                        Port, true);
                    smtpClient.Authenticate(EmailFrom,
                        EmailFromPassword);
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                }
                return Task.FromResult(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        private MimeMessage CreateMimeMessageFromEmailMessage(EmailMessage message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(message.Sender);
            mimeMessage.To.AddRange(message.Reciever);
            mimeMessage.Subject = message.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            { Text = message.Content };
            return mimeMessage;
        }
        private MimeMessage CreateMimeMessageFromEmailPdf(EmailMessage message)
        {
            var builder = new BodyBuilder { HtmlBody = message.Content };
            builder.Attachments.Add(message.FileName, message.Attachment, MimeKit.ContentType.Parse(MediaTypeNames.Application.Pdf));

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(message.Sender);
            mimeMessage.To.AddRange(message.Reciever);
            mimeMessage.Subject = message.Subject;

            mimeMessage.Body = builder.ToMessageBody();
            return mimeMessage;
        }

        public Task SendInvoiceEmailPdfAsync(EmailCompose emailCompose)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("<!DOCTYPE html>");
                sb.Append("<body>");
                sb.Append("<div style='text-align: center'>");
                sb.Append("<p style='font-size:14px;'>" + emailCompose.Description + "</p>");
                sb.Append("<h4>I hope you’re well. Please click on your document to view/download </h4>");

                sb.Append("</div>");
                sb.Append("</body>");

                InternetAddressList list = new InternetAddressList();
                foreach (var emailAddress in emailCompose.EmailTo)
                {
                    list.Add(new MailboxAddress(emailCompose.CompanyName, emailAddress.Cc));
                }

                EmailMessage message = new EmailMessage
                {
                    Sender = new MailboxAddress(emailCompose.CompanyName, EmailFrom),
                    Reciever = list,
                    Subject = emailCompose.Subject,
                    Content = sb.ToString(),
                    Attachment = emailCompose.PdfBytes,
                    FileName = emailCompose.ButtonName
                };
                var mimeMessage = CreateMimeMessageFromEmailPdf(message);
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Connect(SmtpServer,
                        Port, true);
                    smtpClient.Authenticate(EmailFrom,
                        EmailFromPassword);
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                }
                return Task.FromResult(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }

    public class EmailMessage
    {
        public MailboxAddress Sender { get; set; }
        public InternetAddressList Reciever { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string FileName { get; set; }
        public byte[] Attachment { get; set; }
    }
}
