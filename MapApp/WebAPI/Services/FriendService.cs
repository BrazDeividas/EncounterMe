using EncounterMe;
using System.Collections.Generic;
using WebAPI.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace WebAPI.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _friendRepository;

        private readonly IFriendRequestRepository _friendRequestRepository;

        private readonly IUserRepository _userRepository;

        public FriendService(IFriendRepository friendRepository, IUserRepository userRepository, IFriendRequestRepository friendRequestRepository)
        {
            _friendRepository = friendRepository;
            _userRepository = userRepository;
            _friendRequestRepository = friendRequestRepository;
        }

        public async Task<IEnumerable<FriendDto>> GetFriendsByUserId(int id)
        {
            var friends = _friendRepository.GetFriendsByUserId(id);

            if(!friends.Any())
            {
                return null;
            }

            var friendList = new List<FriendDto>();
            User user;

            foreach(var friend in friends)
            {
                user = await _userRepository.GetByIdAsync(friend.FriendId);
                friendList.Add(new FriendDto(user.Id, user.Name, user.LevelPoints));
            }

            return friendList.OrderBy(f => f.Name);
        }

        public async Task<IEnumerable<FriendRequestDto>> GetFriendRequestsByReceiverId(int id)
        {
            var requests = _friendRequestRepository.GetRequestsByReceiverId(id);

            if(!requests.Any())
            {
                return null;
            }

            var requestList = new List<FriendRequestDto>();
            User user;

            foreach(var request in requests)
            {
                user = await _userRepository.GetByIdAsync(request.UserId);
                requestList.Add(new FriendRequestDto(user.Id, user.Name, user.LevelPoints, request.TimeSent));
            }

            return requestList.OrderBy(r => r.TimeSent);
        }

        public async Task<bool> AcceptFriendRequestById(int id)
        {
            var request = await _friendRequestRepository.GetByIdAsync(id);
            if(request != null)
            {
                if(await _friendRequestRepository.DeleteByIdAsync(id))
                {
                    await _friendRepository.AddAsync(new Friend { UserId = request.UserId, FriendId = request.ReceiverId });
                    await _friendRepository.AddAsync(new Friend { UserId = request.ReceiverId, FriendId = request.UserId });

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> DeleteFriendRequestById(int id)
        {
            return await _friendRequestRepository.DeleteByIdAsync(id);
        }

        public async Task<bool> SendFriendRequestById(int senderId, int receiverId)
        {
            var req1 = _friendRequestRepository.GetRequestsBySenderId(senderId);
            var req2 = _friendRequestRepository.GetRequestsByReceiverId(receiverId);

            if(!req1.Any() && !req2.Any())
                return await _friendRequestRepository.AddAsync(new FriendRequest { UserId = senderId, ReceiverId = receiverId, TimeSent = DateTime.Now });

            return false;
        }
    }
}
