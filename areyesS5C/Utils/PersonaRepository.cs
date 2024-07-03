using areyesS5C.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace areyesS5C.Utils
{
    public class PersonaRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }


        private void init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();

        }

        public PersonaRepository(string dbPath)
        {

        _dbPath = dbPath; 
        
        }

        public void AddPersona(string nombre)
        {
            int result = 0;

            try
            {
                init();

                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre Requerido");

                Persona persona = new() { Nombre = nombre };
                result = conn.Insert(persona);
                StatusMessage = string.Format("Dato Insertado con éxito", result, nombre);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al insertar", ex.Message);
            }
        }

            public List<Persona> GetAllPeople()
        {
            try
            {
                init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al mostrar", ex.Message);
            }
            return new List<Persona>();
        }

            public void DeletePersona(int id)
        {
            
            try
            {
                init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);

                if (person != null)                
                {
                    conn.Delete(person);
                    StatusMessage = "Persona eliminada correctamente";
                }
                else 
                {
                    StatusMessage = "Persona no encontrada";
                }
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al eliminar", ex.Message);
            }
            
        }

        public void UpdatePerson(Persona person)
        {
            try
            {
                init();
                var existingPerson = conn.Table<Persona>().FirstOrDefault(p => p.Id == person.Id);
                if (existingPerson != null)
                {
                    existingPerson.Nombre = person.Nombre;
                    conn.Update(existingPerson);
                    StatusMessage = "Persona modificada correctamente";
                }
                else
                {
                    StatusMessage = "Persona no encontrada";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error al modificar: {ex.Message}";
            }
        }


    }
}
