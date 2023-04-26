using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Reflection.Emit;
using System.Text;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Repositories;
using Sieve;
using XuLyKhoaLuan.Interface;
using XuLyKhoaLuan.Helpers;
using XuLyKhoaLuan.Interface.TraoDoi;
using XuLyKhoaLuan.Repositories.BinhLuan;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//// JSON Serializer -- Angular quá nhanh
//builder.Services.AddControllersWithViews()
//    .AddNewtonsoftJson(options =>
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
//    .Json.ReferenceLoopHandling.Ignore)
//    .AddNewtonsoftJson(options =>
//    options.SerializerSettings.ContractResolver = new DefaultContractResolver());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<XuLyKhoaLuanContext>().AddDefaultTokenProviders();

builder.Services.AddDbContext<XuLyKhoaLuanContext>(option => option.UseSqlServer
    (builder.Configuration.GetConnectionString("ConnectKhoaLuan")));

// Mới mở cmt
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();

    ///
    build.WithOrigins("http://localhost:4200")
           .AllowCredentials()
           .AllowAnyHeader()
           .AllowAnyMethod();
}));

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});


// Truy cập IdentityOptions
builder.Services.Configure<IdentityOptions>(options => {
    // Thiết lập về Password
    options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 6; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt
});

// Life cycle DI: AddSingleton(), AddTransient(), AddScoped()
builder.Services.AddTransient<IAccountRepository, AccountRepository>();

builder.Services.AddTransient<IBaocaoRepository, BaocaoRepository>();
builder.Services.AddTransient<IBinhluanRepository, BinhluanRepository>();
builder.Services.AddTransient<IBomonRepository, BomonRepository>();
builder.Services.AddTransient<ICongviecRepository, CongviecRepository>();
builder.Services.AddTransient<IChuyennganhRepository, ChuyennganhRepository>();
builder.Services.AddTransient<IDangkyRepository, DangkyRepository>();
builder.Services.AddTransient<IDetaiRepository, DetaiRepository>();
builder.Services.AddTransient<IDotdkRepository, DotdkRepository>();
builder.Services.AddTransient<IDuyetdtRepository, DuyetdtRepository>();
builder.Services.AddTransient<IGiangvienRepository, GiangvienRepository>();
builder.Services.AddTransient<IGiaovuRepository, GiaovuRepository>();
builder.Services.AddTransient<IHdchamRepository, HdchamRepository>();
builder.Services.AddTransient<IHdgopyRepository, HdgopyRepository>();
builder.Services.AddTransient<IHdpbchamRepository, HdpbchamRepository>();
builder.Services.AddTransient<IHdpbnhanxetRepository, HdpbnhanxetRepository>();
builder.Services.AddTransient<IHdphanbienRepository, HdphanbienRepository>();
builder.Services.AddTransient<IHoidongRepository, HoidongRepository>();
builder.Services.AddTransient<IHuongdanRepository, HuongdanRepository>();
builder.Services.AddTransient<IKehoachRepository, KehoachRepository>();
builder.Services.AddTransient<IKhoaRepository, KhoaRepository>();
builder.Services.AddTransient<ILoimoiRepository, LoimoiRepository>();
builder.Services.AddTransient<INhiemvuRepository, NhiemvuRepository>();
builder.Services.AddTransient<INhomRepository, NhomRepository>();
builder.Services.AddTransient<IPbchamRepository, PbchamRepository>();
builder.Services.AddTransient<IPbnhanxetRepository, PbnhanxetRepository>();
builder.Services.AddTransient<IPhanbienRepository, PhanbienRepository>();
builder.Services.AddTransient<ISinhvienRepository, SinhvienRepository>();
builder.Services.AddTransient<IThamgiaRepository, ThamgiaRepository>();
builder.Services.AddTransient<IThamgiahdRepository, ThamgiahdRepository>();
builder.Services.AddTransient<IThongbaoRepository, ThongbaoRepository>();
builder.Services.AddTransient<ITruongbmRepository, TruongbmRepository>();
builder.Services.AddTransient<ITruongkhoaRepository, TruongkhoaRepository>();
builder.Services.AddTransient<IVaitroRepository, VaitroRepository>();
builder.Services.AddTransient<IXacnhanRepository, XacnhanRepository>();

builder.Services.AddTransient<ITraodoiRepo, TraodoiRepo>();

//
builder.Services.AddSignalR();

//builder.Services.AddSieve();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSieve();

app.UseHttpsRedirection();
app.UseCors("MyCors");

app.UseRouting();

app.UseAuthorization();

//
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<Websocket>("/websocket");
});


app.MapControllers();

app.Run();
