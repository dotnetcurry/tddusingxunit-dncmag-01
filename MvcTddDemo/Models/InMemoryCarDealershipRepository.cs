using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTddDemo.Models
{
    public class InMemoryCarDealershipRepository : ICarDealershipRepository
    {
        public IEnumerable<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }
    }
}