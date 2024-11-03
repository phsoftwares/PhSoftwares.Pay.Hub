using PhSoftwares.Pay.Hub.Application.DTOs.Person;
using PhSoftwares.Pay.Hub.Core.Entities;
using PhSoftwares.Pay.Hub.Core.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhSoftwares.Pay.Hub.Application.Interfaces.Repositories
{
    public interface IFinancialInstitutionRepository
    {
        Task<FinancialInstitution> Insert(FinancialInstitution financialInstitution);
        Task<FinancialInstitution> Delete(Guid id);
        Task<FinancialInstitution> Update(FinancialInstitution financialInstitution);
        Task<IEnumerable<FinancialInstitution>> GetAll();
        Task<FinancialInstitution> GetById(Guid id);
    }
}
