namespace FormulaApi.Core;

public interface IUnitOfWork
{
    IDriverRepository Driver { get; }
    Task CompleteAsync();

}