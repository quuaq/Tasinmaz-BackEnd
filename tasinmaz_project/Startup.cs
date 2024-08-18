//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using System.Text;
//using tasinmaz_project.DataAccess;
//using tasinmaz_project.Helpers;

//namespace tasinmaz_project
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }


//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)

//        {
//            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:Token").Value);
//            services.AddControllers();
//            // Swagger'� ekleyin
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo
//                {
//                    Title = "My API",
//                    Version = "v1"
//                });
//            });

//            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//            {
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(key),
//                    ValidateIssuer = false,
//                    ValidateAudience = false,
//                };
//            });



//            //Yeni Eklene CORS Uygulamas�
//            services.AddCors(options =>
//            {
//                options.AddPolicy("AllowAllOrigins",
//                    builder =>
//                    {
//                        builder.AllowAnyOrigin()
//                               .AllowAnyMethod()
//                               .AllowAnyHeader();
//                    });
//            });

//            //Migration olu�turabilmek i�in startup dosyas�n� yap�land�rd�k.
//            services.AddDbContext<Context>(options =>
//              options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
//            services.AddScoped<IAuthRepository, AuthRepository>();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseHttpsRedirection();

//            app.UseRouting();

//            app.UseAuthorization();

//            // Swagger UI'� etkinle�tir
//            app.UseSwagger();
//            app.UseSwaggerUI(c =>
//            {
//                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//                //c.RoutePrefix = string.Empty; // Swagger UI ana sayfa olarak k�k URL'de yer alacak
//            });

//            // CORS middleware'ini ekleyin
//            app.UseCors("AllowAllOrigins");
//            app.UseAuthentication();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }
//    }
//}
////BURAYA KADAR

//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using System.Text;
//using tasinmaz_project.DataAccess;
//using tasinmaz_project.Helpers;

//namespace tasinmaz_project
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value); // AppSettings:Token kullan�ld�
//            services.AddControllers();

//            // Swagger'� ekleyin
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo
//                {
//                    Title = "My API",
//                    Version = "v1"
//                });
//            });

//            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//            {
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuerSigningKey = true,
//                    IssuerSigningKey = new SymmetricSecurityKey(key),
//                    ValidateIssuer = false,
//                    ValidateAudience = false,
//                };
//            });

//            // CORS'u ekleyin
//            services.AddCors(options =>
//            {
//                options.AddPolicy("AllowAllOrigins",
//                    builder =>
//                    {
//                        builder.AllowAnyOrigin()
//                               .AllowAnyMethod()
//                               .AllowAnyHeader();
//                    });
//            });

//            // Migration olu�turabilmek i�in startup dosyas�n� yap�land�rd�k.
//            services.AddDbContext<Context>(options =>
//              options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))); // UseNpgsql kullan�ld�
//            services.AddScoped<IAuthRepository, AuthRepository>();
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseHttpsRedirection();

//            app.UseRouting();

//            app.UseAuthentication(); // UseAuthentication kullan�ld�
//            app.UseAuthorization();

//            // Swagger UI'� etkinle�tir
//            app.UseSwagger();
//            app.UseSwaggerUI(c =>
//            {
//                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//            });

//            // CORS middleware'ini ekleyin
//            app.UseCors("AllowAllOrigins");

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }
//    }
//}


using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using tasinmaz_project.DataAccess;
using tasinmaz_project.Helpers;

namespace tasinmaz_project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value); // AppSettings:Token kullan�ld�
            services.AddControllers();

            // Swagger'� ekleyin
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            // CORS'u ekleyin
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            // Migration olu�turabilmek i�in startup dosyas�n� yap�land�rd�k.
            services.AddDbContext<Context>(options =>
              options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))); // UseNpgsql kullan�ld�
            services.AddScoped<IAuthRepository, AuthRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); // UseAuthentication kullan�ld�
            app.UseAuthorization();

            // CORS middleware'ini ekleyin
            app.UseCors("AllowAllOrigins");

            // Swagger UI'� etkinle�tir
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
    