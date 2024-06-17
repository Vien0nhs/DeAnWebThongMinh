let responses = {};

fetch('chatBox/responses.json')
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        responses = data;
        console.log('Responses loaded:', responses); // Debugging output
    })
    .catch(error => console.error('Error loading responses:', error));

document.getElementById('send-button').addEventListener('click', () => {
    sendMessage();
});

document.getElementById('user-input').addEventListener('keypress', function (e) {
    if (e.key === 'Enter') {
        sendMessage();
    }
});

document.querySelectorAll('.dialogue-button').forEach(button => {
    button.addEventListener('click', () => {
        const message = button.getAttribute('data-message');
        sendMessage(message);
    });
});

function sendMessage(userMessage) {
    let message = userMessage || document.getElementById('user-input').value.trim();
    if (message !== '') {
        addMessage('user-message', message);

        setTimeout(() => {
            const botResponse = getBotResponse(message);
            addMessage('bot-message', botResponse);
        }, 1000);

        document.getElementById('user-input').value = '';
    }
}

function addMessage(className, text) {
    const messageElement = document.createElement('div');
    messageElement.className = `message ${className}`;
    messageElement.innerText = text;

    const chatboxBody = document.getElementById('chatbox-body');
    chatboxBody.appendChild(messageElement);
    chatboxBody.scrollTop = chatboxBody.scrollHeight;
}

function getBotResponse(userMessage) {
    const lowerCaseUserMessage = userMessage.toLowerCase(); // Chuyển đổi tin nhắn người dùng về chữ thường

    for (const key in responses) {
        if (responses.hasOwnProperty(key)) {
            const responseObj = responses[key];

            if (responseObj.keywords) {
                // Kiểm tra từ khóa
                for (let i = 0; i < responseObj.keywords.length; i++) {
                    const keyword = responseObj.keywords[i].toLowerCase();
                    // Sử dụng indexOf để kiểm tra từ khóa có tồn tại trong tin nhắn của người dùng
                    if (lowerCaseUserMessage.includes(keyword)) {
                        // Trả về câu trả lời ngẫu nhiên từ mảng response
                        const randomResponse = responseObj.response[Math.floor(Math.random() * responseObj.response.length)];
                        return randomResponse;
                    }
                }
            }
        }
    }

    return "Nếu có bất cứ điều gì hãy nhấn hỗ trợ.";
}


function checkForMath(message) {
    const trimmedMessage = message.replace(/\s+/g, '');
    const mathRegex = /^[\d+\-*/.()]+$/;

    if (mathRegex.test(trimmedMessage)) {
        try {
            const result = eval(trimmedMessage);
            return `${trimmedMessage} = ${result}`;
        } catch (error) {
            return "Có lỗi xảy ra khi tính toán.";
        }
    }

    return null;
}

// Toggle chatbox visibility
document.getElementById('chatbox-toggle').addEventListener('click', () => {
    const chatbox = document.getElementById('chatbox');
    if (chatbox.style.display === 'none' || chatbox.style.display === '') {
        chatbox.style.display = 'flex';
    } else {
        chatbox.style.display = 'none';
    }
});

document.getElementById('close-button').addEventListener('click', () => {
    document.getElementById('chatbox').style.display = 'none';
});
