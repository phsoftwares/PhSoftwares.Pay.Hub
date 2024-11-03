using Microsoft.EntityFrameworkCore;
using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Core.Entities;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using PhSoftwares.Pay.Hub.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Infrastructure.Repositories
{
    public class PayerRepository : IPayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payer> Delete(Guid id)
        {
            var payer = await _context.Payers.FindAsync(id);
            if (payer != null)
            {
                _context.Payers.Remove(payer);
                await _context.SaveChangesAsync();
                return payer;
            }
            return null;
        }

        public async Task<IEnumerable<Payer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Payer> GetById(Guid id)
        {
            return await _context.Payers.FindAsync(id);
        }

        public async Task<Payer> GetByDocument(String document)
        {
            return await _context.Payers.FirstOrDefaultAsync(p => p.DocumentNumber.Trim() == document.Trim());
        }

        public async Task<Payer> Insert(Payer payer)
        {
            _context.Payers.Add(payer);
            await _context.SaveChangesAsync();
            return payer;
        }

        public async Task<Payer> Update(Payer payer)
        {
            var existingPayer = await _context.Payers.FindAsync(payer.Id);

            if (existingPayer != null)
            {
                _context.Entry(existingPayer).State = EntityState.Detached;
                payer.CreatedDateTime = existingPayer.CreatedDateTime;
            }
            _context.Payers.Update(payer);
            await _context.SaveChangesAsync();
            return payer;
        }
    }
}
