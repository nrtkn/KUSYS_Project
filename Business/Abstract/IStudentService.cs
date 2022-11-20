using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService
    {
        IResult Add(Student student);
        IResult Delete(int studentId);
        IResult Update(Student student);
        IDataResult<List<Student>> GetAll();
        IDataResult<Student> GetStudent(int studentId);
    }
}
