namespace SneakerServer.Repository
{
  public class UnitOfWork(SneakerContext context) : IDisposable
  {
    private SneakerContext _context = context;
    private GenericRepository<User> _userRepository = null!;
    private GenericRepository<Brand> _brandRepository = null!;

    public GenericRepository<User> UserRepository
    {
      get
      {
        return _userRepository ??= new GenericRepository<User>(_context);
      }
    }

    public GenericRepository<Brand> BrandRepository
    {
      get
      {
        return _brandRepository ??= new GenericRepository<Brand>(_context);
      }
    }


    public void Save() => _context.SaveChanges();

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}