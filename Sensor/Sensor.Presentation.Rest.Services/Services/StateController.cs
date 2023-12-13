using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sensor.Domain.Model;
using Sensor.Domain.Services;
using Sensor.Presentation.Rest.Services.Dto.Measure;
using Sensor.Presentation.Rest.Services.Dto.Threshold;

namespace Sensor.Presentation.Rest.Services
{
    [ApiController]
    [Route("api/states")]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;
        public StateController(
            IStateService stateService,
            IMapper mapper)
        {
            _stateService = stateService ?? throw new ArgumentNullException(nameof(stateService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("source/{sourceId}/indicator/{indicatorId}")]
        public IActionResult Get(int sourceId, int indicatorId)
        {
            try
            {
                var state = _stateService.GetState(sourceId, indicatorId);
                return Ok(state);
            }
            catch
            {
                return BadRequest();
            }

        }

    }
}
