using BookLoversProject.Application.Commands.Create.CreateBookCommand;
using BookLoversProject.Application.Commands.Update.UpdateBookCommand;
using BookLoversProject.Application.DTO.BookDTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OnlineBookStore.IntegrationTests.SocialMedia.Host.IntegrationTests;
using System.Net;
using System.Text;

namespace BookLoversProject.Presentation.IntegrationTest
{
    [TestClass]
    public class BookControllerIntegrationTests
    {
        private static TestContext _testContext;
        private static WebApplicationFactory<Program> _factory;

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            _testContext = testContext;
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [TestMethod]
        public async Task GetAllBooks_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/books");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        public async Task GetAllBooks_ShouldReturnExistingBook()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/books");

            var result = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<BookGetDTO>>(result);

            var book = books.FirstOrDefault(b => b.Id == 1);
            BookAsserts(book);
        }

        [TestMethod]
        public async Task GetBookById_ShouldReturnExistingBook()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/books/1");

            var result = await response.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<BookGetDTO>(result);

            BookAsserts(book);
        }

        [TestMethod]
        public async Task CreateBook_ShouldReturnCreatedResponse()
        {
            var book = new CreateBookCommand
            {            
                Title = "Heart Bones",
                Description = "novel",
                AuthorsId = new List<int> { 1 },
                GenresId = new List<int> { 1 }
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/books",
                new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task CreateBook_ShouldReturnCreatedBook()
        {
            var newBook = new CreateBookCommand
            {
                Title = "Heart Bones",
                Description = "novel",
                AuthorsId = new List<int> { 1 },
                GenresId = new List<int> { 1 }
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/books",
                new StringContent(JsonConvert.SerializeObject(newBook), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<BookGetDTO>(result);

            Assert.AreEqual(newBook.Title, book.Title);
            Assert.AreEqual(newBook.Description, book.Description);
            Assert.AreEqual(1, book.Authors.Count);
            Assert.IsTrue(book.Authors.Any(a => a.Name == "Colleen Hoover"));
            Assert.AreEqual(1, book.Genres.Count);
            Assert.IsTrue(book.Genres.Any(a => a.Name == "Contemporary"));
        }

        [TestMethod]
        public async Task UpdateBook_ShouldReturnUpdatedBook()
        {
            var command = new UpdateBookCommand
            {
                Id = 2,
                Title = "Verity",
                Description = "Updated Description",
            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync("/api/books/2",
                new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"));

            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
        }

        [TestMethod]
        public async Task DeleteBook_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync("api/books/3");
            Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }

        private static void BookAsserts(BookGetDTO book)
        {
            Assert.AreEqual("Ugly Love", book.Title);
            Assert.AreEqual("ugly love description", book.Description);
            Assert.AreEqual(1, book.Authors.Count);
            Assert.IsTrue(book.Authors.Any(a => a.Name == "Colleen Hoover"));
            Assert.AreEqual(1, book.Genres.Count);
            Assert.IsTrue(book.Genres.Any(a => a.Name == "Contemporary"));
        }
    }
}