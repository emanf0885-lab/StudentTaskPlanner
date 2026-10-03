using System.Text.Json;
using StudentTaskPlanner.Models;
using StudentTaskModel = StudentTaskPlanner.Models.Task;

namespace StudentTaskPlanner.Data
{
    public class TaskRepository
    {
        private readonly string filePath = "DataFiles/tasks.json";

        public List<StudentTaskModel> GetAllTasks()
        {
            if (!File.Exists(filePath))
            {
                return new List<StudentTaskModel>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<StudentTaskModel>();
            }

            List<StudentTaskModel>? tasks =
                JsonSerializer.Deserialize<List<StudentTaskModel>>(json);

            if (tasks == null)
            {
                return new List<StudentTaskModel>();
            }

            return tasks;
        }

        public void SaveAllTasks(List<StudentTaskModel> tasks)
        {
            string json = JsonSerializer.Serialize(
                tasks,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                }
            );

            Directory.CreateDirectory("DataFiles");

            File.WriteAllText(filePath, json);
        }
    }
}