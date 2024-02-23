using CarPark.Core.Models;
using CarPark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Business.Abstract
{
    //Servis katmanı, business logic işlemlerin yapıldığı yer. DataAccess burayı besliyor. Soyut işlemler
    public interface IPersonelService
    {
        GetManyResult<Personel> GetPersonelsByAge();
    }
}
