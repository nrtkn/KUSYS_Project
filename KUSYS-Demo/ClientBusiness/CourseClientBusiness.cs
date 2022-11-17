using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace KUSYS_Demo.ClientBusiness
{
    public class CourseClientBusiness
    {
        CourseManager courseManager = new CourseManager(new EFCourseDAL());

        public List<Course> GetCourseList()
        {
            return courseManager.GetAll().Data;
        }
    }
}
