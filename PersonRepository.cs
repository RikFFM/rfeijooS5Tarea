using rfeijooS5Tarea.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rfeijooS5Tarea
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Person>();
        }

        public PersonRepository(string dbPath)
        { _dbPath = dbPath; }

        public void AddNewPersona(string name)
        {
            int result;
            try
            {
                Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre requerido");

                Person person = new() { Name = name };
                result = conn.Insert(person);

                StatusMessage = string.Format("{0} registro(s) guardar(Nombre: {1}", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al agregar {0}. Error:{1}", name, ex.Message);
            }
        }

        public List<Person> GetAllPeople()
        {
            List<Person> personDB;
            try
            {
                Init();
                personDB = conn.Table<Person>().ToList();
                return personDB;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al recibir la data {0}.", ex.Message);
            }
            return new List<Person>();
        }

        public void UpdatePerson(int id, string name)
        {
            int result;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre Requerido");

                Person person = new() { Name = name, Id = id };
                result = conn.Update(person);

                StatusMessage = string.Format("Nombre Actualizado.", name);
            }
            catch (Exception ex) {
                StatusMessage = string.Format("Error al actualizar {0}. Error: {1}", name, ex.Message);
            }


        }

        public void DeletePerson(int id) {
            int result;
            try
            {
                Init();
                if (id <= 0)
                    throw new Exception("ID requerido");

                Person person = new() { Id = id };
                result = conn.Delete(person);

                StatusMessage = string.Format("{0} registro(s) eliminados", result, id);
            } catch (Exception ex) {
                StatusMessage = string.Format("Error al eliminar {0}", id, ex.Message);

            }
        }
    }
}


        