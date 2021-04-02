const getRouteLinks = function (user) {
    const userLinks = [
        {
            title: "Home",
            endPoint: "/",
            linkContent:"Home"
        },
        {
            title: "Post",
            endPoint: "/post",
            linkContent:"Post"
        },
        {
            title: "Share your thoughts",
            endPoint: "/share",
            linkContent: "Share"
        },
        {
            title: "Profile",
            endPoint: "/profile",
            linkContent: "Profile"
        }
    ]

    const guestLinks = [
        {
            title: "Home",
            endPoint: "/",
            linkContent: "Home"
        },
        {
            title: "Post",
            endPoint: "/post",
            linkContent:"Post"
        },
        {
            title: "Login",
            endPoint: "/login",
            linkContent: "Login"
        },
        {
            title: "Register",
            endPoint: "/register",
            linkContent: "Register"
        },
        {
            title: "Profile",
            endPoint: "/profile",
            linkContent: "Profile"
        }
    ]

    const loggedIn = user && user.loggedIn
    return loggedIn ? userLinks : guestLinks
}
export default getRouteLinks