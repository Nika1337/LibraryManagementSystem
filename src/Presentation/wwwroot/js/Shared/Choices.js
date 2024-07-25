
// loading choices
function loadDropdownData(url, choicesInstance, preselectedValues) {
    fetch(url)
        .then(response => response.json())
        .then(data => {
            const choices = data.map(item => ({
                value: item.id,
                label: item.name,
                selected: preselectedValues.includes(item.id)
            }));
            choicesInstance.setChoices(choices, 'value', 'label', true);
        });
}