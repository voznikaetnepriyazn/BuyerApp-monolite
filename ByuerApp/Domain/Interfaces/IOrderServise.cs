namespace ByuerApp.Domain.Interfaces
{
    public interface IOrderServise
    {
        Task<bool> IsOrderCreated(Guid Id);
    }
}
