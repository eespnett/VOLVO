using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Entities
{
    public class EntityTruck
    {
        public int Id { get; set; }
        public EntityModel Model { get; set; }
        public int FactoryYear { get; set; }
        public int ModelYear { get; set; }


        public List<EntityModel> oListModels { get; set; }
    }
}
