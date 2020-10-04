class Forum {
    _users = [];
    _questions = [];
    _id = 1;

    register(name, password, repeatPassword, email) {
        if (!(name && password && repeatPassword && email)) {
            throw new Error('Input can not be empty')
        }
        if (password !== repeatPassword) {
            throw new Error('Passwords do not match')
        }
        if (this._users.some(x => x.name === name)) {
            throw new Error('This user already exists!')
        }

        let currentUser = {
            name: name,
            password: password,
            email: email,
            isLogged: false
        };

        this._users.push(currentUser);
        return `${name} with ${email} was registered successfully!`;
    }

    login(username, password) {
        if (!(this._users.find(x => x.name === username))) {
            throw new Error('There is no such user');
        }
        if (this._users.filter(x => x.name === username)
            && this._users.filter(x => x.password === password)) {
            this._users.find(x => x.name === username).isLogged = true;
            return 'Hello! You have logged in successfully';
        }
    }

    logout(username, password) {
        if (!(this._users.find(x => x.name === username))) {
            throw new Error('There is no such user');
        }
        if (this._users.filter(x => x.name === username)
            && this._users.filter(x => x.password === password)) {
            this._users.find(x => x.name === username).isLogged = false;
            return 'You have logged out successfully';
        }
    }

    postQuestion(username, question) {
        if (!(this._users.find(x => x.name === username))
            || (!this._users.find(x => x.name === username).isLogged)) {

            throw new Error('You should be logged in to post questions')
        }
        if (!question) {
            throw new Error('Invalid question');
        }

        let currentQuestion = {
            username: username,
            questionText: question,
            answer: [],
            userAnswered: [],
            questionId: this._id
        };

        this._id++;
        this._questions.push(currentQuestion);
        return 'Your question has been posted successfully';
    }

    postAnswer(username, questionId, answer) {
        if (!(this._users.find(x => x.name === username))
            || (!this._users.find(x => x.name === username).isLogged)) {
            throw new Error('You should be logged in to post answers')
        }
        if (answer === "") {
            throw new Error('Invalid answer');
        }

        let isThereId = false;

        for (const quest in this._questions) {
            if (this._questions[quest].questionId === questionId) {
                isThereId = true;
                this._questions[quest].answer.push(answer);
                this._questions[quest].userAnswered.push(username);
                break;
            }
        }

        if (!isThereId) {
            throw new Error('There is no such question');
        }

        return 'Your answer has been posted successfully';
    }

    showQuestions() {
        let result = '';

        for (const q in this._questions) {
            let current = this._questions[q];
            result += `Question ${current.questionId} by ${current.username}: ${current.questionText}\n`

            for (let i = 0; i < this._questions[q].answer.length; i++) {
                let currentAnswer = this._questions[q].answer[i];
                let currentUser = this._questions[q].userAnswered[i];
                result += `---${currentUser}: ${currentAnswer}\n`;
            }
        }

        return result.trim();
    }
}

// let forum = new Forum();

// forum.register('Michael', '123', '123', 'michael@abv.bg');

// forum.register('Stoyan', '123ab7', '123ab7', 'some@gmail@.com');
// forum.login('Michael', '123');
// forum.login('Stoyan', '123ab7');

// forum.postQuestion('Michael', "Can I rent a snowboard from your shop?");
// forum.postAnswer('Stoyan', 1, "Yes, I have rented one last year.");
// forum.postQuestion('Stoyan', "How long are supposed to be the ski for my daughter?");
// forum.postAnswer('Michael', 2, "How old is she?");
// forum.postAnswer('Michael', 2, "Tell us how tall she is.");

// console.log(forum.showQuestions());