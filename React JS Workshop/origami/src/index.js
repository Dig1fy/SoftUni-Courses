import React from "react";
import ReactDOM from "react-dom";
import ErrorBoundary from "./errorBoundary";
import "./index.css";
import Navigation from "./navigation";
import reportWebVitals from "./reportWebVitals";

ReactDOM.render(
  <React.StrictMode>
    <ErrorBoundary>
      <Navigation />
    </ErrorBoundary>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
