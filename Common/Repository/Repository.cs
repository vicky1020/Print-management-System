using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using EF;
using System.Data.Entity;
using Common.Mapping;
using Common.Interfaces;
namespace Common.Repository
{
    public class Repository : IRepository
    {
        
        private readonly PrintManagementSystemEntities PMSE;
        public Repository()
        {
            PMSE = new PrintManagementSystemEntities();
        }
        
        public async Task<List<OrderItemModel>> GetAllOrder()
        {
            var AllOrderList = await PMSE.OrderItems.ToListAsync();
            if (AllOrderList.Count > 0)
            {
                return AllOrderList.Select(item => item.ToOrderModel()).ToList();
            }
            return null;
        }

    }
}
