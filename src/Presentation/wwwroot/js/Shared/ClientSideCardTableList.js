
function search() {
    filter();
}

function filter() {
    var searchTerm = document.getElementById('searchTerm').value.toLowerCase();
    var cards = document.querySelectorAll('.list-card');
    var rows = document.querySelectorAll('.table-row');

    cards.forEach(function (card) {
        var matchesSearchTerm = searchableFieldNames.some(field => card.dataset[field].toLowerCase().includes(searchTerm));
        var isActive = card.dataset.active === undefined || card.dataset.active === 'True';

        if (matchesSearchTerm) {
            card.style.display = '';
        } else {
            card.style.display = 'none';
        }
    });

    rows.forEach(function (row) {
        var matchesSearchTerm = searchableFieldNames.some(field => row.dataset[field].toLowerCase().includes(searchTerm));
        var isActive = row.dataset.active === undefined || row.dataset.active === 'True';

        if (matchesSearchTerm) {
            row.style.display = '';
        } else {
            row.style.display = 'none';
        }
    });
}

function sort(element) {
    var sortType = element.getAttribute('data-sort');
    var sortLabel = document.getElementById('sortLabel');

    sortLabel.innerText = element.innerText;

    var cards = Array.from(document.querySelectorAll('.list-card'));
    var rows = Array.from(document.querySelectorAll('.table-row'));

    var sortFunction = getSortFunction(sortType);

    cards.sort(sortFunction);
    rows.sort(sortFunction);

    updateView('#cardView', cards);
    updateView('#table tbody', rows);
}

function getSortFunction(sortType) {
    return function (a, b) {
        var aData, bData;
        switch (sortType) {
            case 'title':
                return compareStrings(a.dataset.title, b.dataset.title);
            case 'titleDesc':
                return compareStrings(b.dataset.title, a.dataset.title);
            case 'releaseDate':
                return compareDates(a.dataset.releasedate, b.dataset.releasedate);
            case 'releaseDateDesc':
                return compareDates(b.dataset.releasedate, a.dataset.releasedate);
            case 'name':
                return compareStrings(a.dataset.name, b.dataset.name);
            case 'nameDesc':
                return compareStrings(b.dataset.name, a.dataset.name);
            case 'dateOfBirth':
                return compareDates(a.dataset.dateofbirth, b.dataset.dateofbirth);
            case 'dateOfBirthDesc':
                return compareDates(b.dataset.dateofbirth, a.dataset.dateofbirth);
            case 'username':
                return compareStrings(a.dataset.username, b.dataset.username);
            case 'usernameDesc':
                return compareStrings(b.dataset.username, a.dataset.username);
            case 'firstName':
                return compareStrings(a.dataset.firstname, b.dataset.firstname);
            case 'firstNameDesc':
                return compareStrings(b.dataset.firstname, a.dataset.firstname);
            case 'lastName':
                return compareStrings(a.dataset.lastname, b.dataset.lastname);
            case 'lastNameDesc':
                return compareStrings(b.dataset.lastname, a.dataset.lastname);
            case 'startDate':
                return compareDates(a.dataset.startdate, b.dataset.startdate);
            case 'startDateDesc':
                return compareDates(b.dataset.startdate, a.dataset.startdate);
            default:
                return 0;
        }
    };
}

function compareStrings(a, b) {
    return a.toLowerCase().localeCompare(b.toLowerCase());
}

function compareDates(a, b) {
    return new Date(a) - new Date(b);
}

function updateView(containerSelector, elements) {
    var container = document.querySelector(containerSelector);
    container.innerHTML = '';
    elements.forEach(function (element) {
        container.appendChild(element);
    });
}



function initializeCurrentValues() {
    // Empty on purpose, nothing to initialize
}