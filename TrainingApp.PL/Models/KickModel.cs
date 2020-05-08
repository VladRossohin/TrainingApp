﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingApp.Api.Models
{
    public class KickModel
    {
        public long Id { get; set; }
        public long ExcerciseId { get; set; }
        public long SensorId { get; set; }
        public DateTime KickDateTime { get; set; }
        public decimal? KickPower { get; set; }
        public decimal? ReactionSpeed { get; set; }
        public int? KickAccuracy { get; set; }
    }
}