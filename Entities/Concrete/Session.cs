using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Session : IEntity
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
    }
}
