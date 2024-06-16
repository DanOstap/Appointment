using Appointment.Models;
using Appointment.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Appointment.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController :ControllerBase
    {
       private readonly ITaskService service;
        public TaskController(ITaskService service)
        {
            this.service = service;
        }
        [HttpGet]
       async public Task<IActionResult> GetOnThisDay() {
            string timeNow = DateTime.UtcNow.Date.ToString("dd/MM/yyyy");
            var tasks = service.FindByTime(timeNow);
            return tasks == null? BadRequest(): Ok(tasks);
        }
        [HttpGet("ByTitle")]
        async public Task<IActionResult> GetByTitile(string title) {
            return Ok(await service.FindByTitle(title));
        }
        [HttpPost]
        async public Task<IActionResult> PostTask(Tasks model)  {
                service.CreateTask(model);
                return Ok();
        }
         [HttpDelete("{id}")]
         async public Task<IActionResult> DeleteTask(int id) {
            var task = await service.DeteleById(id);
            return Ok(task);
            }
        }

    }

