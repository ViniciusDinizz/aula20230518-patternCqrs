using AutoMapper;
using Cqrs.Domain.Commands.v1.CreatePerson;
using Cqrs.Domain.Commands.v1.DeletePerson;
using Cqrs.Domain.Commands.v1.UpdatePerson;
using Cqrs.Domain.Contracts.v1;
using Cqrs.Domain.Queries.v1.GetPerson;
using Cqrs.Domain.Queries.v1.ListPerson;
using Cqrs.Repository;
using Cqrs.Repository.Respositories.v1;
using FluentValidation;
using FluentValidation.AspNetCore;
using MongoDB.Driver;

namespace Cqrs.Api
{
    public static class Bootstrap
    {
        public static void AddInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddCommands();
            services.AddQueries();
            services.AddMappers();
            services.AddValidators();
        }

        private static void AddMappers(this IServiceCollection services) =>
            services.AddAutoMapper(
                typeof(ListPersonQueryProfile),
                typeof(CreatePersonCommandProfile));

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<CreatePersonCommand>, CreatePersonCommandValidator>();
        }

        private static void AddCommands(this IServiceCollection services)
        {
            services.AddTransient<CreatePersonCommandHandler>();
            services.AddTransient<DeletePersonCommandHandler>();
            services.AddTransient<UpdatePersonCommandHandler>();
        }

        private static void AddQueries(this IServiceCollection services)
        {
            services.AddTransient<ListPersonQueryHandler>();
            services.AddTransient<GetPersonQueryHandler>();
        }

        private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoSettings = configuration.GetSection(nameof(MongoRepositorySettings));
            var clientSettings = MongoClientSettings.FromConnectionString(mongoSettings.Get<MongoRepositorySettings>().ConnectionString);

            services.Configure<MongoRepositorySettings>(mongoSettings);
            services.AddSingleton<IMongoClient>(new MongoClient(clientSettings));
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }
    }
}
