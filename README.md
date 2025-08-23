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

✍️ Author: Osama Matter
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/0cf9d1b2-0f8b-459c-85a9-bed35451b109" />


<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/af1e3e67-35c3-4303-ac00-6586116b9028" />



<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/12d05283-c993-4b3d-a6b7-d3914e066043" />




<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/00c95672-806d-4aba-8ffb-795af6983901" />



<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/7cd05c9f-e634-4f46-8ff6-9b36a58906b6" />


<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/bd7431c5-6a90-493f-ba70-a0ff6693426a" />


<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/ab8063bc-4e8e-4bb8-9769-21411924b609" />


<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/e09d659c-31d1-452a-a852-d4f42bdc8332" />


<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/8eed4718-943b-400c-b6b8-c7c54357f1dc" />


<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/46b28547-e590-4765-8a80-20554a253e81" />

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/273fc68a-0d1d-44d6-9dc7-de25811565a4" />
