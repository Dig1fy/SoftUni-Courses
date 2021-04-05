import React, { useState, useEffect } from 'react'

import UserContext from './Context'

// We're gonna use this upper logic to check whether the user is logged in or not (and show the appropriate pages accordingly)
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
        logIn: (e) => logIn,
        logOut: () => logOut
      }}
    >
      {props.children}
    </UserContext.Provider>
  )
}


export default App;
