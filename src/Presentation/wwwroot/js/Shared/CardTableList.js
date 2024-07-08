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

    setUpSearchFunctionality();

    initializeCurrentValues();

    updateSortDropdownLabel();

    updateSearchInputValue();

    setCheckboxState();
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
        console.log(option);
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



function updateSortDropdownLabel() {
    if (currentSort) {
        let sortOption = document.querySelector(`[data-sort="${currentSort}"]`);
        if (sortOption) {
            document.getElementById('sortLabel').textContent = sortOption.textContent;
        }
    }
}


function updateSearchInputValue() {
    if (currentSearch) {
        document.getElementById('searchTerm').value = currentSearch;
    }
}



function setCheckboxState() {
    document.getElementById('includeDeleted').checked = currentShouldIncludeDeleted;
}

