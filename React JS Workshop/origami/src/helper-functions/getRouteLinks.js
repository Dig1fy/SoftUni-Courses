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
            title: "My profile",
            endPoint: `/profile/${user && user.id}`,
            linkContent: "Profile"
        },
        {
            title: "Share your thoughts",
            endPoint: "/share",
            linkContent: "Fake"
        }
    ]

    const guestLinks = [
        {
            title: "Home",
            endPoint: "/",
            linkContent: "Home"
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
        }
    ]

    const loggedIn = user && user.loggedIn
    return loggedIn ? userLinks : guestLinks
}
export default getRouteLinks