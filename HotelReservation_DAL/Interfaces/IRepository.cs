using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation_DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        T GetById(int id);
        Task<T> Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
