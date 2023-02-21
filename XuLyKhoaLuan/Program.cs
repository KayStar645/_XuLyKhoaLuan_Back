using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Reflection.Emit;
using System.Text;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Repositories;
using XuLyKhoaLuan.Repositories.Interface;

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
//builder.Services.AddCors(p => p.AddPolicy("MyCors", build => {
//    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
//}));

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
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

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
