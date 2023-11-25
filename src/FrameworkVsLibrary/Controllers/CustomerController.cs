using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrameworkVsLibrary.Constants;
using FrameworkVsLibrary.Models;
using FrameworkVsLibrary.ViewModel;

namespace FrameworkVsLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public ActionResult<List<CustomerDetail>> GetDetail()
        {
            var model = new List<Customer>();
            model.Add(new Customer()
            {
                Id = 1,
                Name = "Haris",
                CusomterType = Enums.CustomerTypes.Wholesale,
                Address = new Address() { AddressLine1 = "1 AddressLine1", AddressLine2 = "1 AddressLine2", City = "1 City", State = "1 State" }
            });
            model.Add(new Customer()
            {
                Id = 2,
                Name = "Jayadev",
                CusomterType = Enums.CustomerTypes.Retail,
                Address = new Address() { AddressLine1 = "2 AddressLine1", AddressLine2 = "2 AddressLine2", City = "2 City", State = "2 State" }
            });

            var response = _mapper.Map<List<CustomerDetail>>(model);

            return Ok(response);
        }
    }
}
