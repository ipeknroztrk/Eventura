// Handle the click event on the ticket item
document.querySelectorAll('.event-item .btn-info').forEach(button => {
    button.addEventListener('click', function () {
        const parent = this.closest('.event-item');
        const eventTitle = parent.getAttribute('data-event-name');
        const eventDate = parent.getAttribute('data-event-date');
        const qrUrl = parent.getAttribute('data-qr-url');

        document.getElementById('eventTitle').textContent = eventTitle;
        document.getElementById('eventDate').textContent = 'Event Date: ' + new Date(eventDate).toLocaleDateString('tr-TR', {
            weekday: 'long', year: 'numeric', month: 'long', day: 'numeric'
        });
        document.getElementById('qrCodeImage').src = qrUrl;

        // Display the modal
        document.getElementById('ticketModal').style.display = 'block';
    });
});

// Close the modal when the close button is clicked
document.querySelector('.close-btn').addEventListener('click', function () {
    document.getElementById('ticketModal').style.display = 'none';
});

// Close the modal if the user clicks outside of the modal content
window.addEventListener('click', function (event) {
    if (event.target == document.getElementById('ticketModal')) {
        document.getElementById('ticketModal').style.display = 'none';
    }
});
