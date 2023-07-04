using MarmitariaReal.Domain.Entities;
using MarmitariaReal.Domain.Interfaces.Repositories;
using MarmitariaReal.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmitariaReal.Repositories.Repositories
{
    public class ReceitasRepository : IReceitasRepository
    {
        protected readonly ProdutosDbContext _db;
        protected readonly DbSet<Receita> _dbSet;

        public ReceitasRepository(ProdutosDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Receita>();
        }
        public async Task<int> Delete(Guid id)
        {
            var receita = await _dbSet.FindAsync(id);
            _dbSet.Remove(receita);
            return await SaveChanges();
        }

        public async Task<List<Receita>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Receita> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> Insert(Receita receita)
        {
            _dbSet.Add(receita);
            return await SaveChanges();
        }

        public async Task<int> Update(Receita receita)
        {
            _dbSet.Update(receita);
            return await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
