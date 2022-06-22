using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentRide.DomainModels;
using RentRide.Foundation.Services.Abstracts;
using RentRide.WebApplication.Models.Requests.Contracts;
using RentRide.WebApplication.Models.Responses.Contracts;

namespace RentRide.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : Controller
    {
        private readonly IContractService _contractService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        
        public ContractsController(IContractService contractService, IUserService userService, IMapper mapper)
        {
            _contractService = contractService;
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        ///     Returns list of all contracts
        /// </summary>
        /// <returns>Contracts Collection</returns>
        [ProducesResponseType(typeof(IReadOnlyCollection<Contract>),StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult> GetContracts()
        {
            var contracts = await _contractService.GetContractsAsync();

            return Ok(contracts);
        }
        
        /// <summary>
        ///     Allows get contract with current ID
        /// </summary>
        /// <param name="id">Unique GUID contract identifier</param>
        /// <returns>Contract</returns>
        [ProducesResponseType(typeof(ContractResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetContract(Guid id)
        {
            var contract = await _contractService.GetContractById(id);
            
            if (contract == null)
            {
                return NotFound("Invalid data");
            }
            
            var contractResponseModel = _mapper.Map<ContractResponseModel>(contract);

            return Ok(contractResponseModel);
        }

        /*[HttpPost]
        public async Task<ActionResult> AddContract([FromBody] ContractRequestModel contractRequestModel)
        {
            var contract = _mapper.Map<Contract>(contractRequestModel);
            
            var clientId = Guid.Parse(HttpContext.User.GetSubjectId());
            var client = await _userService.GetUserByIdAsync(clientId);
            
            contract.Client = client;
            
            await 
            return Ok();
        }*/
    }
}