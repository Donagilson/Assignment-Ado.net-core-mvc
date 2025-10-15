using PatientManagementSystem2025.Repository;
using PatientManagementSystem2025.Services;

namespace PatientManagementSystem2025
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IPatientRepository, PatientRepositoryImpl>();
            builder.Services.AddScoped<IPatientService, PatientServiceImpl>();

            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Patients}/{action=List}/{id?}");

            app.Run();
        }
    }
}
