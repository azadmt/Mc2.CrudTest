namespace Framework.Core.Bus
{
    public interface IQueryHandler<TQuery, TQueryResult> where TQuery : IQuery
    {
        TQueryResult Handle(TQuery query);
    }
}
