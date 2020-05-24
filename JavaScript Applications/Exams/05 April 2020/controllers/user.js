import models from '../models/index.js';
import extend from '../utils/context.js';
import docModifier from '../utils/doc-modifier.js';


export default {
    get: {
        login(context) {
            extend(context).then(function () {
                this.partial('../views/user/login.hbs');
            });
        },
        register(context) {
            extend(context).then(function () {
                this.partial('../views/user/register.hbs');
            });
        },
        logout(context) {
            models.user.logout().then(response => {
                context.redirect('#/login');
            });
        },
        profile(context) {

            models.cause.getAll().then(response => {
                const treks = response.docs
                    .map(docModifier)
                    .filter(trek => trek.uid === localStorage.getItem('userId'))
                    .map(trek => trek = trek.location);

                context.treks = treks;
                context.treksNumber = treks.length;

                extend(context).then(function() {
                    this.partial('../views/user/profile.hbs');
                });
            });
            
        }
    },
    post: {
        login(context) {
            const { email, password } = context.params;
            models.user.login(email, password)
                .then(response => {
                    context.user = response;
                    context.redirect('#/home');
                })
                .catch(e => console.error(e));

        },
        register(context) {
            const { email, password, rePassword } = context.params;

            if (password === rePassword) {
                models.user.register(email, password)
                    .then(response => {
                        context.redirect('#/home');
                    })
                    .catch(e => console.error(e));
            }

        }
    }
}