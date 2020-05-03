using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.BLL.DTO
{
    public class ExcerciseDTO
    {
        public ExcerciseDTO()
        {
            Kick = new HashSet<KickDTO>();
        }

        public long Id { get; set; }
        public long TrainingId { get; set; }
        public long SensorId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public virtual SensorDTO Sensor { get; set; }
        public virtual TrainingDTO Training { get; set; }
        public virtual ICollection<KickDTO> Kick { get; set; }
    }
}
