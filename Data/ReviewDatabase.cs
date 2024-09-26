using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildYourBowl.Data
{
    public class ReviewDatabase
    {
        private static List<Review> _reviews;

        static ReviewDatabase()
        {
            if (File.Exists("reviews.json"))
            {
                string json = File.ReadAllText("reviews.json");

                _reviews = JsonConvert.DeserializeObject<List<Review>>(json);
            }

            if (_reviews == null) _reviews = new();
        }

        public static IEnumerable<Review> Reviews => _reviews;

        public static void AddReview(Review r)
        {
            if (r != null && r.Text != "")
            {
                _reviews.Add(r);

                File.WriteAllText("reviews.json", JsonConvert.SerializeObject(Reviews));
            }
        }
    }
}
