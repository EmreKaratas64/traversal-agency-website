using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.UOWAbstract;
using BusinessLayer.UOWConcrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DataAccessLayer.UOWAbstract;
using DataAccessLayer.UOWEntityFramework;
using DTOLayer.DTOs.AccountUowDTOs;
using DTOLayer.DTOs.ContactDTOs;
using DTOLayer.DTOs.NotificationDTOs;
using DTOLayer.DTOs.ReservationDTOs;
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
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();


            services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();


        }

        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<NotificationAddDto>, NotificationAddValidator>();
            services.AddTransient<IValidator<NotificationUpdateDto>, NotificationUpdateValidator>();
            services.AddTransient<IValidator<VisitorModelDto>, VisitorAddValidator>();
            services.AddTransient<IValidator<VisitorModelDto>, VisitorUpdateValidator>();

            services.AddTransient<IValidator<SendOperationModelDto>, SendOperationValidator>();

            services.AddTransient<IValidator<ContactMessageAddDto>, ContactMessageAddValidator>();
            services.AddTransient<IValidator<ReservationAddDto>, ReservationAddValidator>();
            services.AddTransient<IValidator<ReservationUpdateDto>, ReservationUpdateValidator>();
        }
    }
}
