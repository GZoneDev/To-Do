using Microsoft.AspNetCore.Mvc;
using TaskPlatform.API.Contracts.TaskInfos;
using TaskPlatform.Application.Services;

namespace TaskPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskInfoController : Controller
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(
               [FromBody] CreateTaskInfoRequest createTaskInfoRequest,
               [FromServices] TaskInfoService taskInfoService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await taskInfoService.AddTaskInfoAsync(
                createTaskInfoRequest.CategoryId,
                createTaskInfoRequest.Name,
                createTaskInfoRequest.Description);

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateTaskInfoRequest updateTaskInfoRequest,
            [FromServices] TaskInfoService taskInfoService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await taskInfoService.UpdateTaskInfoAsync(
                updateTaskInfoRequest.TaskId,
                updateTaskInfoRequest.CategoryId,
                updateTaskInfoRequest.Name,
                updateTaskInfoRequest.Description);

            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(
            [FromBody] DeleteTaskInfoRequest deleteTaskInfoRequest,
            [FromServices] TaskInfoService taskInfoService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await taskInfoService.DeleteTaskInfo(deleteTaskInfoRequest.TaskId, deleteTaskInfoRequest.CategoryId);

            return Ok();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(
        [FromQuery] GetTaskInfoRequest getTaskInfoRequest,
        [FromServices] TaskInfoService taskInfoService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await taskInfoService.GetListByCategoryAsync(
                getTaskInfoRequest.CategoryId,
                getTaskInfoRequest.Index,
                getTaskInfoRequest.Number);

            return Ok(result);
        }
    }
}
