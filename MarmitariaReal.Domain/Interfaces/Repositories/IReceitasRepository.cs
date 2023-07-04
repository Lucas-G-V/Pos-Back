using MarmitariaReal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmitariaReal.Domain.Interfaces.Repositories
{
    public interface IReceitasRepository
    {
        Task<Receita> GetById(Guid id);
        Task<List<Receita>> GetAll();
        Task<int> Delete(Guid id);
        Task<int> Update(Receita receita);
        Task<int> Insert(Receita receita);
    }
}
