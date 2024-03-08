import './App.css';

import { render } from "react-dom";
import { BrowserRouter as Router } from "react-router-dom";
import { OidcProvider } from "@axa-fr/react-oidc";
import Header from "./components/header";
import Routes from "./components/routes";
import Home from "./components/home";

function App() {

  const configuration = {
    client_id: "react",
    redirect_uri: window.location.origin + "/authentication/callback",
    silent_redirect_uri:
      window.location.origin + "/authentication/silent-callback",
    scope: "openid profile offline_access custom", // offline_access scope allow your client to retrieve the refresh_token
    authority: "https://localhost:5001",
    service_worker_relative_url: "/OidcServiceWorker.js", // just comment that line to disable service worker mode
    service_worker_only: false,
    demonstrating_proof_of_possession: false,
  };

  return (
    <OidcProvider configuration={configuration}>
      <Router>
        <Header />
        <Routes />
        <Home />
      </Router>
    </OidcProvider>
  );
}

export default App;
