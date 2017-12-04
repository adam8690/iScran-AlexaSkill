using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlexaApi.Controllers
{
    [Route("api/[controller]")]
    public class AlexaController : Controller
    {
        // GET api/alexa
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "there" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Hello";
        }

        [HttpPost, Route("demo")]
        public dynamic PluralSight()
        {
            return new
            {
                version = "1.0",
                sessionAttributes = new
                {

                },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "PlainText",
                        text = "Nay bad yer cell!"
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "Pluralsight",
                        content = "Nae bad yersel?"
                    },
                    shouldEndSession = true
                }
            };
        }
    }
}
