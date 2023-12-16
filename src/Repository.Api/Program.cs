using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Domain;
using Repository.EfCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));

});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
// {
//     var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
//     context.Database.Migrate();
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/api/developer", (IUnitOfWork unitOfWork) =>
{
    var developer = new Developer
    {
        Followers = 35,
        Name = "Mukesh Murugan"
    };
    var project = new Project
    {
        Name = "codewithmukesh"
    };
    unitOfWork.Developers.Add(developer);
    unitOfWork.Projects.Add(project);
    unitOfWork.Complete();
    return Results.Created();
})
.WithOpenApi();

app.Run();

