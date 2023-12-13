using Sensor.Domain.Model;
using Sensor.Domain.Services;
using Sensor.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Impl.Services
{
    public class IndicatorService : IIndicatorService
    {
        private readonly IIndicatorRepository _indicatorRepository;

        public IndicatorService(IIndicatorRepository indicatorRepository)
        {
            _indicatorRepository= indicatorRepository?? throw new ArgumentNullException(nameof(indicatorRepository));
        }

        public void AddIndicator(Indicator indicator)
        {
            var newId =_indicatorRepository.Add(indicator);
        }

        public IEnumerable<Indicator> GetAllIndicator()
        {
            return _indicatorRepository.GetAll();
        }

        public Indicator GetIndicator(int id)
        {
            return _indicatorRepository.GetById(id);
        }

        public void UpdateIndicator(Indicator indicator)
        {
            _indicatorRepository.Update(indicator);
        }

        public void DeleteIndicator(Indicator indicator)
        {
            _indicatorRepository.Delete(indicator);
        }


    }
}
