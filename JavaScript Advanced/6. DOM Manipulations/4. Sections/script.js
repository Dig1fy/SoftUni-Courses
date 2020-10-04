function create(words) {
   let divContent = document.getElementById('content');
   
   for (const word of words) {
      let div = document.createElement('div');
      let paragraph = document.createElement('p');
      paragraph.textContent = word;
      paragraph.style.display = 'none';
      div.appendChild(paragraph);
      divContent.appendChild(div);

      div.addEventListener('click', () => {
         paragraph.style.display = 'block';
      })
   }
}