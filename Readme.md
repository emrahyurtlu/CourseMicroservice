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