using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class Kick
    {
        public long Id { get; set; }
        public long ExerciseId { get; set; }
        public DateTime KickDateTime { get; set; }
        public float? KickPower { get; set; }
        public double? KickAccuracy { get; set; }
        public float ReactionSpeed { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
