using Google.Cloud.Vision.V1;
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

            //working on accessing the credentials that were created in google cloud shell

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
