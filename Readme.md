# Courses Microservice Project
This project aims to sell **online courses** just like Udemy. Project structure is like below.

## How to start project?
> Prerequisites
- .Net 7 should be installed
- Docker shoud be installed

### Step 1
> cd CourseMicroservice

> docker-compose up -d

*After the process is completed please check all the containers are active and running. If there is any stopped container because of any reason, please start it manually.*
> docker ps

> docker run \<containerName>

Up to now, we assume that everything goes on well.

### Step 2
We have two types of resources. First one is stemming from IdentityServer that is related to user and token management.
Secondly, a bunch of endpoints comes from services such as catalog, basket, discount etc.

To get the list of endpoints of IdentityServer, you should send a request the endpoint below:
> GET http://localhost:5001/.well-known/openid-configuration

Result:
{
  "issuer": "http://localhost:5001",
  "jwks_uri": "http://localhost:5001/.well-known/openid-configuration/jwks",
  "authorization_endpoint": "http://localhost:5001/connect/authorize",
  "token_endpoint": "http://localhost:5001/connect/token",
  "userinfo_endpoint": "http://localhost:5001/connect/userinfo",
  "end_session_endpoint": "http://localhost:5001/connect/endsession",
  "check_session_iframe": "http://localhost:5001/connect/checksession",
  "revocation_endpoint": "http://localhost:5001/connect/revocation",
  "introspection_endpoint": "http://localhost:5001/connect/introspect",
  "device_authorization_endpoint": "http://localhost:5001/connect/deviceauthorization",
  "frontchannel_logout_supported": true,
  "frontchannel_logout_session_supported": true,
  "backchannel_logout_supported": true,
  "backchannel_logout_session_supported": true,
  "request_parameter_supported": true
}

Let's try to get a publis token from IdentityServer
> POST http://localhost:5001/connect/token Body: client_id:WebMvcClient client_secret:secret grant_type:client_credentials

Result:
{
    "access_token": "eyJhbGciOiJSUzI1NiIsImtpZCI6IjQyNjYyRjJBQzk2RjdERDY2ODU3QUVFMzQ3MjFGMTYyIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2OTY1MzkyNDMsImV4cCI6MTY5NjU0Mjg0MywiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjpbInJlc291cmNlX2Jhc2tldCIsInJlc291cmNlX2NhdGFsb2ciLCJyZXNvdXJjZV9nYXRld2F5IiwicmVzb3VyY2VfcGhvdG9fc3RvY2siLCJodHRwOi8vbG9jYWxob3N0OjUwMDEvcmVzb3VyY2VzIl0sImNsaWVudF9pZCI6IldlYk12Y0NsaWVudCIsImp0aSI6Ijc0REU2Qzg1RDg3RkEyM0UyRTIxREVBREVGMDM0RTk0IiwiaWF0IjoxNjk2NTM5MjQzLCJzY29wZSI6WyJiYXNrZXRfZnVsbHBlcm1pc3Npb24iLCJjYXRhbG9nX2Z1bGxwZXJtaXNzaW9uIiwiZ2F0ZXdheV9mdWxscGVybWlzc2lvbiIsIklkZW50aXR5U2VydmVyQXBpIiwicGhvdG9fc3RvY2tfZnVsbHBlcm1pc3Npb24iXX0.CoVT9Gk9OoTOlV7zwHrTiiV1e6ygN39E1ZK_uWMDIrUa4EmxWQDpggMCaZUAp07c4R-pFoAbVDWdXgJ4AJhpZnLxhNLnZ41YGEUdFUgIyy34cN7BMdmLqBARyuazW-t1b2j439HAyPt_Xb_KjMmb2cnbmfGzb9ZQVToJR6-Lcy2ME0S5h-opGQ7Im9DhyvYwUbIGyllXideZZq5ci5iaksu8f-hmbF_y130tbrGX1xSy7dvee9KrU7t4LBrORQb2oqZMWl4qztx9YmdtKooiC-6UAeL09K6A80cL8Pou0MWBWEo8-tTwGWWkg_fUy0VVJnGMr03Uwk8wI-3f2Dukiw",
    "expires_in": 3600,
    "token_type": "Bearer",
    "scope": "basket_fullpermission catalog_fullpermission gateway_fullpermission IdentityServerApi photo_stock_fullpermission"
}

To list all the list related to IdentityServer, you should send a request to the endpoint below:
> GET http://locahhost:5000/services/


- Microservices Solution
    1. Gateways
        1. Courses.Gateway
    2. IdentityServer
        1. Courses.IdentityServer
    3. Services
        1. Courses.Services.Basket
        2. Courses.Services.Catalog
        3. Courses.Services.Discount
        4. Courses.Services.FakePayment
        5. Courses.Services.Order
        6. Courses.Services.PhotoStock
    4. Shared
        1. Courses.Shared