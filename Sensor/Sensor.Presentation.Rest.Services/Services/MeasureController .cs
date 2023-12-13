using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sensor.CrossCutting;
using Sensor.Domain.Model;
using Sensor.Domain.Services;
using Sensor.Presentation.Rest.Services.Dto.Measure;
using System.ComponentModel;
using DateTimeConverter = Sensor.CrossCutting.DateTimeConverter;

namespace Sensor.Presentation.Rest.Services
{


    [ApiController]
    [Route("api/measures")]
    public class MeasureController : ControllerBase
    {
        private readonly IMeasureService _measureService;
        private readonly IMapper _mapper;
        public MeasureController(
             IMeasureService measureService,
             IMapper mapper            
            )
        {
            _measureService = measureService ?? throw new ArgumentNullException(nameof(measureService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var measure =_measureService.GetMeasure(id);
                var meaureDto =  _mapper.Map<MeasureDto>(measure);
                return Ok(meaureDto);
            } 
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("init")]
        public IActionResult Inti()
        {

            Indicator indic = new Indicator(
                0,
                "Temperature",
                "Mesure le degre de chaleur ou de froid. Indispensable pour evaluer les conditions climatiques et environnementales",
                "Chaleur",
                Domain.Enum.ValueTypeEnum.Numeric
                );
            Source s = new Source(
                0,
                "Pioneer2",
                Domain.Enum.SourceTypeEnum.Sensor
                );

            Measure measure = new Measure(
                0,
                indic,
                s,
                new MeasureValue("25", "Celsius"),
                DateTime.UtcNow
                ) ;

            _measureService.AddMeasure(measure);


            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int? historyCount)
        {
            try
            {
                IEnumerable<Measure> measureList;

                if (historyCount.HasValue && historyCount > 0)
                {
                    measureList = _measureService.GetLatestMeasures(historyCount.Value);
                }
                else
                {
                    measureList = _measureService.GetAllMeasure();
                }
                var measureDtoList = _mapper.Map<IEnumerable<MeasureDto>>(measureList);
                return Ok(measureDtoList);
            }
            catch
            {
                return BadRequest();
            }

        }


       

        [HttpPost]
        public IActionResult Create(CreateMeasureDto createMeasureDto)
        {
            try
            {
                var measure = _measureService.AddMeasure(
                    createMeasureDto.IndicatorId,
                    createMeasureDto.SourceId,
                    createMeasureDto.Valeur,
                    createMeasureDto.Unite,
                    DateTimeConverter.ConvertToDateTimeUtc(createMeasureDto.ObservationTime)
                    )
                    ;

                var mesureDto = _mapper.Map<Measure>(measure);

                return Ok(mesureDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(UpdateMeasureDto updateMeasure)
        {
            try
            {
                var measure =_measureService.UpdateMeasure(
                    updateMeasure.Id,
                    updateMeasure.Value,
                    updateMeasure.Unity,
                    DateTimeConverter.ConvertToDateTimeUtc(updateMeasure.ObservationTime)
                    );

                var mesureDto = _mapper.Map<MeasureDto>(measure);

                return Ok(mesureDto);
            }
            catch
            {
                return BadRequest();
            }

        }


        [HttpDelete]
        public IActionResult Delete(Measure measure)
        {
            try
            {
                _measureService.DeleteMesure(measure);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
  }
