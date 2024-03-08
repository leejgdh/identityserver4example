import React from 'react'
import { useOidc } from '@axa-fr/react-oidc';
import DisplayUserInfo from './user-info';

function Home() {
    
  const { login, logout, renewTokens, isAuthenticated } = useOidc();

 
  return (
    <div className="container-fluid mt-3">
      <div className="card">
        <div className="card-body">
          <h5 className="card-title">Welcome !!!</h5>
          <p className="card-text">
            React Demo Application protected by OpenId Connect
          </p>
          {!isAuthenticated && (
            <button
              type="button"
              className="btn btn-primary"
              onClick={() => login("/profile")}
            >
              Login
            </button>
          )}
          {isAuthenticated && (
            <button
              type="button"
              className="btn btn-primary"
              onClick={() => logout()}
            >
              logout
            </button>
          )}
          {isAuthenticated && (
            <button
              type="button"
              className="btn btn-primary"
              onClick={() => renewTokens()}
            >
              renewTokens
            </button>
          )}
          {isAuthenticated && (
            <DisplayUserInfo />
          )}
        </div>
      </div>
    </div>
  );
}

export default Home