🎓 University Management System
===============================

A comprehensive ASP.NET Core MVC web application for managing university operations including student applications, course management, instructor assignments, and result tracking.

---

🌟 Features
-----------

👥 User Management
- Role-based Authentication System (Admin, Employee, Student)
- User registration and login
- Secure password handling
- Role-specific dashboard access

📚 Course Management
- Course creation and management
- Department-based course organization
- Course application system for students
- Application status tracking (Pending, Approved, Rejected)

🎓 Student Portal
- Student application system
- Course registration
- Result viewing
- Personal information management

🛠 Administrative Features
- User role management
- Application review and decision system
- Comprehensive dashboard with analytics
- Export and reporting capabilities

🛠 Employee Features
- Course and department management
- Application review capabilities
- Student information access

---

🛠️ Technology Stack
--------------------
- Backend: ASP.NET Core MVC  
- Frontend: HTML5, CSS3, JavaScript, Bootstrap 5  
- Database: Entity Framework Core (SQL Server)  
- Authentication: ASP.NET Core Identity  
- Icons: Bootstrap Icons  
- Styling: Custom CSS with Google Fonts (Poppins)  

---

📦 Project Structure
-------------------

university_Project/
├── Controllers/
│   ├── AccountController.cs
│   ├── ApplyCourseController.cs
│   ├── CourseController.cs
│   ├── HomeController.cs
│   ├── InstructorsController.cs
│   ├── ResultController.cs
│   └── RoleController.cs
├── Models/
│   ├── AppApplayCourse.cs
│   ├── Course.cs
│   ├── Department.cs
│   ├── Instructor.cs
│   └── Result.cs
├── ViewModels/
│   ├── ApplayCourseViewModel.cs
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
├── Views/
│   ├── Account/
│   ├── ApplyCourse/
│   ├── Course/
│   ├── Home/
│   ├── Instructors/
│   ├── Result/
│   └── Shared/
├── wwwroot/
│   └── css/
└── Program.cs

---

🚀 Getting Started
-----------------

### Prerequisites
- .NET 6.0 SDK or later
- SQL Server (LocalDB or Express)
- Git

### Installation
1️⃣ Clone the repository:
git clone https://github.com/Osama-matter/university_Project.git
cd university_Project

2️⃣ Restore dependencies:
dotnet restore

3️⃣ Database setup:
- Update connection string in `appsettings.json`
- Run migrations:
dotnet ef database update

4️⃣ Run the application:
dotnet run
- Open in browser: https://localhost:7000 (or the port shown in console)

---

🧑‍💼 Default Accounts
---------------------
- Admin: Full system access (user management, settings)  
- Employee: Course management and application review  
- Student: Course application and result viewing  

---

📖 Usage Guide
--------------

### For Students
- Register for an account with student role
- Browse available courses
- Submit course applications
- Track application status
- View results

### For Employees
- Access employee dashboard
- Manage courses and departments
- Review student applications
- Update application statuses
- Generate reports

### For Administrators
- Manage user accounts and roles
- Configure system settings
- Monitor application metrics
- Access all system features

---

🎨 UI/UX Features
-----------------
- Responsive Design: Works on desktop, tablet, and mobile devices  
- Modern Interface: Clean, professional design with intuitive navigation  
- Accessibility: WCAG-compliant elements  
- Interactive Elements: Hover effects, transitions, visual feedback  
- Color-coded Status System: Easy identification of application states  

---

🔧 Configuration
----------------
### Environment Variables
- ConnectionStrings:DefaultConnection → Database connection string  
- ASPNETCORE_ENVIRONMENT → Environment (Development/Production)  

### Example `appsettings.json`
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=UniversityDB;Trusted_Connection=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}

---

🤝 Contributing
---------------
1️⃣ Fork the project  
2️⃣ Create a feature branch:
git checkout -b feature/AmazingFeature
3️⃣ Commit changes:
git commit -m "Add some AmazingFeature"
4️⃣ Push to branch:
git push origin feature/AmazingFeature
5️⃣ Open a Pull Request

---

📄 License
-----------
This project is licensed under the MIT License - see LICENSE.md file.

---

🐛 Troubleshooting
-----------------
- Database Connection Errors: Verify SQL Server is running and connection string  
- Migration Issues: Ensure EF Core tools are installed; run `dotnet ef migrations add InitialCreate` if needed  
- Authentication Problems: Ensure ASP.NET Core Identity is configured correctly  

---

📞 Support
----------
- Open an issue on GitHub  
- Check existing issues for solutions  
- Review ASP.NET Core documentation: https://learn.microsoft.com/en-us/aspnet/core/

---

🏆 Acknowledgments
-----------------
- Bootstrap team for the frontend framework  
- Microsoft ASP.NET Core  
- All contributors who helped shape this project  

---

