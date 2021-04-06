import React, { useState, useEffect } from 'react'

import UserContext from './Context'

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
    setUser({
      loggedIn: false,
      user: null
    })
  }

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