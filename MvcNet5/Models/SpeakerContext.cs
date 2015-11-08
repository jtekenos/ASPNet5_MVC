using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcNet5.Models
{
    public class SpeakerContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }
    }
}
