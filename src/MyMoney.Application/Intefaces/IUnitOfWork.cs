namespace MyMoney.Application.Intefaces;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
}
