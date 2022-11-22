namespace BookLoversProject.Presentation.StructuralPatterns.Decorator
{
    public class FantasyBookDecorator : BaseBookDecorator
    {
        public FantasyBookDecorator(IBook book) : base(book)
        {
        }

        public override string GetDescription()
        {
            return "fantasy " + _book.GetDescription();
        }
    }
}
