using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NmarketTestApp.Contracts;
using NmarketTestApp.Models;
using NmarketTestApp.Data;
using NmarketTestApp.Utils.Extensions;
using NmarketTestApp.Utils.Paging;
using System.Linq;

namespace NmarketTestApp.Services
{
    public class ObjectService : IObjectService
    {

        NmarketDbContext _context;
        public ObjectService(NmarketDbContext context)
        {
            _context = context;
        }

        public void DeleteFlat(int FlatId)
        {
            var flat = _context.Flat.Where(r => r.FlatId == FlatId).FirstOrDefault();
            _context.Remove(flat);
            _context.SaveChanges();
        }

        public Task<PagedResult<Flat>> GetAllFlats(string column, string direction, int PageNumber, int PageSize)
        {
            bool sortDirection = direction == "asc";

            var result = _context.Flat
              .Join(
                 _context.Building,
                 f => f.BuildingId,
                 b => b.BuildingId,
                 (f, b) =>
                    new
                    {
                        f = f,
                        b = b
                    }
              )
              .Join(
                 _context.District,
                 temp0 => temp0.b.DistrictId,
                 d => d.DistrictId,
                 (temp0, d) =>
                    new
                    {
                        temp0 = temp0,
                        d = d
                    }
              )
              .Join(
                 _context.Region,
                 temp1 => temp1.d.RegionId,
                 r => r.RegionId,
             (temp1, r) => new Flat
             {
                 Id = temp1.temp0.f.Id,
                 FlatId = temp1.temp0.f.FlatId,
                 Floor = temp1.temp0.f.Floor,
                 RoomsCount = temp1.temp0.f.RoomsCount,
                 TotalArea = temp1.temp0.f.TotalArea,
                 KitchenArea = temp1.temp0.f.KitchenArea,
                 Price = temp1.temp0.f.Price,
                 BuildingId = temp1.temp0.f.BuildingId,
                 Building = new Building
                 {
                     Id = temp1.temp0.b.Id,
                     BuildingId = temp1.temp0.b.BuildingId,
                     Name = temp1.temp0.b.Name,
                     Queue = temp1.temp0.b.Queue,
                     Housing = temp1.temp0.b.Housing,
                     DistrictId = temp1.temp0.b.DistrictId,
                     District = new District
                     {
                         Id = temp1.d.Id,
                         DistrictId = temp1.d.DistrictId,
                         Name = temp1.d.Name,
                         RegionId = temp1.d.RegionId,
                         Region = new Region
                         {
                             Id = r.Id,
                             RegionId = r.RegionId,
                             Name = r.Name
                         }
                     }
                 }
             }
          ).OrderByDynamic(column, sortDirection).GetPaged(PageNumber, PageSize);


            return Task.Run(() => result);

        }

        public Task<Flat> GetFlatById(int FlatId)
        {
            throw new NotImplementedException();
        }

        public void UpdateFlat(Flat model)
        {
            var flat = _context.Flat.Where(r => r.FlatId == model.FlatId).FirstOrDefault();
            if (flat != null)
            {
                flat.TotalArea = model.TotalArea;
                flat.KitchenArea = model.KitchenArea;
                flat.Price = model.Price;
            }
            _context.SaveChanges();
        }
    }
}
