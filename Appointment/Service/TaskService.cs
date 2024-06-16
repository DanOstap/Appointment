using Appointment.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Appointment.Service
{
    public interface ITaskService {
        public Task<Tasks?> CreateTask(Tasks dto);
        public Task<List<Tasks?>> FindByTime(string timeFrom);
        public Task<List<Tasks?>> FindAll();
        public Task<Tasks?> FindById(int id);
        public Task<Tasks?> FindByTitle(string title);
        public Task<Tasks?> Update(int id, Tasks model);
        public Task<Tasks?> DeteleById(int id);

    }
    public class TaskService: ITaskService
    {
        private readonly Context context;
        public TaskService(Context context)
        {
            this.context = context;
        }

        async public Task<Tasks> CreateTask(Tasks model)
        {
            context.Add(model);
            await context.SaveChangesAsync();
            return model;
        }
         public async Task<List<Tasks?>> FindByTime(string timeFrom) {
            var tasks =  await context.Task_Model.Where(propa => propa.TimeFrom == timeFrom).ToListAsync();
            return tasks == null ? null : tasks;
        }
        async public Task<List<Tasks>> FindAll() {
            return await context.Task_Model.ToListAsync();
        }
        async public Task<Tasks> FindById(int id) {
            var task = await context.Task_Model.FindAsync(id);
           return task == null ? null : task;
        }
        async public Task<Tasks?> FindByTitle(string title) {
            var task = await context.Task_Model.FirstOrDefaultAsync(propa => propa.Title == title);
            return task == null ? null : task;
        }
        async public Task<Tasks?> Update(int id, Tasks model) {
            context.Entry(model).State = EntityState.Modified;
            try { await context.SaveChangesAsync(); }
            catch(DbUpdateConcurrencyException)
            {
                if (!TaskExists(id)) return null;
                else throw;
            }
            return model;
        }

        async public Task<Tasks> DeteleById(int id) {
            var task = await context.Task_Model.FindAsync(id);
            if (task == null) { 
                return null;
            }
            context.Remove(task);
            return task;
        }
        private bool TaskExists(int id)
        {
            return (context.Task_Model?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
