using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using libDB;
using LibLogic.Interfaces;
using LibLogic.service;
using LibLogic.mappers;
using LibLogic.Services;

namespace LibLogic
{
    public static class Configuration
    {
        public static void ConfigureBLLServices(this IServiceCollection services)
        {
            services.ConfigureDALServices();
            IMapper mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserMapper());
                mc.AddProfile(new BookMapper());
                mc.AddProfile(new BookRentalMapper());
            }).CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookRentalService, BookRentalService>();
        }
    }
}
