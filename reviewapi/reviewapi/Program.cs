using Google.Cloud.Vision.V1;
using System;

namespace reviewapi
{
    class Program
    {
        static void Main(string[] args)
        {
            var yelpReviewResults = Api.GetYelpApiData();
            var parsedList = Api.ParseInfo(yelpReviewResults);
            var result = Api.ConverttoJson(parsedList);

            var client = ImageAnnotatorClient.Create();
            string[] pictures = { };

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
