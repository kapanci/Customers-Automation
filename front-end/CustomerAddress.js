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

function addDataToTable(customerAddresses) {
    const tableBody = document.getElementById('customer-table-body');
    
    // Clear the table
    tableBody.innerHTML = '';

    // Add new data
    customerAddresses.forEach((address, index) => {
        const row = document.createElement('tr');

        row.innerHTML = `
            <td>${index + 1}</td>
            <td>${address.addressName}</td>
            <td>${address.city}</td>
            <td>${address.district}</td>
            <td>${address.neighborhood}</td>
            <td>${address.street}</td>
            <td>${address.buildingNumber}</td>
            <td>${address.apartmentNumber}</td>
            <td>${address.postalCode}</td>
            <td>${address.fullAddress}</td>
            <td>
                <button class="btn btn-warning btn-sm" onclick="editCustomer(${address.id})">Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deleteCustomer(${address.id})">Delete</button>
            </td>
        `;

        tableBody.appendChild(row);
    });
}

document.getElementById('editCustomerForm').addEventListener('submit', async function(event) {
    event.preventDefault(); // Prevent the default form submission

    console.log("Save Changes button clicked"); // Check if this logs in the console

    const id = document.getElementById('editCustomerId').value;
    const addressName = document.getElementById('editCustomeraddressName').value;
    const city = document.getElementById('editCustomercity').value;
    const district = document.getElementById('editCustomerdistrict').value;
    const neighborhood = document.getElementById('editCustomerneighborhood').value;
    const street = document.getElementById('editCustomerstreet').value;
    const buildingNumber = document.getElementById('editCustomerbuildingNumber').value;
    const apartmentNumber = document.getElementById('editCustomerapartmentNumber').value;
    const postalCode = document.getElementById('editCustomerpostalCode').value;
    const fullAddress = document.getElementById('editCustomerfullAddress').value;


    const updatedCustomer = {
        id: id,
        addressName: addressName,
        city: city,
        district: district,
        neighborhood: neighborhood,
        street: street,
        buildingNumber: buildingNumber,
        apartmentNumber: apartmentNumber,
        postalCode: postalCode,
        fullAddress: fullAddress
    };

    try {
        const response = await fetch(`https://localhost:7182/CustomerAddress/${id}`, {
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
        fetchData('https://localhost:7182/CustomerAddress');
        
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
    
    const AddressName = document.getElementById('AddressName').value;
    const City = document.getElementById('City').value;
    const District = document.getElementById('District').value;
    const Neighborhood = document.getElementById('Neighborhood').value;
    const Street = document.getElementById('Street').value;
    const BuildingNumber = document.getElementById('BuildingNumber').value;
    const ApartmentNumber = document.getElementById('ApartmentNumber').value;
    const PostalCode = document.getElementById('PostalCode').value;
    const FullAddress = document.getElementById('FullAddress').value;


    const newCustomer = {
        AddressName: AddressName,
        City: City,
        District: District,
        Neighborhood: Neighborhood,
        Street: Street,
        BuildingNumber: BuildingNumber,
        ApartmentNumber: ApartmentNumber,
        PostalCode: PostalCode,
        FullAddress: FullAddress
    };

    try {
        const response = await fetch('https://localhost:7182/CustomerAddress', {
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
        fetchData('https://localhost:7182/CustomerAddress');
        
    } catch (error) {
        console.error('There was a problem with your fetch operation:', error);
    }

    // Close the modal
    const modal = bootstrap.Modal.getInstance(document.getElementById('addCustomerModal'));
    modal.hide();
});

async function deleteCustomer(id) {
    try {
        const response = await fetch(`https://localhost:7182/CustomerAddress/${id}`, {
            method: 'DELETE',
        });

        if (!response.ok) {
            console.error('HTTP error:', response.status);
            return;
        }

        // If deletion is successful, update the table
        fetchData('https://localhost:7182/CustomerAddress');
        
    } catch (error) {
        console.error('There was a problem with your delete operation:', error);
    }
}

async function editCustomer(id) {
    try {
        const response = await fetch(`https://localhost:7182/CustomerAddress/${id}`);
        
        if (!response.ok) {
            console.error("HTTP error:", response.status);
            return;
        }

        const customer = await response.json();

        // Fill the form with the existing customer data
        document.getElementById('editCustomerAddressName').value = customer.AddressName;
        document.getElementById('editCustomerCity').value = customer.City;
        document.getElementById('editCustomerDistrict').value = customer.District;
        document.getElementById('editCustomerNeighborhood').value = customer.Neighborhood;
        document.getElementById('editCustomerStreet').value = customer.Street;
        document.getElementById('editCustomerBuildingNumber').value = customer.BuildingNumber;
        document.getElementById('editCustomerApartmentNumber').value = customer.ApartmentNumber;
        document.getElementById('editCustomerPostalCode').value = customer.PostalCode;
        document.getElementById('editCustomerFullAddress').value = customer.FullAddress;


        // Show the modal
        const editModal = new bootstrap.Modal(document.getElementById('editCustomerModal'));
        editModal.show();

    } catch (error) {
        console.error('There was a problem with your fetch operation:', error);
    }
}


fetchData("https://localhost:7182/CustomerAddress");
