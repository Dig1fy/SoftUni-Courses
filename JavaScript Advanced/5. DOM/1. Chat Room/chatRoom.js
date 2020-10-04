function solve() {

   const sendBtn = document.getElementById("send");
   const messageContainer = document.getElementById("chat_input");

   if (sendBtn === null || messageContainer === null) {
      throw new Error("Something went wrong :))");
   }
   sendBtn.addEventListener("click", sendMessage);

   function sendMessage() {

      let message = messageContainer.value
      let newMessage = document.createElement('div');
      newMessage.classList.add('message', 'my-message');
      newMessage.textContent = message;
      document.getElementById('chat_messages').appendChild(newMessage);
      messageContainer.value = "";
   }
}

solve();
