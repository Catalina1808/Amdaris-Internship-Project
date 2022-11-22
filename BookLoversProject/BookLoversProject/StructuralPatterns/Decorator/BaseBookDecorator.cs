namespace BookLoversProject.Presentation.StructuralPatterns.Decorator
{
    public abstract class BaseBookDecorator : IBook
    {
        protected IBook _book;


        public BaseBookDecorator(IBook book)
        {
            _book = book;
        }

        public abstract string GetDescription();
    }
}
