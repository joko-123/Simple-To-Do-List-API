 Simple To-Do List API (.NET 8)

Simple To-Do List API adalah backend sederhana menggunakan **.NET 8 Minimal API** untuk mengelola task (CRUD).  
Data disimpan di file `tasks.json` secara lokal. Cocok untuk portofolio backend developer.

---

## Features

- ✅ Get all tasks (`GET /tasks`)  
- ✅ Get task by ID (`GET /tasks/{id}`)  
- ✅ Add new task (`POST /tasks`)  
- ✅ Update task (`PUT /tasks/{id}`)  
- ✅ Delete task (`DELETE /tasks/{id}`)  

---

## Getting Started

### Clone repository
```bash
git clone https://github.com/username/todo-api.git
cd todo-api
Run project
bash
Copy code
dotnet run
Server berjalan di:

arduino
Copy code
http://localhost:5000
https://localhost:5001
API Endpoints
Method	Endpoint	Description	Body (JSON)
GET	/tasks	Get all tasks	—
GET	/tasks/{id}	Get task by ID	—
POST	/tasks	Add new task	{ "title": "Task Title", "description": "Task Description", "isCompleted": false }
PUT	/tasks/{id}	Update task by ID	{ "title": "New Title", "description": "New Description", "isCompleted": true }
DELETE	/tasks/{id}	Delete task by ID	—

Example Requests
1. POST /tasks
Request:

json
Copy code
{
  "title": "Belajar .NET",
  "description": "Membuat To-Do List API",
  "isCompleted": false
}
Response:

json
Copy code
{
  "id": 1,
  "title": "Belajar .NET",
  "description": "Membuat To-Do List API",
  "isCompleted": false,
  "createdAt": "2025-10-16T15:17:04.7502292Z"
}
2. GET /tasks
Response:

json
Copy code
[
  {
    "id": 1,
    "title": "Belajar .NET",
    "description": "Membuat To-Do List API",
    "isCompleted": false,
    "createdAt": "2025-10-16T15:17:04.7502292Z"
  }
]
3. PUT /tasks/1
Request:

json
Copy code
{
  "title": "Belajar .NET Minimal API",
  "description": "Update task",
  "isCompleted": true
}
Response:

json
Copy code
{
  "id": 1,
  "title": "Belajar .NET Minimal API",
  "description": "Update task",
  "isCompleted": true,
  "createdAt": "2025-10-16T15:17:04.7502292Z"
}
4. DELETE /tasks/1
Response: 204 No Content

Notes
Pastikan file tasks.json berisi array kosong [] saat pertama kali dijalankan.

Optional: Swagger UI
Jika menambahkan Swashbuckle ke project, bisa mengakses dokumentasi langsung di browser:

bash
Copy code
http://localhost:5000/swagger/index.html
License
Open-source, bebas digunakan untuk belajar atau pengembangan pribadi.

yaml
Copy code
