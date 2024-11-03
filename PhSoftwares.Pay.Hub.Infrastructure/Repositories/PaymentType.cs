using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Core.Entities;
using PhSoftwares.Pay.Hub.Infrastructure.Context;

namespace PhSoftwares.Pay.Hub.Infrastructure.Repositories
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentType> Delete(Guid id)
        {
            var PaymentType = await _context.PaymentTypes.FindAsync(id);
            if (PaymentType != null)
            {
                _context.PaymentTypes.Remove(PaymentType);
                await _context.SaveChangesAsync();
                return PaymentType;
            }
            return null;
        }

        public async Task<IEnumerable<PaymentType>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PaymentType> GetById(Guid id)
        {
            return await _context.PaymentTypes.FindAsync(id);
        }

        public async Task<PaymentType> Insert(PaymentType paymentType)
        {
            _context.PaymentTypes.Add(paymentType);
            await _context.SaveChangesAsync();
            return paymentType;
        }

        public async Task<PaymentType> Update(PaymentType paymentType)
        {
            _context.PaymentTypes.Update(paymentType);
            await _context.SaveChangesAsync();
            return paymentType;
        }
    }
}
