using GreenAtom.Data.Interfaces;
using GreenAtom.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace GreenAtom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private IAllOrders Orders { get; set; }

        public OrdersController(IBaseInterface<Order> Products)
        {
            this.Orders = (IAllOrders)Products;
        }
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Orders.GetAllOrders);
        }
        [HttpPost]
        public JsonResult Post(Order order)
        {
            bool success = true;
            Order _order = Orders.Get(order.Id);
            try
            {
                if (_order != null)
                {
                    _order = Orders.Edit(order);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                success = false;
                return new JsonResult(ex.Message);
            }
            return success ? new JsonResult($"Order {order.Id} updated") : new JsonResult("Order was not updated");
        }
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            Order _order = Orders.Get(id);
            try
            {
                if (_order != null)
                {
                    Orders.Delete(id);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
            return RedirectToAction("Get");
        }
        public JsonResult Create(Order order)
        {
            bool success = true;
            Order _order = order;
            try
            {
                if (_order != null && !Orders.GetAllOrders.Contains(_order))
                {
                    Orders.Add(_order);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                success = false;
                return new JsonResult(ex.Message);
            }
            return success ? new JsonResult($"Order was created") : new JsonResult("Order was not created");
        }
    }
}
