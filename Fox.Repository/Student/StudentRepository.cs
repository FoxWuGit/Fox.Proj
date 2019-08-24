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


        /// <summary>
        /// 查詢學生資料
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public IModelResult<IndexVM> SelectStudent (IndexVM vm = null)
        {
            IModelResult<IndexVM> modelResult;

            try
            {
                doEventLog($"查詢資料:input=>{JsonConvert.SerializeObject(vm)}");
                doLog($"查詢資料:input=>{JsonConvert.SerializeObject(vm)}");

                SelectStudentDaoReqModel model = null;
                if (vm != null)
                    model = AutoMapper.Mapper.Map<SelectStudentDaoReqModel>(vm);
                IModelResult<IList<SelectStudentDaoResModel>> dbResult = dao.StudentSelect(model);
                if (dbResult.IsOk)
                {
                    modelResult = new ModelResult<IndexVM>();
                    if (dbResult.ResultData.Any())
                    {
                        modelResult.ResultData = new IndexVM();
                        modelResult.ResultData.lstStudentInfo = dbResult.ResultData.Select(x =>
                        {
                            IndexStudentItem item = AutoMapper.Mapper.Map<IndexStudentItem>(x);
                            return item;
                        }).ToList();
                    }
                }
                else
                {
                    modelResult = new ModelResult<IndexVM>(dbResult.ErrorCode.Value) { SystemMessage = dbResult.SystemMessage };
                }
                doEventLog($"查詢結果:input=>{JsonConvert.SerializeObject(vm)},result=>{JsonConvert.SerializeObject(modelResult)}");
                doLog($"查詢結果:input=>{JsonConvert.SerializeObject(vm)},result=>{JsonConvert.SerializeObject(modelResult)}");
            }
            catch (Exception ex)
            {
                modelResult = new ModelResult<IndexVM>(SystemCodes.Codes.ApplicationError01) { SystemMessage = ex.Message };
            }

            return modelResult;
        }

        /// <summary>
        /// 新增學生資料
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public IModelResult InsertStudent(InsertVm vm)
        {
            IModelResult modelResult;
            try
            {
                doEventLog($"新增資料:input=>{JsonConvert.SerializeObject(vm)}");
                doLog($"新增資料:input=>{JsonConvert.SerializeObject(vm)}");

                InsertStudentDaoReqModel model = AutoMapper.Mapper.Map<InsertStudentDaoReqModel>(vm);
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
                modelResult = new ModelResult(SystemCodes.Codes.ApplicationError02) { SystemMessage = ex.Message };
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
