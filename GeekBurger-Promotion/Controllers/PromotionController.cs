using System;
using BLL.Promotion;
using Contracts.Models;
using Contracts.Models.Request;
using Contracts.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace GeekBurger_Promotion.Controllers
{
    [ApiController]
    [Route("promotion")]
    public class PromotionController : ControllerBase
    {
        private readonly ILogger<PromotionController> _logger;
        private readonly IPromotionBLL _bll;

        public PromotionController(ILogger<PromotionController> logger, IPromotionBLL bll)
        {
            _logger = logger;
            _bll = bll;
        }

        [HttpGet("{storeName}")]
        [ProducesResponseType(typeof(PromotionResponse), StatusCodes.Status200OK)]
        public IActionResult Get([FromRoute] string storeName)
        {
            var response = _bll.GetByStoreName(storeName);

            if (response == null)
                return NoContent();

            return Ok(response);
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<PromotionResponse>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var response = _bll.GetAll();

            if (!response.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] PromotionRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _bll.Create(model);

            return StatusCode(201);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Put([FromBody] PromotionRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _bll.Update(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete([FromRoute] int id)
        {
            _bll.Delete(id);

            return NoContent();
        }
    }
}

