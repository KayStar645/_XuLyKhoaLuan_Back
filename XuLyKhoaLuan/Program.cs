using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Repositories;
using XuLyKhoaLuan.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// JSON Serializer -- Angular quá nhanh
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
    .Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ContractResolver = new DefaultContractResolver());


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
builder.Services.AddScoped<ISinhvienRepository, SinhvienRepository>();
builder.Services.AddScoped<IKhoaRepository, KhoaRepository>();

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
