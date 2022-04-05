using EncounterMe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IFriendService
    {
        Task<IEnumerable<FriendDto>> GetFriendsByUserId(int id);

        Task<IEnumerable<FriendRequestDto>> GetFriendRequestsByReceiverId(int id);

        Task<bool> SendFriendRequestById(int senderId, int receiverId);

        Task<bool> AcceptFriendRequestById(int id);

        Task<bool> DeleteFriendRequestById(int id);
    }
}
