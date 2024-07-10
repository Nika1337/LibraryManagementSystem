let currentSort = '';
let currentSearch = '';
let currentPage = 1;
let currentPageSize = 10;
let currentFilters = {}; // Object to store current filter selections

function updateUrl() {
    let url = new URL(window.location.href);
    url.searchParams.set('pageNumber', currentPage);
    url.searchParams.set('pageSize', currentPageSize);

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


    // Clear existing filter parameters
    url.searchParams.forEach((value, key) => {
        if (key !== 'pageNumber' && key !== 'pageSize' && key !== 'searchTerm' && key !== 'sortField') {
            url.searchParams.delete(key);
        }
    });

    // Add new filter parameters
    Object.entries(currentFilters).forEach(([key, value]) => {
        if (typeof value === 'boolean') {
            url.searchParams.set(key, value);
        } else if (typeof value === 'object' && 'start' in value && 'end' in value) {
            if (value.start) url.searchParams.set(`${key}Start`, value.start);
            if (value.end) url.searchParams.set(`${key}End`, value.end);
        } else if (Array.isArray(value)) {
            url.searchParams.set(key, value.join(','));
        }
    });

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
    currentFilters = {};

    document.querySelectorAll('.filter-input').forEach(input => {
        const filterName = input.dataset.filter;
        const filterType = input.dataset.filterType;

        switch (filterType) {
            case 'checkbox':
                if (input.checked) {
                    currentFilters[filterName] = true;
                }
                break;
            case 'range':
                if (!currentFilters[filterName]) {
                    currentFilters[filterName] = {};
                }
                if (input.id.endsWith('_start')) {
                    currentFilters[filterName].start = input.value;
                } else if (input.id.endsWith('_end')) {
                    currentFilters[filterName].end = input.value;
                }
                break;
            case 'list':
                if (!currentFilters[filterName]) {
                    currentFilters[filterName] = [];
                }
                if (input.checked) {
                    currentFilters[filterName].push(input.value);
                }
                break;
        }
    });


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
    let urlParams = new URLSearchParams(window.location.search);
    currentSort = urlParams.get('sortField') || '';
    currentSearch = urlParams.get('searchTerm') || '';
    currentPage = parseInt(urlParams.get('pageNumber')) || 1;
    currentPageSize = parseInt(urlParams.get('pageSize')) || 10;

    // Initialize filters from URL params
    currentFilters = {};
    for (const [key, value] of urlParams.entries()) {
        if (!['sortField', 'searchTerm', 'pageNumber', 'pageSize'].includes(key)) {
            if (key.endsWith('Start') || key.endsWith('End')) {
                // Handle range filters
                const baseKey = key.replace(/(Start|End)$/, '');
                if (!currentFilters[baseKey]) currentFilters[baseKey] = {};
                currentFilters[baseKey][key.endsWith('Start') ? 'start' : 'end'] = value;
            } else {
                // Handle other filters (checkbox and list)
                currentFilters[key] = value.includes(',') ? value.split(',') : value;
            }
        }
    }

    // Update UI based on initial filter values
    Object.entries(currentFilters).forEach(([filterName, filterValue]) => {
        console.log(filterName);
        console.log(filterValue);
        if (typeof filterValue === 'object' && ('start' in filterValue || 'end' in filterValue)) {
            // Handle range inputs
            const startInput = document.querySelector(`input.filter-input[data-filter="${filterName}"][id="${filterName}_start"]`);
            const endInput = document.querySelector(`input.filter-input[data-filter="${filterName}"][id="${filterName}_end"]`);
            if (startInput && filterValue.start) {
                startInput.value = filterValue.start;
            }
            if (endInput && filterValue.end) {
                endInput.value = filterValue.end;
            }
        } else if (Array.isArray(filterValue)) {
            // Handle list filters (multiple checkboxes)
            filterValue.forEach(value => {
                const input = document.querySelector(`input.filter-input[data-filter="${filterName}"][value="${value}"]`);
                console.log(input);
                if (input) input.checked = true;
                console.log(document.querySelector(`input.filter-input[data-filter="${filterName}"][value="${value}"]`));
            });
        } else {
            // Handle boolean filters (single checkbox)
            const input = document.querySelector(`input.filter-input[data-filter="${filterName}"]`);

            console.log(input);
            if (input && input.type === 'checkbox') {
                input.checked = filterValue === 'true';
            }
        }
    });

    updateSortDropdownLabel();
    updateSearchInputValue();
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
