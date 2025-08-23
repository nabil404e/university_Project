// Sample data for trainers
const trainers = [
    {
        id: "001",
        name: "Ahmed Saleh",
        email: "ahmed.saleh@university.edu",
        department: "Computer Science",
        status: "Active"
    },
    {
        id: "002",
        name: "Fatima Khalil",
        email: "fatima.khalil@university.edu",
        department: "Mathematics",
        status: "Active"
    },
    {
        id: "003",
        name: "Mohammed Omar",
        email: "mohammed.omar@university.edu",
        department: "Physics",
        status: "Pending"
    },
    {
        id: "004",
        name: "Nour Ali",
        email: "nour.ali@university.edu",
        department: "Chemistry",
        status: "Active"
    },
    {
        id: "005",
        name: "Sara Ahmed",
        email: "sara.ahmed@university.edu",
        department: "Engineering",
        status: "Active"
    }
];

// Function to populate trainers table
function populateTrainersTable() {
    const tableBody = document.getElementById('trainersTableBody');
    tableBody.innerHTML = '';

    trainers.forEach(trainer => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>#${trainer.id}</td>
            <td>
                <div style="display: flex; align-items: center;">
                    <div style="width: 40px; height: 40px; background: linear-gradient(135deg, #667eea, #764ba2); border-radius: 50%; display: flex; align-items: center; justify-content: center; color: white; font-weight: bold; margin-right: 15px;">
                        ${trainer.name.split(' ').map(n => n[0]).join('')}
                    </div>
                    <div>
                        <div style="font-weight: 600; color: #4a5568;">${trainer.name}</div>
                        <small style="color: #718096;">${trainer.department}</small>
                    </div>
                </div>
            </td>
            <td>${trainer.email}</td>
            <td>
                <span class="status-badge" style="background: #e6fffa; color: #234e52;">
                    ${trainer.department}
                </span>
            </td>
            <td>
                <span class="status-badge ${trainer.status === 'Active' ? 'status-active' : 'status-pending'}">
                    ${trainer.status}
                </span>
            </td>
            <td>
                <button class="action-btn btn-view" onclick="viewTrainer('${trainer.id}')">👁️ View</button>
                <button class="action-btn btn-edit" onclick="editTrainer('${trainer.id}')">✏️ Edit</button>
                <button class="action-btn btn-delete" onclick="deleteTrainer('${trainer.id}')">🗑️ Delete</button>
            </td>
        `;
        tableBody.appendChild(row);
    });
}

// Action functions
function addNewTrainer() {
    alert('Add New Trainer functionality will be implemented here!');
}

function viewTrainer(id) {
    alert(`Viewing trainer with ID: ${id}`);
}

function editTrainer(id) {
    alert(`Editing trainer with ID: ${id}`);
}

function deleteTrainer(id) {
    if (confirm(`Are you sure you want to delete trainer with ID: ${id}?`)) {
        alert(`Trainer with ID: ${id} has been deleted!`);
    }
}

// Initialize the page
document.addEventListener('DOMContentLoaded', function() {
    populateTrainersTable();
    
    // Add some interactive features
    const cards = document.querySelectorAll('.card');
    cards.forEach(card => {
        card.addEventListener('click', function() {
            this.style.transform = 'scale(1.02)';
            setTimeout(() => {
                this.style.transform = 'translateY(-5px)';
            }, 150);
        });
    });
});

// Add smooth scrolling for navigation
document.querySelectorAll('.nav-link').forEach(link => {
    link.addEventListener('click', function(e) {
        e.preventDefault();
        this.style.transform = 'scale(0.95)';
        setTimeout(() => {
            this.style.transform = 'scale(1)';
        }, 150);
    });
});
