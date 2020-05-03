using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.BLL.DTO
{
    public class SensorDTO
    {
        public SensorDTO()
        {
            Excercise = new HashSet<ExcerciseDTO>();
            Kick = new HashSet<KickDTO>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ExcerciseDTO> Excercise { get; set; }
        public virtual ICollection<KickDTO> Kick { get; set; }
    }
}
