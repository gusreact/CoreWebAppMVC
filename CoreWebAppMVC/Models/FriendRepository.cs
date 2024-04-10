
namespace CoreWebAppMVC.Models
{
    public class FriendRepository : IFriendRepository
    {
        private readonly AppDbContext _context;
        private List<Friend> _friends;

        public FriendRepository(AppDbContext context)
        {
            _context = context;
        }

        public Friend Create(Friend friend)
        {
            _context.Friends.Add(friend);
            _context.SaveChanges();
            return friend;
        }

        public Friend Delete(int id)
        {
            Friend friend = _context.Friends.Find(id);
            if(friend != null)
            {
                _context.Friends.Remove(friend);
                _context.SaveChanges();
            }
            return friend;
        }

        public List<Friend> GetAllFriends()
        {
            return _context.Friends.ToList<Friend>();
        }

        public Friend GetFriend(int? id)
        {
            return _context.Friends.Find(id);
        }

        public Friend Update(Friend friend)
        {
            var friendToUpdate = _context.Friends.Attach(friend);
            friendToUpdate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return friend;
        }
    }
}
