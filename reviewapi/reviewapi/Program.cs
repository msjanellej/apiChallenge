using Google.Apis.Auth.OAuth2;
using Google.Cloud.Vision.V1;
using Grpc.Auth;
using System;
using System.Collections.Generic;

namespace reviewapi
{
    class Program
    {
        static void Main(string[] args)
        {
            var yelpReviewResults = Api.GetYelpApiData();
            var parsedList = Api.ParseInfo(yelpReviewResults);
            var result = Api.ConverttoJson(parsedList);

            // need to export json file from cloud terminal to app, so that there is a file path to my credentials.

            var credential = GoogleCredential.FromFile(@"<CRED_JSON_FILEPATH>").CreateScoped(ImageAnnotatorClient.DefaultScopes);
            var channel = new Grpc.Core.Channel(ImageAnnotatorClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials());
            

            var client = ImageAnnotatorClient.Create();
            List<string> pictures = new List<string>();
            for (int i = 0; i < parsedList.Count; i++)
            {
                pictures.Add(parsedList[1].avatarUrl);
            }
       
            foreach (var picture in pictures)
            {
                var image = Image.FromUri("gs://cloud-vision-codelab/" + picture);
                var response = client.DetectFaces(image);
                foreach (var annotation in response)
                {
                    Console.WriteLine($"Picture: {picture}");
                    Console.WriteLine($" Surprise: {annotation.JoyLikelihood}");
                }
            }
        }
    }
}
