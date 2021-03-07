using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Models;
using MimeKit;
using MailKit.Net.Smtp;
namespace TaskList2
{
    public class EmailService
    {
        public void SendEmailWithCode(UserModel user,int key)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Список задач", "testovictest224@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", user.Email));
            emailMessage.Subject = user.Name;
            emailMessage.Body = new TextPart("plain") { Text = @$"Уважаемый {user.Email}! Ваш ключ подтверждения: {key}" };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("testovictest224@gmail.com", "azaza!@3456"); //логин-пароль от аккаунта
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
