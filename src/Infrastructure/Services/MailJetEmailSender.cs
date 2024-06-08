
using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using Nika1337.Library.Application.Abstractions;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class MailJetEmailSender : IEmailSender
{
    private readonly IMailjetClient _client;

    public MailJetEmailSender(IMailjetClient client)
    {
        _client = client;
    }

    

    public async Task SendEmailAsync(string fromEmail, string toEmail, string subject, string body)
    {
        var email = BuildTransactionalEmail(fromEmail, toEmail, subject, body);

        await _client.SendTransactionalEmailAsync(email);
    }

    private static TransactionalEmail BuildTransactionalEmail(string fromEmail, string toEmail, string subject, string body)
    {
        return new TransactionalEmailBuilder()
            .WithFrom(new SendContact(fromEmail))
            .WithTo(new SendContact(toEmail))
            .WithSubject(subject)
            .WithHtmlPart(body)
            .Build();
    }
     
}
