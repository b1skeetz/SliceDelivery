using SliceDelivery.DAL.Interfaces;
using SliceDelivery.Domain.Enum;
using SliceDelivery.Domain.Models;
using SliceDelivery.Domain.Response;
using SliceDelivery.Domain.ViewModels.Mailer;
using SliceDelivery.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SliceDelivery.Service.Implementations
{
    public class MailerService : IMailerService
    {
        private readonly IBaseRepository<Mailers> _mailerRepository;
        public MailerService(IBaseRepository<Mailers> mailerRepository)
        {
            _mailerRepository = mailerRepository;
        }

        public async Task<IBaseResponse<Mailers>> Create(MailerViewModel model)
        {
            try
            {
                var mailer = new Mailers()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Number = model.Number,
                };

                await _mailerRepository.Create(mailer);

                return new BaseResponse<Mailers>()
                {
                    Description = "Заявка создана успешно! Скоро с Вами свяжутся.",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Mailers>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
