using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class Kick
    {
        public long Id { get; set; }
        public long ExcerciseId { get; set; }
        public long SensorId { get; set; }
        public DateTime KickDateTime { get; set; }
        public decimal? KickPower { get; set; }
        public decimal? ReactionSpeed { get; set; }
        public int? KickAccuracy { get; set; }

        public virtual Excercise Excercise { get; set; }
        public virtual Sensor Sensor { get; set; }
    }
}
