using Microsoft.Extensions.DependencyInjection;
using Snail.EntityFramework.Benchmarks;
using Snail.EntityFramework.Options;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
///     项目启动配置类
/// </summary>
public static class Startup
{
    /// <summary>
    ///     配置服务
    /// </summary>
    /// <param name="services">容器服务</param>
    public static void ConfigureServices(this IServiceCollection services)
    {
        //注册数据库实体框架
        services.AddSnailEntityFramework(options =>
        {
            options.ConfigureOptions = new List<DatabaseConfigureOptions>
            {
                new()
                {
                    Enabled = true,
                    Default = true,
                    ConnectionName = Configure.ConnectionName,
                    ConnectionString = Configure.ConnectionString
                }
            };

            options.UseMySqlConnector();
        });
    }
}