using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Training Training { get; set; }
    }
}
