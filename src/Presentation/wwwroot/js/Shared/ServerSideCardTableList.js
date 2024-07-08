let currentSort = '';
let currentSearch = '';
let currentPage = 1;
let currentPageSize = 10;
let currentShouldIncludeDeleted = true;

function updateUrl() {
    let url = new URL(window.location.href);
    url.searchParams.set('pageNumber', currentPage);
    url.searchParams.set('shouldIncludeDeleted', currentShouldIncludeDeleted);

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


function sort(element) {
    const sortField = element.getAttribute('data-sort');
    currentSort = sortField;
    currentPage = 1; // Reset to first page when sorting
    updateUrl();
}



function search() {
    currentSearch = document.getElementById('searchTerm').value.trim();
    currentPage = 1; // Reset to first page when searching
    updateUrl();
}



function filter() {
    const checkbox = document.getElementById('includeDeleted');
    currentShouldIncludeDeleted = checkbox.checked;
    updateUrl();
}





// Paging
function changePage(pageNumber) {
    currentPage = pageNumber;
    updateUrl();
}

function changePageSize(pageSize) {
    currentPageSize = pageSize;
    currentPage = 1; // Reset to first page when changing page size
    updateUrl();
}


function initializeCurrentValues() {
    // Initialize current values from URL params
    let urlParams = new URLSearchParams(window.location.search);
    currentSort = urlParams.get('sortField') || '';
    currentSearch = urlParams.get('searchTerm') || '';
    currentPage = parseInt(urlParams.get('pageNumber')) || 1;
    currentPageSize = parseInt(urlParams.get('pageSize')) || 10;
    currentShouldIncludeDeleted = urlParams.get('shouldIncludeDeleted') !== 'false';
}