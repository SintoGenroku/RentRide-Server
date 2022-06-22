using Microsoft.AspNetCore.Mvc;
using RentRide.Foundation.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RentRide.DomainModels;
using RentRide.WebApplication.Models.Requests.Cars;
using RentRide.WebApplication.Models.Responses.Cars;

namespace RentRide.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarModelService _carModelService;
        private readonly IMapper _mapper;

        public CarsController(ICarService carService, IMapper mapper, ICarModelService carModelService)
        {
            _carService = carService;
            _mapper = mapper;
            _carModelService = carModelService;
        }

        /// <summary>
        ///     Returns list of all cars
        /// </summary>
        /// <returns>Cars Collection</returns>
        [ProducesResponseType(typeof(IReadOnlyCollection<Car>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult> GetCars()
        {
            var cars = await _carService.GetCarsAsync();

            return Ok(cars);
        }
        
        /// <summary>
        ///     Allows get current car by it's ID
        /// </summary>
        /// <param name="id">unique GUID car identifier</param>
        /// <returns>Car</returns>
        [ProducesResponseType(typeof(CarResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id::guid}")]
        public async Task<ActionResult> GetCar(Guid id)
        {
            var car = await _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound("Invalid data");
            }
            var carResponseModel = _mapper.Map<CarResponseModel>(car);
            
            return Ok(carResponseModel);
        }

        /// <summary>
        ///     Returns created car
        /// </summary>
        /// <param name="carRequestModel">Request Model of car to creation</param>
        /// <returns>Car</returns>
        [ProducesResponseType(typeof(CarResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> CreateCar([FromBody] CarRequestModel carRequestModel)
        {
            try
            {
                var car = _mapper.Map<Car>(carRequestModel);
                var carModels = await _carModelService.GetCarModelsAsync();
                if (carModels.Any(cm => cm.Id == car.CarModel.Id))
                {
                    car.CarModel = null;
                    await _carService.CreateCarAsync(car);
                    var carResponseModel = _mapper.Map<CarResponseModel>(car);
                    return Ok(carResponseModel);
                }
                else
                {
                    await _carService.CreateCarAsync(car);
                    var carResponseModel = _mapper.Map<CarResponseModel>(car);
                
                    return Ok(carResponseModel);
                    
                }
            }

            catch
            {
                return BadRequest("Bad Request");
            }
           
        }
        
        /// <summary>
        ///     Update car with new data
        /// </summary>
        /// <param name="editCarRequestModel">Request Model of car to edit</param>
        /// <returns>Car</returns>
        [ProducesResponseType(typeof(CarResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:guid}")]
        public async Task<ActionResult> EditCar(EditCarRequestModel editCarRequestModel, Guid id)
        {
            if (editCarRequestModel.Id != id)
            {
                throw new BadHttpRequestException("Id doesn't match");
            }

            var car = await _carService.GetCarById(id);

            car.SerialNumber = editCarRequestModel.SerialNumber;
            car.CarModel.Engine = editCarRequestModel.CarModelEngine;
            car.CarModel.Color = editCarRequestModel.CarModelColor;
            car.CarModel.Price = editCarRequestModel.CarModelPrice;
            car.CarModel.RentCoefficient = editCarRequestModel.CarModelRentCoefficient;

            await _carService.UpdateCarAsync(car);
            var carResponseModel = _mapper.Map<CarResponseModel>(car);
            return Ok(carResponseModel);
        }

        /// <summary>
        ///     Returns updated car
        /// </summary>
        /// <param name="id">Unique GUID identifier of car to delete</param>
        /// <returns>Delete operation status</returns>
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
            var car = await _carService.GetCarById(id);
            if (car == null)
            {
                return BadRequest("Invalid data");
            }

            await _carService.DeleteCarAsync(car);
            
            return Ok();
        }
    }
}
