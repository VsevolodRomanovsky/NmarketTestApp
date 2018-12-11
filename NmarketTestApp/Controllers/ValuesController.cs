using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NmarketTestApp.Contracts;
using AutoMapper;
using NmarketTestApp.ViewModel;
using NmarketTestApp.Models;
using System.Linq;
using System.Threading.Tasks;
using NmarketTestApp.Utils.Paging;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NmarketTestApp.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {

    private readonly IObjectService _service;
    private readonly IMapper _mapper;
    public ValuesController(IObjectService service, IMapper mapper)
    {
      _service = service;
      _mapper = mapper;
    }

    // GET: api/<controller>
    [HttpGet]
    public async Task<PagedResult<Flat>> Get([FromQuery] int pageNumber = 1, int pageSize = 20,
      string sort = "TotalArea", string order = "asc")
    {
      var result = await _service.GetAllFlats(sort, order, pageNumber, pageSize);
      return result;
    }

    [HttpPut]
    public void Put([FromBody]Flat value)
    {
      _service.UpdateFlat(value);
    }

    [HttpDelete]
    public async Task<PagedResult<Flat>> Delete( [FromQuery]  int flatId, int pageNumber = 1,
                                                 int pageSize = 20,
                                                 string sort = "TotalArea", string order = "asc")
    {
      _service.DeleteFlat(flatId);
      var result = await _service.GetAllFlats(sort, order, pageNumber, pageSize);
      return result;
    }
  }
}
