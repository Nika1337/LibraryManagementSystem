
// Function to populate metrics dropdown
function populateMetrics() {
    var subject = document.getElementById('Subject').value;
    var metricSelect = document.getElementById('Metric');

    // Clear the current options
    metricSelect.innerHTML = `<option value="">${selectAMetricText}</option>`;

    if (subject && subjectsWithMetrics[subject]) {
        // Enable the metric dropdown and populate options
        metricSelect.disabled = false;
        subjectsWithMetrics[subject].forEach(function (metric) {
            var option = document.createElement('option');
            option.value = metric;
            option.textContent = metric;
            metricSelect.appendChild(option);
        });
    } else {
        // Disable the metric dropdown if no subject is selected
        metricSelect.disabled = true;
    }
}

// Function to navigate to the report
function navigateToReport() {
    var subject = document.getElementById('Subject');
    var metric = document.getElementById('Metric');
    var year = document.getElementById('Year');

    // Remove previous error classes
    subject.classList.remove('input-error');
    metric.classList.remove('input-error');
    year.classList.remove('input-error');

    let valid = true;

    // Validate subject, metric, and year
    if (!subject.value) {
        subject.classList.add('input-error'); // Highlight subject if missing
        valid = false;
    }

    if (!metric.value) {
        metric.classList.add('input-error'); // Highlight metric if missing
        valid = false;
    }

    if (!year.value) {
        year.classList.add('input-error'); // Highlight year if missing
        valid = false;
    }

    // If all fields are valid, proceed with navigation
    if (valid) {
        window.location.href = `/Reports/${subject.value}/${metric.value}/${year.value}`;
    }
}

// Function to download report
function downloadReport() {
    var reportName = document.getElementById('ReportName');
    var year = document.getElementById('DownloadYear');

    // Remove previous error classes
    reportName.classList.remove('input-error');
    year.classList.remove('input-error');

    let valid = true;

    // Validate reportName and year
    if (!reportName.value) {
        reportName.classList.add('input-error'); // Highlight report name if missing
        valid = false;
    }

    if (!year.value) {
        year.classList.add('input-error'); // Highlight year if missing
        valid = false;
    }

    // If all fields are valid, proceed with download
    if (valid) {
        window.location.href = `/Reports/${reportName.value}/${year.value}`;
    }
}
