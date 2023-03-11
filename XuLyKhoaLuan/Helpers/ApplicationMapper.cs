using AutoMapper;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Models;

namespace XuLyKhoaLuan.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Baocao, BaocaoModel>().ReverseMap();
            CreateMap<Binhluan, BinhluanModel>().ReverseMap();
            CreateMap<Bomon, BomonModel>().ReverseMap();
            CreateMap<Congviec, CongviecModel>().ReverseMap();
            CreateMap<Chuyennganh, ChuyennganhModel>().ReverseMap();
            CreateMap<Dangky, DangkyModel>().ReverseMap();
            CreateMap<Detai, DetaiModel>().ReverseMap();
            CreateMap<Dotdk, DotdkModel>().ReverseMap();
            CreateMap<Duyetdt, DuyetdtModel>().ReverseMap();
            CreateMap<Giangvien, GiangvienModel>().ReverseMap();
            CreateMap<Giaovu, GiaovuModel>().ReverseMap();
            CreateMap<Hdcham, HdchamModel>().ReverseMap();
            CreateMap<Hdgopy, HdgopyModel>().ReverseMap();
            CreateMap<Hdpbcham, HdpbchamModel>().ReverseMap();
            CreateMap<Hdpbnhanxet, HdpbnhanxetModel>().ReverseMap();
            CreateMap<Hdphanbien, HdphanbienModel>().ReverseMap();
            CreateMap<Hoidong, HoidongModel>().ReverseMap();
            CreateMap<Huongdan, HuongdanModel>().ReverseMap();
            CreateMap<Kehoach, KehoachModel>().ReverseMap();
            CreateMap<Khoa, KhoaModel>().ReverseMap();
            CreateMap<Loimoi, LoimoiModel>().ReverseMap();
            CreateMap<Nhiemvu, NhiemvuModel>().ReverseMap();
            CreateMap<Nhom, NhomModel>().ReverseMap();
            CreateMap<Pbcham, PbchamModel>().ReverseMap();
            CreateMap<Pbnhanxet, PbnhanxetModel>().ReverseMap();
            CreateMap<Phanbien, PhanbienModel>().ReverseMap();
            CreateMap<Sinhvien, SinhvienModel>().ReverseMap();
            CreateMap<Thamgium, ThamgiaModel>().ReverseMap();
            CreateMap<Thamgiahd, ThamgiahdModel>().ReverseMap();
            CreateMap<Thongbao, ThongbaoModel>().ReverseMap();
            CreateMap<Truongbm, TruongbmModel>().ReverseMap();
            CreateMap<Truongkhoa, TruongkhoaModel>().ReverseMap();
            CreateMap<Vaitro, VaitroModel>().ReverseMap();
            CreateMap<Xacnhan, XacnhanModel>().ReverseMap();
            CreateMap<DetaiChuyennganh, DetaiChuyennganhModel>().ReverseMap();
            CreateMap<Rade, RadeModel>().ReverseMap();
        }
    }
}
