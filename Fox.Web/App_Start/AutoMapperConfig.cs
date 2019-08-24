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
                cfg.CreateMap<InsertVm, InsertDaoReqModel>();
                cfg.CreateMap<InsertDaoReqModel, Student>();
            });
        }
    }
}