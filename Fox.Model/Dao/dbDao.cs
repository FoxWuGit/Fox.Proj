using Fox.Model.Config;
using Fox.Model.Dao.Interface;
using Fox.Model.DaoModel.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Model.Dao
{
    public class dbDao : IdbDao
    {
        dbEntities entities = new dbEntities();
        public dbDao()
        {

        }

        /// <summary>
        /// 查詢學生資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IModelResult<IList<SelectStudentDaoResModel>> StudentSelect(SelectStudentDaoReqModel model = null)
        {
            IModelResult<IList<SelectStudentDaoResModel>> modelResult;

            try
            {
                IEnumerable<Student> dbModel = entities.Student;
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.studentId))
                    {
                        dbModel = dbModel.Where(x => x.studentId.Equals(model.studentId));
                    }
                    if (!string.IsNullOrEmpty(model.studentName))
                    {
                        dbModel = dbModel.Where(x => x.studentName.Contains(model.studentName));
                    }
                }
                //實際查詢
                dbModel = dbModel.ToList();
                if (dbModel.Any())
                {
                    IList<SelectStudentDaoResModel> dbResult = dbModel.Select(x =>
                    {
                        SelectStudentDaoResModel item = AutoMapper.Mapper.Map<SelectStudentDaoResModel>(x);
                        return item;
                    }).ToList();
                    modelResult = new ModelResult<IList<SelectStudentDaoResModel>>() { ResultData = dbResult };
                }
                else
                {
                    modelResult = new ModelResult<IList<SelectStudentDaoResModel>>() { ResultData = new List<SelectStudentDaoResModel>() };
                }
            }
            catch (Exception ex)
            {
                modelResult = new ModelResult<IList<SelectStudentDaoResModel>>(SystemCodes.Codes.DBError) { SystemMessage = ex.Message };
            }
            return modelResult;
        }

        /// <summary>
        /// 新增學生資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IModelResult StudentInsert(InsertStudentDaoReqModel model)
        {
            IModelResult modelResult;
            try
            {
                Student dbModel = AutoMapper.Mapper.Map<Student>(model);
                dbModel.id = Guid.NewGuid();
                entities.Student.Add(dbModel);
                entities.SaveChanges();
                modelResult = new ModelResult();
            }
            catch(Exception ex)
            {
                modelResult = new ModelResult(SystemCodes.Codes.DBError) { SystemMessage = ex.Message };
            }
            return modelResult;
        }

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public IModelResult StudentDelete(string gid)
        {
            IModelResult modelResult;
            try
            {
                IList<Student> dbModel = entities.Student.Where(x => x.id.ToString() == gid).ToList();
                if (dbModel.Any())
                {
                    Student deleteItem = dbModel.First();
                    entities.Student.Remove(deleteItem);
                    entities.SaveChanges();
                    modelResult = new ModelResult();
                }
                else
                {
                    modelResult = new ModelResult(SystemCodes.Codes.DBError) { SystemMessage = $"無此資料{gid}" };
                }
            }
            catch (Exception ex)
            {
                modelResult = new ModelResult(SystemCodes.Codes.DBError) { SystemMessage = ex.Message };
            }
            return modelResult;
        }
    }
}
