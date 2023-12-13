using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Repository
{
    public interface IMeasureRepository
    {
        int Add(Measure item);
        IEnumerable<Measure> GetAll();
        bool Update(Measure item);
        Measure GetById(int id);
        void Delete(Measure mesure);
    }
}
