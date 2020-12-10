using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UDP_Receiver_Broadcast;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiriLavMad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IOTController : ControllerBase
    {

        public static List<MSG> MsgList = new List<MSG>()
        {
            new MSG("Hej")
        };

        // GET: api/<IOTController>
        [HttpGet]
        [Route("List")]
        public IEnumerable<MSG> Get()
        {
            return MsgList;
        }

        // GET api/<IOTController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IOTController>
        [HttpPost]
        [Route("Post")]
        public void Post([FromBody] MSG value)
        {
            MsgList.Add(value);
        }

        // PUT api/<IOTController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IOTController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
