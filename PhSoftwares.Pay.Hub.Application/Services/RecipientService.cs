using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappings;
using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using PhSoftwares.Pay.Hub.Application.Mappings;
using PhSoftwares.Pay.Hub.Core.Entities.Person;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class RecipientService : IRecipientService
    {
        private readonly IRecipientRepository _recipientRepository;
        private readonly IRecipientMapper _recipientMapper;

        public RecipientService(IRecipientRepository recipientRepository, IRecipientMapper recipientMapper)
        {
            _recipientRepository = recipientRepository;
            _recipientMapper = recipientMapper;
        }

        public async Task<RecipientDTO> Delete(Guid id)
        {
            var recipient = await _recipientRepository.Delete(id);
            return await _recipientMapper.MapFromEntitie(recipient);
        }

        public Task<IEnumerable<RecipientDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<RecipientDTO> GetById(Guid id)
        {
            var recipient = await _recipientRepository.GetById(id);
            return await _recipientMapper.MapFromEntitie(recipient);
        }

        public async Task<RecipientDTO> Insert(RecipientDTO recipientDTO)
        {
            var recipient = await _recipientMapper.MapFromDTO(recipientDTO);
            var recipientInserted = await _recipientRepository.Insert(recipient);
            return await _recipientMapper.MapFromEntitie(recipientInserted);
        }

        public async Task<RecipientDTO> Update(RecipientDTO recipientDTO)
        {
            var recipient = await _recipientMapper.MapFromDTO(recipientDTO);
            var recipientUpdate = await _recipientRepository.Update(recipient);
            return await _recipientMapper.MapFromEntitie(recipientUpdate);
        }

        public async Task<RecipientDTO> UpdateWithId(RecipientDTO recipientDTO, Guid id)
        {
            recipientDTO.SetId(id);
            var recipient = await _recipientMapper.MapFromDTO(recipientDTO);
            var recipientUpdate = await _recipientRepository.Update(recipient);
            return await _recipientMapper.MapFromEntitie(recipientUpdate);
        }

        public async Task<Guid> GetIdIfDocumentIsRegistred(String document)
        {
            var recipient = await _recipientRepository.GetByDocument(document);
            if (recipient != null)
            {
                return recipient.Id;
            }
            return Guid.Empty;
        }
    }
}
