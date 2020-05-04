using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.BLL.DTO
{
    public class TrainingDTO
    {
        public TrainingDTO()
        {
            Excercise = new HashSet<ExcerciseDTO>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
