using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NmarketTestApp.Models;
using NmarketTestApp.Utils.Paging;

namespace NmarketTestApp.Contracts
{
    public interface IObjectService
    {
        Task<PagedResult<Flat>> GetAllFlats(string sort, string direction, int PageNumber, int PageSize);

        void UpdateFlat(Flat flat);

        Task<Flat> GetFlatById(int FlatId);

        void DeleteFlat(int FlatId);
    }
}
