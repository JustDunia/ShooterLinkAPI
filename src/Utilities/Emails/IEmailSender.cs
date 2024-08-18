namespace ShooterLink.Utilities.Emails;

public interface IEmailSender
{
    Task SendEmailAsync(string to, string subject, string body, CancellationToken ct, bool isHtml = true);
}
