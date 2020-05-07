using System;

namespace TrainingApp.BLL.DTO
{
    public class KickDTO
    {
        public long Id { get; set; }
        public long ExcerciseId { get; set; }
        public long SensorId { get; set; }
        public DateTime KickDateTime { get; set; }
        public double? KickPower { get; set; }
        public double? ReactionSpeed { get; set; }
        public int? KickAccuracy { get; set; }
    }
}