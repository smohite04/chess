namespace Chess.Application
{
    public interface IUseCase<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
