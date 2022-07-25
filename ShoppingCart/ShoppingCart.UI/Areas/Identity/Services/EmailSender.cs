using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace ShoppingCart.UI.Areas.Identity.Services
{
  public class EmailSender : IEmailSender
  {
    //taken from https://docs.microsoft.com/en-za/aspnet/core/security/authentication/accconfirm?view=aspnetcore-6.0&tabs=netcore-cli
    private readonly ILogger _logger;

    public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

    public EmailSender(IOptions<AuthMessageSenderOptions> optionAccessor, ILogger<EmailSender> logger)
    {
      Options = optionAccessor.Value;
      _logger = logger;
    }

    public async Task SendEmailAsync(
      string email,
      string subject,
      string htmlMessage)
    {
      if (string.IsNullOrEmpty(Options.SendGridKey))
      {
        throw new Exception("Null SendGridKey");
      }

      await SendEmailAsync(
        Options.SendGridKey,
        subject,
        htmlMessage,
        email);
    }

    public async Task SendEmailAsync(
      string apiKey,
      string subject,
      string message,
      string toEmail)
    {
      var client = new SendGridClient(apiKey);
      var msg = new SendGridMessage()
      {
        From = new EmailAddress("example@email.com", "Password Recovery"),
        Subject = subject,
        PlainTextContent = message,
        HtmlContent = message
      };

      msg.AddTo(new EmailAddress(toEmail));
      msg.SetClickTracking(false, false);
      Response? response = await client.SendEmailAsync(msg);
      _logger.LogInformation(
        response.IsSuccessStatusCode
          ? $"Email to {toEmail} queued successfully!"
          : $"Failure Email to {toEmail}");
    }
  }
}
