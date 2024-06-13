

function filter() {
    var searchTerm = document.getElementById('searchTerm').value.toLowerCase();
    var includeDeleted = document.getElementById('includeDeleted').checked;
    var employeeCards = document.querySelectorAll('.employee-card');
    var employeeRows = document.querySelectorAll('.employee-row');

    employeeCards.forEach(function (card) {
        var name = card.dataset.firstname.toLowerCase() + ' ' + card.dataset.lastname.toLowerCase();
        var username = card.dataset.username.toLowerCase();
        var isActive = card.dataset.active === 'True';
        if ((name.includes(searchTerm) || username.includes(searchTerm)) && (includeDeleted || isActive)) {
            card.style.display = '';
        } else {
            card.style.display = 'none';
        }
    });

    employeeRows.forEach(function (row) {
        var name = row.dataset.firstname.toLowerCase() + ' ' + row.dataset.lastname.toLowerCase();
        var username = row.dataset.username.toLowerCase();
        var isActive = row.dataset.active === 'True';
        if ((name.includes(searchTerm) || username.includes(searchTerm)) && (includeDeleted || isActive)) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
}

function sort(sortType) {
    var employeeCards = Array.from(document.querySelectorAll('.employee-card'));
    var employeeRows = Array.from(document.querySelectorAll('.employee-row'));

    var sortFunction = function (a, b) {
        var aData, bData;
        switch (sortType) {
            case 'username':
                aData = a.dataset.username.toLowerCase();
                bData = b.dataset.username.toLowerCase();
                return aData.localeCompare(bData);
            case 'usernameDesc':
                aData = a.dataset.username.toLowerCase();
                bData = b.dataset.username.toLowerCase();
                return bData.localeCompare(aData);
            case 'firstName':
                aData = a.dataset.firstname.toLowerCase();
                bData = b.dataset.firstname.toLowerCase();
                return aData.localeCompare(bData);
            case 'firstNameDesc':
                aData = a.dataset.firstname.toLowerCase();
                bData = b.dataset.firstname.toLowerCase();
                return bData.localeCompare(aData);
            case 'lastName':
                aData = a.dataset.lastname.toLowerCase();
                bData = b.dataset.lastname.toLowerCase();
                return aData.localeCompare(bData);
            case 'lastNameDesc':
                aData = a.dataset.lastname.toLowerCase();
                bData = b.dataset.lastname.toLowerCase();
                return bData.localeCompare(aData);
            case 'startDate':
                aData = new Date(a.dataset.startdate);
                bData = new Date(b.dataset.startdate);
                return aData - bData;
            case 'startDateDesc':
                aData = new Date(a.dataset.startdate);
                bData = new Date(b.dataset.startdate);
                return bData - aData;
            case 'dateOfBirth':
                aData = new Date(a.dataset.dateofbirth);
                bData = new Date(b.dataset.dateofbirth);
                return aData - bData;
            case 'dateOfBirthDesc':
                aData = new Date(a.dataset.dateofbirth);
                bData = new Date(b.dataset.dateofbirth);
                return bData - aData;
            default:
                return 0;
        }
    };

    employeeCards.sort(sortFunction);
    employeeRows.sort(sortFunction);

    var cardView = document.getElementById('cardView');
    cardView.innerHTML = '';
    employeeCards.forEach(function (card) {
        cardView.appendChild(card);
    });

    var tableBody = document.querySelector('#employeeTable tbody');
    tableBody.innerHTML = '';
    employeeRows.forEach(function (row) {
        tableBody.appendChild(row);
    });
}