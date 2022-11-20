using Entities;
using Entities.Concrete;
using KUSYS_Demo.ClientBusiness;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers
{
    public class StudentController : Controller
    {
        UserClientBusiness userClientBusiness = new UserClientBusiness();
        StudentClientBusiness studentClientBusiness = new StudentClientBusiness();
        SessionClientBusiness sessionClientBusiness = new SessionClientBusiness();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StudentAdd(int sessionId)
        {
            StudentAddDTO studentAdd = new StudentAddDTO();
            var session = sessionClientBusiness.GetSessionInfo(sessionId);  
            studentAdd.UserId = session.UserId;
            studentAdd.UserName = session.UserName; 
            studentAdd.SessionId = sessionId;
            studentAdd.RoleId = session.RoleId;
            studentAdd.StartDate = session.StartDate;
            return View("StudentAdd",studentAdd);
        }
        public IActionResult SubmitStudent(StudentAddDTO student,int sessionId)
        {
            student.SessionId = sessionId;
            if (studentClientBusiness.AddStudent(student))
            {
                return RedirectToAction("StudentList","Login",student);
            }
            else
            {
                return View("StudentAdd");
            }
        }
        public IActionResult DeleteStudent(int sessionId, int studentId) 
        {
            var student = new StudentAddDTO() {
                SessionId = sessionId,
                StudentId = studentId,
            };  
            if (studentClientBusiness.DelStudent(student))
            {
                return RedirectToAction("StudentList", "Login", student);
            }
            return View();
        }
        public IActionResult EditStudent(StudentAddDTO stdent)
        {
            StudentAddDTO student = studentClientBusiness.GetStudent(stdent.StudentId);
            student.SessionId = stdent.SessionId;
            return View(student);
        }
        public IActionResult SaveStudentEdit(StudentAddDTO student)
        {
            if (studentClientBusiness.EditStudent(student))
            {
                return RedirectToAction("StudentList", "Login", student);
            }
            else
            {
                return View("EditStudent",student);
            }
        }
    }
}
