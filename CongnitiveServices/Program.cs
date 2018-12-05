using System;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Vision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;

namespace CongnitiveServices
{
    class Program
    {
        static void Main(string[] args)
        {
            var subscriptionKey = "002d9cf2be714679abeedb67f0bf137a";
            var imageUrl = "https://conteudo.imguol.com.br/blogs/40/files/2017/03/Honda_WRV_2018_frentlat.jpg";

            ComputerVisionClient client = new ComputerVisionClient(
                        new ApiKeyServiceClientCredentials(subscriptionKey)
                );
            client.Endpoint = "https://brazilsouth.api.cognitive.microsoft.com/";

            var features = new List<VisualFeatureTypes>
            {
                VisualFeatureTypes.Faces,
                VisualFeatureTypes.Categories,
                VisualFeatureTypes.Tags,
                VisualFeatureTypes.Description
            };

            var result = client.AnalyzeImageAsync(imageUrl, features).Result;

            Console.WriteLine(JsonConvert.SerializeObject(result));
            Console.Read();


        }
    }
}
