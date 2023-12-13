using Microsoft.AspNetCore.Mvc;
using Sensor.Domain.Model;
using Sensor.Domain.Services;

namespace Sensor.Presentation.Rest.Services
{


    [ApiController]
    [Route("api/indicators")]
    public class IndicatorController : ControllerBase
    {
        private readonly IIndicatorService _indicatorService;
        public IndicatorController(IIndicatorService indicatorService)
        {
            _indicatorService = indicatorService ?? throw new ArgumentNullException(nameof(indicatorService));

        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_indicatorService.GetIndicator(id));

        }

        [HttpGet]
        public IEnumerable<string> GetAll()
        {
          return  _indicatorService.GetAllIndicator().Select(item => item.Name);
            
        }


        [HttpPut]
        public IActionResult Update(Indicator indicator)
        {
            try
            {
                _indicatorService.UpdateIndicator(indicator);
                return Ok();
            }
            catch 
            {
                return BadRequest();
            }
        }



        [HttpPost]
        public IActionResult Create(Indicator indicator)
        {
            try
            {
                // il faut verifier si le controller n'existe pas deja et c'est pour qu'il faut codes
                _indicatorService.AddIndicator(indicator);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }



        [HttpDelete]
        public IActionResult Delete(Indicator indicator)
        {
            try
            {
                // il faut verifier si le controller n'existe pas deja et c'est pour qu'il faut codes
                _indicatorService.DeleteIndicator(indicator);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
