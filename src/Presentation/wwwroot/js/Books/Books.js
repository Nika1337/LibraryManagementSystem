// Global variables to store current state
let currentPage = 1;
let currentPageSize = 10;
let currentSort = '';
let currentSearchTerm = '';
let currentIncludeDeleted = true;

// Function to fetch data from the server
function fetchData() {
    $.ajax({
        url: '/Books/Books',
        method: 'GET',
        data: {
            pageNumber: currentPage,
            pageSize: currentPageSize,
            orderBy: currentSort,
            searchTerm: currentSearchTerm,
            includeDeleted: currentIncludeDeleted
        },
        success: function (response) {
            $('#cardView').html($(response).find('#cardView').html());
            $('#tableView').html($(response).find('#tableView').html());
            $('nav[aria-label="Page navigation"]').replaceWith($(response).find('nav[aria-label="Page navigation"]'));
            attachEventListeners();
        },
        error: function (xhr, status, error) {
            console.error('AJAX request failed:', error);
        }
    });
}

// Function to handle filtering
function filter() {
    currentSearchTerm = $('#searchTerm').val();
    currentIncludeDeleted = $('#includeDeleted').prop('checked');
    currentPage = 1; // Reset to first page when filtering
    fetchData();
}

// Function to handle sorting
function sort(sortOption) {
    currentSort = sortOption;
    currentPage = 1; // Reset to first page when sorting
    fetchData();

    // Update sort label
    var sortLabel = $('#sortLabel');
    var selectedOption = $('.sort-option[data-sort="' + sortOption + '"]');
    if (selectedOption.length) {
        sortLabel.text(selectedOption.text());
    }
}

// Function to handle pagination
function changePage(pageNumber) {
    currentPage = pageNumber;
    fetchData();
}

// Function to attach event listeners
function attachEventListeners() {
    // Sorting
    $('.sort-option').on('click', function () {
        sort($(this).data('sort'));
    });

    // Pagination
    $('.page-link').on('click', function (e) {
        e.preventDefault();
        var pageNumber = $(this).attr('href').split('pageNumber=')[1].split('&')[0];
        changePage(pageNumber);
    });
}

// Initial setup
$(document).ready(function () {
    attachEventListeners();

    // Search button
    $('button[onclick="filter()"]').on('click', filter);

    // Include deleted checkbox
    $('#includeDeleted').on('change', filter);
});