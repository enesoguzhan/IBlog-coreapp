using IBlog.Entities.DTO.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Business.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request); 
    }
}
