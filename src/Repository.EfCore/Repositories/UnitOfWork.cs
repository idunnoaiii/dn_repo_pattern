using System.Security.Cryptography.X509Certificates;

namespace Repository.EfCore;


public interface IUnitOfWork : IDisposable
{
    IDeveloperRepository Developers { get; }
    IProjectRepository Projects { get; }
    int Complete();

}

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
        Developers = new DeveloperRepository(_context);
        Projects = new ProjectRepository(_context);
    }

    public IDeveloperRepository Developers { get; }

    public IProjectRepository Projects { get; }

    public int Complete() => _context.SaveChanges();

    public void Dispose()
    {
        _context.Dispose();
    }
}
