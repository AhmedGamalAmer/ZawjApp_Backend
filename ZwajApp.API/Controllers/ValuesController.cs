using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ZwajApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Convention Name
    public class ValuesController : ControllerBase
    {
        // Kestrel بيعمل تنصت على ports معينه ويعرف ايه ال Responce اللى جاى ,df]hx da,ti
        // وبعدين يسلمه لل APP - وال APP يسلمه الى ال MVC - وبعدين الى ال Controller

      
        //port 5000 المتعارف عليه فى ال MVC
        //Root = Base url / api / ControllerName
        // http://localhost:5000/api/values
        // هينفذ ال Get() لانها ليس لها parameter
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    //throw new Exception("Test Exception");
        //    return new string[] { "Ahmed", "Mohammed" };
        //}



        //// http://localhost:5000/api/values/5
        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return $"value {id}";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}







        //------------------------------------------------
        //https://localhost:49934/api/

        //10-02-08
        //الزم private على مستوى ال Class
        private readonly DataContext _context;

        //اى داتا موجوده فى DataContext.cs 
        //عايز استخدم ال DependencyInjection داخل ال Constructor
        //لو استخدمت ال Controller فى اى مكان فى المشروع خلاص هو بينفد ال ال Constructor
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        //// https://localhost:49934/api/values
        //[HttpGet]
        //public IActionResult GetValues()
        //{
        //    var values = _context.Values.ToList();

        //    //return Ok HTTP Response 200 = تم التنفيد بنجاح
        //    return Ok(values);
        //}


        ////id = root paramter = int id
        //[HttpGet("{id}")]
        //public IActionResult GetValue(int id)
        //{
        //    //EF Methods شبيه بال ال Linq
        //    var value = _context.Values.FirstOrDefault(x => x.id == id);
        //    return Ok(value);
        //}

        ////------------------------

        //11-02-09
        //Asynchronous بيخلى ال app سريع جدا جدا
        //async = Asynchronous
        //Task عشان يحطها فى Task
        //await يسلم ال method الى ال Delegate
        //ToListAsync يحولها الى Async
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            //يسلم ال method الى ال Delegate
            var values = await _context.Values.ToListAsync();

            //return Ok HTTP Response 200 = تم التنفيد بنجاح
            return Ok(values);
        }


        //id = root paramter = int id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            //EF Methods شبيه بال ال Linq
            var value = await _context.Values.FirstOrDefaultAsync(x => x.id == id);
            return Ok(value);
        }
        //----------------------------------
    }
}
