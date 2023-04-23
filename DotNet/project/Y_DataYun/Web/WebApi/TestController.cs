using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.WebApi
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5        
        [HttpGet]
        public string Get(string id)
        {
            return id;
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
        /// <summary>
        /// 请求JSON
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetJson()
        {
            return Json<dynamic>(new { code = 200, data = "请求成功！" });
        }
    }
}
