const authenticate = async (url, body, onSuccess, onFailure) => {    

    try {
        const promise = await fetch(url, {
            method: "post",
            //Depends how it's been configured in our restApi
            body: JSON.stringify(body),
            headers: {
                "Content-Type": "application/json"
            }
        })

        // console.log(promise);
        //we access the cookie from the response like this: promise.headers.get("Authorization")
        const authorizationCookie = promise.headers.get("Authorization")
        document.cookie = `x-auth-token= ${authorizationCookie}`
        const response = await promise.json()

        if (response.username && authorizationCookie) {
            onSuccess();
        } else {
            onFailure()
        }

    } catch (e) {
        onFailure(e);
    }
}

export default authenticate