import extend from '../utils/context.js';
import models from '../models/index.js';
import docModifier from '../utils/doc-modifier.js';
import fillFormWithData from '../utils/formFiller.js';

export default {
    get: {
        dashboard(context) {

            models.cause.getAll().then(response => {
                const treks = response.docs.map(docModifier);
                context.treks = treks;

                extend(context).then(function () {
                    this.partial('../views/cause/dashboard.hbs');
                });
            })
        },
        create(context) {
            extend(context).then(function () {
                this.partial('../views/cause/create.hbs');
            });
        },
        details(context) {
            const { causeId } = context.params;

            models.cause.get(causeId).then(response => {

                const trek = docModifier(response);
                Object.keys(trek).forEach(key => context[key] = trek[key]);

                context.canLike = trek.uid !== localStorage.getItem('userId');

                extend(context).then(function () {
                    this.partial('../views/cause/details.hbs');
                });

            })
                .catch(e => alert(e.message));
        },
        edit(context) {
            extend(context).then(function () {
                context.id = context.params.causeId;
                this.partial('../views/cause/edit.hbs');
            });

            const { causeId } = context.params;

            models.cause.get(causeId).then(response => {
                const formValues = response.data();
                const formRef = document.querySelector('form');
                fillFormWithData(formRef, formValues);
            });

        }
    },
    post: {
        create(context) {

            const data = {
                ...context.params,
                uid: localStorage.getItem('userId'),
                organizer: localStorage.getItem('userEmail'),
                likes: 0
            }

            models.cause.create(data)
                .then(response => {
                    context.redirect('#/cause/dashboard');
                })
                .catch(e => alert(e.message));
        }

    },
    del: {
        close(context) {
            const { causeId } = context.params;
            models.cause.close(causeId).then(response => {
                context.redirect('#/cause/dashboard');
            })
                .catch(e => alert(e.message));
        }
    },
    put: {
        like(context) {
            const { causeId } = context.params;

            models.cause.get(causeId).then(response => {
                const trek = docModifier(response);
                trek.likes += 1;

                return models.cause.edit(causeId, trek);
            })
                .then(response => {
                    context.redirect(`#/cause/details/${causeId}`);
                });
        },
        edit(context) {
            const { causeId } = context.params;
            const trek = {
                ...context.params,
                uid: localStorage.getItem('userId')
            }

            models.cause.edit(causeId, trek)
                .then(response => {
                    context.redirect(`#/cause/details/${causeId}`);
                })
                .catch(e => alert(e.message));
        }
    }
}