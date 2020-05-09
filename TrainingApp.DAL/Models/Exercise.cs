using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            Kicks = new HashSet<Kick>();
        }

        public long Id { get; set; }
        public long TrainingId { get; set; }
        public long SensorId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public virtual Sensor Sensor { get; set; }
        public virtual Training Training { get; set; }
        public virtual ICollection<Kick> Kicks { get; set; }
    }
}
