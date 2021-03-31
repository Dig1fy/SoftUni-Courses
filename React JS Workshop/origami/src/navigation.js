import React, { useContext } from 'react'
import { Switch, Route, Redirect, BrowserRouter } from 'react-router-dom'
import HomePage from './pages/home/home'
import LoginPage from './pages/login/login'
// import ErrorPage from './pages/error/error'

const Navigation = () => {
    let loggedIn = false;

    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={HomePage} />
                <Route path="/login" >
                    {loggedIn ? (<Redirect to="/" />) : (<LoginPage />)}
                </Route>
            </Switch>
        </BrowserRouter>
    )
}

export default Navigation