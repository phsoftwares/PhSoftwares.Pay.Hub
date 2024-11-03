using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using PhSoftwares.Pay.Hub.Infrastructure.Context;

namespace PhSoftwares.Pay.Hub.Infrastructure.Repositories
{
    public class RecipientRepository : IRecipientRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Recipient> Delete(Guid id)
        {
            var Recipient = await _context.Recipients.FindAsync(id);
            if (Recipient != null)
            {
                _context.Recipients.Remove(Recipient);
                await _context.SaveChangesAsync();
                return Recipient;
            }
            return null;
        }

        public async Task<IEnumerable<Recipient>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Recipient> GetById(Guid id)
        {
            return await _context.Recipients.FindAsync(id);
        }

        public async Task<Recipient> Insert(Recipient recipient)
        {
            _context.Recipients.Add(recipient);
            await _context.SaveChangesAsync();
            return recipient;
        }

        public async Task<Recipient> Update(Recipient recipient)
        {
            _context.Recipients.Update(recipient);
            await _context.SaveChangesAsync();
            return recipient;
        }
    }
}
