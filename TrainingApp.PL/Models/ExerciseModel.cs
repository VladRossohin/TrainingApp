using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingApp.Api.Models
{
    public class ExerciseModel
    {
        public long Id { get; set; }
        public long TrainingId { get; set; }
        public long SensorId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
