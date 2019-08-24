using Fox.Model.Config;
using Fox.Model.DaoModel.Student;
using System.Collections.Generic;

namespace Fox.Model.Dao.Interface
{
    public interface IdbDao
    {
        IEnumerable<Student> StudentSelect();

        /// <summary>
        /// 新增學生資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IModelResult StudentInsert(InsertDaoReqModel model);
    }
}