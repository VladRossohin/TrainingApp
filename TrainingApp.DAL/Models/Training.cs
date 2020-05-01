using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class Training
    {
        public Training()
        {
            Excercise = new HashSet<Excercise>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual User IdNavigation { get; set; }
        public virtual ICollection<Excercise> Excercise { get; set; }
    }
}
