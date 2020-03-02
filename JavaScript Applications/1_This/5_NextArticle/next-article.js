function getArticleGenerator(articles) {
    let copyOfArticles = [...articles];

    let contentRef = document.querySelector('#content');

    return function () {
        if (copyOfArticles.length === 0) {
            return;
        }
        let result = copyOfArticles.shift();

        let resultElement = document.createElement('article');
        resultElement.textContent = result;
        contentRef.appendChild(resultElement);
    }
}