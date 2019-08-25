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
        protected IdbDao dao;

        /// <summary>
        /// 查詢學生資料
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        protected SelectStudentDaoReqModel selectStudentModel = null;
        public IModelResult<IndexVM> SelectStudent (IndexVM vm = null)
        {
            IModelResult<IndexVM> modelResult;

            try
            {
                doEventLog($"查詢資料:input=>{JsonConvert.SerializeObject(vm)}");
                doLog($"查詢資料:input=>{JsonConvert.SerializeObject(vm)}");

                selectStudentModel = null;
                if (vm != null)
                    selectStudentModel = AutoMapper.Mapper.Map<SelectStudentDaoReqModel>(vm);

                dao = GetDao();
                IModelResult<IList<SelectStudentDaoResModel>> dbResult = dao.StudentSelect(selectStudentModel);
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
                    else
                    {
                        modelResult.ResultData = new IndexVM();
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
        /// 查詢案件(修改用)
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public IModelResult<SelectEditVM> SelectStudent(string gid)
        {
            IModelResult<SelectEditVM> modelResult;

            try
            {
                doEventLog($"查詢資料:input=>{gid}");
                doLog($"查詢資料:input=>{gid}");

                dao = GetDao();
                IModelResult<IList<SelectStudentDaoResModel>> dbResult = dao.StudentSelect();
                if (dbResult.IsOk)
                {
                    modelResult = new ModelResult<SelectEditVM>();
                    if (dbResult.ResultData.Any())
                    {
                        IList<SelectStudentDaoResModel> lstDBResult = dbResult.ResultData.Where(x => x.id.ToString().Equals(gid)).ToList();
                        if (lstDBResult.Any())
                        {
                            SelectEditVM model = AutoMapper.Mapper.Map<SelectEditVM>(lstDBResult.First());
                            modelResult.ResultData = model;
                        }
                        else
                        {
                            modelResult = new ModelResult<SelectEditVM>(SystemCodes.Codes.ApplicationError01) { SystemMessage = $"查詢錯誤，無此識別碼{gid}" };
                        }
                    }
                }
                else
                {
                    modelResult = new ModelResult<SelectEditVM>(dbResult.ErrorCode.Value) { SystemMessage = dbResult.SystemMessage };
                }
                doEventLog($"查詢結果:input=>{gid},result=>{JsonConvert.SerializeObject(modelResult)}");
                doLog($"查詢結果:input=>{gid},result=>{JsonConvert.SerializeObject(modelResult)}");
            }
            catch (Exception ex)
            {
                modelResult = new ModelResult<SelectEditVM>(SystemCodes.Codes.ApplicationError01) { SystemMessage = ex.Message };
            }

            return modelResult;
        }

        /// <summary>
        /// 新增學生資料
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public IModelResult InsertStudent(InsertVM vm)
        {
            IModelResult modelResult;
            try
            {
                doEventLog($"新增資料:input=>{JsonConvert.SerializeObject(vm)}");
                doLog($"新增資料:input=>{JsonConvert.SerializeObject(vm)}");

                InsertStudentDaoReqModel model = AutoMapper.Mapper.Map<InsertStudentDaoReqModel>(vm);
                dao = GetDao();
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
        /// 修改學生資料
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        public IModelResult UpdateStudent(EditVM vm)
        {
            IModelResult modelResult;
            try
            {
                doEventLog($"修改資料:input=>{JsonConvert.SerializeObject(vm)}");
                doLog($"修改資料:input=>{JsonConvert.SerializeObject(vm)}");

                UpdateStudentDaoReqModel model = AutoMapper.Mapper.Map<UpdateStudentDaoReqModel>(vm);
                dao = GetDao();
                IModelResult dbResult = dao.StudentUpdate(model);
                if (dbResult.IsOk)
                {
                    modelResult = new ModelResult();
                }
                else
                {
                    modelResult = new ModelResult(dbResult.ErrorCode.Value) { SystemMessage = dbResult.SystemMessage };
                }
                doEventLog($"修改結果:input=>{JsonConvert.SerializeObject(vm)},result=>{JsonConvert.SerializeObject(modelResult)}");
                doLog($"修改結果:input=>{JsonConvert.SerializeObject(vm)},result=>{JsonConvert.SerializeObject(modelResult)}");
            }
            catch (Exception ex)
            {
                modelResult = new ModelResult(SystemCodes.Codes.ApplicationError03) { SystemMessage = ex.Message };
            }

            return modelResult;
        }

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public IModelResult DeleteStudent(string gid)
        {
            IModelResult modelResult;
            try
            {
                doEventLog($"刪除資料:input=>{gid}");
                doLog($"刪除資料:input=>{gid}");

                dao = GetDao();
                IModelResult dbResult = dao.StudentDelete(gid);
                if (dbResult.IsOk)
                {
                    modelResult = new ModelResult();
                }
                else
                {
                    modelResult = new ModelResult(dbResult.ErrorCode.Value) { SystemMessage = dbResult.SystemMessage };
                }
                doEventLog($"刪除結果:input=>{gid},result=>{JsonConvert.SerializeObject(modelResult)}");
                doLog($"刪除結果:input=>{gid},result=>{JsonConvert.SerializeObject(modelResult)}");
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
