using Autofac;
using CSEData.Scrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Worker
{
    public class WorkerModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Scraper>().As<IScrapper>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
