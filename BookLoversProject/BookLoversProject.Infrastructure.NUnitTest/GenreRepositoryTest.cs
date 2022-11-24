using AutoFixture;
using BookLoversProject.Domain.Domain;
using BookLoversProject.Infrastructure.Repositories;

namespace BookLoversProject.Infrastructure.NUnitTest
{
    [TestFixture]
    public class GenreRepositoryTest
    {
        GenreRepository genreRepository;

        [SetUp]
        public void SetUp()
        {
            var fixture = new Fixture();
            genreRepository = fixture.Build<GenreRepository>().Create();
        }

        [Test]
        [TestCase("1")]
        [TestCase("4")]
        [TestCase("6")]
        public void GetGenreByIdTest(int Id)
        {
            Genre genre = new Genre
            {
                Id = Id,
                Name = "Drama"
            };

            genreRepository.AddGenre(genre);

            Assert.That(genreRepository.GetGenreById(Id), Is.EqualTo(genre));
        }

        [Test]
        [TestCase("1")]
        [TestCase("4")]
        [TestCase("6")]
        public void GetGenreByIdTestException(int Id)
        {
            Exception ex = Assert.Throws<Exception>(() => genreRepository.GetGenreById(Id));
            Assert.That(ex.Message, Is.EqualTo("Exception occured, genre not found!"));
        }


        [Test]
        public void AddGenreTest()
        {
            Genre genre = new Genre
            {
                Id = 1,
                Name = "Drama"
            };

            genreRepository.AddGenre(genre);

            Assert.IsTrue(genreRepository.GetAllGenres().Contains(genre));
        }
    }
}