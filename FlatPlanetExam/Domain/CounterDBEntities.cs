using System.Data.Entity;
using FlatPlanetExam.Domain.Entity;

namespace FlatPlanetExam.Domain
{
    public class CounterDbEntities : DbContext
    {
        public CounterDbEntities() 
            : base ("name=CounterEntities")
        {

        }

        public virtual DbSet<CounterEntity> Counters { get; set; }
    }
}