import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import NotFoundPage from "./pages/error/error";
import HomePage from "./pages/home/home";
import LoginPage from "./pages/login/login";
import RegisterPage from "./pages/register/register";
import PostPage from "./pages/post/post"

const Navigation = () => {
  return (
    <Router>
        <Switch>
          <Route path="/" exact component={HomePage} />
          <Route path="/login" exact component={LoginPage} />
          <Route path="/register" exact component={RegisterPage} />
          <Route path ="/post" exact component = {PostPage}/>
          <Route component={NotFoundPage} />
        </Switch>
    </Router>
  );
};

export default Navigation;
