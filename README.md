# 🎓 Online Education Platform

An online education platform where students can enroll in courses, watch lessons, read blogs, teachers can create content, and admins can manage the whole system.  

## 🚀 Features

### 👥 Visitors
- Browse available courses and blogs without registering.

### 🧑‍🎓 Students
- Register and enroll in any available course.
- Watch uploaded lesson videos.
- Read and engage with blog posts.

### 🧑‍🏫 Teachers
- Create courses under predefined categories (set by Admin).
- Write blog posts in any category.

### 🛠️ Admin
- Manage all users and their roles (Student ↔ Teacher ↔ Admin).
- Approve, activate or deactivate courses and blogs.
- Add new course or blog categories.

---

## 🏗️ Technologies Used

### Backend
- **ASP.NET Core Web API**
- **N-Tier Architecture**
- **Entity Framework Core**
- **Generic Repository Pattern**
- **Identity** (Authentication & Authorization)
- **JWT Token** (RBAC)

### Frontend
- **ASP.NET Core MVC UI**  
  (Static template integrated with API to make it fully dynamic)

### Database
- **SQL Server**

---

## 📂 Project Structure
- **API Layer** → Backend services for courses, blogs, users, categories  
- **MVC UI** → User interface with separated areas (Admin, Teacher, Student)  
- **Core / Data / Business / Web** layers following N-Tier structure  

---

## ⚡ Getting Started

This project is **not containerized (Docker)** and runs locally.  

1. Clone the repository:
   ```bash
   git clone https://github.com/FerhatFeyzullah/online-education-platform.git
   ```

2. Configure the database connection in `appsettings.json`.

3. Run database migrations (if needed) and update the database.

4. Start the **Web API project**.

5. Run the **MVC UI project**.

---

## 📌 Notes
- The frontend was initially static and is now fully dynamic with API integration. 
