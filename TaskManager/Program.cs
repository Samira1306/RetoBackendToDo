using Application.Email;
using Application.Interface;
using Application.TaskManageraOpi;
using Application.TaskManageraOpi.Services;
using Infrastructure.Services;
using Infrastructure.TaskManagerDbContext;
using Infrastructure.TaskManagerRepository;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskDbContext>(options => { options.UseOracle(builder.Configuration.GetConnectionString("DBTASK"),
    b=>b.MigrationsAssembly("TaskManager"));
    });
builder.Services.AddScoped<IRepository, TaskManagerOpiRepository>();
builder.Services.AddScoped<ICreateTask, CreateTask>();
builder.Services.AddScoped<IGetAllTasks, GetAllTasks>();
builder.Services.AddScoped<IGetTaskById, GetTaskById>();
builder.Services.AddScoped<IEditTask, EditStatusTask>();
builder.Services.AddTransient<ISendGridServices>(e =>
{
    string api = e.GetRequiredService<IConfiguration>().GetValue<string>("SendGrid");
    return new SendGridServices(api);
});
builder.Services.AddTransient<ISendGrid, SendGridEmail>();
builder.Services.AddHostedService<WorkerEmail>();
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));






var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
app.UseCors("AllowWebapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
