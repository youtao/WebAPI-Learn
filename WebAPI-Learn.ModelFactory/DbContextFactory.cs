   using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebAPI_Learn.ModelFactory
{
    /// <summary>
    /// 数据库上下文工厂
    /// </summary>
    public class DbContextFactory
    {
        // 获取当前模型数据库上下文
        public static DbContext GetContext<T>()
        {
            var assembly = Assembly.GetAssembly(typeof(T)); // 获取当前类的程序集
            var assemblyName = assembly.GetName().Name;
            DbContext context = HttpContext.Current.Items[assemblyName] as DbContext;
            if (context == null)
            {
                var type = assembly.GetTypes().FirstOrDefault(e => e.BaseType == typeof(DbContext));
                if (type != null)
                {
                    context = Activator.CreateInstance(type) as DbContext;
                    HttpContext.Current.Items.Add(assemblyName, context); // 按程序集名称保存到Http缓存中
                }
            }
            return context;
        }
    }
}