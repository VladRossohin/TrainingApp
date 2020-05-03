using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.BLL.DTO
{
    public class RoleDTO
    {
        public RoleDTO()
        {
            User = new HashSet<UserDTO>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserDTO> User { get; set; }
    }
}
