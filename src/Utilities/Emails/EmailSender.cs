﻿using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using ShooterLink.Utilities.ApplicationOptions;

namespace ShooterLink.Utilities.Emails;

public class EmailSender(IOptions<EmailProviderOptions> options) : IEmailSender
{
    private readonly string _senderAddress = options.Value.SenderAddress;

    private readonly SmtpClient _client = new(options.Value.Host, options.Value.Port)
    {
        Credentials = new NetworkCredential(options.Value.UserName, options.Value.Password),
        EnableSsl = true
    };

    public async Task SendEmailAsync(string to, string subject, string body, CancellationToken ct, bool isHtml = true)
    {
        var mailMessage = new MailMessage(_senderAddress, to, subject, body)
        {
            IsBodyHtml = isHtml
        };

        await _client.SendMailAsync(mailMessage, ct);
    }
}
