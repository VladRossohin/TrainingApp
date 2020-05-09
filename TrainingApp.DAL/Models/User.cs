using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Trainings = new HashSet<Training>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
    }
}
