using System.Collections.Generic;

namespace Fox.Model.Dao.Interface
{
    public interface IdbDao
    {
        IEnumerable<Student> StudentSelect();
    }
}