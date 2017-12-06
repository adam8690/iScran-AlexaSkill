using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexaApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace AlexaApi
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

        [HttpPost, Route("api/alexa/iscran")]
        public dynamic Scran(AlexaRequest alexaRequest)
        {
            var request = alexaRequest.Request;
            AlexaResponse response = null;

            switch (request.Type)
            {
                case "LaunchRequest":
                    response = LaunchRequestHandler(request);
                    break;
                case "IntentRequest":
                    response = IntentRequestHandler(request);
                    break;
                case "SessionEndedRequest":
                    response = SessionEndedRequestHandler(request);
                    break;
            }

            return response;
        }

        private AlexaResponse SessionEndedRequestHandler(AlexaRequest.RequestAttributes request)
        {
            return new AlexaResponse("Bye bye");
        }

        private AlexaResponse IntentRequestHandler(AlexaRequest.RequestAttributes request)
        {
            return new AlexaResponse("Intent handler");
        }

        private AlexaResponse LaunchRequestHandler(AlexaRequest.RequestAttributes request)
        {
            return new AlexaResponse("Hello would you like to hear about our promotions");
        }
    }
}
