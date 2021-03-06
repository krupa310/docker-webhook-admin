using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Docker.Webhook.Admin.Controllers
{
    [Produces("application/json")]
    [Route("api/container")]
    public class ContainerController : Controller
    {
        private readonly IDockerClient _dockerClient;

        public ContainerController(IDockerClient dockerClient)
        {
            _dockerClient = dockerClient;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetConatiners()
        {
            return Ok(await _dockerClient.Containers.ListContainersAsync(new ContainersListParameters() {All = true}));
        }

        [HttpGet]
        [Route("{containerId}")]
        public async Task<IActionResult> GetContainer(string containerId)
        {
            return Ok(await _dockerClient.Containers.InspectContainerAsync(containerId));
        }
    }
}