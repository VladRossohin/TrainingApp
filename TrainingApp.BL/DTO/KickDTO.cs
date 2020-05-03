using System;

namespace TrainingApp.BLL.DTO
{
    public class KickDTO
    {
        public long Id { get; set; }
        public long ExcerciseId { get; set; }
        public long SensorId { get; set; }
        public DateTime KickDateTime { get; set; }
        public decimal? KickPower { get; set; }
        public decimal? ReactionSpeed { get; set; }
        public int? KickAccuracy { get; set; }

        public virtual ExcerciseDTO Excercise { get; set; }
        public virtual SensorDTO Sensor { get; set; }
    }
}