using AutoFixture;
using BookLoversProject.Domain.Domain;
using BookLoversProject.Infrastructure.InMemoryRepository;

namespace BookLoversProject.Infrastructure.NUnitTest
{
    [TestFixture]
    public class GenreRepositoryTest
    {
        InMemoryGenreRepository genreRepository;

        [SetUp]
        public void SetUp()
        {
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
              .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            genreRepository = fixture.Build<InMemoryGenreRepository>().Create();
        }

        [Test]
        [TestCase("1")]
        [TestCase("4")]
        [TestCase("6")]
        public async Task GetGenreByIdTestAsync(int Id)
        {
            Genre genre = new()
            {
                Id = Id,
                Name = "Drama"
            };

            await genreRepository.AddGenre(genre);
            var result = await genreRepository.GetGenreById(Id);

            Assert.That(result, Is.EqualTo(genre));
        }

        [Test]
        [TestCase("1")]
        [TestCase("4")]
        [TestCase("6")]
        public void GetGenreByIdTestException(int Id)
        {
            Exception ex = Assert.ThrowsAsync<Exception>(() => genreRepository.GetGenreById(Id));
            Assert.That(ex.Message, Is.EqualTo("Exception occured, genre not found!"));
        }


        [Test]
        public async Task AddGenreTestAsync()
        {
            Genre genre = new()
            {
                Id = 1,
                Name = "Drama"
            };

            genreRepository.AddGenre(genre);
            var result = await genreRepository.GetAllGenres();

            Assert.IsTrue(result.Contains(genre));
        }
    }
}