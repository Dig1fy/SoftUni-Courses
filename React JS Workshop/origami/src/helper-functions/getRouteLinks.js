const getRouteLinks = function (user) {
    console.log(user, "ROUTELINKS");
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
            linkContent: "Fake"
        },
        {
            title: "My profile",
            endPoint: `/profile/${user && user.id}`,
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