using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Contracts;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
using Newtonsoft.Json;

namespace MyProject.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public DataController(IRepositoryWrapper repositoryWrapper,ILoggerManager logger,IMapper mapper)
        {
            RepositoryWrapper = repositoryWrapper;
            _logger = logger;
            this._mapper = mapper;
        }

        public IRepositoryWrapper RepositoryWrapper { get; }

        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        // GET: api/<DataController>
        [HttpGet]
        public List<string> Get()
        {
            //Getting Data
            return new List<string>() { "value1", "value2" }; 
        }
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees([FromQuery] EmployeeParameters employeeParameters)
        {
            var employees = RepositoryWrapper.Employee.GetEmployees(employeeParameters);
            //Testing Changes
            var metadata = new
            {
                employees.TotalCount,
                employees.PageSize,
                employees.CurrentPage,
                employees.TotalPages,
                employees.HasNext,
                employees.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            var employeeResult = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            _logger.LogInfo($"Returned {employees.TotalCount} owners from database.");

            return Ok(employeeResult);
        }
    }
}
