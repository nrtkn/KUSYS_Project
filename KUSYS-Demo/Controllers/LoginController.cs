using Business.Concrete;
using Entities;
using Entities.Concrete;
using KUSYS_Demo.ClientBusiness;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers
{
    public class LoginController : Controller
    {
        UserClientBusiness userClientBusiness = new UserClientBusiness();
        StudentClientBusiness studentClientBusiness = new StudentClientBusiness();
        SessionClientBusiness sessionClientBusiness = new SessionClientBusiness();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StudentList(int sessionId) 
        {
            if (sessionId != 0 && sessionId != null)
            {
                var session = sessionClientBusiness.GetSessionInfo(sessionId);
                StudentListModelDTO modelDTO= new StudentListModelDTO();
                modelDTO.SessionId = sessionId;
                modelDTO.UserName = session.UserName;
                modelDTO.UserId = session.UserId;
                modelDTO.RoleId = session.RoleId;
                modelDTO.StudentList = studentClientBusiness.ListAllStudents();
                return View("StudentList",modelDTO);
            }
            else
            {
                return View("Index");
            }
        }
        public IActionResult MainPage(User user)
        {
            Session sess = new Session();
            var usr = userClientBusiness.ControlLogin(user);
            if (usr != null)
            {
                sess.UserName = usr.UserName;
                sess.UserId = usr.UserId;
                sess.RoleId = usr.RoleId;
                sess.StartDate = DateTime.Now;
                sessionClientBusiness.AddSession(sess);
                sess.SessionId = sessionClientBusiness.GetSession().SessionId;
                return View("MainPage",sess);
            }
            else
            {
                return View("Index");
            }
            
        }
        public IActionResult MainPg(int SessionId)
        {
            var session = sessionClientBusiness.GetSessionInfo(SessionId);
            return View("MainPage",session);
        }

        public IActionResult Logout(int sessionId)
        {
            var session = sessionClientBusiness.GetSessionInfo(sessionId);
            var result = sessionClientBusiness.EndSession(session);
            if (result)
            {
                return View("Index");
            }
            else
            {
                return View("MainPage", session.SessionId);
            }
            
        }
    }
}
