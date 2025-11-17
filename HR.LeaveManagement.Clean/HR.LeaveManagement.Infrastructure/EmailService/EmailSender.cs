using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }
        public EmailSender(IOptions<EmailSettings> emailSetting) { 
            _emailSettings = emailSetting.Value;
        }
        public async Task<bool> SendEmail(EmailMeassage email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var from = new EmailAddress(_emailSettings.FromAddress, _emailSettings.FromName);
            var to = new EmailAddress(email.To);
            var msg = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(msg);
            
            return response.IsSuccessStatusCode;
        }
    }
}
