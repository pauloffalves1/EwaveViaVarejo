using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViaVarejo.Services.Friends.Domain;
using ViaVarejo.Services.Friends.Domain.Interfaces;

namespace ViaVarejo.Services.Friends.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        IFriendRepository friendRepository;

        public FriendsController(IFriendRepository _friendRepository)
        {
            friendRepository = _friendRepository;
        }

        [HttpGet]
        [Route("GetFriends")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetFriends()
        {
            try
            {
                var categories = await friendRepository.GetFriends();
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpGet]
        [Route("GetFriend")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetFriend(int? friendId)
        {
            if (friendId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await friendRepository.GetFriend(friendId);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddFriend")]
        [Authorize("Bearer")]
        public async Task<IActionResult> AddFriend([FromBody]Friend model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var friendId = await friendRepository.AddFriend(model);
                    if (friendId > 0)
                    {
                        return Ok(friendId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteFriend/{friendId}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> DeleteFriend(int? friendId)
        {
            int result = 0;

            if (friendId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await friendRepository.DeleteFriend(friendId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        
        [HttpPut]
        [Route("UpdateFriend")]
        [Authorize("Bearer")]
        public async Task<IActionResult> UpdateFriend([FromBody]Friend model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await friendRepository.UpdateFriend(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetThreeClosestFriends/{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetThreeClosestFriends([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                var post = await friendRepository.GetThreeClosestFriends(id);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}