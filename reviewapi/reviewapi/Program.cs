using System;

namespace reviewapi
{
    class Program
    {
        static void Main(string[] args)
        {
            var yelpReviewResults = Api.GetYelpApiData();
            var parsedList = Api.ParseInfo(yelpReviewResults);
        }
    }
}
