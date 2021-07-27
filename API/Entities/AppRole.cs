using System.Collections.Generic;

namespace API.Entities
{
    public class AppRole
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}