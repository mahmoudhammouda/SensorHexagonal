using Sensor.Infrastructure.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : ModelEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        int Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);


    }
}
