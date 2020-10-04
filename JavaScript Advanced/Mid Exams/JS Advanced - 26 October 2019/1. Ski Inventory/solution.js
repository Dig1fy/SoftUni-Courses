function solve() {
   let priceCounter = 0;
   let itemInputs = document.querySelectorAll('#add-new > input');
   let addButton = document.querySelector('#add-new > button');
   let availableProducts = document.querySelector('#products ul');
   let myProducts = document.querySelector('#myProducts');
   let totalPriceRef = document.querySelector("#myProducts").previousElementSibling;

   let filterInput = document.querySelector('#filter');
   let filterButton = document.querySelector("#products > div > button");
   let buyButton = document.querySelector('#myProducts > button');

   addButton.addEventListener('click', addItemHandler);
   filterButton.addEventListener('click', filterItemsHandler);
   availableProducts.addEventListener('click', addProductsToClientsListHandler);
   buyButton.addEventListener('click', buyProductsHandler);

   function buyProductsHandler(e) {
      myProducts.querySelector('ul').textContent = "";
      priceCounter = 0;
      totalPriceRef.textContent = `Total Price: ${priceCounter.toFixed(2)}`;
   }
   function addProductsToClientsListHandler(e) {
      let buttonTarget = e.target.tagName;

      if (buttonTarget === 'BUTTON') {

         let currentProductQyRef = e.target.parentNode.parentNode.querySelector('strong');
         let productQy = (Number(currentProductQyRef.textContent.substring(10)));
         if (productQy > 0) {
            productQy--;

            currentProductQyRef.textContent = `Available: ${productQy}`;

            let currentProduct = e.target.parentNode.parentNode.querySelector('span');
            let newListItem = document.createElement('li');
            newListItem.textContent = currentProduct.textContent;

            let currentProductPrice = e.target.parentNode.querySelector('strong');
            let itemsPrice = document.createElement('strong');
            itemsPrice.textContent = (Number(currentProductPrice.textContent)).toFixed(2);

            newListItem.appendChild(itemsPrice);
            myProducts.querySelector('ul').appendChild(newListItem);
            priceCounter += Number(currentProductPrice.textContent);

            totalPriceRef.textContent = `Total Price: ${priceCounter.toFixed(2)}`;
         }

         if (productQy === 0) {
            e.target.parentNode.parentNode.remove();
         }
      }
   }
   function addItemHandler(e) {
      e.preventDefault();
      let newLi = document.createElement('li');
      let itemName = document.createElement('span');
      itemName.textContent = itemInputs[0].value;

      let itemQuantity = document.createElement('strong');
      itemQuantity.textContent = `Available: ${Number(itemInputs[1].value)}`;
      newLi.appendChild(itemName);
      newLi.appendChild(itemQuantity);

      let newDiv = document.createElement('div');
      let itemPrice = document.createElement('strong');
      itemPrice.textContent = (Number(itemInputs[2].value)).toFixed(2);
      let addToClientListBtn = document.createElement('button');
      addToClientListBtn.textContent = `Add to Client's List`;

      newDiv.appendChild(itemPrice);
      newDiv.appendChild(addToClientListBtn);
      newLi.appendChild(newDiv);

      availableProducts.appendChild(newLi);
   }
   function filterItemsHandler() {
      let filterValue = filterInput.value;

      Array.from(availableProducts.children).forEach(el => {

         let currentItemName = el.querySelector('span');

         if (currentItemName.textContent.toLowerCase().includes(filterValue.toLowerCase())) {
            el.style.display = 'block';
         } else {
            el.style.display = 'none';
         }
      })
   }
}

