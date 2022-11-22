namespace BookLoversProject.Presentation.StructuralPatterns.Decorator
{
    public class RomanceBookDecorator : BaseBookDecorator
    {
        public RomanceBookDecorator(IBook book) : base(book)
        {
        }

        public override string GetDescription()
        {
            return "romance " + _book.GetDescription();
        }
    }
}
