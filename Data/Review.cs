using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BuildYourBowl.Data
{
    public class Review
    {
        public string? Text;

        public DateTime Time;

        public Review(string? text, DateTime time)
        {
            Text = text;
            Time = time;
        }
    }
}
