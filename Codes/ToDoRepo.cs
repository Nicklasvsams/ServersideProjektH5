using Microsoft.EntityFrameworkCore;
using ServersideProjektH5.Data;
using ServersideProjektH5.Models;

namespace ServersideProjektH5.Codes
{
    public class ToDoRepo
    {
        private readonly ToDoDBContext _dbContext;

        public ToDoRepo(ToDoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool InsertToDoAsync(ToDoModel toDo)
        {
            _dbContext.ToDo.Add(toDo);
            _dbContext.SaveChanges();

            return true;
        }

        public List<ToDoModel> GetAllToDosByUsernameAsync(string username)
        {
            return _dbContext.ToDo.Where(u => u.User == username).ToList();
        }
    }
}
