using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class Sensor
    {
        public Sensor()
        {
            Exercis = new HashSet<Exercise>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Exercise> Exercis { get; set; }
    }
}
