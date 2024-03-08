import { useOidcUser } from "@axa-fr/react-oidc";

const DisplayUserInfo = () => {
    const { oidcUser, oidcUserLoadingState } = useOidcUser();

    console.log('oidc user loading state',oidcUserLoadingState);


    return (
        <div className="card text-white bg-success mb-3">
            <div className="card-body">
                <h5 className="card-title">User information</h5>
                <p className="card-text">{JSON.stringify(oidcUser)}</p>
            </div>
        </div>
    );
};

export default DisplayUserInfo;