using Seuphone.Api.Models;
using Seuphone.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seuphone.Api.Data
{
    public class SeedingService
    {

        private SeuphoneApiContext _context;

        public SeedingService(SeuphoneApiContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // If database already exists data
            if (_context.User.Any() || _context.Provider.Any() ||
                _context.Product.Any() || _context.Order.Any() ||
                _context.OrderItems.Any())
            {
                // Database have registers, return empty;
                return;
            }

            // Seeding database automatically for testing purposes
            User u1 = new User(new int(), "bob.brown@gmail.com", "654321",
                "Bob Brown", 'M', new DateTime(1980, 01, 03), "123.456.789-10", "09112-000",
                "Av. Sila Nalon Gonzaga", 123, "Parque Marajoara", "Santo André", "SP");

            User u2 = new User(new int(), "m_green@gmail.com", "123456",
                "Maria Green", 'F', new DateTime(1991, 05, 15), "321.123.213-02", "09360-490",
                "Av. Caetano Scila", 123, "Vila Assis Brasil", "Mauá", "SP");


            Provider p1 = new Provider(new int(), "Apple Computer Inc.", "123.456.789/0001-01",
                "09360-490", "Rua dos iPhones", 123, "Matriz", "São Bernardo do Campo", "SP");

            Provider p2 = new Provider(new int(), "iCapinhas.", "456.123.987/0001-77",
                "09112-000", "Rua das Capinhas", 123, "Três Oitão", "Osasco", "SP");


            Product prod1 = new Product(new int(), "iPhone 12 Pro - 128GB - Azul", "iPhone 12 Pro",
                "Azul", "128GB", 9999.99, 0, "aqui vem a string base64", p1);

            Product prod2 = new Product(new int(), "Capa Anti-Impact iPhone 12", "Anti-Impact",
                "Transparente", "Não se aplica", 25.00, 0, "aqui vem a string base64", p2);


            Order o1 = new Order(new int(), u1, new DateTime(2021, 04, 05), OrderStatus.RECEBIDO);

            Order o2 = new Order(new int(), u2, new DateTime(2021, 03, 22), OrderStatus.AGUARDANDO);


            OrderItems oi1 = new OrderItems(new int(), prod1, 1, 9999.99, o1);

            OrderItems oi2 = new OrderItems(new int(), prod2, 2, 50.00, o1);

            OrderItems oi3 = new OrderItems(new int(), prod1, 1, 9999.99, o2);


            _context.User.AddRange(u1, u2);
            _context.Provider.AddRange(p1, p2);
            _context.Product.AddRange(prod1, prod2);
            _context.Order.AddRange(o1, o2);
            _context.OrderItems.AddRange(oi1, oi2, oi3);

            _context.SaveChanges();

        }

    }
}
