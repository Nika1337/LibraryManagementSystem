using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Services;

public class EmailService : IEmailService
{
    private readonly IEmailSender _emailSender;
    private readonly IRepository<EmailTemplate> _emailTemplateRepository;

    public EmailService(
        IEmailSender emailSender,
        IRepository<EmailTemplate> emailTemplateRepository)
    {
        _emailSender = emailSender;
        _emailTemplateRepository = emailTemplateRepository;
    }

    public async Task SendEmailAsync(string toEmail, string templateName, object templateContent)
    {
        var template = await GetTemplate(templateName);

        var formattedBody = FormatEmailBody(template, templateContent);

        await _emailSender.SendEmailAsync(template.FromEmail, toEmail, template.Subject, formattedBody);
    }

    private async Task<EmailTemplate> GetTemplate(string templateName)
    {
        return await _emailTemplateRepository.SingleOrDefaultAsync(new EmailTemplateSpecification(templateName)) ?? 
            throw new ApplicationException($"No Email Template with name '{templateName}' exists");
    }

    private static string FormatEmailBody(EmailTemplate template, object templateContent)
    {
        // Extract the separator and escape it for regex if necessary
        var separator = Regex.Escape(template.Separator);

        // Define the regex pattern to find all placeholders
        var pattern = $@"{separator}(.*?){separator}";
        IEnumerable<Match> matches = Regex.Matches(template.Body, pattern);

        // Use reflection to get the properties of the templateContent object
        var properties = templateContent.GetType().GetProperties();

        var propertyDict = properties.ToDictionary(p => p.Name, p => p);


        // Create a dictionary to hold placeholder-value pairs
        var placeholderValues = new Dictionary<string, string>();

        // Validate and extract placeholder values
        foreach (Match match in matches)
        {
            var placeholder = match.Groups[1].Value;


            if (propertyDict.TryGetValue(placeholder, out var propertyInfo))
            {
                // Get value of property in templateContent
                var value = (string)propertyInfo.GetValue(templateContent)!;
                placeholderValues.Add(match.Value, value);
            }
            else
            {
                throw new ArgumentException($"The placeholder '{placeholder}' does not have a corresponding property in the provided content.");
            }
        }


        // Replace placeholders in the body
        var body = template.Body;
        foreach (var kvp in placeholderValues)
        {
            body = body.Replace(kvp.Key, kvp.Value);
        }

        return body;
    }
}
