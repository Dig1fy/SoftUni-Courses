import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import PageLayout from "./components/layout/layout";
import NotFoundPage from "./pages/error/error";
import HomePage from "./pages/home/home";
import LoginPage from "./pages/login/login";
import RegisterPage from "./pages/register/register";

const Navigation = () => {
  return (
    <Router>
      {/* <PageLayout> */}
        <Switch>
          <Route path="/" exact component={HomePage} />
          <Route path="/login" exact component={LoginPage} />
          <Route path="/register" exact component={RegisterPage} />

          <Route component={NotFoundPage} />
        </Switch>
      {/* </PageLayout> */}
    </Router>
  );
};

export default Navigation;
