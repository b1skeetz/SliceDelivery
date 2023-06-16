using SliceDelivery.Domain.Models;
using SliceDelivery.Domain.Response;
using SliceDelivery.Domain.ViewModels.Mailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceDelivery.Service.Interfaces
{
    public interface IMailerService
    {
        Task<IBaseResponse<Mailers>> Create(MailerViewModel model);
    }
}
