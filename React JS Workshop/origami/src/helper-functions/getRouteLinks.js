const getRouteLinks = function (user) {
    const userLinks = [
        {
            title: "Home",
            endPoint: "/",
            linkContent:"Home"
        },
        {
            title: "Publications",
            endPoint: "/publications",
            linkContent:"Publications"
        },
        {
            title: "Share your thoughts",
            endPoint: "/share",
            linkContent: "Share"
        },
        {
            title: "My profile",
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
            title: "Publications",
            endPoint: "/publications",
            linkContent:"Publications"
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
            title: "My profile",
            endPoint: "/profile",
            linkContent: "Profile"
        }
    ]

    const loggedIn = user && user.loggedIn
    return loggedIn ? userLinks : guestLinks
}
export default getRouteLinks