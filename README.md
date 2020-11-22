# BankingSystem API
BankingSystem API live version can be found here:
https://bankingsystem-backend.herokuapp.com/swagger/index.html
![BankingSystem API](https://i.imgur.com/hSOiTVc.png)

### Tools
- Visual studio version: 16.8.2
- C# 7.1
- .NET 5
- Docker


#### 1. Download and install Docker for windows
https://docs.docker.com/docker-for-windows/install/

#### 2. Run the project
Navigate to the project folder where the **docker-compose.yml** file is contained, for example:
![docker-compose file](https://i.imgur.com/xs66039.png)

> C:\git\bankingsystem-backend

Open a console in project root and execute:

    docker-compose build
    docker-compose up -d

![docker-compose build](https://i.imgur.com/0uSsSBw.png)
![docker-compose up -d](https://i.imgur.com/08dRCP8.png)

This will create 2 containers:
- SqlServer
- .Net Core API

**Wait** 30s for SqlServer service initialization and fake data seeding.
Once is completed, you will be able to login using the following information:

    localhost
    sa
    .0]--2G!*t54tfzup^WUdoeDBw:5F3qcKHNW>+MU>Qer?R3u+XzR~1A@oMN.5J_%

![Sql Server login](https://i.imgur.com/4hUOIgg.png)

When seeding background process finishes, there will be a database BankingSystem created.

![Database](https://i.imgur.com/EMzbIzl.png)

#### 3. Swagger
The project has a swagger UI to test endpoints.
Is available in URL:
[http://localhost/swagger/index.html](http://localhost/swagger/index.html)

There is pre inserted fake data for:
Banks, ids (1-5).
Clients, ids (1-5).
AccountTypes, ids (1-4)
Accounts, ids (1-5)

#### 4. InMemoryDatabase
In case nothing works, or you don't have docker installed, there is also a version used for live deployment which uses Sqlite in memory database.

Is available to clone at:

    feature/BS-8_deploy
    Commit ID: 31590f7199a90a1fb571001ab530d3a5ecc08c29
    
This version can be run pressing Start in visual studio.