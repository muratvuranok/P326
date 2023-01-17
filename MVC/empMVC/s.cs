using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Utilities;
using PRO.SharedKernel.Infrastructure.DbProvider.EFCore.Aggregates;
using PRO.SharedKernel.Infrastructure.DbProviders.EFCore.Aggregates;
using PRO.SharedKernel.Infrastructure.Engine.WorkContext;
using System.Collections;
using System.Linq.Expressions;
​
namespace PRO.SharedKernel;
​
/// <summary> 
/// Extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
/// 
public static class EnumerableExtensions
{
    public static string ToJoinString(this IEnumerable<string> values)
    {
        return String.Join(",", values);
    }
    public static string ToJoinString(this IEnumerable<string> values, string seperator)
    {
        return String.Join(seperator, values);
    }
​
    /// <summary>
    /// Filters a <see cref="IQueryable{T}"/> by given predicate if given condition is true.
    /// </summary>
    /// <param name="source">Enumerable to apply filtering</param>
    /// <param name="condition">A boolean value</param>
    /// <param name="predicate">Predicate to filter the enumerable</param>
    /// <returns>Filtered or not filtered enumerable based on <paramref name="condition"/></returns>
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
    {
        return condition
            ? source.Where(predicate)
            : source;
    }
​
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="source"></param>
    /// <param name="condition"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static IIncludableQueryable<TEntity, TProperty> IncludeIf<TEntity, TProperty>(
        this IQueryable<TEntity> source,
        bool condition,
        Expression<Func<TEntity, TProperty>> predicate)
        where TEntity : class
    {
        return condition
           ? source.Include(predicate)
           : new IncludableQueryable<TEntity, TProperty>(source);
    }
​
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPreviousProperty"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="source"></param>
    /// <param name="condition"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static IIncludableQueryable<TEntity, TProperty> ThenIncludeIf<TEntity, TPreviousProperty, TProperty>(
        this IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>> source,
        bool condition,
        Expression<Func<TPreviousProperty, TProperty>> predicate)
        where TEntity : class
    {
        return condition
           ? source.ThenInclude(predicate)
           : new IncludableQueryable<TEntity, TProperty>(source);
    }
​
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="workContext"></param>
    /// <returns></returns>
    public static IQueryable<T> WhereTenant<T>(this IQueryable<T> query, IWorkContext workContext) where T : ITenant
    {
        return query.Where(s => s.AccountId == workContext.CurrentUser.AccountId);
    }
​
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <param name="entities"></param>
    /// <param name="viewModels"></param>
    /// <param name="mapper"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidCastException"></exception>
    public static (IEnumerable<TDto> created, IEnumerable<TEntity> updated, IEnumerable<TEntity> deleted) CUDs<TEntity, TDto, TPrimaryKey>(this IEnumerable<TEntity> entities, IEnumerable<TDto> viewModels, IMapper mapper)
        where TEntity : IEntity<TPrimaryKey>
        where TDto : IDto<TPrimaryKey>
        where TPrimaryKey : struct
    {
        if (viewModels == null)
            throw new ArgumentNullException(nameof(viewModels));
​
        var entityIds = entities.Select(x => x.Id).ToList();
        var viewModelIds = viewModels.Select(x => x.Id).ToList();
​
        dynamic initValue;
        if (typeof(TPrimaryKey) == typeof(int)) initValue = 0;
        else if (typeof(TPrimaryKey) == typeof(byte)) initValue = 0;
        else if (typeof(TPrimaryKey) == typeof(long)) initValue = 0;
        else if (typeof(TPrimaryKey) == typeof(Guid)) initValue = Guid.Empty;
        else if (typeof(TPrimaryKey) == typeof(string)) initValue = string.Empty;
        else throw new InvalidCastException();
​
        // Created Entities
        var createdEntities = viewModels.Where(s => object.Equals(s.Id, initValue)).ToList();
​
        // Updated Entities
        var updatedEntities = entities.Where(s => viewModelIds.Contains(s.Id)).ToList();
​
        // Deleted Entities
        var deletedEntities = entities.Where(s => !viewModelIds.Contains(s.Id)).ToList();
​
        return (createdEntities, updatedEntities, deletedEntities);
    }
}
​
public sealed class IncludableQueryable<TEntity, TProperty> : IIncludableQueryable<TEntity, TProperty>, IAsyncEnumerable<TEntity>
{
    private readonly IQueryable<TEntity> _queryable;
​
    public IncludableQueryable(IQueryable<TEntity> queryable)
    {
        _queryable = queryable;
    }
​
    public Expression Expression
        => _queryable.Expression;
​
    public Type ElementType
        => _queryable.ElementType;
​
    public IQueryProvider Provider
        => _queryable.Provider;
​
    public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => ((IAsyncEnumerable<TEntity>)_queryable).GetAsyncEnumerator(cancellationToken);
​
    public IEnumerator<TEntity> GetEnumerator()
        => _queryable.GetEnumerator();
​
    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}