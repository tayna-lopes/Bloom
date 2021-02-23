using Bloom.BLL.RepositoriesInterfaces;
using Bloom.DAO.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Bloom.DAO.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        protected readonly BloomContext _context;
        private readonly IConfiguration _configuration;
        public readonly SqlConnection Connection;

        public RepositoryBase(BloomContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            Connection = new SqlConnection(_configuration.GetConnectionString("SQLConnectionString"));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(Guid id)
        {

            return _context.Set<TEntity>().Find(id);

        }

        public virtual void Add(TEntity obj)
        {

            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();

        }

        public virtual void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        public virtual void Edit(TEntity obj)
        {

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public void Dispose()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
                Connection.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
