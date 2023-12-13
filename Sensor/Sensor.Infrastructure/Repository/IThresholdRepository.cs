using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Repository
{
    public interface IThresholdRepository
    {
        void Add(Threshold item);
        bool Update(Threshold item);
        Threshold GetById(int id);
        IEnumerable<Threshold> GetAll();
        bool Delete(Threshold item);

    }
}
