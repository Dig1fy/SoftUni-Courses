function solve() {
   let tableRows = document.querySelectorAll('tr');

   Array.from(tableRows)
      .slice(1)
      .forEach(x => {
         x.addEventListener('click', function () {
            if (this.hasAttribute('style')) {
               this.removeAttribute('style')
            } else {
               Array.from(this.parentNode.children)
                  .forEach(x => x.removeAttribute('style'))

               this.style.background = "#413f5e";
            }
         });
      });
}