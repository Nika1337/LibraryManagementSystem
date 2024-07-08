

document.addEventListener('DOMContentLoaded', function () {

   

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

    // Set the checkbox state
    document.getElementById('includeDeleted').checked = currentShouldIncludeDeleted;

});


