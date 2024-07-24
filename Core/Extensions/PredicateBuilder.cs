using System.Linq.Expressions;

namespace Core.Extensions
{
	public static class PredicateBuilder
	{
		// Expression<Func<Domain.Entities.Task, bool>> query = x => true; // Start with a default expression that is always true

		// if (request.CityId.HasValue)
		//{
		//    query = query.AndAlso(x => x.CityId == request.CityId);
		//}
	public static Expression<Func<T, bool>> AndAlso<T>(
			this Expression<Func<T, bool>> expr1,
			Expression<Func<T, bool>> expr2)
		{
			var parameter = Expression.Parameter(typeof(T), "x");
			var body = Expression.AndAlso(
				Expression.Invoke(expr1, parameter),
				Expression.Invoke(expr2, parameter)
			);
			return Expression.Lambda<Func<T, bool>>(body, parameter);
		}
	}
}
