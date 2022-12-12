# Custom Policy for App Service with HttpsOnly by Bicep

## Introduction

Every organisation is responsible to secure its environment and enforcing organizational standards and adopting the governance of the organisation in Azure cloud. One way to ensure this governance is to define azure policies and assign them to check non-compliance resources. Azure policy is an effective way to remain necessary standard and governance. 
This article introduces how to define a custom policy with bicep to enforce certain security aspects in your organisation. There are three App Services which 2 from them are not configured with HttpsOnly and 1 App is confiuged right in that case. The Result is to find out which Apps are compliant or not to fix them.

## Prerequisites:  
In order to implement the solution the following resources were provisioned:  
 - Subscription 
 - Resource group
 - 3 App Services (2 Apps are not configured with HttpsOnly and 1 App is configured with HttpsOnly)

## Azure Policy Introduction
Azure policy allows to create, assign, and manage polices to identify which azure resources are compliant or not. Azure Policy ensures that resource state is compliant to your business rules without concern for who made the change or who has permission to make a change. Azure Policy through DenyAction effect can also block certain actions on resources. Some Azure Policy resources, such as policy definitions, initiative definitions, and assignments, are visible to all users.
You can enable “managed identity” for running app services or functions to improve your authentication and security. However, managed identity saves the need of developers to manage the credentials by providing the identity for azure resource in Azure AD and use it to remain Azure Active directory (AAD) tokens.

## Defination for App Service by Bicep
It is possible to define a custom policy with bicep and convert it as ARM-Template to deploy it on Azure.
Here is the policy definition, [Bicep-Template](https://github.com/melashkr/technical-articles/blob/main/bicep/custom-policy-appService-httpsOnly/code/httpsonlyWebApp_PD.bicep?row=true) is here.
![alt text](https://github.com/melashkr/technical-articles/blob/main/bicep/custom-policy-appService-httpsOnly/images/policy-defintion.PNG?row=true "Azure Policy Defintion")

To convert bicep to ARM-Template(in Json format), then run the Azure CLI command:  
cmd: az bicep build --file .\httpsonlyWebApp_PD.bicep  



The azure policy has generally different Effects such as “audit” or “auditIfNotExist” and enforce Effect such as (deny, modify, DeployIfNotExists). Those effects track the impact of your policy definition in your environment. 
It is important to consider the hierarchy of your organisation when you are start creating definitions and assignments for any azure policy. It is recommended from MS to define policies at higher level such the Management group or subscription level.

## RBAC for Policy in Template
Each policy has only a single effect. after the policy is already assigned, the policy will check the condition and evaluate it. This policy allow to use “AuditIfNotExists” or “DeployIfNotExists” and we are focusing on “DeployIfNotExists”. To understand more about this Effect, please check Microsoft documentation for [DeployIfNotExists](https://learn.microsoft.com/en-us/azure/governance/policy/concepts/effects#deployifnotexists)

The managed identity of a deployIfNotExists or modify policy assignment needs enough permissions to create or update targeted resources.
For custom policy definition with “DeployIfNotExists” requires to assign a contributor role unter details property, then add a roleDefinitionIds property.
This part is here in the template:
![alt text](https://github.com/melashkr/technical-articles/blob/main/bicep/custom-policy-appService-httpsOnly/images/role-defintion.PNG?row=true "Role Defintion")

To get the role ID for “Contributer” role in your in environment, use this Azure CLI command:  
cmd: az role definition list --name "Contributor"


## Deploy ARM-Tempate
You will get the ARM-Template in json format after converting the bicep template. You can deploy this template in Azure. 
![alt text](https://github.com/melashkr/technical-articles/blob/main/bicep/custom-policy-appService-httpsOnly/images/deploy-template.PNG?row=true "Policy definition")

## Assign Azure Policy

The policy is prepared to be assigned. Open the Azure Portal, search for Policy. Select the policy and assign it.  
![alt text](https://github.com/melashkr/technical-articles/blob/main/bicep/custom-policy-appService-httpsOnly/images/app-service-policy-defintion.PNG?row=true "Policy assignment")

It is possible to specify the parameters of the policy, there are two options (**DeployIfNotExistes** or **AuditIfNotExists**). If you choose "DeployIfNotExistes", then you need to create a managed identity and assign a role contributer
![alt text](https://github.com/melashkr/technical-articles/blob/main/bicep/custom-policy-appService-httpsOnly/images/assign-policy-01.PNG?row=true "Policy assignment")

## Check Compliance

Next step, you need to assign the policy. After the policy have been assigned, you will get the result of compliance for running App Services and the account of compliant and non-compliant ressources. However, the policy does not do any action or auto-remediate task, therefore you could create a remediate task manually to fix non-compliant ressources
![alt text](https://github.com/melashkr/technical-articles/blob/main/bicep/custom-policy-appService-httpsOnly/images/compliance-result-policy.PNG?row=true "Compliance result")

## Create a remediate Task

Last step, you can make sure that your running apps are secure and the security requirements are fullfilled. A remediate task will fix a non-compliant resources to be compliant.  

### Feedback  
Please reach out to me if you have any feedback. I hope, the article is helpful for you.  
E-Mail: mohamed.elashkr@gmail.com

References:  
https://learn.microsoft.com/en-us/azure/governance/policy/overview  
https://learn.microsoft.com/en-us/azure/governance/policy/concepts/effects#deployifnotexists
