using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcNet5.Models
{
    public static class DummyData
    {
        public static void Initialize(SpeakerContext context)
        {
            if (!context.Speakers.Any())
            {
                context.Speakers.Add(new Speaker
                {
                    FirstName = "Richard",
                    LastName = "Stone"
                });
                context.Speakers.Add(new Speaker
                {
                    FirstName = "Anthony",
                    LastName = "Lee"
                });
                context.Speakers.Add(new Speaker
                {
                    FirstName = "Tommy",
                    LastName = "Douglas"
                });
                context.Speakers.Add(new Speaker
                {
                    FirstName = "Charles",
                    LastName = "Brown"
                });
                context.Speakers.Add(new Speaker
                {
                    FirstName = "Peter",
                    LastName = "Mason"
                });

                context.SaveChanges();
            }
        }
    }
}
