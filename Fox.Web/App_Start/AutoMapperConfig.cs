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
                cfg.CreateMap<InsertVM, InsertStudentDaoReqModel>();
                cfg.CreateMap<InsertStudentDaoReqModel, Student>();
                cfg.CreateMap<IndexVM, SelectStudentDaoReqModel>();
                cfg.CreateMap<Student, SelectStudentDaoResModel>();
                cfg.CreateMap<SelectStudentDaoResModel, IndexStudentItem>();
                cfg.CreateMap<SelectStudentDaoResModel, SelectEditVM>()
                    .ForMember(target => target.studentBirth, opt => opt.MapFrom(src => src.studentBirth.HasValue ? src.studentBirth.Value.ToString("yyyy/MM/dd") : ""));
                cfg.CreateMap<EditVM, UpdateStudentDaoReqModel>();
            });
        }
    }
}