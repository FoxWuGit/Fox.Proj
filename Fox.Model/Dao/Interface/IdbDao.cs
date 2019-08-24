using Fox.Model.Config;
using Fox.Model.DaoModel.Student;
using System.Collections.Generic;

namespace Fox.Model.Dao.Interface
{
    public interface IdbDao
    {
        /// <summary>
        /// 查詢學生資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IModelResult<IList<SelectStudentDaoResModel>> StudentSelect(SelectStudentDaoReqModel model = null);

        /// <summary>
        /// 新增學生資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IModelResult StudentInsert(InsertStudentDaoReqModel model);

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        IModelResult StudentDelete(string gid);
    }
}