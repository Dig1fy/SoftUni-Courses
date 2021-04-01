const getRouteLinks = function (user) {
    const userLinks = [
        {
            title: "Home",
            endPoint: "/"
        },
        {
            title: "Share your thoughts",
            endPoint: "/share"
        }, 
        {
            title: "Profile",
            endPoint: "/profile"
        }
    ]

    const guestLinks = [
        {
            title: "Home",
            endPoint: "/"
        },
        {
            title: "Login",
            endPoint: "/login"
        },
        {
            title: "Register",
            endPoint: "/register"
        }, 
        {
            title: "Profile",
            endPoint: "/profile"
        }
    ]
    
    const loggedIn = user && user.loggedIn
    return loggedIn ? userLinks : guestLinks
}
export default getRouteLinks