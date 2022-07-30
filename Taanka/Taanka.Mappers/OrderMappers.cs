using Taanka.Models.DomainModels;
using Taanka.Models.WebModels;

namespace Taanka.Mappers
{
    public static class OrderMapepr
    {

        public static OrderModel ToModel(this Order source)
        {
            return new OrderModel
            {
                Address = source.Address,
                Email = source.Email,
                Id = source.Id,
                OrderDate = source.OrderDate,
                Phone = source.Phone,
                FullName = source.FullName,
                OrderNo = source.OrderNo, 
                TotalAmount = source.TotalAmount,
                Details = source.Details,
                IsApproved = source.IsApproved

            };
        }
        
        public static Order ToDB(this OrderModel source)
        {
            return new Order
            {
                Address = source.Address,
                Email = source.Email,
                Id = source.Id,
                OrderDate = source.OrderDate,
                Phone = source.Phone,  
                FullName = source.FullName,
                OrderNo = source.OrderNo,    
                TotalAmount = source.TotalAmount,
                Details = source.Details,
                IsApproved = source.IsApproved
            };
        }
    }
}