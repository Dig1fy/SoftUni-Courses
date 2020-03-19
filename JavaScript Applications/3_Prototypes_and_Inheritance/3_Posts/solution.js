function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(currentComment) {
            this.comments.push(currentComment);
        }

        toString() {
            let string = super.toString() + `\nRating: ${this.likes - this.dislikes}`;

            if (this.comments.length > 0) {
                string += "\nComments:";
                this.comments.forEach(c => string += `\n * ${c}`);
            }

            return string;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content)
            this.views = views;
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            return super.toString() + `\nViews: ${this.views}`
        }
    }

    return { Post, SocialMediaPost, BlogPost };
}

// let x = solve();
// let post = new x.Post("Post", "Content");

// console.log(post.toString());

// // Post: Post
// // Content: Content

// let scm = new x.SocialMediaPost("TestTitle", "TestContent", 25, 30);

// scm.addComment("Good post");
// scm.addComment("Very good post");
// scm.addComment("Wow!");

// console.log(scm.toString());

// // Post: TestTitle
// // Content: TestContent
// // Rating: -5
// // Comments:
// //  * Good post
// //  * Very good post
// //  * Wow!