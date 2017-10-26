using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces
{
  public interface IRepository
    {
        Task<List<OrderItemModel>> GetAllOrder();
    }
   
}
