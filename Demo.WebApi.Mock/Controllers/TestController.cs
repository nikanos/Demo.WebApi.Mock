using CacheCow.Server.WebApi;
using Demo.WebApi.Mock.Models;
using System.Web.Http;

namespace Demo.WebApi.Mock.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("")]
        [HttpGet]
        [HttpCache(DefaultExpirySeconds = 0)]
        public IHttpActionResult Test()
        {
            var ret = new ReturnData
            {
                Result = true
            };
            return Ok(ret);
        }

        [Route("delay")]
        [HttpGet]
        [HttpCache(DefaultExpirySeconds = 0)]
        public IHttpActionResult TestDelay(int delayInMilliseconds)
        {
            if (delayInMilliseconds > 0)
                System.Threading.Thread.Sleep(delayInMilliseconds);

            var ret = new ReturnData
            {
                Result = true
            };
            return Ok(ret);
        }

        [Route("size")]
        [HttpGet]
        [HttpCache(DefaultExpirySeconds = 0)]
        public IHttpActionResult TestSize(int sizeInBytes)
        {
            var ret = new ReturnData
            {
                Result = true
            };
            if (sizeInBytes > 0)
            {
                ret.Data = new byte[sizeInBytes];
                for (int i = 0; i < sizeInBytes; i++)
                {
                    ret.Data[i] = (byte)i;
                }
            }
            return Ok(ret);
        }
    }
}