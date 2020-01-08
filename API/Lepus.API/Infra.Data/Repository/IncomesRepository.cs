﻿using Lepus.API.Domain.Interfaces;
using Lepus.Domain.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lepus.API.Infra.Data.Repository
{
    public class IncomesRepository: IIncomesRepository
    {
        readonly IMongoCollection<Income> _collection;
        public IncomesRepository(IMongoCollection<Income> collection)
        {
            _collection = collection;
        }

        public async Task<List<Income>> Select(string userName, int year, int month)
        {
            return await _collection.Find(x => x.UserName == userName
                                            && x.Year == year
                                            && x.Month == month).ToListAsync();
        }
    }
}
