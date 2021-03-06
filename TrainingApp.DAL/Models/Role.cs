﻿using System;
using System.Collections.Generic;

namespace TrainingApp.DAL.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
