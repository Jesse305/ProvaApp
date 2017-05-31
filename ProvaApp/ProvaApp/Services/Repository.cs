using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvaApp.Models;

namespace ProvaApp.Services
{
    public class Repository
    {
        public async Task<List<Car>> GetCars()
        {
            var Service = new AzureServiceCar<Car>();
            var Items = await Service.GetTable();
            return Items.ToList();
        }
    }
}
