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

            string credential_path = @"C:\Users\janel\Desktop\practice\Test API\My First Project-6c75c1ef5dee.json";
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);
            
            var client = ImageAnnotatorClient.Create();

            //List<List<string>> joyLikelihood = new List<List<string>>();
            for (int i = 0; i < parsedList.Count; i++)
            {
                var tempresult = GoogleVision.GetURL(parsedList[i].avatarUrl);
                parsedList[i].joyLikelihood.Add(tempresult);
            }
       
            //foreach (var picture in pictures)
            //{
            //    var image = Image.FromUri(picture);
            //    //not allowed to access picture on my behalf, says to download the photo or add
            //    var response = client.DetectFaces(image);
            //    foreach (var annotation in response)
            //    {
            //        Console.WriteLine($"Picture: {picture}");
            //        Console.WriteLine($" Surprise: {annotation.JoyLikelihood}");
            //    }
            //}

            

            
        }
    }
}
