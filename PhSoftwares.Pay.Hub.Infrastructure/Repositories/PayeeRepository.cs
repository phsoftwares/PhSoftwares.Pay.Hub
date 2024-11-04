using Microsoft.EntityFrameworkCore;
using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Core.Entities;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using PhSoftwares.Pay.Hub.Infrastructure.Context;

namespace PhSoftwares.Pay.Hub.Infrastructure.Repositories
{
    public class PayeeRepository : IPayeeRepository
    {
        private readonly ApplicationDbContext _context;

        public PayeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payee> Delete(Guid id)
        {
            var Payee = await _context.Payees.FindAsync(id);
            if (Payee != null)
            {
                _context.Payees.Remove(Payee);
                await _context.SaveChangesAsync();
                return Payee;
            }
            return null;
        }

        public async Task<IEnumerable<Payee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Payee> GetById(Guid id)
        {
            return await _context.Payees.FindAsync(id);
        }

        public async Task<Payee> GetByDocument(String document)
        {           
            return await _context.Payees.FirstOrDefaultAsync(p => p.DocumentNumber.Trim() == document.Trim());
        }

        public async Task<Payee> Insert(Payee payee)
        {
            _context.Payees.Add(payee);
            await _context.SaveChangesAsync();
            return payee;
        }

        public async Task<Payee> Update(Payee payee)
        {
            var existingPayee = await _context.Payees.FindAsync(payee.Id);

            if (existingPayee != null)
            {
                _context.Entry(existingPayee).State = EntityState.Detached;
                payee.CreatedDateTime = existingPayee.CreatedDateTime;
                payee.CreationUserId = existingPayee.CreationUserId;
            }

            _context.Payees.Update(payee);
            await _context.SaveChangesAsync();
            return payee;
        }
    }
}
