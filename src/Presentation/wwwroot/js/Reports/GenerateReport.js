$(function () {
    let subjectsWithMetrics = {};

    // Initialize Choices.js for Subject and Metric dropdowns
    const subjectChoices = new Choices('#Subject', {
        removeItemButton: false,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select a subject',
    });

    const metricChoices = new Choices('#Metric', {
        removeItemButton: false,
        searchEnabled: true,
        placeholder: true,
        placeholderValue: 'Select a metric',
    });

    // Fetch subjects with metrics once and store them
    $.get('/Reports/SubjectsWithMetrics', function (data) {
        subjectsWithMetrics = data;

        // Populate the Subject dropdown with subjects
        Object.keys(subjectsWithMetrics).forEach(subject => {
            subjectChoices.setChoices([{ value: subject, label: subject, selected: false, disabled: false }], 'value', 'label', false);
        });
    });

    // Event listener for Subject selection change
    $('#Subject').on('change', function () {
        // Clear previous metrics
        metricChoices.clearStore();

        // Get the selected subject
        const selectedSubject = $(this).val();

        // Populate Metric dropdown with metrics corresponding to the selected subject
        if (selectedSubject && subjectsWithMetrics[selectedSubject]) {
            const metrics = subjectsWithMetrics[selectedSubject];
            metrics.forEach(metric => {
                metricChoices.setChoices([{ value: metric, label: metric, selected: false, disabled: false }], 'value', 'label', false);
            });
        }
    });
});
