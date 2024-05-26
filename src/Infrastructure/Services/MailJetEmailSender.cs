using Nika1337.Library.ApplicationCore.Abstractions;
using System;
using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Nika1337.Library.Infrastructure.Services;

public class MailJetEmailSender : IEmailSender
{
    private readonly IAppLogger<MailJetEmailSender> _logger;
    private readonly string _apiKey;
    private readonly string _secretKey;

    public MailJetEmailSender(IAppLogger<MailJetEmailSender> logger, IConfiguration configuration)
    {
        _logger = logger;
        _apiKey = configuration["MailjetConfiguration:MailjetApiKey"]!;
        _secretKey = configuration["MailjetConfiguration:MailjetSecretKey"]!;
    }

    public async Task<bool> SendEmailAsync(string fromEmail, string toEmail, string subject, string body)
    {
        try
        {
            return await Execute(fromEmail, toEmail, subject, body);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Sending email.");
            return false;
        }
    }

    private async Task<bool> Execute(string fromEmail, string toEmail, string subject, string body)
    {
        var client = new MailjetClient(_apiKey, _secretKey);

        var email = BuildTranstionalEmail(fromEmail, toEmail, subject, body);

        var response = await client.SendTransactionalEmailAsync(email);
        var message = response.Messages[0];
        
        bool isResponseSuccessful = message.Status.Equals("success", StringComparison.CurrentCultureIgnoreCase);

        if (isResponseSuccessful)
        {
            _logger.LogInformation("Email sent successfully");
        }
        else
        {
            _logger.LogInformation("Email Response unsuccessful");
        }
        return isResponseSuccessful;
    }

    private static TransactionalEmail BuildTranstionalEmail(string fromEmail, string toEmail, string subject, string body)
    {
        return new TransactionalEmailBuilder()
            .WithFrom(new SendContact(fromEmail))
            .WithTo(new SendContact(toEmail))
            .WithSubject(subject)
            .WithHtmlPart(body)
            .Build();
    }
     
}
