using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

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
			services.AddScoped<ITaskTypeRepository, TaskTypeRepository>();
			return services;
		}
	}
}
