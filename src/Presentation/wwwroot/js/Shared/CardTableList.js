/*
    This file is for CardTableLayout, it shouldn't be used on its own, because several functions need to be implemented.
    functions need to be implemented:
    - search()
    - filter()
    - sort(sortField)
    - initializeCurrentValues()
*/

$(function () {
    initializeView();
    setUpSortDropdown();
    setUpFilteringChoices();
    setUpSearchFunctionality();
    initializeCurrentValues();
});
function initializeView() {
    var savedView = localStorage.getItem('viewPreference') || 'table';
    toggleView(savedView);
}

function toggleView(view) {
    var $cardView = $('#cardView');
    var $tableView = $('#tableView');
    var $cardViewIcon = $('#cardViewIcon');
    var $tableViewIcon = $('#tableViewIcon');

    if (view === 'card') {
        $cardView.removeClass('d-none');
        $tableView.addClass('d-none');
        $cardViewIcon.addClass('selected');
        $tableViewIcon.removeClass('selected');
    } else if (view === 'table') {
        $tableView.removeClass('d-none');
        $cardView.addClass('d-none');
        $tableViewIcon.addClass('selected');
        $cardViewIcon.removeClass('selected');
    }

    localStorage.setItem('viewPreference', view);
}

function setUpSortDropdown() {
    getSortOptions();

    $('.sort-option').on('click', function () {
        sort(this);
    });
}

function getSortOptions() {
    const cachedOptions = localStorage.getItem(`sortOptions${viewName}`);
    if (cachedOptions) {
        populateSortOptions(JSON.parse(cachedOptions));
    } else {
        fetchSortOptions();
    }
}

function fetchSortOptions() {
    const path = getPath();
    $.getJSON(`${path}/SortOptions`)
        .done(function (data) {
            localStorage.setItem(`sortOptions${viewName}`, JSON.stringify(data));
            populateSortOptions(data);
        })
        .fail(function (error) {
            console.error('Error fetching sort options:', error);
        });
}

function populateSortOptions(options) {
    const $sortOptionsMenu = $('#sortOptionsMenu');
    $sortOptionsMenu.empty();

    options.forEach(option => {
        const $li = $('<li>');
        const $a = $('<a>', {
            class: 'dropdown-item sort-option',
            'data-sort': option.key,
            text: option.value
        });
        $li.append($a);
        $sortOptionsMenu.append($li);
    });
}

function getPath() {
    return window.location.pathname;
}

function setUpFilteringChoices() {
    getFilterChoices();
}

function getFilterChoices() {
    const cachedOptions = localStorage.getItem(`filterOptions${viewName}`);
    if (cachedOptions) {
        populateFilterOptions(JSON.parse(cachedOptions));
    } else {
        fetchFilterOptions();
    }
}

function fetchFilterOptions() {
    const path = getPath();
    $.getJSON(`${path}/FilterOptions`)
        .done(function (data) {
            localStorage.setItem(`filterOptions${viewName}`, JSON.stringify(data));
            populateFilterOptions(data);
            initializeCurrentValues();
        })
        .fail(function (error) {
            console.error('Error fetching filter options:', error);
        });
}

function populateFilterOptions(options) {
    const $filterOptionsContainer = $('#filterOptions');
    $filterOptionsContainer.empty();

    options.forEach(optionJson => {
        const option = JSON.parse(optionJson);
        const $filterGroup = $('<div>', { class: 'mb-3' });

        switch (option.Type) {
            case 'bool':
                $filterGroup.html(`
                    <div class="form-check">
                        <input class="form-check-input filter-input" type="checkbox" value="${option.Name}" id="${option.Name}" data-filter="${removeWhiteSpaces(option.Name)}" data-filter-type="checkbox">
                        <label class="form-check-label" for="${option.Name}">${option.Name}</label>
                    </div>
                `);
                break;
            case 'range':
                $filterGroup.html(`
                    <h6>${option.Name}</h6>
                    <div class="input-group">
                        <input type="${option.RangeFilterOptionType}" class="form-control filter-input" id="${option.Name}_start" data-filter="${option.Name}" data-filter-type="range" placeholder="Start">
                        <input type="${option.RangeFilterOptionType}" class="form-control filter-input" id="${option.Name}_end" data-filter="${option.Name}" data-filter-type="range" placeholder="End">
                    </div>
                `);
                break;
            case 'list':
                $filterGroup.html(`<h6>${option.Name}</h6>`);
                option.Choices.forEach(choice => {
                    $filterGroup.append(`
                        <div class="form-check">
                            <input class="form-check-input filter-input" type="checkbox" value="${choice}" id="${option.Name}_${choice}" data-filter="${option.Name}" data-filter-type="list">
                            <label class="form-check-label" for="${option.Name}_${choice}">${choice}</label>
                        </div>
                    `);
                });
                break;
        }

        $filterOptionsContainer.append($filterGroup);
    });
}

function setUpSearchFunctionality() {
    $('#searchTerm').on('keypress', function (e) {
        if (e.key === 'Enter') {
            search();
        }
    });
}

function removeWhiteSpaces(text) {
    return text.replace(/\s+/g, '');
}
