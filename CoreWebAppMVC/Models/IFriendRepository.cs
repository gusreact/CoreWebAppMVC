namespace CoreWebAppMVC.Models
{
    public interface IFriendRepository
    {
        Friend GetFriend(int? id);

        List<Friend> GetAllFriends();

        Friend Create(Friend friend);

        Friend Update(Friend friend);

        Friend Delete(int id); 
    }
}
