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
    public class MeasureService : IMeasureService
    {
        private readonly IMeasureRepository _measureRepository;
        private readonly IIndicatorRepository _indicatorRepository;
        private readonly ISourceRepository _sourceRepository;

        public MeasureService(
            IMeasureRepository measureRepository,
            IIndicatorRepository indicatorRepository,
            ISourceRepository sourceRepository)
        {
            _measureRepository = measureRepository ?? throw new ArgumentNullException(nameof(measureRepository));
            _indicatorRepository = indicatorRepository ?? throw new ArgumentNullException(nameof(indicatorRepository));
            _sourceRepository = sourceRepository ?? throw new ArgumentNullException(nameof(sourceRepository));
        }

        public void AddMeasure(Measure measure)
        {
            if(CheckRulesAndThrowException(measure,true))
                _measureRepository.Add(measure);
        }

        public Measure AddMeasure(int indicatorId, int sourceId, string value, string unite, DateTime observationTime)
        {
            var indicator = _indicatorRepository.GetById(indicatorId);
            var source = _sourceRepository.GetById(sourceId);

            if (indicator != null && source != null) 
            {
               Measure measure = new Measure(-1, indicator, source, new MeasureValue(value, unite), observationTime);
              _measureRepository.Add(measure);
               return measure;
            }

            throw new InvalidOperationException("Measure to create not correct");
        }

        public IEnumerable<Measure> GetAllMeasure()
        {
            return _measureRepository.GetAll();
        }

        public IEnumerable<Measure> GetLatestMeasures(int count)
        {
            return _measureRepository.GetAll()
                                     .OrderByDescending(m => m.ObservationTime)
                                     .Take(count)
                                     .ToList();
        }

        public Measure GetMeasure(int id)
        {
            return _measureRepository.GetById(id);
        }

        public void UpdateMeasure(Measure measure)
        {
            if (CheckRulesAndThrowException(measure, true))
                _measureRepository.Update(measure);
        }


        public Measure UpdateMeasure(int id, string value, string unite, DateTime observationTime)
        {

            var measure = _measureRepository.GetById(id);
            if (measure != null) 
            {
                measure.SetAndValidateMeasureValue(new MeasureValue(value, unite));
                measure.SetAndValidateObservationTime(observationTime);
                if (CheckRulesAndThrowException(measure, true))
                {
                    var isUpdaed = _measureRepository.Update(measure);
                    if (isUpdaed) 
                    {
                        return measure;
                    }
                    else
                    {
                        throw new InvalidOperationException("Measure to update not correct");
                    }
                }
                else 
                {
                    throw new InvalidOperationException("Measure to update not correct");
                }
                    

            }
            else 
            {
                throw new InvalidOperationException("Measure to update not correct");
            }

           

        }

        public void DeleteMesure(Measure measure)
        {
            if (CheckRulesAndThrowException(measure, true))
                _measureRepository.Delete(measure);
        }

        private bool CheckRulesAndThrowException(Measure measure, bool isThrow) 
        {
            
            var newMeasure = measure;

            if (newMeasure == null) 
            {
                throw new ArgumentNullException(nameof(Measure));
            }

            if (newMeasure.Indicator == null) 
            {
                if(isThrow)
                    throw new Exception("measure.Indicator is missing ");

                return false;

            }
                

            if (newMeasure.Source == null) 
            {
                if(isThrow)
                    throw new Exception("measure.Source is missing ");

                return false;
            }
                

            Indicator currentIndicator = null;
            Source currentSource = null;


            if (newMeasure.Source.Id >= 0)
                currentSource = _sourceRepository.GetById(newMeasure.Source.Id);

            if (newMeasure.Indicator.Id >= 0)
                currentIndicator = _indicatorRepository.GetById(newMeasure.Indicator.Id);

            if (currentSource == null)
            {
                if(isThrow)
                    throw new Exception("newMeasure.Source unknow ");

                return false;
            }

            if (currentIndicator == null)
            {
                if(isThrow)
                    throw new Exception("newMeasure.Indicator unknow ");

                return false;
            }

            return true;
        }

      

 
    }
}
