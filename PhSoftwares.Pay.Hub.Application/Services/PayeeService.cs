using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappings;
using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using PhSoftwares.Pay.Hub.Application.Mappings;
using PhSoftwares.Pay.Hub.Core.Entities.Person;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class PayeeService : IPayeeService
    {
        private readonly IPayeeRepository _payeeRepository;
        private readonly IPayeeMapper _payeeMapper;

        public PayeeService(IPayeeRepository payeeRepository, IPayeeMapper payeeMapper)
        {
            _payeeRepository = payeeRepository;
            _payeeMapper = payeeMapper;
        }

        public async Task<PayeeDTO> Delete(Guid id)
        {
            var payee = await _payeeRepository.Delete(id);
            return await _payeeMapper.MapFromEntitie(payee);
        }

        public Task<IEnumerable<PayeeDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PayeeDTO> GetById(Guid id)
        {
            var payee = await _payeeRepository.GetById(id);
            return await _payeeMapper.MapFromEntitie(payee);
        }

        public async Task<PayeeDTO> Insert(PayeeDTO payeeDTO)
        {
            var payee = await _payeeMapper.MapFromDTO(payeeDTO);
            var payeeInserted = await _payeeRepository.Insert(payee);
            return await _payeeMapper.MapFromEntitie(payeeInserted);
        }

        public async Task<PayeeDTO> Update(PayeeDTO payeeDTO)
        {
            var payee = await _payeeMapper.MapFromDTO(payeeDTO);
            var payeeUpdate = await _payeeRepository.Update(payee);
            return await _payeeMapper.MapFromEntitie(payeeUpdate);
        }

        public async Task<PayeeDTO> UpdateWithId(PayeeDTO payeeDTO, Guid id)
        {
            payeeDTO.SetId(id);
            var payee = await _payeeMapper.MapFromDTO(payeeDTO);
            var payeeUpdate = await _payeeRepository.Update(payee);
            return await _payeeMapper.MapFromEntitie(payeeUpdate);
        }

        public async Task<Guid> GetIdIfDocumentIsRegistred(String document)
        {
            var payee = await _payeeRepository.GetByDocument(document);
            if (payee != null)
            {
                return payee.Id;
            }
            return Guid.Empty;
        }
    }
}
