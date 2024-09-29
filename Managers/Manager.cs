public class Manager
{
    private readonly ApplicationDbContext _context;

    public Manager(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ConcertBaseViewModel> GetAll()
    {
        return _context.Concerts.Select(c => new ConcertBaseViewModel
        {
            ConcertId = c.ConcertId,
            Name = c.Name,
            ConcertDate = c.ConcertDate,
            Location = c.Location
        }).ToList();
    }

    public ConcertBaseViewModel GetOne(int id)
    {
        var concert = _context.Concerts.Find(id);
        if (concert == null) return null;

        return new ConcertBaseViewModel
        {
            ConcertId = concert.ConcertId,
            Name = concert.Name,
            ConcertDate = concert.ConcertDate,
            Location = concert.Location
        };
    }

    public void AddNew(ConcertAddViewModel model)
    {
        var concert = new Concert
        {
            Name = model.Name,
            ConcertDate = model.ConcertDate,
            Location = model.Location
        };

        _context.Concerts.Add(concert);
        _context.SaveChanges();
    }

    public bool UpdateExisting(ConcertBaseViewModel model)
    {
        var concert = _context.Concerts.Find(model.ConcertId);
        if (concert == null) return false;

        concert.Name = model.Name;
        concert.ConcertDate = model.ConcertDate;
        concert.Location = model.Location;

        _context.SaveChanges();
        return true;
    }

    public void DeleteExisting(int id)
    {
        var concert = _context.Concerts.Find(id);
        if (concert != null)
        {
            _context.Concerts.Remove(concert);
            _context.SaveChanges();
        }
    }
}
