using Autofac;

namespace XYZ.InventoryManagementSystem.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkContext>()
                 .WithParameter("connectionString", _connectionString)
                 .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                 .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
