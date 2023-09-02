using FluentEmail.Core;

namespace dotnet_sendMail.Infra.Mail
{
    public class MailService
    {
        private readonly IFluentEmail _fluentEmail;
        public MailService(IFluentEmail fluentEmail) => _fluentEmail = fluentEmail;
        public async Task SendMail(string to, string message) => await _fluentEmail.To(to).Body(message).SendAsync();

    }
}
