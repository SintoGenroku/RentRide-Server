using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentRide.DomainModels;
using RentRide.Foundation.Services.Abstracts;
using RentRide.WebApplication.Models.Requests.Salons;
using RentRide.WebApplication.Models.Responses.Salons;

namespace RentRide.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonsController : Controller
    {
        private readonly ISalonService _salonService;
        private readonly IMapper _mapper;
        
        public SalonsController(ISalonService salonService, IMapper mapper)
        {
            _salonService = salonService;
            _mapper = mapper;
        }

        /// <summary>
        ///     Allows you get all salons
        /// </summary>
        // <returns>Salons collection</returns>
        [ProducesResponseType(typeof(IReadOnlyCollection<Salon>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult> GetSalons()
        {
            var salons = await _salonService.GetSalonsAsync();
            return Ok(salons);
        }

        /// <summary>
        ///     Allows get current salon by it's ID
        /// </summary>
        /// <param name="id">unique GUID salon identifier</param>
        /// <returns>Salon</returns>
        [ProducesResponseType(typeof(SalonResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id::guid}")]
        public async Task<ActionResult> GetSalon(Guid id)
        {
            var salon = await _salonService.GetSalonById(id);
            
            if (salon == null)
            {
                return BadRequest("Salon with such ID doesn't exist");
            }
            var salonResponseModel = _mapper.Map<SalonResponseModel>(salon);
            
            return Ok(salonResponseModel);
        }
        
        
        /// <summary>
        ///     Update salon with new data
        /// </summary>
        /// <param name="salonRequestModel">Salon model that you want to update with new data</param>
        /// <param name="id">unique GUID salon identifier of updating salon</param>
        /// <returns>Updated salon</returns>
        [ProducesResponseType(typeof(SalonResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPatch("{id:guid}")]
        public async Task<ActionResult> EditSalon(SalonRequestModel salonRequestModel, Guid id)
        {
            if (salonRequestModel.Id != id)
            {
                throw new BadHttpRequestException("Id doesn't match");
            }
            var salon = _mapper.Map<Salon>(salonRequestModel);
            
            await _salonService.UpdateSalonAsync(salon);

            var salonResponseModel = _mapper.Map<SalonResponseModel>(salon);
            
            return Ok(salonResponseModel);
        }

    }
}