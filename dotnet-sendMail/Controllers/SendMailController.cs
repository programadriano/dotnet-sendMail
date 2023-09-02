using dotnet_sendMail.Infra.Mail;
using dotnet_sendMail.Model;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_sendMail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendMailController : ControllerBase
    {

        private readonly MailService _mailService;
        public SendMailController(MailService mailService) => _mailService = mailService;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MailViewModel mailViewModel)
        {
            try
            {
                await _mailService.SendMail(mailViewModel.To, mailViewModel.Message);
                return Ok("Email enviado com sucesso");
            }
            catch (Exception ex)
            {
                return Ok($"Erro ao tentar enviar o e-mail {ex.Message}");
            }
        }
    }
}