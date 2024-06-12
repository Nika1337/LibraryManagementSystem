


function filter() {
    var searchTerm = document.getElementById('searchTerm').value.toLowerCase();
    var includeDeleted = document.getElementById('includeDeleted').checked;
    var languageCards = document.querySelectorAll('.language-card');
    var languageRows = document.querySelectorAll('.language-row');

    languageCards.forEach(function (card) {
        var name = card.dataset.name.toLowerCase();
        var isActive = card.dataset.active === 'True';
        if (name.includes(searchTerm) && (includeDeleted || isActive)) {
            card.style.display = '';
        } else {
            card.style.display = 'none';
        }
    });

    languageRows.forEach(function (row) {
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
    var languageCards = Array.from(document.querySelectorAll('.language-card'));
    var languageRows = Array.from(document.querySelectorAll('.language-row'));

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
            default:
                return 0;
        }
    };

    languageCards.sort(sortFunction);
    languageRows.sort(sortFunction);

    var cardView = document.getElementById('cardView');
    cardView.innerHTML = '';
    languageCards.forEach(function (card) {
        cardView.appendChild(card);
    });

    var tableBody = document.querySelector('#languageTable tbody');
    tableBody.innerHTML = '';
    languageRows.forEach(function (row) {
        tableBody.appendChild(row);
    });
}