using CrudApplicationWithMySQL.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplicationWithMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudApplicationController : ControllerBase
    {
        public readonly ICRudApplicationsSL _cRudApplicationsSL;
        public CrudApplicationController(ICRudApplicationsSL cRudApplicationsSL)
        {
            _cRudApplicationsSL = cRudApplicationsSL;
        }
    }
}
