# IdentityServer4 를 이용한 Identity Server 구성

참조
[# IdentityServer4](https://identityserver4.readthedocs.io/en/latest/index.html)


asp.net 기반의 IdentityServer 구성


# 프로젝트 설명

## IdentityServer
인증 서비스 제공을 해주는 메인 IdentityServer로
dotnet core 3.1 버전으로 구성되어 있음

IdentityServer4는 현재는 Duende로 변경되었으나,
제대로 사용하려면 유료 정책을 적용해야 함으로, 무료 지원이 가능한 IdentityServer4를 사용하여 구성하였다.

다만 IdentityServer4는 dotnet core 3.1까지만 지원함으로
Identity Server는 core 3.1로 구성하고, 그 외 api나 client들은 dotnet 8로 구성함.

ImMemory 형태로 설정 파일들을 구성했으며 (./IdentityServer/Config.cs) Scope 요청에 따른 Custom Claim까지 반환할 수 있게 추가함.

## Api
Identity Server에 의해 보호되는 api 프로젝트, 권한이 맞다면 간단히 claim을 반환한다.
요구 scope는 api1

## Client
예제에 있는 console client 프로그램, 가장 기본적인 인증 방식과 보호된 api를 요청하는 방법이 담겨있음.

## MvcClient
dotnet 8 기준으로 만들어진 mvc Client,
로그인, 로그오프 등의 기능이 어떤식으로 구성되는지 알 수 있다.

/home/privacy => Authroize에 의해 보호되며 접근하면 IdentityServer로 Redirect 되어 로그인 진행 후 페이지에 접근하게 됨.

/home/logout => 로그아웃 (UI 안만듬)

/home/callapi => Api 프로젝트(보호된)로 보호된 api를 호출한다.

## react-client

javascript를 이용해서 client를 구성할 수 있는데

react를 사용할것이므로 react 프로젝트로 만들었으며

oidc client 패키지는 @axa-fr/react-oidc 패키지를 이용했다.(오픈 소스)

기본적인 로그인, 로그아웃 등의 기능이 담겨있음.





