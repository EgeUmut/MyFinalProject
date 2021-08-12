using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.WiewModel.Entities.WiewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubProductController: ControllerBase
    {
        
        ISubProductService _subproductservice;
        IMapper _mapper;
        public SubProductController(ISubProductService subproductService,IMapper mapper)
        {
            _subproductservice = subproductService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            // bağımlılık zinciri   

            var result = _subproductservice.GetAll();
            var viewModel = _mapper.Map<IEnumerable<SubProductViewModel>>(result.Data);
            if (result.Success)
            {
                return Ok(viewModel);
            }
            else
            {
                return BadRequest(viewModel);
            }

        }

        [HttpPost("add")]
        public IActionResult Add(SubProduct subProduct)
        {

            var result = _subproductservice.Add(subProduct);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getSubProductsById")]
        public IActionResult GetById(int Id)
        {
            var result = _subproductservice.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
