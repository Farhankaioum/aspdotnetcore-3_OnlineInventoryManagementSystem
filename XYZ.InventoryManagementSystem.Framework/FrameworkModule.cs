using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

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
           
            base.Load(builder);
        }
    }
}
