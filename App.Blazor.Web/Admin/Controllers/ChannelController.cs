using App.Business.Model;
using App.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Blazor.Web.Admin.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "admin")]
    [Area("admin")]
    [Authorize]
    [Route("api/[area]/[controller]")]
    public class ChannelController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelController(IChannelService articleService)
        {
            _channelService = articleService;
        }

        [HttpPost]
        public Task<string> AddChannel(ChannelModel model)
        {
            return _channelService.AddChannelAsync(model);
        }

        [HttpDelete("{id}")]
        public Task<bool> DeleteChannel(string Id)
        {
            return _channelService.DelChannelAsync(Id);
        }

        [HttpPut("{id}")]
        public Task<bool> UpdateChannel(ChannelModel model)
        {
            return _channelService.UpdateChannelAsync(model);
        }

        [HttpGet]
        public Task<List<ChannelModel>> GetChannels()
        {
            return _channelService.GetChannelsAsync();
        }
    }
}
