using ByudgetTracker.Entities;
using ByudgetTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByudgetTracker.Data
{
    public class EntityMappingProfile : AutoMapper.Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<Transaction, TransactionModel>()
                .ReverseMap();
        }
    }
}
