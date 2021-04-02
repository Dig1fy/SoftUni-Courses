import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import NotFoundPage from "./pages/error/error";
import HomePage from "./pages/home/home";
import LoginPage from "./pages/login/login";
import RegisterPage from "./pages/register/register";
import PublicationsPage from "./pages/publications/publications"
import ProfilePage from './pages/profile/profile'

const Navigation = () => {
  return (
    <Router>
        <Switch>
          <Route path="/" exact component={HomePage} />
          <Route path="/login" exact component={LoginPage} />
          <Route path="/register" exact component={RegisterPage} />
          <Route path ="/publications" exact component = {PublicationsPage}/>
          <Route path = "/profile" component = {ProfilePage} />
          <Route component={NotFoundPage} />
        </Switch>
    </Router>
  );
};

export default Navigation;
