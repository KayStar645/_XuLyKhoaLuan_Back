using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Repositories;
using XuLyKhoaLuan.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDbContext<XuLyKhoaLuanContext>(option => option.UseSqlServer
    (builder.Configuration.GetConnectionString("ConnectKhoaLuan")));
//builder.Services.AddCors(p => p.AddPolicy("MyCors", build => {
//    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
//}));

builder.Services.AddAutoMapper(typeof(Program));

// Life cycle DI: AddSingleton(), AddTransient(), AddScoped()
builder.Services.AddScoped<IBaocaoRepository, BaocaoRepository>();
builder.Services.AddScoped<IBinhluanRepository, BinhluanRepository>();
builder.Services.AddScoped<IBomonRepository, BomonRepository>();
builder.Services.AddScoped<ICongviecRepository, CongviecRepository>();
builder.Services.AddScoped<IChuyennganhRepository, ChuyennganhRepository>();
builder.Services.AddScoped<IDangkyRepository, DangkyRepository>();
builder.Services.AddScoped<IDetaiRepository, DetaiRepository>();
builder.Services.AddScoped<IDotdkRepository, DotdkRepository>();
builder.Services.AddScoped<IDuyetdtRepository, DuyetdtRepository>();
builder.Services.AddScoped<IGiangvienRepository, GiangvienRepository>();
builder.Services.AddScoped<IGiaovuRepository, GiaovuRepository>();
builder.Services.AddScoped<IHdchamRepository, HdchamRepository>();
builder.Services.AddScoped<IHdgopyRepository, HdgopyRepository>();
builder.Services.AddScoped<IHdpbchamRepository, HdpbchamRepository>();
builder.Services.AddScoped<IHdpbnhanxetRepository, HdpbnhanxetRepository>();
builder.Services.AddScoped<IHdphanbienRepository, HdphanbienRepository>();
builder.Services.AddScoped<IHoidongRepository, HoidongRepository>();
builder.Services.AddScoped<IHuongdanRepository, HuongdanRepository>();
builder.Services.AddScoped<IKehoachRepository, KehoachRepository>();
builder.Services.AddScoped<IKhoaRepository, KhoaRepository>();
builder.Services.AddScoped<ILoimoiRepository, LoimoiRepository>();
builder.Services.AddScoped<INhiemvuRepository, NhiemvuRepository>();
builder.Services.AddScoped<INhomRepository, NhomRepository>();
builder.Services.AddScoped<IPbchamRepository, PbchamRepository>();
builder.Services.AddScoped<IPbnhanxetRepository, PbnhanxetRepository>();
builder.Services.AddScoped<IPhanbienRepository, PhanbienRepository>();
builder.Services.AddScoped<ISinhvienRepository, SinhvienRepository>();
builder.Services.AddScoped<IThamgiaRepository, ThamgiaRepository>();
builder.Services.AddScoped<IThamgiahdRepository, ThamgiahdRepository>();
builder.Services.AddScoped<IThongbaoRepository, ThongbaoRepository>();
builder.Services.AddScoped<ITruongbmRepository, TruongbmRepository>();
builder.Services.AddScoped<ITruongkhoaRepository, TruongkhoaRepository>();
builder.Services.AddScoped<IVaitroRepository, VaitroRepository>();
builder.Services.AddScoped<IXacnhanRepository, XacnhanRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
