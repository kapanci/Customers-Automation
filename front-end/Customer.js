// Fetch data and populate the table
async function fetchData(url) {
    try {
        const response = await fetch(url);
        
        if (!response.ok) {
            console.error("HTTP error:", response.status);
            return;
        }

        const data = await response.json();
        console.log(data);

        // Add data to table
        addDataToTable(data);

    } catch (error) {
        console.error('There was a problem with your fetch operation:', error);
    }
}

function addDataToTable(customers) {
    const tableBody = document.getElementById('customer-table-body');
    
    // Clear the table
    tableBody.innerHTML = '';

    // Add new data
    customers.forEach((customer, index) => {
        const row = document.createElement('tr');

        row.innerHTML = `
            <td>${index + 1}</td>
            <td>${customer.name}</td>
            <td>${customer.surname}</td>
            <td>${customer.tcNo}</td>
            <td>${customer.isUnusualName}</td>

            <td>
                <button class="btn btn-warning btn-sm" onclick="editCustomer(${customer.id})">Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deleteCustomer(${customer.id})">Delete</button>
            </td>
        `;

        tableBody.appendChild(row);
    });
}

document.getElementById('editCustomerForm').addEventListener('submit', async function(event) {
    event.preventDefault(); // Prevent the default form submission

    console.log("Save Changes button clicked"); // Check if this logs in the console

    const id = document.getElementById('editCustomerId').value;
    const name = document.getElementById('editCustomerName').value;
    const surname = document.getElementById('editCustomerSurname').value;
    const tcNo = document.getElementById('editCustomerTcNo').value;

    const updatedCustomer = {
        id: id,
        name: name,
        surname: surname,
        tcNo: tcNo
    };

    try {
        const response = await fetch(`https://localhost:7182/Customer/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedCustomer)
        });

        if (!response.ok) {
            console.error('HTTP error:', response.status);
            return;
        }

        // If the update is successful, refresh the table
        fetchData('https://localhost:7182/Customer');
        
    } catch (error) {
        console.error('There was a problem with your update operation:', error);
    }

    // Close the modal
    const modal = bootstrap.Modal.getInstance(document.getElementById('editCustomerModal'));
    modal.hide();
});



// Adding a new customer
document.getElementById('addCustomerForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    
    const name = document.getElementById('customerName').value;
    const surname = document.getElementById('customerSurname').value;
    const tcNo = document.getElementById('customerTcNo').value;

    const newCustomer = {
        name: name,
        surname: surname,
        tcNo: tcNo
    };

    try {
        const response = await fetch('https://localhost:7182/Customer', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newCustomer)
        });

        if (!response.ok) {
            console.error('HTTP error:', response.status);
            return;
        }

        // If adding a new customer is successful, update the table
        fetchData('https://localhost:7182/Customer');
        
    } catch (error) {
        console.error('There was a problem with your fetch operation:', error);
    }

    // Close the modal
    const modal = bootstrap.Modal.getInstance(document.getElementById('addCustomerModal'));
    modal.hide();
});

async function deleteCustomer(id) {
    try {
        const response = await fetch(`https://localhost:7182/Customer/${id}`, {
            method: 'DELETE',
        });

        if (!response.ok) {
            console.error('HTTP error:', response.status);
            return;
        }

        // If deletion is successful, update the table
        fetchData('https://localhost:7182/Customer');
        
    } catch (error) {
        console.error('There was a problem with your delete operation:', error);
    }
}

async function CategoryAdd(category) {
    try {
        const response = await fetch('https://localhost:7070/Category/AddCategory', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(category)
        });
        
        if (!response.ok) {
            console.error("HTTP error:", response.status);
            return;
        }

        const data = await response.json();
        console.log(data);
    } catch (error) {
        console.error('There was a problem with your fetch operation:', error);
    }
}

async function editCustomer(id) {
    try {
        const response = await fetch(`https://localhost:7182/Customer/${id}`);
        
        if (!response.ok) {
            console.error("HTTP error:", response.status);
            return;
        }

        const customer = await response.json();

        // Fill the form with the existing customer data
        document.getElementById('editCustomerId').value = customer.id;
        document.getElementById('editCustomerName').value = customer.name;
        document.getElementById('editCustomerSurname').value = customer.surname;
        document.getElementById('editCustomerTcNo').value = customer.tcNo;

        // Show the modal
        const editModal = new bootstrap.Modal(document.getElementById('editCustomerModal'));
        editModal.show();

    } catch (error) {
        console.error('There was a problem with your fetch operation:', error);
    }
}


fetchData("https://localhost:7182/Customer");
