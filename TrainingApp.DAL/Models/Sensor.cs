using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class Sensor
    {
        public Sensor()
        {
            Exercises = new HashSet<Exercise>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
