namespace CoreWebAppMVC.Models
{
    public class MockFriendRepository : IFriendRepository
    {
        private List<Friend> friendList;

        public MockFriendRepository()
        {
            friendList = new List<Friend>();
            friendList.Add(new Friend() { Id = 1, Name = "Nezuko", Skill = SkillEnum.Demon});
            friendList.Add(new Friend() { Id = 2, Name = "Tanjiro", Skill = SkillEnum.BreathingOfTheSun });
            friendList.Add(new Friend() { Id = 3, Name = "Inosuke", Skill = SkillEnum.BreathingOfTheBeast });
            friendList.Add(new Friend() { Id = 4, Name = "Zenitsu", Skill = SkillEnum.BreathingOfTheLight });
        }

        public Friend GetFriend(int? id) {
            return id == null ? friendList.Where(x => x.Id == id).FirstOrDefault() : friendList.FirstOrDefault();
        }

        public List<Friend> GetAllFriends()
        {
            return friendList;
        }

        public Friend Create(Friend friend)
        {
            friend.Id = friendList.Max(x => x.Id) + 1;
            friendList.Add(friend);
            return friend;
        }

        public Friend Update(Friend friendToUpdate)
        {
            Friend friend = friendList.FirstOrDefault(e => e.Id == friendToUpdate.Id);
            if(friend != null)
            {
                friend.Name = friendToUpdate.Name;
                friend.Email = friendToUpdate.Email;
                friend.Skill = friendToUpdate.Skill;
            }
            return friend;
        }

        public Friend Delete(int id)
        {
            Friend friend = friendList.FirstOrDefault(e => e.Id == id);
            if(friend != null)
            {
                friendList.Remove(friend);
            }
            return friend;
        }
    }
}
