/*
    This file is for CardTableLayout, it shouldn't be use on its own, because several functions need to be implemented.
    functions need to  be implemented:
    - search()
    - filter()
    - sort(sortField)
    - initializeCurrentValues()
*/

document.addEventListener('DOMContentLoaded', function () {
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
    var cardView = document.getElementById('cardView');
    var tableView = document.getElementById('tableView');
    var cardViewIcon = document.getElementById('cardViewIcon');
    var tableViewIcon = document.getElementById('tableViewIcon');

    if (view === 'card') {
        cardView.classList.remove('d-none');
        tableView.classList.add('d-none');
        cardViewIcon.classList.add('selected');
        tableViewIcon.classList.remove('selected');
    } else if (view == 'table') {
        tableView.classList.remove('d-none');
        cardView.classList.add('d-none');
        tableViewIcon.classList.add('selected');
        cardViewIcon.classList.remove('selected');
    }

    // Store the choice in localStorage
    localStorage.setItem('viewPreference', view);
}



function setUpSortDropdown() {
    getSortOptions();

    // Set up sort dropdown functionality
    let sortOptions = document.querySelectorAll('.sort-option');
    sortOptions.forEach(option => {
        option.addEventListener('click', function () {
            sort(this);
        });
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
    fetch(`${path}/SortOptions`)
        .then(response => response.json())
        .then(data => {
            localStorage.setItem(`sortOptions${viewName}`, JSON.stringify(data));
            populateSortOptions(data);
        })
        .catch(error => console.error('Error fetching sort options:', error));
}

function populateSortOptions(options) {
    const sortOptionsMenu = document.getElementById('sortOptionsMenu');
    sortOptionsMenu.innerHTML = '';
    options.forEach(option => {
        const li = document.createElement('li');
        const a = document.createElement('a');
        a.className = 'dropdown-item sort-option';
        a.setAttribute('data-sort', option.key);
        a.textContent = option.value;
        li.appendChild(a);
        sortOptionsMenu.appendChild(li);
    });
}

function getPath() {
    let url = new URL(window.location.href);
    return url.pathname;
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
    fetch(`${path}/FilterOptions`)
        .then(response => response.json())
        .then(data => {
            localStorage.setItem(`filterOptions${viewName}`, JSON.stringify(data));
            populateFilterOptions(data);
            initializeCurrentValues();
        })
        .catch(error => console.error('Error fetching filter options:', error));
}

function populateFilterOptions(options) {
    const filterOptionsContainer = document.getElementById('filterOptions');
    filterOptionsContainer.innerHTML = '';

    options.forEach(optionJson => {
        const option = JSON.parse(optionJson);
        let filterGroup = document.createElement('div');
        filterGroup.className = 'mb-3';

        switch (option.Type) {
            case 'bool':
                filterGroup.innerHTML = `
                    <div class="form-check">
                        <input class="form-check-input filter-input" type="checkbox" value="${option.Name}" id="${option.Name}" data-filter="${removeWhiteSpaces(option.Name)}" data-filter-type="checkbox">
                        <label class="form-check-label" for="${option.Name}">${option.Name}</label>
                    </div>
                `;
                break;
            case 'range':
                filterGroup.innerHTML = `
                    <h6>${option.Name}</h6>
                    <div class="input-group">
                        <input type="${option.RangeFilterOptionType}" class="form-control filter-input" id="${option.Name}_start" data-filter="${option.Name}" data-filter-type="range" placeholder="Start">
                        <input type="${option.RangeFilterOptionType}" class="form-control filter-input" id="${option.Name}_end" data-filter="${option.Name}" data-filter-type="range" placeholder="End">
                    </div>
                `;
                break;
            case 'list':
                filterGroup.innerHTML = `<h6>${option.Name}</h6>`;
                option.Choices.forEach(choice => {
                    filterGroup.innerHTML += `
                        <div class="form-check">
                            <input class="form-check-input filter-input" type="checkbox" value="${choice}" id="${option.Name}_${choice}" data-filter="${option.Name}" data-filter-type="list">
                            <label class="form-check-label" for="${option.Name}_${choice}">${choice}</label>
                        </div>
                    `;
                });
                break;
        }

        filterOptionsContainer.appendChild(filterGroup);
    });
}




function setUpSearchFunctionality() {
    let searchInput = document.getElementById('searchTerm');
    if (searchInput) {
        searchInput.addEventListener('keypress', function (e) {
            if (e.key === 'Enter') {
                search();
            }
        });
    }
}

function removeWhiteSpaces(text) {
    return text.replace(/\s+/g, '');
}
