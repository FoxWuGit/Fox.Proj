using AutoMapper;
using Fox.Model.Config;
using Fox.Model.Dao;
using Fox.Model.Dao.Interface;
using Fox.Model.DaoModel.Student;
using Fox.Model.ViewModel.Student;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fox.Repository.Student
{
    public class StudentRepository
    {
        private IdbDao dao;

        public StudentRepository()
        {
            dao = GetDao();
        }



        public IndexVM SelectStudent (IndexVM model = null)
        {

            return null;
        }

        public IModelResult InsertStudent(InsertVm vm)
        {
            IModelResult modelResult;
            try
            {
                doEventLog($"新增資料:input=>{JsonConvert.SerializeObject(vm)}");
                doLog($"新增資料:input=>{JsonConvert.SerializeObject(vm)}");

                InsertDaoReqModel model = AutoMapper.Mapper.Map<InsertDaoReqModel>(vm);
                IModelResult dbResult = dao.StudentInsert(model);
                if (dbResult.IsOk)
                {
                    modelResult = new ModelResult();
                }
                else
                {
                    modelResult = new ModelResult(dbResult.ErrorCode.Value) { SystemMessage = dbResult.SystemMessage };
                }
                doEventLog($"新增結果:input=>{JsonConvert.SerializeObject(vm)},result=>{JsonConvert.SerializeObject(modelResult)}");
                doLog($"新增結果:input=>{JsonConvert.SerializeObject(vm)},result=>{JsonConvert.SerializeObject(modelResult)}");
            }
            catch (Exception ex)
            {
                modelResult = new ModelResult(SystemCodes.Codes.ApplicationError01) { SystemMessage = ex.Message };
            }

            return modelResult;
        }

        /// <summary>
        /// 取得dao服務
        /// </summary>
        /// <returns></returns>
        protected virtual IdbDao GetDao()
        {
            return new dbDao();
        }

        /// <summary>
        /// 存取db事件
        /// </summary>
        /// <param name="msg"></param>
        protected virtual void doEventLog(string msg)
        {
            //可存db事件
        }

        /// <summary>
        /// 存取log工具
        /// </summary>
        /// <param name="msg"></param>
        protected virtual void doLog(string msg)
        {
            //存取log工具
        }
    }
}
