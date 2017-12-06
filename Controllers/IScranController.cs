using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace AlexaApi
{
    [Route("api/[controller]")]
    public class IScranController : Controller
    {
        private List<string> promotions = new List<String>()
        {
            "Promotion one Fash and chaps",
            "promotion two deep fried haggis"
        };

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

        [HttpPost]
        public dynamic Scran([FromBody] AlexaRequest alexaRequest)
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
            var output = new StringBuilder();
            switch (request.Intent.Name)
            {
                case "PromotionsIntent":
                    output.Append("Here are our pure tasty and cheap promos babe");
                    foreach (var promotion in promotions)
                    {
                        output.Append("\n");
                        output.Append(promotion);
                    }
                    output.Append("\nIf you want something, hollaaaaaa");
                    break;
                case "StopIntent":
                    output.Append("STOP RIGHT NOW");
                    break;
            }
            return new AlexaResponse(output.ToString());
        }

        private AlexaResponse LaunchRequestHandler(AlexaRequest.RequestAttributes request)
        {
            return new AlexaResponse("Hello would you like to hear about our promotions");
        }
    }
}
