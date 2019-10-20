using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLibraryV2.Data;
using MyLibraryV2.Models;

namespace MyLibraryV2.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext application)
        {
            context = application;
        }
        public async Task<IActionResult> AddBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View("AddBook");
            }

            var bookToAdd = new Book
            {
                Name = book.Name,
                Genre = book.Genre,
            };
            if (!context.books.Contains(book))
            {
                await context.books.AddAsync(bookToAdd);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Book already exists");
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RentABook(int? id)
        {
            if (id == null)
            {
                var books = context.books.ToList();
                return View("RentABook", books);
            }

            var currentBook = await context.books.FindAsync(id);

            return await Orders(id, currentBook);
            //return View("Orders", currentBook);
        }

        public async Task<IActionResult> Orders(int? id, Book book)
        {
            var stringVar = $"{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";

            var newOrder = new UserBookOrder
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                BookId = book.Id,
                BookName = book.Name,
                DateCreated = stringVar,
                BookGenre = book.Genre
            };
            await context.userBookOrders.AddAsync(newOrder);
            context.SaveChanges();
            return View("Orders", book);
        }

        public IActionResult ViewOrders()
        {
            var orders = context.userBookOrders.Where(x => x.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View("ViewOrders", orders);
        }

    }
}