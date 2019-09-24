using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMyDataBase _myDataBase;

        public ValuesController(IMyDataBase myDataBase)
        {
            _myDataBase = myDataBase;
        }
        
        // POST api/values
        [HttpPost]
        public string Post([FromBody] int value)
        {
            if (value <= 0)
                return "Error! Value must be positive(";
            
            if (_myDataBase.Contains(value))
            {
                return "Error! This value already incremented(";
            }

            if (_myDataBase.ContainsLittle(value))
            {
                return "Error! This value can not be incremented(";
            }
            
            _myDataBase.AddValue(value);
            value++;

            return value.ToString();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_myDataBase.GetValues());
        }
    }
}