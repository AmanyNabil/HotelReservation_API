using HotelReservation_DAL.DataContxt;
using HotelReservation_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation_DAL.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected HotelResrvation_context db_context;
        public Repository(HotelResrvation_context context)
        {
            db_context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await db_context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
        public  T GetById(int id)
        {
            try
            {
                return  db_context.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);

            }
        }
        public async Task<T> Create(T entity)
        {
            try
            {
                var obj = await db_context.Set<T>().AddAsync(entity);
                db_context.SaveChanges();
                return obj.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
        public void Update(T entity)
        {
            try
            {
                db_context.Set<T>().Update(entity);
                db_context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
        public void Delete(T entity)
        {
            try
            {
                db_context.Set<T>().Remove(entity);
                db_context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

    }
}
