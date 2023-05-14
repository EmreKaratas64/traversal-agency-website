﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.NotificationDTOs;
using DTOLayer.DTOs.VisitorDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container
{
    public static class ProgramExtentions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<IRezervationService, RezervationManager>();
            services.AddScoped<IRezervationDal, EfRezervationDal>();
            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();
            services.AddScoped<IExcelService, ExcelManager>();
            services.AddScoped<IPdfService, PdfManager>();
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<INotificationDal, EfNotificationDal>();
        }

        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<NotificationAddDto>, NotificationAddValidator>();
            services.AddTransient<IValidator<NotificationUpdateDto>, NotificationUpdateValidator>();

            services.AddTransient<IValidator<VisitorModelDto>, VisitorAddValidator>();
            services.AddTransient<IValidator<VisitorModelDto>, VisitorUpdateValidator>();

        }
    }
}
