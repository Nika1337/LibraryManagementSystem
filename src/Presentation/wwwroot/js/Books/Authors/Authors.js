


function filter() {
    var searchTerm = document.getElementById('searchTerm').value.toLowerCase();
    var includeDeleted = document.getElementById('includeDeleted').checked;
    var authorCards = document.querySelectorAll('.author-card');
    var authorRows = document.querySelectorAll('.author-row');

    authorCards.forEach(function (card) {
        var name = card.dataset.name.toLowerCase();
        var isActive = card.dataset.active === 'True';
        if (name.includes(searchTerm) && (includeDeleted || isActive)) {
            card.style.display = '';
        } else {
            card.style.display = 'none';
        }
    });

    authorRows.forEach(function (row) {
        var name = row.dataset.name.toLowerCase();
        var isActive = row.dataset.active === 'True';
        if (name.includes(searchTerm) && (includeDeleted || isActive)) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
}


function sort(sortType) {
    var authorCards = Array.from(document.querySelectorAll('.author-card'));
    var authorRows = Array.from(document.querySelectorAll('.author-row'));

    var sortFunction = function (a, b) {
        var aData, bData;
        switch (sortType) {
            case 'name':
                aData = a.dataset.name.toLowerCase();
                bData = b.dataset.name.toLowerCase();
                return aData.localeCompare(bData);
            case 'nameDesc':
                aData = a.dataset.name.toLowerCase();
                bData = b.dataset.name.toLowerCase();
                return bData.localeCompare(aData);
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

    authorCards.sort(sortFunction);
    authorRows.sort(sortFunction);

    var cardView = document.getElementById('cardView');
    cardView.innerHTML = '';
    authorCards.forEach(function (card) {
        cardView.appendChild(card);
    });

    var tableBody = document.querySelector('#authorTable tbody');
    tableBody.innerHTML = '';
    authorRows.forEach(function (row) {
        tableBody.appendChild(row);
    });
}