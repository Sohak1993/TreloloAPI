using DAL.Interfaces;
using DAL.Models.Project;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Models;
using ToolBox;
using DAL.Models.List;

namespace DAL.Repositories
{
    public class ListRepo : Connection, IListRepo
    {
        private string? _connectionString;

        public ListRepo(IConfiguration config) : base(config)
        {

        }

        public bool Create(NewList list)
        {
            Command cmd = new Command("INSERT INTO Lists (Name, DeadLine, IdProject) VALUES (@name, @deadLine, @idProject)");

            cmd.AddParameter("name", list.Name);
            cmd.AddParameter("deadLine", list.DeadLine);
            cmd.AddParameter("idProject", list.IdProject);

            return ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Lists WHERE Id = @id");

            cmd.AddParameter("id", id);

            return ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<TaskList> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Lists");

            return ExecuteReader<TaskList>(cmd);
        }

        public TaskList GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM Lists WHERE Id = @id");

            cmd.AddParameter("id", id);

            return ExecuteReader<TaskList>(cmd).First();
        }

        public bool Update(TaskList list)
        {
            Command cmd = new Command("UPDATE Lists SET Name = @name, DeadLine = @deadLine WHERE Id= @id");

            cmd.AddParameter("name", list.Name);
            cmd.AddParameter("deadLine", list.DeadLine);
            cmd.AddParameter("id", list.Id);

            return ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<TaskList> GetByProject(int idProject)
        {
            Command cmd = new Command("SELECT * FROM Lists WHERE IdProject = @idProject");

            cmd.AddParameter("idProject", idProject);

            return ExecuteReader<TaskList>(cmd);
        }

    }
}
