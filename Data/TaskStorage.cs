using System.Text.Json;
using TodoApi.Models;

namespace TodoApi.Data
{
    public static class TaskStorage
    {
        private static readonly string filePath = "tasks.json";

        public static List<TaskItem> LoadTasks()
        {
            if (!File.Exists(filePath))
                return new List<TaskItem>();

            var json = File.ReadAllText(filePath).Trim();
            if (string.IsNullOrEmpty(json))
                return new List<TaskItem>();

            try
            {
                return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            catch
            {
                return new List<TaskItem>();
            }
        }

        public static void SaveTasks(List<TaskItem> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
