using System;
using System.Collections.Generic;
using AutoMapper;
using Fox.Model.Config;
using Fox.Model.Dao.Interface;
using Fox.Model.DaoModel.Student;
using Fox.Model.ViewModel.Student;
using Fox.Repository.Student;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;

namespace Fox.Repository.Tests.Student
{
    [TestClass]
    public class StudentRepositoryTests
    {
        /// <summary>
        /// 建構子
        /// </summary>
        public StudentRepositoryTests()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IndexVM, SelectStudentDaoReqModel>();
                cfg.CreateMap<SelectStudentDaoResModel, IndexStudentItem>();
            });
        }

        [TestMethod]
        public void 測試StudentRepository查詢_Given_查詢資料_When_執行SelectStudent_Then_驗證查詢結果是否與預設結果一致()
        {
            FakeStudentRepository fake = new FakeStudentRepository();
            //查詢資料
            IndexVM vm = new IndexVM()
            {
                studentId = null,
                studentName = "吳"
            };
            IModelResult<IndexVM> selectResult = fake.SelectStudent(vm);
            string actualStr = JsonConvert.SerializeObject(selectResult);
            //預期值
            IList<IndexStudentItem> expectedLstStudentInfo = new List<IndexStudentItem>();
            expectedLstStudentInfo.Add(new IndexStudentItem()
            {
                id = new Guid(),
                studentId = "G121550397",
                studentName = "吳小欣",
                studentSex = "1",
                studentBirth = new DateTime(1888, 3, 3)
            });
            IModelResult<IndexVM> expectedResult = new ModelResult<IndexVM>()
            {
                 ResultData = new IndexVM()
                 {
                      lstStudentInfo = expectedLstStudentInfo
                 }
            };
            string expectedStr = JsonConvert.SerializeObject(expectedResult);
            Assert.AreEqual(expectedStr, actualStr);
        }
    }

    public class FakeStudentRepository : StudentRepository
    {
        public FakeStudentRepository()
            : base()
        {
        }

        /// <summary>
        /// 模擬預設資料
        /// </summary>
        /// <returns></returns>
        protected override IdbDao GetDao()
        {
            ///預設dao查詢資料
            IList<SelectStudentDaoResModel> daoStudentSelectItem = new List<SelectStudentDaoResModel>();
            daoStudentSelectItem.Add(new SelectStudentDaoResModel()
            {
                id = new Guid(),
                studentId = "G121550397",
                studentName = "吳小欣",
                studentSex = "1",
                studentBirth = new DateTime(1888,3,3),
                studentAddr = "宜蘭縣"
            });
            IModelResult<IList<SelectStudentDaoResModel>> daoStudentSelectModel = new ModelResult<IList<SelectStudentDaoResModel>>()
            {
                ResultData = daoStudentSelectItem
            };
            IdbDao idbDao = Substitute.For<IdbDao>();
            idbDao.StudentSelect(this.selectStudentModel).Returns(daoStudentSelectModel);


            return idbDao;   
        }

        protected override void doEventLog(string msg)
        {
            //base.doEventLog(msg);
        }
        protected override void doLog(string msg)
        {
            //base.doLog(msg);
        }
    }
}
