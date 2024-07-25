using Application.Repositories;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Services;

namespace Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
		{
			services.AddDbContext<CaseAppContext>(opt =>
			{
				opt.UseInMemoryDatabase("CaseAppDb");
			});
			services.AddScoped<ICityRepository, CityRepository>();
			services.AddScoped<ICompletedTaskRepository, CompletedTaskRepository>();
			services.AddScoped<IRegionRepository, RegionRepository>();
			services.AddScoped<ITaskRepository, TaskRepository>();
			services.AddScoped<ITaskService, TaskService>();
			services.AddScoped<ITaskTypeRepository, TaskTypeRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			return services;
		}
	}
}
