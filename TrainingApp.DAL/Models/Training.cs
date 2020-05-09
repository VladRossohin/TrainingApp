using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class Training
    {
        public Training()
        {
            Exercises = new HashSet<Exercise>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
