using TodoApi.Models;
using TodoApi.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Load tasks dari JSON
var tasks = TaskStorage.LoadTasks();

// GET all tasks
app.MapGet("/tasks", () => tasks);

// GET task by ID
app.MapGet("/tasks/{id:int}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    return task is not null ? Results.Ok(task) : Results.NotFound();
});

// POST new task
app.MapPost("/tasks", (TaskItem task) =>
{
    task.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
    task.CreatedAt = DateTime.UtcNow;
    tasks.Add(task);
    TaskStorage.SaveTasks(tasks);
    return Results.Created($"/tasks/{task.Id}", task);
});

// PUT update task
app.MapPut("/tasks/{id:int}", (int id, TaskItem updatedTask) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task is null) return Results.NotFound();

    task.Title = updatedTask.Title;
    task.Description = updatedTask.Description;
    task.IsCompleted = updatedTask.IsCompleted;
    TaskStorage.SaveTasks(tasks);
    return Results.Ok(task);
});

// DELETE task
app.MapDelete("/tasks/{id:int}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task is null) return Results.NotFound();

    tasks.Remove(task);
    TaskStorage.SaveTasks(tasks);
    return Results.NoContent();
});

app.Run();
