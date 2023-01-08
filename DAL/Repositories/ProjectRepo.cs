using DAL.Interfaces;
using DAL.Models.Project;
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
    public class ProjectRepo : Connection, IProjectRepo
    {
        private string? _connectionString;

        public ProjectRepo(IConfiguration config) : base(config)
        {

        }

        public bool Create(NewProject project)
        {
            Command cmd = new Command("INSERT INTO Projects (Name, IdUser) VALUES (@name, @idUser)");

            cmd.AddParameter("name", project.Name);
            cmd.AddParameter("idUser", project.IdUser);

            return ExecuteNonQuery(cmd) == 1;
        }

        public bool Delete(int id)
        {
            Command cmd = new Command("DELETE FROM Project WHERE Id = @id");

            cmd.AddParameter("id", id);

            return ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Project> GetAll()
        {
            Command cmd = new Command("SELECT * FROM Projects");

            return ExecuteReader<Project>(cmd);
        }

        public Project GetById(int id)
        {
            Command cmd = new Command("SELECT * FROM Projects WHERE Id = @id");

            cmd.AddParameter("id", id);

            return ExecuteReader<Project>(cmd).First();
        }

        public bool Update(Project project)
        {
            Command cmd = new Command("UPDATE Projects SET Name = @name WHERE Id = @id");

            cmd.AddParameter("name", project.Name);
            cmd.AddParameter("id", project.Id);

            return ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Project> GetByUser(int idUser)
        {
            Command cmd = new Command("SELECT * FROM Projects WHERE IdUser = @idUser");

            cmd.AddParameter("idUser", idUser);

            return ExecuteReader<Project>(cmd);
        }
    }
}
