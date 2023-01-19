using Microsoft.EntityFrameworkCore;
using XuLyKhoaLuan.Data;
using XuLyKhoaLuan.Repositories;

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
builder.Services.AddScoped<IDetaiRepository, DetaiRepository>();

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
