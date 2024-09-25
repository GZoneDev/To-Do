using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TaskPlatform.API.Middlewares;
using TaskPlatform.Application.Interfaces.Repositories;
using TaskPlatform.Persistence.Common.Mappings;
using TaskPlatform.Persistence.Repository;
using TaskPlatform.Persistence.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
builder.Services.AddScoped<ITaskInfoRepository, EFTaskInfoRepository>();

builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DBConnection")));

builder.Services.AddAutoMapper(typeof(TaskMappingProfile));

builder.Services.AddHttpClient();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<AuthMiddleware>();

app.UseRouting();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
