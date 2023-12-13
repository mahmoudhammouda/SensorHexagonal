using Sensor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Infrastructure.Repository
{
    public interface ISourceRepository
    {
        int Add(Source item);
        bool Update(Source item);
        Source GetById(int id);
    }
}
