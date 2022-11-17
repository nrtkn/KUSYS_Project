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
    public class StudentManager : IStudentService
    {
        IStudentDAL _studentDAL;

        public StudentManager(IStudentDAL studentDAL)
        {
            _studentDAL = studentDAL;
        }

        public IResult Add(Student student)
        {
           _studentDAL.Add(student);
            return new SuccessResult();
        }

        public IResult Delete(int studentId)
        {
            var studentToDelete = _studentDAL.Get(x=>x.StudentId == studentId);
            _studentDAL.Delete(studentToDelete);
            return new SuccessResult();
        }

        public IDataResult<List<Student>> GetAll()
        {
            var resultList = _studentDAL.GetAll();
            return new SuccessDataResult<List<Student>>(resultList);
        }

        public IResult Update(Student student)
        {
            var studentToUpdate = _studentDAL.Get(x=>x.StudentId == student.StudentId);
            studentToUpdate.BirthDate = student.BirthDate;
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            return new SuccessResult();
        }
    }
}
