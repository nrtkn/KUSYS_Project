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
        public bool DelStudent(StudentAddDTO student)
        {
            var std = studentManager.GetStudent(student.StudentId).Data;
             
            return studentManager.Delete(std.StudentId).Success;
        }
        public bool EditStudent(StudentAddDTO stdent)
        {
            Student student = new Student()
            {
                StudentId = stdent.StudentId,
                BirthDate = stdent.BirthDate,
                FirstName = stdent.FirstName,
                LastName = stdent.LastName 
            };
            return studentManager.Update(student).Success;
        }
        public StudentAddDTO GetStudent(int studentId)
        {
            var std = studentManager.GetStudent(studentId).Data;
            StudentAddDTO student = new StudentAddDTO()
            {
                StudentId = std.StudentId,
                BirthDate = std.BirthDate,  
                FirstName = std.FirstName,
                LastName = std.LastName,
            };
            return student ;
        }
    }
}
