using Fox.Model.Config;
using Fox.Model.ViewModel.Student;

namespace Fox.Repository.Interface.Student
{
    public interface IStudentRepository
    {
        IModelResult DeleteStudent(string gid);
        IModelResult InsertStudent(InsertVM vm);
        IModelResult<IndexVM> SelectStudent(IndexVM vm = null);
        IModelResult<SelectEditVM> SelectStudent(string gid);
        IModelResult UpdateStudent(EditVM vm);
    }
}