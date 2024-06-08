using Certificit.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.DAL.Interfaces
{
    public interface IGenaricInterface<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T?> GetById(int Id);
        public Task<int> AddAsync(T obj);
        public Task<int> AddRangeAsync(List<T> obj);
        public Task<int> DeleteAsync(T obj);
        public Task<int> DeleteRangeAsync(List<T> obj);
        public Task<int> UpdateAsync(T obj);
    }
}
