import React, { useState, useEffect } from 'react'
import UserContext from './Context'
import getCookie from '../../origami/src/helper-functions/getCookie'

// // We're gonna use this upper logic to check whether the user is logged in or not (and show the appropriate pages accordingly)
const App = (props) => {
  const [user, setUser] = useState(props.user ? { ...props.user, loggedIn: true } : null)
  const origamis = props.origamis || []

  const logIn = (userAsObject) => {
    setUser({
      loggedIn: true,
      ...userAsObject
    })
  }

  const logOut = () => {
    // Removing the cookie when logout (if we don't do that, the cookie will keep popping on every page refresh)
    document.cookie = "x-auth-token= expires = Thu, 01 Jan 1970 00:00:00 GMT"
    setUser({
      loggedIn: false,
      user: null
    })
  }

  useEffect(() => {
    const cookieToken = getCookie('x-auth-token')
    const token = cookieToken || ''

    if (!token) {
      logOut()
      return;
    }

    fetch('http://localhost:9999/api/user/verify', {
      method: "post",
      body: JSON.stringify({ token }),
      headers: {
        'Content-Type': 'application/json',
        'Authorization': token
      }
    }).then(promise => {
      return promise.json()
    }).then(response => {
      console.log(response, "RESPONSEEEEEEEEEEEEEEEEEEEEEEEEEE")
      if (response.status) {
        logIn({
          username: response.user.username,
          id: response.user._id
        })
      } else {
        logOut()
      }
    }).catch(err => console.log(err))


  }, [])

  return (
    <UserContext.Provider
      value={{
        origamis,
        user,
        logIn,
        logOut
      }}
    >
      {props.children}
    </UserContext.Provider>
  )
}


export default App;


//CLASS COMPONENT
// class App extends React.Component{
//   constructor(props){
//     super(props)
//   }


// }

// const App = (props) => {

//   const [user, setUser] = useState(props.user ? {
//     ...props.user,
//     loggedIn: true
//   } : null)
//   const origamis = props.origamis || []

//   const logIn = (userObject) => {
//     setUser({
//       ...userObject,
//       loggedIn: true
//     })
//   }

//   const logOut = () => {
//    // document.cookie = "x-auth-token= ; expires = Thu, 01 Jan 1970 00:00:00 GMT"
//     setUser({
//       loggedIn: false
//     })
//   }

//   console.log('user', user)

//   return (
//     <UserContext.Provider value={{
//       user,
//       logIn,
//       logOut,
//       origamis
//     }}>
//       {props.children}
//     </UserContext.Provider>
//   )
// }

// export default App