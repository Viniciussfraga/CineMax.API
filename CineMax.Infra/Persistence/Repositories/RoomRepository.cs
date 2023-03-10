using CineMax.Core.Entities;
using CineMax.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime;

namespace CineMax.Infra.Persistence.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ICineMaxDbContext _dbContext;

        public RoomRepository(ICineMaxDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> AddRoomAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Room> DeleteRoomAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Room>> GetAllRoomAndSectionsAsync()
        {
            return await _dbContext.Rooms.Include(r => r.Sections).ThenInclude(r=>r.Movie).Include(r => r.Seats).AsNoTracking().ToListAsync();

        }

        public async Task<Room> GetByIdRoomAndSectionsAsync(int id)
        {
            return await _dbContext.Rooms.Where(r => r.Id == id).Include(r => r.Sections).ThenInclude(r => r.Movie).Include(r => r.Seats).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
            
        }

        public void UpdateRoom(Room room)
        {
           _dbContext.Entry(room).State = EntityState.Modified;

          _dbContext.Set<Room>().Update(room);
        }
    }
}
