# Clone App Service between two ASPs-Linx with Bicep

## Introduction
One of the major challenges by migration is to clone app from ASP-Linux to another ASP-Linux 
and may be from one subscription (or region) to another subscription (or another region)

Solution:  Bicep can do it, it is possible to clone a web app which is running in ASP with linux-plan to another ASP 
and between two different subscriptions.

## Prerequisites:
•	Two subscriptions
•	2 ASE with External Load balancer (one in every subscription)
•	2 ASP-Linux plan (one in every subscription)
•	Service App (Web app)
Cloning App not possible in Azure-Portal
TODO: put Image

## Cloning App between 2 subscriptions in ASP-Linux with Bicep
Yes, it is possible to clone Service App with bicep from ASP in first subscription to another ASP in another subscription. 
Firstly, you need to define a clone-app template and afterwards you need define a migration module for Service App

**Bicep-Template**

References: 
https://docs.microsoft.com/en-us/azure/app-service/app-service-web-app-cloning
