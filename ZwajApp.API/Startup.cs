using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ZwajApp.API.Data;

namespace ZwajApp.API
{
    //عشان يعرف ال configuration اللى انا عملتها
    //اروح لل Startup
    public class Startup
    {
        //Constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //بتمثل ال key:Value
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //هعمل للداتابيز Service عشان اخليها  Global على مستوى المشروع
            //هنغير هنا بدل ال Connectionstring هنحط ال Congiguration
            //services.AddDbContext<DataContext>(x => x.UseSqlite("Connectionstring"));                     
            //من appsettings (Configuration.GetConnectionString("DefaultConnection"))
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));


            //AddMVC المسؤل عن Routing ينقل  Page to page
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //16-02-14-مشاركة الكود بين أكثر من دومين عن طريق إضافة CORS
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //فى مرحله التطوير كتابه الكود
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //فى مرحله production
            else
            {
                //جديد فى ال core adds middleware fo using HSTS(Security) HTTPS
                //app.UseHsts();
            }

            //16 - 02 - 14 - مشاركة الكود بين أكثر من دومين عن طريق إضافة CORS
            //اضيف الصلاحيات
            app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //بعدين عشان ال Security
            //class app اللى بيبنى المشروع
            //app.UseHttpsRedirection();

            //Requet from client to control there no view here
            //المسئول عن تحديد المسارات
            app.UseMvc();
        }
    }
}
