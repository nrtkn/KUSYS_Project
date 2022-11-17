using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SessionManager : ISessionService
    {
        ISessionDAL _sessionDAL;
        public SessionManager(ISessionDAL sessionDAL)
        {
            _sessionDAL = sessionDAL;
        }

        public IResult Add(Session session)
        {
            _sessionDAL.Add(session);
            return new SuccessResult();

        }

        public IResult EndSession(Session session)
        {
            _sessionDAL.Update(session);
            return new SuccessResult();
        }

        public IDataResult<Session> GetSession(int sessionId)
        {
            var session = _sessionDAL.Get(x=>x.SessionId == sessionId);
            return new SuccessDataResult<Session>(session);
        }

        public IDataResult<Session> GetSessionByDate()
        {
            var session = _sessionDAL.GetAll().Where(x=>x.EndDate == null).OrderByDescending(x => x.StartDate).FirstOrDefault();
            return new SuccessDataResult<Session>(session);
        }
    }
}
