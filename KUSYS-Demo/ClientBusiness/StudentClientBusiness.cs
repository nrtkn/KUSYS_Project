using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;

namespace KUSYS_Demo.ClientBusiness
{
    public class StudentClientBusiness
    {
        StudentManager studentManager = new StudentManager(new EFStudentDAL());
        public List<Student> ListAllStudents()
        {
            return studentManager.GetAll().Data;
        }
        public bool AddStudent(StudentAddDTO student)
        {
            var std = new Student();
            std.FirstName = student.FirstName;
            std.LastName = student.LastName;
            std.BirthDate = student.BirthDate;
            return studentManager.Add(std).Success;
        }
    }
}
