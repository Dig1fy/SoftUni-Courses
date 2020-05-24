
import controllers from '../controllers/index.js';

const app = Sammy('#root', function () {

    this.use('Handlebars', 'hbs');

    //Home
    this.get('#/home', controllers.home.get.home);

    //User
    this.get('#/login', controllers.user.get.login);
    this.get('#/register', controllers.user.get.register);

    this.post('#/login', controllers.user.post.login);
    this.post('#/register', controllers.user.post.register);
    this.get('#/logout', controllers.user.get.logout);

    // //article
    this.get('#/create', controllers.cause.get.create);
    this.post('#/create', controllers.cause.post.create);
    this.get('#/details/:articleId', controllers.cause.get.details);
    this.get('#/close/:articleId', controllers.cause.del.close);
    this.get('#/edit/:articleId', controllers.cause.get.edit);


    this.post('#/edit/:articleId', controllers.cause.put.edit);
});

(() => {
    app.run('#/home');
})();