using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace KUSYS_Demo.ClientBusiness
{
    public class SessionClientBusiness
    {
        SessionManager sessionManager = new SessionManager(new EFSessionDAL());
       
        public void AddSession(Session session)
        {
            var sessionToAdd = new Session();
            sessionToAdd.UserId = session.UserId;
            sessionToAdd.RoleId = session.RoleId;
            sessionToAdd.UserName = session.UserName;
            sessionToAdd.StartDate = DateTime.Now;
            sessionManager.Add(sessionToAdd);
        }
        public Session GetSessionInfo(int sessionId)
        {
            var session = sessionManager.GetSession(sessionId).Data;
            return session;
        }
        public Session GetSession()
        {
            var session = sessionManager.GetSessionByDate().Data;
            return session;
        }
        public bool EndSession(Session session)
        {
            var sessionToEnd = session;
            sessionToEnd.SessionId = session.SessionId;
            sessionToEnd.UserName = session.UserName;
            sessionToEnd.UserId = session.UserId;
            sessionToEnd.RoleId = session.RoleId;
            sessionToEnd.StartDate = session.StartDate;
            sessionToEnd.EndDate = DateTime.Now;
            var result = sessionManager.EndSession(sessionToEnd).Success;
            return result;
        }
    }
}
