﻿using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Core.Entities;
using PhSoftwares.Pay.Hub.Infrastructure.Context;

namespace PhSoftwares.Pay.Hub.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> Delete(Guid id)
        {
            var Payment = await _context.Payments.FindAsync(id);
            if (Payment != null)
            {
                _context.Payments.Remove(Payment);
                await _context.SaveChangesAsync();
                return Payment;
            }
            return null;
        }

        public async Task<IEnumerable<Payment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Payment> GetById(Guid id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task<Payment> Insert(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> Update(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }
    }
}
