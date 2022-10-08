using SolarEnergy.Infra.DataBase;

namespace SolarEnergy.Infra.DataBase.Repositories;

public class BaseRepository <TEntity, Tkey> where TEntity : class
{
    protected readonly SolarDbContext _context;

    public BaseRepository(SolarDbContext context)
    {
        _context = context;
    }

    public virtual IList<TEntity> Get()
    {
        return _context.Set<TEntity>()
            .ToList();
    }
    public virtual TEntity GetById(Tkey id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public virtual void Post(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }

    public virtual void Put(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
    }

    public virtual void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
    }
}
