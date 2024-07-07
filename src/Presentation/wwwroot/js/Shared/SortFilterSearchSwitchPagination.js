
let currentSort = '';
let currentSearch = '';
let currentPage = 1;
let currentPageSize = 10;

function updateUrl() {
    let url = new URL(window.location.href);
    url.searchParams.set('pageNumber', currentPage);

    if (currentSort) {
        url.searchParams.set('sortField', currentSort);
    } else {
        url.searchParams.delete('sortField');
    }

    if (currentSearch) {
        url.searchParams.set('searchTerm', currentSearch);
    } else {
        url.searchParams.delete('searchTerm');
    }

    window.location.href = url.toString();
}

function sort(sortField) {
    currentSort = sortField;
    currentPage = 1; // Reset to first page when sorting
    updateUrl();
}

function search() {
    currentSearch = document.getElementById('searchTerm').value.trim();
    currentPage = 1; // Reset to first page when searching
    updateUrl();
}

function changePage(pageNumber) {
    currentPage = pageNumber;
    updateUrl();
}

function changePageSize(pageSize) {
    currentPageSize = pageSize;
    currentPage = 1; // Reset to first page when changing page size
    updateUrl();
}

document.addEventListener('DOMContentLoaded', function () {
    getSortOptions();
    // Set up sort dropdown functionality
    let sortOptions = document.querySelectorAll('.sort-option');
    sortOptions.forEach(option => {
        option.addEventListener('click', function () {
            let sortField = this.getAttribute('data-sort');
            sort(sortField);
        });
    });

    // Set up search functionality
    let searchButton = document.querySelector('button[onclick="search()"]');
    if (searchButton) {
        searchButton.addEventListener('click', search);
    }

    let searchInput = document.getElementById('searchTerm');
    if (searchInput) {
        searchInput.addEventListener('keypress', function (e) {
            if (e.key === 'Enter') {
                search();
            }
        });
    }

    // Initialize current values from URL params
    let urlParams = new URLSearchParams(window.location.search);
    currentSort = urlParams.get('sortField') || '';
    currentSearch = urlParams.get('searchTerm') || '';
    currentPage = parseInt(urlParams.get('pageNumber')) || 1;
    currentPageSize = parseInt(urlParams.get('pageSize')) || 10;

    // Update the sort dropdown label
    if (currentSort) {
        let sortOption = document.querySelector(`[data-sort="${currentSort}"]`);
        if (sortOption) {
            document.getElementById('sortLabel').textContent = sortOption.textContent;
        }
    }

    // Set the search input value
    if (currentSearch) {
        document.getElementById('searchTerm').value = currentSearch;
    }
});






function getSortOptions() {
    const cachedOptions = localStorage.getItem('sortOptions');
    if (cachedOptions) {
        populateSortOptions(JSON.parse(cachedOptions));
    } else {
        fetchSortOptions();
    }
}

function fetchSortOptions() {
    const controller = getControllerName();
    fetch(`/${controller}/SortOptions`)
        .then(response => response.json())
        .then(data => {
            localStorage.setItem('sortOptions', JSON.stringify(data));
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
        a.textContent = option.displayString;
        li.appendChild(a);
        sortOptionsMenu.appendChild(li);
    });
}

function getControllerName() {
    let url = new URL(window.location.href);
    let parts = url.pathname.split('/').filter(part => part !== '');
    return parts.length > 0 ? parts[0] : '';
}