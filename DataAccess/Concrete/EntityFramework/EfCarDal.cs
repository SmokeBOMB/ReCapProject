﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, EntityFrameworkContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (EntityFrameworkContext context = new EntityFrameworkContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailsDto { CarName = c.CarName, BrandName = b.Name, ColorName = co.Name };
                return result.ToList();
                             
            }
        }
    }
}
