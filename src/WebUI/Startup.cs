using CrossCutting.IOC;
using Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace WebUI
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } //Constructor

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //Adicionando suporte ao MVC
            services.AddMvc();

            //Adding context
            string connString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ContextEF>(options =>
                options.UseSqlServer(connString)
            );

            //Adicionando Automapper
            services.AddAutoMapper();

            //Adicionando os meus servicos de IOC
            RegisterServices(services);

        } //ConfigureServices

        //Meu metodo para registrar servicos de IOC no projeto cross cutting
        private static void RegisterServices(IServiceCollection service)
        {
            NativeInjectorMapping.RegisterServices(service);
        } //RegistesServices

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Default}/{action=Index}/{id?}");

            });


        }
    }
}
