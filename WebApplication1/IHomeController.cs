using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Entities;

namespace WebApplication1
{
    interface IHomeController
    {
        IActionResult TruckCreate();
        IActionResult TruckCreate(EntityTruck myModel);

        IActionResult TruckChange(int idTruck);
        IActionResult TruckChange(EntityTruck myModel);
        IActionResult Index();
        


    }
}
