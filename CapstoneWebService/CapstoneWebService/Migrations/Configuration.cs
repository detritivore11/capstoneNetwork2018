namespace CapstoneWebService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CapstoneWebService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CapstoneWebService.Models.VehicleDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CapstoneWebService.Models.VehicleDB context)
        {
            context.VehicleInfos.AddOrUpdate();
            string initInfo = "{\"version\": \"0.01\", \"params\": [{\"name\": \"Oil Level\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"mm\", \"message\": \"\", \"type\": \"float\", \"id\": 0}, {\"name\": \"Air Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 2}, {\"name\": \"Engine Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 1}], \"id\": 1, \"key\": \"asdf\"}";
            VehicleInfo vInfo = JsonConvert.DeserializeObject<VehicleInfo>(initInfo);
            VehicleDB.Add(vInfo);
            initInfo = "{\"version\": \"0.01\", \"params\": [{\"name\": \"Oil Level\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"mm\", \"message\": \"\", \"type\": \"float\", \"id\": 0}, {\"name\": \"Air Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 2}, {\"name\": \"Engine Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 1}], \"id\": 2, \"key\": \"asdf\"}";
            vInfo = JsonConvert.DeserializeObject<VehicleInfo>(initInfo);
            VehicleDB.Add(vInfo);
            initInfo = "{\"version\": \"0.01\", \"params\": [{\"name\": \"Oil Level\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"mm\", \"message\": \"\", \"type\": \"float\", \"id\": 0}, {\"name\": \"Air Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 2}, {\"name\": \"Engine Temperature\", \"timestamp\": 1544478309, \"value\": \"hello world 1544478309.21\", \"units\": \"C\", \"message\": \"\", \"type\": \"float\", \"id\": 1}], \"id\": 3, \"key\": \"asdf\"}";
            vInfo = JsonConvert.DeserializeObject<VehicleInfo>(initInfo);
            VehicleDB.Add(vInfo);
        }
    }
}
