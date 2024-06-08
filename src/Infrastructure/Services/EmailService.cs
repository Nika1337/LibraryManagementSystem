using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Services;

public class EmailService : IEmailService
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailTemplateService _emailTemplateService;

    public EmailService(
        IEmailSender emailSender,
        IEmailTemplateService emailTemplateService)
    {
        _emailSender = emailSender;
        _emailTemplateService = emailTemplateService;
    }

    public async Task SendEmailAsync(string toEmail, int templateId, object templateContent)
    {
        var template = await GetTemplate(templateId);

        var formattedBody = FormatEmailBody(template, templateContent);

        await _emailSender.SendEmailAsync(template.FromEmail, toEmail, template.Subject, formattedBody);
    }

    private async Task<EmailTemplate> GetTemplate(int templateId)
    {
        return await _emailTemplateService.GetEmailTemplateAsync(templateId);
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

        var placeholderValues = ExtractPlaceholderValues(matches, propertyDict, templateContent);

        var body = ReplacePlaceholderValues(template.Body, placeholderValues);

        return body;
    }

    private static Dictionary<string, string> ExtractPlaceholderValues(IEnumerable<Match> matches, Dictionary<string, PropertyInfo> properties, object templateContent)
    {
        // Create a dictionary to hold placeholder-value pairs
        var placeholderValues = new Dictionary<string, string>();

        // Validate and extract placeholder values
        foreach (Match match in matches)
        {
            var placeholder = match.Groups[1].Value;


            if (properties.TryGetValue(placeholder, out var propertyInfo))
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
        return placeholderValues;
    }

    private static string ReplacePlaceholderValues(string body, Dictionary<string, string> placeholderValues)
    {
        var modifiedBody = body;
        foreach (var kvp in placeholderValues)
        {
            modifiedBody = modifiedBody.Replace(kvp.Key, kvp.Value);
        }
        return modifiedBody;
    }
}
