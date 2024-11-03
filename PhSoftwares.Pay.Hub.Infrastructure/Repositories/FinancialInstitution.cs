using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Core.Entities;
using PhSoftwares.Pay.Hub.Infrastructure.Context;

namespace PhSoftwares.Pay.Hub.Infrastructure.Repositories
{
    public class FinancialInstitutionRepository : IFinancialInstitutionRepository
    {
        private readonly ApplicationDbContext _context;

        public FinancialInstitutionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FinancialInstitution> Delete(Guid id)
        {
            var FinancialInstitution = await _context.FinancialInstitutions.FindAsync(id);
            if (FinancialInstitution != null)
            {
                _context.FinancialInstitutions.Remove(FinancialInstitution);
                await _context.SaveChangesAsync();
                return FinancialInstitution;
            }
            return null;
        }

        public async Task<IEnumerable<FinancialInstitution>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<FinancialInstitution> GetById(Guid id)
        {
            return await _context.FinancialInstitutions.FindAsync(id);
        }

        public async Task<FinancialInstitution> Insert(FinancialInstitution financialInstitution)
        {
            _context.FinancialInstitutions.Add(financialInstitution);
            await _context.SaveChangesAsync();
            return financialInstitution;
        }

        public async Task<FinancialInstitution> Update(FinancialInstitution financialInstitution)
        {
            _context.FinancialInstitutions.Update(financialInstitution);
            await _context.SaveChangesAsync();
            return financialInstitution;
        }
    }
}
