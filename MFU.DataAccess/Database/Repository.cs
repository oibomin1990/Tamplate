using MFU.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
namespace MFU.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public Repository()
        {
            ConnectionFactory.LoadDatabaseSource();
        }

        public Repository(DatabaseSource dataSource)
        {
            ConnectionFactory.LoadDatabaseSource(dataSource);
        }

        public T GetById(int id)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                return conn.Get<T>(id);
            }
            
        }

        public IEnumerable<T> GetAll()
        {
            using (var conn = ConnectionFactory.Connection())
            {
                return conn.GetList<T>();
            }
        }

        public T Add(T entity)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                conn.Insert(entity);
            }
            return entity;
        }

        public void Delete(T entity)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                conn.Delete(entity);
            }
        }

        public void Update(T entity)
        {
            using (var conn = ConnectionFactory.Connection())
            {
                conn.Update(entity);
            }
        }
    }
}