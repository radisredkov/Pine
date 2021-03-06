"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
//document.getElementById("SendMessage").disabled = true;

connection.on("ReceiveMessage", function (data) {

     console.log(data);
    var message = document.createElement("div")
    message.classList.add('message')

    var header = document.createElement("header")
    header.appendChild(document.createTextNode(data.senderName))

    var p = document.createElement("p")
    p.appendChild(document.createTextNode(data.text))        

    var footer = document.createElement("footer")
    footer.appendChild(document.createTextNode(data.time))

    message.appendChild(header);
    message.appendChild(p);
    message.appendChild(footer);

    document.querySelector('chat-body').append(message);


});

var _connectionId = '';



var joinChat = function () {
    var url = '/chat/JoinChat/' + _connectionId + '/@Model.senderName'
    axios.post(url, null)
        .then(res => {
            console.log("Chat Joined!", res);
        })
        .catch(err => {
            console.err("Failed to join chat!", res)
        }
           
}

connection.start().then(function () {
    connection.invoke('getConnectionId')
        .then(function (connectionId) {
            _connectionId = connectionId
            joinChat();
        })
}).catch(function (err) {
    console.log(err)
});



var sendMessage = function (event) {
    event.preventDefault();

    var data = new FormData(event.target);
    document.getElementById('message-input').value = '';
    axios.post('Chat/SendMessage', data)
        .then(res => {
            console.log("Message sent!")
        }).catch(err => {
            console.log("Failed to send message!")
        })
}



//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});