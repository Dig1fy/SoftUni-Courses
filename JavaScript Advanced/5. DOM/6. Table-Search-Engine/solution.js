function solve() {
   let tableData = Array.from(document.querySelectorAll('tbody > tr'));
   let searchBtn = document.querySelector("#searchBtn");
   let searchField = document.querySelector("#searchField");

   searchBtn.addEventListener('click', () => {
      let regex = new RegExp(searchField.value, 'gim');
      tableData.map(x => {
         x.classList.remove('select');
         if (x.innerHTML.match(regex) !== null) {
            x.className = 'select';
         }
      });

      searchField.value = '';
   });
}