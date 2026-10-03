using StudentTaskPlanner.Data;
using StudentTaskModel = StudentTaskPlanner.Models.Task;

namespace StudentTaskPlanner.BusinessLogic
{
    public class TaskManager
    {
        private readonly TaskRepository taskRepository;

        public TaskManager()
        {
            taskRepository = new TaskRepository();
        }

        public List<StudentTaskModel> GetAllTasks()
        {
            return taskRepository.GetAllTasks();
        }

        public void AddTask(StudentTaskModel task)
        {
            List<StudentTaskModel> tasks = taskRepository.GetAllTasks();

            tasks.Add(task);

            taskRepository.SaveAllTasks(tasks);
        }

        public bool CompleteTask(string title)
        {
            List<StudentTaskModel> tasks = taskRepository.GetAllTasks();

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Title.Equals(
                    title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    tasks[i].Status = "Completed";

                    taskRepository.SaveAllTasks(tasks);

                    return true;
                }
            }

            return false;
        }

        public bool DeleteTask(string title)
        {
            List<StudentTaskModel> tasks = taskRepository.GetAllTasks();

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Title.Equals(
                    title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    tasks.RemoveAt(i);

                    taskRepository.SaveAllTasks(tasks);

                    return true;
                }
            }

            return false;
        }

        public List<StudentTaskModel> SearchTasks(string searchText)
        {
            List<StudentTaskModel> tasks = taskRepository.GetAllTasks();

            List<StudentTaskModel> results =
                new List<StudentTaskModel>();

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Title.Contains(
                    searchText,
                    StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(tasks[i]);
                }
            }

            return results;
        }

        public List<StudentTaskModel> SortByDueDate()
        {
            List<StudentTaskModel> tasks = taskRepository.GetAllTasks();

            for (int i = 0; i < tasks.Count - 1; i++)
            {
                for (int j = 0; j < tasks.Count - i - 1; j++)
                {
                    if (tasks[j].DueDate > tasks[j + 1].DueDate)
                    {
                        StudentTaskModel temporaryTask = tasks[j];

                        tasks[j] = tasks[j + 1];

                        tasks[j + 1] = temporaryTask;
                    }
                }
            }

            return tasks;
        }
    }
}