namespace BusinessLayer.Abstract
{
    public interface IServiceManager
    {
        IMovieService MovieService { get; }
        IGenreService GenreService { get; }
        ICommentService CommentService { get; }
    }
}
