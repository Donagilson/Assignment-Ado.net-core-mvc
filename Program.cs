using ProfessorManagementSystem.Repository;
using ProfessorManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register repository & service
builder.Services.AddScoped<IProfessorRepository, ProfessorRepositoryImpl>();
builder.Services.AddScoped<IProfessorService, ProfessorServiceImpl>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Professor}/{action=List}/{id?}"
);

app.Run();
