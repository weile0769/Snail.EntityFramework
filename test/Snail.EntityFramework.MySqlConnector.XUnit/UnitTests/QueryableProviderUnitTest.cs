using Snail.EntityFramework.MySqlConnector.XUnit.Entities;
using Snail.EntityFramework.Providers;

namespace Snail.EntityFramework.MySqlConnector.XUnit.UnitTests;

/// <summary>
///     QueryableProvider单元测试
/// </summary>
[Collection("MySqlConnector数据库驱动测试案例组别")]
public class QueryableProviderUnitTest
{
    /// <summary>
    ///     IQueryable查询对象提供器
    /// </summary>
    private readonly IQueryableProvider _queryableProvider;

    /// <summary>
    ///     构造函数
    /// </summary>
    public QueryableProviderUnitTest(IQueryableProvider queryableProvider)
    {
        _queryableProvider = queryableProvider;
    }

    /// <summary>
    ///     无参数设置查询条件单元测试案例
    /// </summary>
    [Fact(DisplayName = "无参数设置查询条件单元测试案例")]
    public void AppendWhereConditionsNoSqlParameterUnitTest()
    {
        var queryableProvider = _queryableProvider.Where<User>("id>1");
        Assert.NotNull(queryableProvider.WhereConditions);
        Assert.NotEmpty(queryableProvider.WhereConditions);
    }


    /// <summary>
    ///     对象参数化设置查询条件单元测试案例
    /// </summary>
    [Fact(DisplayName = "对象参数化设置查询条件单元测试案例")]
    public void AppendWhereConditionsIncludeObjectParameterUnitTest()
    {
        var queryableProvider = _queryableProvider.Where<User>("id>@id", new
        {
            id = 1
        });
        Assert.NotNull(queryableProvider.WhereConditions);
        Assert.NotEmpty(queryableProvider.WhereConditions);
        Assert.NotNull(queryableProvider.SqlParameters);
        Assert.NotEmpty(queryableProvider.SqlParameters);
        Assert.True(queryableProvider.SqlParameters.Exists(s => int.Parse(s.Value?.ToString() ?? "0") == 1));
    }
}