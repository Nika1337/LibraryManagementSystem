

function searchGenres() {
    filterGenres();
}

function filterGenres() {
    var searchTerm = document.getElementById('searchTerm').value.toLowerCase();
    var includeDeleted = document.getElementById('includeDeleted').checked;
    var genreCards = document.querySelectorAll('.genre-card');
    var genreRows = document.querySelectorAll('.genre-row');

    genreCards.forEach(function (card) {
        var name = card.dataset.name.toLowerCase();
        var isActive = card.dataset.active === 'True';
        if (name.includes(searchTerm) && (includeDeleted || isActive)) {
            card.style.display = '';
        } else {
            card.style.display = 'none';
        }
    });

    genreRows.forEach(function (row) {
        var name = row.dataset.name.toLowerCase();
        var isActive = row.dataset.active === 'True';
        if (name.includes(searchTerm) && (includeDeleted || isActive)) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
}

document.querySelectorAll('.sort-option').forEach(function (element) {
    element.addEventListener('click', function () {
        var sortType = element.getAttribute('data-sort');
        var sortLabel = document.getElementById('sortLabel');
        sortLabel.innerText = element.innerText;
        sortGenres(sortType);
    });
});

function sortGenres(sortType) {
    var genreCards = Array.from(document.querySelectorAll('.genre-card'));
    var genreRows = Array.from(document.querySelectorAll('.genre-row'));

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

    genreCards.sort(sortFunction);
    genreRows.sort(sortFunction);

    var cardView = document.getElementById('cardView');
    cardView.innerHTML = '';
    genreCards.forEach(function (card) {
        cardView.appendChild(card);
    });

    var tableBody = document.querySelector('#genreTable tbody');
    tableBody.innerHTML = '';
    genreRows.forEach(function (row) {
        tableBody.appendChild(row);
    });
}