let currentFilters = {};

function search() {
    filter();
}

function filter() {
    const searchTerm = $('#searchTerm').val().toLowerCase();
    const cards = $('.list-card');
    const rows = $('.table-row');

    // Update currentFilters based on filter inputs
    updateCurrentFilters();

    console.log(currentFilters);
    function checkElement(element) {
        const $element = $(element);
        console.log(element);

        // Check search term
        const matchesSearch = searchableFieldNames.some(field =>
            $element.data(field).toLowerCase().includes(searchTerm)
        );

        // Check filters
        const matchesFilters = Object.entries(currentFilters).every(([filterName, filterValue]) => {
            const formattedFilterName = removeWhiteSpaces(filterName).toLowerCase();
            console.log(formattedFilterName);
            console.log(filterValue);

            if (typeof filterValue === 'boolean') {
                return !filterValue || $element.data(formattedFilterName) === true;
            } else if (typeof filterValue === 'object' && 'start' in filterValue && 'end' in filterValue) {
                let value = $element.data(formattedFilterName);
                let start = filterValue.start ? filterValue.start : -Infinity;
                let end = filterValue.end ? filterValue.end : Infinity;

                // Convert value to appropriate type based on range type
                switch ($element.data(`${formattedFilterName}_rangetype`)) {
                    case 'datetime-local':
                    case 'date':
                        value = new Date(value).getTime();
                        start = new Date(start).getTime();
                        end = new Date(end).getTime();
                        break;
                    case 'number':
                        value = parseFloat(value);
                        start = parseFloat(start);
                        end = parseFloat(end);
                        break;
                }

                if (isNaN(start) && isNaN(end)) return true;
                else if (isNaN(start)) return value <= end;
                else if (isNaN(end)) return value >= start;
                else return value >= start && value <= end;
            } else if (Array.isArray(filterValue)) {
                return filterValue.includes($element.data(formattedFilterName));
            }
            return true;
        });

        return matchesSearch && matchesFilters;
    }

    cards.each(function () {
        $(this).toggle(checkElement(this));
    });

    rows.each(function () {
        $(this).toggle(checkElement(this));
    });
}

function updateCurrentFilters() {
    currentFilters = {};

    $('.filter-input').each(function () {
        const $input = $(this);
        const filterName = $input.data('filter');
        const filterType = $input.data('filterType');

        console.log(`input - ${$input.html()}`);
        console.log(`filterName - ${filterName}`);
        console.log(`filterType - ${filterType}`);

        switch (filterType) {
            case 'checkbox':
                currentFilters[filterName] = $input.is(':checked');
                break;
            case 'range':
                if (!currentFilters[filterName]) {
                    currentFilters[filterName] = {};
                }
                if (this.id.endsWith('_start')) {
                    currentFilters[filterName].start = $input.val();
                } else if (this.id.endsWith('_end')) {
                    currentFilters[filterName].end = $input.val();
                }
                break;
            case 'list':
                if (!currentFilters[filterName]) {
                    currentFilters[filterName] = [];
                }
                if ($input.is(':checked')) {
                    currentFilters[filterName].push($input.val());
                }
                break;
        }
    });
}

function sort(element) {
    const $element = $(element);
    const sortType = $element.data('sort');
    $('#sortLabel').text($element.text());
    const cards = $('.list-card').toArray();
    const rows = $('.table-row').toArray();
    const sortFunction = getSortFunction(sortType);
    cards.sort(sortFunction);
    rows.sort(sortFunction);
    updateView('#cardView', cards);
    updateView('#table tbody', rows);
}

function initializeCurrentValues() {
    // Empty on purpose, nothing to initialize
}
function getSortFunction(sortType) {
    return function (a, b) {
        var aData, bData;
        switch (sortType) {
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