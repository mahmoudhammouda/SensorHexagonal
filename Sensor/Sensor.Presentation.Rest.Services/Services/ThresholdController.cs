using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sensor.Domain.Model;
using Sensor.Domain.Services;
using Sensor.Presentation.Rest.Services.Dto.Measure;
using Sensor.Presentation.Rest.Services.Dto.Threshold;

namespace Sensor.Presentation.Rest.Services
{
    [ApiController]
    [Route("api/thresholds")]
    public class ThresholdController : ControllerBase
    {
        private readonly IThresholdService _thresholdService;
        private readonly IMapper _mapper;
        public ThresholdController(
            IThresholdService thresholdService,
            IMapper mapper)
        {
            _thresholdService = thresholdService ?? throw new ArgumentNullException(nameof(thresholdService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var threshold = _thresholdService.GetThreshold(id);
                var thresholdDto = _mapper.Map<ThresholdDto>(threshold);
                return Ok(thresholdDto);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Threshold> thresholdList;
            try
            {
                thresholdList=_thresholdService.GetAllThreshold();
                var thresholdLisDtoList = _mapper.Map<IEnumerable<ThresholdDto>>(thresholdList);
                return Ok(thresholdList);
            }
            catch
            {
                return BadRequest();
            }
           
            
        }


        [HttpPost]
        public IActionResult Create(CreateThresholdDto createThresholdDto)
        {
            try
            {
                var threshold = _mapper.Map<Threshold>(createThresholdDto);
                _thresholdService.AddThreshold(threshold);
                return Ok(threshold);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(UpdateThresholdDto updateThresholdDto)
        {
            try
            {
                var threshold = _mapper.Map<Threshold>(updateThresholdDto);
                _thresholdService.UpdateThreshold(threshold);
                var updatedThreshold = _mapper.Map<Threshold>(threshold);

                return Ok(updatedThreshold);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete(Threshold threshold)
        {
            try
            {
                // il faut verifier si le controller n'existe pas deja et c'est pour qu'il faut codes
                _thresholdService.DeleteThreshold(threshold);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
