import React from "react";
import ReactDOM from "react-dom/client";
import "semantic-ui-css/semantic.min.css";
import App from "./app/layout/App";
import "./app/layout/index.css";

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
