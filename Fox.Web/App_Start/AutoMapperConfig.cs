using AutoMapper;
using Fox.Model;
using Fox.Model.DaoModel.Student;
using Fox.Model.ViewModel.Student;

namespace Fox.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<InsertVm, InsertStudentDaoReqModel>();
                cfg.CreateMap<InsertStudentDaoReqModel, Student>();
                cfg.CreateMap<IndexVM, SelectStudentDaoReqModel>();
                cfg.CreateMap<Student, SelectStudentDaoResModel>();
                cfg.CreateMap<SelectStudentDaoResModel, IndexStudentItem>();
            });
        }
    }
}