# Clone App Service between two ASPs with Linux-Plan by Bicep

## Introduction
One of the major challenges by migration of App Service is to clone the App Service from ASP-Linux to another ASP-Linux in ASEv3
and maybe from one subscription (or region) to another subscription (or another region).  
One of the current restriction is Cloning App Service in ASP-Linux to another ASP-Linux (see references down there).

Solution:  Bicep can do it, it is possible to clone a web app (App Service) which is running in ASP with linux-plan to another ASP 
and between two different subscriptions.

## Prerequisites:  

In order to implement the solution the following services were provisioned:  
 - Two subscriptions
 - 2 ASE with External Load balancer (one in every subscription)
 - 2 ASP-Linux plan (one in every subscription)
 - App Service (Web app)

**Cloning App not possible in Azure-Portal**  
![alt text](https://github.com/melashkr/technical-articles/blob/main/bicep/clone-appService-aspLinux/images/cloning-app-not-possible-azure-portal.PNG "Cloning App Service in ASP-Linux")

## Cloning App between 2 subscriptions in ASP-Linux with Bicep
Yes, it is possible to clone Service App with bicep from ASP in first subscription to another ASP in another subscription. 
Firstly, you need to define a clone-app template and afterwards you need define a migration module for Service App

**Bicep-Template**

Firstly, you create a bicep module to clone the app from ASP to another ASP, see "cloneAppServiceModule.bicep". It is possible to define a module to call from outside by "migAppService.bicep".

![alt text](https://github.com/melashkr/technical-articles/blob/main/bicep/clone-appService-aspLinux/images/clone-app-module-bicep.PNG "Cloning App Service in ASP-Linux")

The bicep-templates are defined under code-folder:
 - cloneAppServiceModule.bicep
 - migAppService.bicep
 - migAppService.parameters.json

To run the template:  
cmd: az deployment group create  --resource-group rg-target  --parameters .\migAppService.parameters.json  --template-file .\migAppService.bicep

### Feedback  
Please reach out to us if you have any feedback. We hope, the article is helpful for you.  
E-Mail: mohamed.elashkr@gmail.com

References:  
https://docs.microsoft.com/en-us/azure/app-service/app-service-web-app-cloning
