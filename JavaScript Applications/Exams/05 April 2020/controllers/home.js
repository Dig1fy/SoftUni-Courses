import extend from '../utils/context.js';
import models from '../models/index.js'
import docModifier from '../utils/doc-modifier.js';

export default {
    get: {
        home(context) {
            models.cause.getAll().then(response => {
                context.JavaScript = []
                context.CSharp = []
                context.Pyton = []
                context.Java = []

                const categories = response.docs.map(docModifier);

                categories.forEach(el => {
                    let currentCategory = el.category.toLowerCase();

                    if (currentCategory === "javascript") {
                        context.JavaScript.push(el)
                    } else if (currentCategory === "csharp" || currentCategory === "c#") {
                        context.CSharp.push(el)
                    } else if (currentCategory === "java") {
                        context.Java.push(el)
                    } else if (currentCategory === "pyton") {
                        context.Pyton.push(el)
                    }
                });

                extend(context).then(function () {
                    this.partial('../views/home/home.hbs');
                });

            })
        }
    }
}