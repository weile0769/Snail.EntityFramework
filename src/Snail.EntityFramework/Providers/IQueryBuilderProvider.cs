namespace Snail.EntityFramework.Providers;

/// <summary>
///     IQueryable查询对象提供器
/// </summary>
public interface IQueryBuilderProvider
{
    string ToSql();
}