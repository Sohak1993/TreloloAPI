using DAL.Interfaces;
using DAL.Models.Task;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using ToolBox.Models;

namespace DAL.Repositories
{
    public class TaskRepo : Connection, ITaskRepo
    {
        private string? _connectionString;

        public TaskRepo(IConfiguration config) : base(config)
        {

        }

        public bool Create(NewTask task)
        {
            Command cmd = new Command("INSERT INTO Tasks (Name, IdList, DeadLine) VALUES (@name, @idList, @DeadLine)");

            cmd.AddParameter("name", task.Name);
            cmd.AddParameter("idList", task.IdList);
            cmd.AddParameter("DeadLine", task.DeadLine);

            return ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Tasks WHERE Id = @id");

            cmd.AddParameter("id", id);

            return ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<FullTask> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Tasks");

            return ExecuteReader<FullTask>(cmd);
        }

        public FullTask GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM Tasks WHERE Id = @id");

            cmd.AddParameter("id", id);

            return ExecuteReader<FullTask>(cmd).First();
        }

        public bool Update(FullTask task)
        {
            Command cmd = new Command("UPDATE Tasks SET Name = @name, DeadLine = @DeadLine, IdList = @IdList");

            cmd.AddParameter("name", task.Name);
            cmd.AddParameter("DeadLine", task.DeadLine);
            cmd.AddParameter("IdList", task.IdList);

            return ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<FullTask> GetByList(int idList)
        {
            Command cmd = new Command("SELECT * FROM Tasks WHERE IdList = @idList");

            cmd.AddParameter("idList", idList);

            return ExecuteReader<FullTask>(cmd);
        }
    }
}
