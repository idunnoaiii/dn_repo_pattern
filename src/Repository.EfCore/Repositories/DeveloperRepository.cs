using Repository.Domain;

namespace Repository.EfCore;

public interface IDeveloperRepository : IGenericRepository<Developer> {
    IEnumerable<Developer> GetPopularDeveloper(int count);    
}
public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
{
    public DeveloperRepository(ApplicationContext context) : base(context)
    {
    }

    public IEnumerable<Developer> GetPopularDeveloper(int count)
    {
        return _context.Developers.OrderByDescending(d => d.Followers).Take(count).ToList();
    }
}
