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

        public IEnumerable<Student> StudentSelect()
        {
            return null;
        }

        public IModelResult StudentInsert(InsertDaoReqModel model)
        {
            IModelResult modelResult = new ModelResult();
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
    }
}
