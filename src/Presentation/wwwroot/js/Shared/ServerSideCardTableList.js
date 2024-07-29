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
    Array.from(url.searchParams.keys()).forEach(key => {
        if (!['pageNumber', 'pageSize', 'searchTerm', 'sortField'].includes(key)) {
            url.searchParams.delete(key);
        }
    });

    // Add new filter parameters
    $.each(currentFilters, (key, value) => {
        const trimmedKey = removeWhiteSpaces(key);

        if (typeof value === 'boolean') {
            url.searchParams.set(trimmedKey, value);
        } else if (typeof value === 'object' && 'start' in value && 'end' in value) {
            if (value.start) url.searchParams.set(`${trimmedKey}Start`, value.start);
            if (value.end) url.searchParams.set(`${trimmedKey}End`, value.end);
        } else if (Array.isArray(value)) {
            url.searchParams.set(trimmedKey, value.join(','));
        } else {
            url.searchParams.set(trimmedKey, value);
        }
    });

    window.location.href = url.toString();
}

function sort(element) {
    const $element = $(element);
    const sortField = $element.data('sort');
    currentSort = sortField;
    currentPage = 1; // Reset to first page when sorting
    updateUrl();
}


function search() {
    currentSearch = $('#searchTerm').val().trim();
    currentPage = 1; // Reset to first page when searching
    updateUrl();
}

function filter() {
    currentFilters = {};

    $('.filter-input').each(function () {
        const $input = $(this);
        const filterName = $input.data('filter');
        const filterType = $input.data('filterType');

        switch (filterType) {
            case 'checkbox':
                if ($input.is(':checked')) {
                    currentFilters[filterName] = true;
                }
                break;
            case 'range':
                if (!currentFilters[filterName]) {
                    currentFilters[filterName] = {};
                }
                if ($input.attr('id').endsWith('_start')) {
                    currentFilters[filterName].start = $input.val();
                } else if ($input.attr('id').endsWith('_end')) {
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
    urlParams.forEach((value, key) => {
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
    });

    // Update UI based on initial filter values
    Object.entries(currentFilters).forEach(([filterName, filterValue]) => {
        if (typeof filterValue === 'object' && ('start' in filterValue || 'end' in filterValue)) {
            // Handle range inputs
            $(`input.filter-input[data-filter="${filterName}"]`).each(function () {
                const $input = $(this);
                if ($input.attr('id').endsWith('_start') && filterValue.start) {
                    $input.val(filterValue.start);
                }
                if ($input.attr('id').endsWith('_end') && filterValue.end) {
                    $input.val(filterValue.end);
                }
            });
        } else if (filterValue === 'true' || filterValue === 'false') {
            // Handle boolean filters (single checkbox)
            $(`input.filter-input[data-filter="${filterName}"]`).prop('checked', filterValue === 'true');
        } else if (Array.isArray(filterValue)) {
            // Handle list filters (multiple checkboxes)
            filterValue.forEach(value => {
                $(`input.filter-input[data-filter="${filterName}"][value="${value}"]`).prop('checked', true);
            });
        } else {
            $(`input.filter-input[data-filter="${filterName}"][value="${filterValue}"]`).prop('checked', true);
        }
    });

    updateSortDropdownLabel();
    updateSearchInputValue();
}

function updateSortDropdownLabel() {
    if (currentSort) {
        const sortOption = $(`[data-sort="${currentSort}"]`);
        if (sortOption.length) {
            $('#sortLabel').text(sortOption.text());
        }
    }
}

function updateSearchInputValue() {
    if (currentSearch) {
        $('#searchTerm').val(currentSearch);
    }
}
