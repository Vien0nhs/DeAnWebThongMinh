let responses = {};

fetch('chatBox/responses.json')
    .then(response => response.json())
    .then(data => {
        responses = data;
    })
    .catch(error => console.error('Error loading responses:', error));
