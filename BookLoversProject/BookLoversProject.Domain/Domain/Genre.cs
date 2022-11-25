namespace BookLoversProject.Domain.Domain
{
    [Serializable]
    public class Genre: Entity
    {
        public string Name { get; set; }

        public ICollection<GenreBook> Books { get; set; }
    }
}