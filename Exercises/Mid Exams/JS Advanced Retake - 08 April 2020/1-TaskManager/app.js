// function solve() {

//     let html = {
//         taskInputRef: document.querySelector("#task"),
//         descriptionInputRef: document.querySelector("#description"),
//         dateInputRef: document.querySelector("#date"),
//         addBtnRef: document.querySelector("#add"),
//         openSectionRef: document.querySelector("body > main > div > section:nth-child(2) > div:nth-child(2)"),
//         progressRef: document.querySelector("#in-progress"),
//         completeRef: document.querySelector("body > main > div > section:nth-child(4) > div:nth-child(2)")
//     }

//     html.addBtnRef.addEventListener('click', addHandle);

//     function addHandle(e) {
//         e.preventDefault();

//         let task = html.taskInputRef.value;
//         let description = html.descriptionInputRef.value;
//         let date = html.dateInputRef.value;

//         if (task && description && date) {

//             let article = document.createElement('article');
//             let h3 = document.createElement('h3'); //1
//             h3.textContent = task;

//             let desciptionPar = document.createElement('p'); //2
//             desciptionPar.textContent = `Description: ${description}`

//             let datePar = document.createElement('p'); //3
//             datePar.textContent = `Due Date: ${date}`;

//             let divWrapper = document.createElement('div'); //4
//             divWrapper.className = 'flex';
//             let startBtn = document.createElement('button')
//             startBtn.className = 'green';
//             startBtn.textContent = "Start";
//             startBtn.addEventListener('click', startHandler)
//             let deleteBtn = document.createElement('button');
//             deleteBtn.className = 'red';
//             deleteBtn.textContent = "Delete";
//             deleteBtn.addEventListener('click', deleteHandler)

//             divWrapper.appendChild(startBtn)
//             divWrapper.appendChild(deleteBtn)

//             article = appendChildrenToParent([h3, desciptionPar, datePar, divWrapper], article)

//             html.openSectionRef.appendChild(article);
//         }
//     }

//     function appendChildrenToParent(children, parent) {
//         children.forEach((c) => parent.appendChild(c));
//         return parent;
//     }

//     function startHandler(e) {
//         let currentDiv = e.target.parentNode
//         let currentArticle = e.target.parentNode.parentNode;
//         currentDiv.innerHTML = '';

//         let deleteBtn = document.createElement('button');
//         deleteBtn.className = 'red';
//         deleteBtn.textContent = 'Delete';
//         deleteBtn.addEventListener('click', deleteHandler)

//         let finishBtn = document.createElement('button');
//         finishBtn.className = 'orange'
//         finishBtn.textContent = 'Finish'
//         finishBtn.addEventListener('click', finishHandler)

//         currentDiv.appendChild(deleteBtn)
//         currentDiv.appendChild(finishBtn)

//         currentArticle.appendChild(currentDiv);

//         html.progressRef.appendChild(currentArticle)

//     }
//     function deleteHandler(e) {
//         e.target.parentNode.parentNode.remove();
//     }

//     function finishHandler(e) {
//         let div = e.target.parentNode.parentNode;
//         e.target.parentNode.remove()

//         html.completeRef.appendChild(div)
//     }
// }

function solve() {
 
 
    var task  =  document.getElementById('task')
   
    var description  =  document.getElementById('description')
    var dueDate = document.getElementById('date')
 
    var addBtn = document.getElementById('add')
    var openSection = document.querySelectorAll("section")[1]
    var openDiv = openSection.querySelectorAll('div')[1]
    console.log(openDiv)
   
    var progressSection = document.querySelectorAll("section")[2]
    var progressDiv = document.createElement('div')
    var completeSection = document.querySelectorAll("section")[3]
    var completeDiv = completeSection.querySelectorAll('div')[1]
    console.log(progressDiv)
   
    addBtn.addEventListener('click', addTask)
 
 
    function addTask(e){
 
        e.preventDefault()
 
        if(task.value == '' || description.value == '' ||dueDate.value == ''){
       
        }else{
           
       
            var  article = document.createElement('article')
            var h3 = document.createElement('h3')
            var pDescription = document.createElement('p')
            var pDate = document.createElement('p')
            var divButtons = document.createElement('div')
            var delButton =document.createElement('button')
            var startButton =document.createElement('button')
            var finishButton =document.createElement('button')
           
 
h3.innerText = task.value
pDescription.innerText = `Description: ${description.value}`
pDate.innerText = `Due Date: ${date.value}`
delButton.innerText = "Delete"
startButton.innerText = "Start"
divButtons.className = "flex"
delButton.className = "red"
startButton.className = "green"
 
 
 console.log(openDiv.textContent);
openDiv.appendChild(article)
article.appendChild(h3)
article.appendChild(pDescription)
article.appendChild(pDate)
article.appendChild(divButtons)
divButtons.appendChild(startButton)
divButtons.appendChild(delButton)
 
            task.innerText == ''
            description.innerText == ''
            dueDate.innerText == ''
 
 
delButton.addEventListener('click', delEvent)
function delEvent(e){
    e.preventDefault()
    openDiv.removeChild(article)
    console.log(openDiv.textContent + '2');
}
 
startButton.addEventListener('click', startTask)
 
function startTask(e){
    e.preventDefault()
   
    progressSection.appendChild(progressDiv)
            h3.innerText = task.value
pDescription.innerText = `Description: ${description.value}`
pDate.innerText = `Due Date: ${date.value}`
delButton.innerText = "Delete"
finishButton.innerText = "Finish"
divButtons.className = "flex"
delButton.className = "red"
finishButton.className = "orange"
 
divButtons.removeChild(startButton)
progressDiv.appendChild(article)
article.appendChild(h3)
article.appendChild(pDescription)
article.appendChild(pDate)
article.appendChild(divButtons)
divButtons.appendChild(delButton)
divButtons.appendChild(finishButton)
 
delButton.addEventListener('click', delEvent)
function delEvent(e){
    e.preventDefault()
    progressDiv.removeChild(article)
 
}
 
 
 
}
 
finishButton.addEventListener('click', finishEvent)
function finishEvent(e){
  e.preventDefault()
  completeDiv.appendChild(article)
article.appendChild(h3)
article.appendChild(pDescription)
article.appendChild(pDate)
article.removeChild(divButtons)
completeDiv.appendChild(article)
h3.innerText = task.value
pDescription.innerText = `Description: ${description.value}`
pDate.innerText = `Due Date: ${date.value}`
 
}
 
 
 
 
 
 
}
 
 
}
 
 
}