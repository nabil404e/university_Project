A comprehensive ASP.NET Core web application for managing university operations including student applications, course management, instructor assignments, and result tracking.

🌟 Features
User Management
Role-based Authentication System (Admin, Employee, Student)

User registration and login functionality

Secure password handling

Role-specific dashboard access

Course Management
Course creation and management

Department-based course organization

Course application system for students

Application status tracking (Pending, Approved, Rejected)

Student Portal
Student application system

Course registration

Result viewing

Personal information management

Administrative Features
User role management

Application review and decision system

Comprehensive dashboard with analytics

Export and reporting capabilities

Employee Features
Course and department management

Application review capabilities

Student information access

🛠️ Technology Stack
Backend: ASP.NET Core MVC

Frontend: HTML5, CSS3, JavaScript, Bootstrap 5

Database: Entity Framework Core (SQL Server)

Authentication: ASP.NET Core Identity

Icons: Bootstrap Icons

Styling: Custom CSS with Google Fonts (Poppins)

📦 Project Structure
text
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
🚀 Getting Started
Prerequisites
.NET 6.0 SDK or later

SQL Server (LocalDB or Express)

Git

Installation
Clone the repository

bash
git clone https://github.com/Osama-matter/university_Project.git
cd university_Project
Restore dependencies

bash
dotnet restore
Database setup

Update the connection string in appsettings.json

Run database migrations:

bash
dotnet ef database update
Run the application

bash
dotnet run
Access the application

Open your browser and navigate to https://localhost:7000 (or the port shown in the console)

Default Accounts
The system includes role-based access:

Admin: Full system access (user management, settings)

Employee: Course management and application review

Student: Course application and result viewing

📖 Usage Guide
For Students
Register for an account with student role

Browse available courses

Submit course applications

Track application status

View results when available

For Employees
Access the admin dashboard

Manage courses and departments

Review student applications

Update application statuses

Generate reports

For Administrators
Manage user accounts and roles

Configure system settings

Monitor application metrics

Access all system features

🎨 UI/UX Features
Responsive Design: Works on desktop, tablet, and mobile devices

Modern Interface: Clean, professional design with intuitive navigation

Accessibility: WCAG-compliant design elements

Interactive Elements: Hover effects, transitions, and visual feedback

Color-coded Status System: Easy identification of application states

🔧 Configuration
Environment Variables
Set the following environment variables for production:

ConnectionStrings:DefaultConnection: Database connection string

ASPNETCORE_ENVIRONMENT: Environment (Development/Production)

AppSettings.json
json
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
🤝 Contributing
Fork the project

Create your feature branch (git checkout -b feature/AmazingFeature)

Commit your changes (git commit -m 'Add some AmazingFeature')

Push to the branch (git push origin feature/AmazingFeature)

Open a Pull Request

📄 License
This project is licensed under the MIT License - see the LICENSE.md file for details.

🐛 Troubleshooting
Common Issues
Database Connection Errors

Verify SQL Server is running

Check connection string in appsettings.json

Migration Issues

Ensure Entity Framework Core tools are installed

Run dotnet ef migrations add InitialCreate if needed

Authentication Problems

Check that ASP.NET Core Identity is properly configured

Getting Help
Create an issue on GitHub

Check existing issues for solutions

Review ASP.NET Core documentation

📞 Support
For support, please open an issue on the GitHub repository or contact the development team.

Developed by @Osama Matter 

🏆 Acknowledgments
Bootstrap team for the frontend framework

Microsoft for ASP.NET Core

All contributors who have helped shape this project

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
