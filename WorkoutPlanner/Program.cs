using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WorkoutPlanner.Data;
using WorkoutPlanner.Data.Repositories;
using WorkoutPlanner.Models;
using WorkoutPlanner.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TodoExerciseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICrudRepository<TodoExercise, int>, TodoExerciseRepository>();
builder.Services.AddScoped<ICrudService<TodoExercise, int>, TodoExerciseService>();
builder.Services.AddScoped<ICrudRepository<Day, int>, DayRepository>();
builder.Services.AddScoped<ICrudService<Day, int>, DayService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Workout Planner",
        Version =
    "v1"
    });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);//To EnableCors - CrossOrigin

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
