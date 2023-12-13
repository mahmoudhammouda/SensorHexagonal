using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Repository
{
    public interface IIndicatorRepository
    {
        int Add(Indicator item);
        bool Update(Indicator item);
        Indicator GetById(int id);
        IEnumerable<Indicator> GetAll();
        void Delete(Indicator item);

    }
}
