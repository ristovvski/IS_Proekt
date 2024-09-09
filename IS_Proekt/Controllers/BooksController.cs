using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IS_Proekt.Data;
using Microsoft.CodeAnalysis.Operations;
using System.Security.Claims;
using Service.Interface;
using IS_Proekt.Domain;
using System.Security.Policy;
using System.Data.Entity;

namespace IS_Proekt.Controllers
{
    public class BooksController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public BooksController(IProductService productService, IShoppingCartService shoppingCartService, IAuthorService authorService, IPublisherService publisherService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        // GET: Products
        public IActionResult Index()
        {
            var books = _productService.GetAllBooks().ToList();
            return View(books);
        }


        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetBookDetails(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            // Assuming _context is your database context
            ViewData["AuthorId"] = new SelectList(_authorService.GetAllAuthors(), "Id", "FirstName");
            ViewData["PublisherId"] = new SelectList(_publisherService.GetAllPublishers(), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,CoverImage,Price,Rating,AuthorId,PublisherId")] Book book)
        {

            book.Id = Guid.NewGuid();
            book.Author = _authorService.GetAuthorDetails(book.AuthorId);
            book.Publisher = _publisherService.GetPublisherDetails(book.PublisherId);
            _productService.AddBook(book);
            return RedirectToAction(nameof(Index));

        }


        public IActionResult AddToCart(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetBookDetails(id);

            BookInShoppingCart ps = new BookInShoppingCart();

            if (product != null)
            {
                ps.BookId = product.Id;
            }

            return View(ps);
        }

        [HttpPost]
        public IActionResult AddToCartConfirmed(BookInShoppingCart model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.AddBookToShoppingCart(model, userId);

            return View("Index", _productService.GetAllBooks().ToList());
        }


        // GET: Products/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetBookDetails(id);

            ViewData["AuthorId"] = new SelectList(_authorService.GetAllAuthors(), "Id", "FirstName", product.AuthorId);
            ViewData["PublisherId"] = new SelectList(_publisherService.GetAllPublishers(), "Id", "Name", product.PublisherId);
            
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Title,Description,CoverImage,Price,Rating,AuthorId,PublisherId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            book.Author = _authorService.GetAuthorDetails(book.AuthorId);
            book.Publisher = _publisherService.GetPublisherDetails(book.PublisherId);

            _productService.UpdateBook(book);

            return RedirectToAction(nameof(Index)); // Redirect to a relevant view after successful edit
        }


        // GET: Products/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetBookDetails(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _productService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
