using DbUp;
using DbUp.Engine;
using System.Reflection;
using System.Threading.Tasks;

namespace NetCoreSaaS.Data.Migrations
{
    public static class DbUpgrader
    {
        public static Task<DatabaseUpgradeResult> UpgardeAsync(string connectionString)
        {
            return Task.Run(() =>
            {
                try
                {
                    var upgradeEngineBuilder = DeployChanges.To
                                            .SqlDatabase(connectionString, null)
                                            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                                            //.WithTransaction()
                                            .LogToAutodetectedLog();

                    var upgrader = upgradeEngineBuilder.Build();
                    if (upgrader.IsUpgradeRequired())
                        return upgrader.PerformUpgrade();
                    else
                        return new DatabaseUpgradeResult(null, true, null);
                }
                catch (System.Exception e)
                {
                    return new DatabaseUpgradeResult(null, false, e);
                }
            });
        }
    }
}
