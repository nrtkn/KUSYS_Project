using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Course : IEntity
    {
        public int CId { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
