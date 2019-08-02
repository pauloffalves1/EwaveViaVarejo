using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ViaVarejo.Services.Friends.Domain.Interfaces
{
    public interface IFriendRepository
    {
        Task<List<Friend>> GetFriends();

        Task<Friend> GetFriend(int? friendId);

        Task<int> AddFriend(Friend friend);

        Task<int> DeleteFriend(int? friendId);

        Task UpdateFriend(Friend friend);

        Task<IEnumerable<TreeFriends>> GetThreeClosestFriends(int id);
    }
}
