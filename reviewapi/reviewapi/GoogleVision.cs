using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace reviewapi
{
    public static class GoogleVision
    {
        public static List<string> GetURL(string url)
        {
            var image = Image.FromUri(url);
            var client = ImageAnnotatorClient.Create();
            var response = client.DetectFaces(image);
            int count = 1;
            List<string> faceList = new List<string>();
            foreach (var faceAnnotation in response)
            {
                Console.WriteLine("Face {0}:", count++);
                Console.WriteLine("  Joy: {0}", faceAnnotation.JoyLikelihood);

            }
            return faceList;
        }  
    }
}
