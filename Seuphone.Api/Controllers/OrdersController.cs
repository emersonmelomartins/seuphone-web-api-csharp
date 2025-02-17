﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seuphone.Api.Data;
using Seuphone.Api.DTO;
using Seuphone.Api.Models;
using Seuphone.Api.Models.Enums;
using Seuphone.Api.Services;

namespace Seuphone.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly SeuphoneApiContext _context;
        private OrderService _orderService;
        private MailService _mailService;

        public OrdersController(SeuphoneApiContext context, OrderService orderService, MailService mailService)
        {
            _context = context;
            _orderService = orderService;
            _mailService = mailService;
        }

        // GET: api/Orders
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder(OrderType orderType = OrderType.ALL)
        {

            var query = from o in _context.Order select o;


            if (orderType != OrderType.ALL)
            {
                query = query.Where(o => o.OrderType == orderType);
            }

            if (query == null)
            {
                return BadRequest("Não Houve resultado de pedidos !");
            }

            return await query.Include(o => o.OrderItems).ToListAsync();



            //return await _context.Order
            //    .Include(order => order.OrderItems)
            //    //.Include(order => order.User)
            //    //.ThenInclude(orderItems => orderItems.Product)
            //    //.ThenInclude(product => product.Provider)
            //    .ToListAsync();
        }

        // GET: api/Orders/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Order
                .Include(order => order.OrderItems)
                    .ThenInclude(orderItems => orderItems.Product)
                //.Include(order => order.User)
                //.ThenInclude(product => product.Provider)
                .Where(order => order.OrderItems.Any(oI => oI.OrderId == id))
                .SingleOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // GET: api/Orders/5
        //[Authorize]
        [HttpGet("{id}/pdf")]
        public async Task<ActionResult<Stream>> GetOrderPDF(int id)
        {
            try
            {
                var order = await _context.Order
                .Include(order => order.User)
                .Include(order => order.OrderItems)
                    .ThenInclude(orderItems => orderItems.Product)
                //.ThenInclude(product => product.Provider)
                .Where(order => order.OrderItems.Any(oI => oI.OrderId == id))
                .SingleOrDefaultAsync();

                if (order == null)
                {
                    return NotFound("Não foi encontrado.");
                }


                var pdf = _orderService.CreateOrderPDF(order);

                return pdf;

            } catch(Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex);
            }
                    }

        // GET: api/Orders/5
        //[Authorize]
        [HttpGet("{id}/invoice-pdf")]
        public async Task<ActionResult<Stream>> GetOrderInvoicePDF(int id)
        {
            var order = await _context.Order
                .Include(order => order.User)
                .Include(order => order.OrderItems)
                    .ThenInclude(orderItems => orderItems.Product)
                //.ThenInclude(product => product.Provider)
                .Where(order => order.OrderItems.Any(oI => oI.OrderId == id))
                .SingleOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }


            var pdf = _orderService.CreateOrderInvoicePDF(order);

            return pdf;
        }



        // GET: api/Orders/5
        [Authorize]
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByUser(int id)
        {

            User user = await _context.User.FindAsync(id);

            var orders = await _context.Order.Where(o => o.UserId == id && o.OrderType == OrderType.OUT)
                .Include(o => o.OrderItems)
                .ToListAsync();

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}/order-status")]
        public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] OrderStatusDTO orderStatusDto)
        {

            var order = await _context.Order.FindAsync(id);

            if(order != null)
            {

                order.OrderStatus = orderStatusDto.OrderStatus;

                _context.Entry(order).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
            }

            return NoContent();
            }

            return NotFound();

        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {

            User user = _context.User.Find(order.UserId);
            order.User = user;

            try
            {
                // Saída
                if (order.OrderType == OrderType.OUT)
                {
                    foreach (var item in order.OrderItems)
                    {
                        Product product = await _context.Product
                            .Where(p => p.Id == item.ProductId)
                            .SingleOrDefaultAsync();

                        if (product.StockQuantity >= item.Quantity)
                        {

                            product.StockQuantity = product.StockQuantity - item.Quantity;

                            // Salva retirada de estoque
                            _context.SaveChanges();
                        }
                        else
                        {
                            return BadRequest("Não há estoque suficiente para o produto " + product.Id + " - " + product.Description);
                        }

                    }
                }

            // Entrada
            if (order.OrderType == OrderType.IN)
            {
                foreach (var item in order.OrderItems)
                {
                    var product = await _context.Product
                        .Where(p => p.Id == item.ProductId)
                        .SingleOrDefaultAsync();

                        product.StockQuantity = product.StockQuantity + item.Quantity;

                        _context.SaveChanges();
                   

                }
            }

                // Salva Pedido
                _context.Order.Add(order);
                await _context.SaveChangesAsync();

                if(order.OrderType == OrderType.OUT)
                {
                // Envia e-mail
                Stream pdf = _orderService.CreateOrderPDF(order);
                _mailService.CreateOrderMail(order, pdf, user.Email);
                }

                return CreatedAtAction("GetOrder", new { id = order.Id }, order);

            } catch(Exception ex)
            {
                return BadRequest("Ocorreu um erro " + ex);
            }
          
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
