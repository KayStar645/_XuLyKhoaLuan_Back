using AutoMapper;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Detai, DetaiModel>().ReverseMap();
        }
    }
}
