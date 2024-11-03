using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappings;
using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class PayerService : IPayerService
    {
        private readonly IPayerRepository _payerRepository;
        private readonly IPayerMapper _payerMapper;

        public PayerService(IPayerRepository payerRepository, IPayerMapper payerMapper)
        {
            _payerRepository = payerRepository;
            _payerMapper = payerMapper;
        }

        public async Task<PayerDTO> Delete(Guid id)
        {
            var payer = await _payerRepository.Delete(id);
            return await _payerMapper.MapFromEntitie(payer);
        }

        public Task<IEnumerable<PayerDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PayerDTO> GetById(Guid id)
        {
            var payer = await _payerRepository.GetById(id);
            return await _payerMapper.MapFromEntitie(payer);
        }

        public async Task<PayerDTO> Insert(PayerDTO payerDTO)
        {
            var payer = await _payerMapper.MapFromDTO(payerDTO);
            var payerInserted = await _payerRepository.Insert(payer);
            return await _payerMapper.MapFromEntitie(payerInserted);
        }

        public async Task<PayerDTO> Update(PayerDTO payerDTO)
        {
            var payer = await _payerMapper.MapFromDTO(payerDTO);
            var payerUpdate = await _payerRepository.Update(payer);
            return await _payerMapper.MapFromEntitie(payerUpdate);
        }

        public async Task<PayerDTO> UpdateWithId(PayerDTO payerDTO, Guid id)
        {
            payerDTO.SetId(id);
            var payer = await _payerMapper.MapFromDTO(payerDTO);
            var payerUpdate = await _payerRepository.Update(payer);
            return await _payerMapper.MapFromEntitie(payerUpdate);
        }

        public async Task<Guid> GetIdIfDocumentIsRegistred(String document)
        {
            var payer = await _payerRepository.GetByDocument(document);
            if (payer != null)
            {
                return payer.Id;
            }
            return Guid.Empty;
        }
    }
}
