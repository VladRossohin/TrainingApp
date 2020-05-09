using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.BLL.DTO
{
    public class ExerciseDTO
    {
        public long Id { get; set; }
        public long TrainingId { get; set; }
        public long SensorId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
