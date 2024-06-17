

function filter() {
    var searchTerm = document.getElementById('searchTerm').value.toLowerCase();
    var includeDeleted = document.getElementById('includeDeleted').checked;
    var bookCards = document.querySelectorAll('.book-card');
    var bookRows = document.querySelectorAll('.book-row');

    bookCards.forEach(function (card) {
        var title = card.dataset.title.toLowerCase();
        var isActive = card.dataset.active === 'True';

        if (title.includes(searchTerm) && (includeDeleted || isActive)) {
            card.style.display = '';
        } else {
            card.style.display = 'none';
        }
    });

    bookRows.forEach(function (row) {
        var title = row.dataset.title.toLowerCase();
        var isActive = row.dataset.active === 'True';

        if (title.includes(searchTerm) && (includeDeleted || isActive)) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
}

function sort(sortType) {
    var bookCards = Array.from(document.querySelectorAll('.book-card'));
    var bookRows = Array.from(document.querySelectorAll('.book-row'));

    var sortFunction = function (a, b) {
        var aData, bData;
        switch (sortType) {
            case 'title':
                aData = a.dataset.title.toLowerCase();
                bData = b.dataset.title.toLowerCase();
                return aData.localeCompare(bData);
            case 'titleDesc':
                aData = a.dataset.title.toLowerCase();
                return bData.localeCompare(aData);
            case 'releaseDate':
                aData = new Date(a.dataset.releasedate);
                bData = new Date(b.dataset.releasedate);
                return aData - bData;
            case 'releaseDateDesc':
                aData = new Date(a.dataset.releasedate);
                bData = new Date(b.dataset.releasedate);
                return bData - aData;
            default:
                return 0;
        }
    };

    bookCards.sort(sortFunction);
    bookRows.sort(sortFunction);

    var cardView = document.getElementById('cardView');
    cardView.innerHTML = '';
    bookCards.forEach(function (card) {
        cardView.appendChild(card);
    });

    var tableBody = document.querySelector('#bookTable tbody');
    tableBody.innerHTML = '';
    bookRows.forEach(function (row) {
        tableBody.appendChild(row);
    });
}