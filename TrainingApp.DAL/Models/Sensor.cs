using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class Sensor
    {
        public Sensor()
        {
            Excercise = new HashSet<Excercise>();
            Kick = new HashSet<Kick>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Excercise> Excercise { get; set; }
        public virtual ICollection<Kick> Kick { get; set; }
    }
}
