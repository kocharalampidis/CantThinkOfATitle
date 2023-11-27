using CantThinkOfATitle.DTOs;

namespace CantThinkOfATitle.Services.Interfaces
{
    public interface IEmailService
    {
        string SendEmail(EmailDTO request);

    }
}
