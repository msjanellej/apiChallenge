using System;
using System.Collections.Generic;
using System.Text;

namespace reviewapi
{
     public class Review
    {
        public string reviewerName;
        public string avatarUrl;
        public string rating;
        public string reviewContent;
        public List<List<string>> joyLikelihood;


        public Review()
        {
            joyLikelihood = new List<List<string>>();

        }
    }
}
