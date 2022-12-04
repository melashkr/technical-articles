# Custom Policy for App Service with HttpsOnly by Bicep

## Introduction
Every organisation is responsible to secure it environment and enforcing organizational standards and adopting the governance of the organisation in cloud. One way to ensure this governance is to define azure policies and assign them to check non-compliance resources. Azure policy is an effective way to remain necessary standard and governance. 
This article introduces how to define a custom policy with bicep to enforce certain security aspects in your organisation.

## Prerequisites:  
In order to implement the solution the following services were provisioned:  
 - Subscription 
 - Resource group
 - App Service

## Azure Policy Introduction
Azure policy allows to create, assign, and manage polices to identify which azure resources are compliant or not. Azure Policy ensures that resource state is compliant to your business rules without concern for who made the change or who has permission to make a change. Azure Policy through DenyAction effect can also block certain actions on resources. Some Azure Policy resources, such as policy definitions, initiative definitions, and assignments, are visible to all users.
You can enable “managed identity” for running app services or functions to improve your authentication and security. However, managed identity saves the need of developers to manage the credentials by providing the identity for azure resource in Azure AD and use it to remain Azure Active directory (AAD) tokens.

## Defination for App Service by Bicep
It is possible to define a custom policy with bicep and convert it as ARM-Template to deploy it on Azure.
Here is the policy definition:  
... pic

To convert bicep to ARM-Template(in Json format), then run the Azure CLI command:  
az bicep build --file .\httpsonlyWebApp_PD.bicep  

The azure policy has generally different Effects such as “audit” or “auditIfNotExist” and enforce Effect such as (deny, modify, deployIfNotExists). Those effect track the impact of your policy definition in your environment. 
It is important to consider the hierarchy of your organisation when you are start creating definitions and assignments. It is recommended from MS to define policies at higher lever such the Management group or subscription level.


## RBAC for Policy in Template
Each policy has only a single effect. after the policy is already assigned, the policy will check the condition and evaluate it. This policy allow to use “AuditIfNotExists” or “DeployIfNotExists” and we are focusing on “DeployIfNotExists”. To understand more about this Effect, please check Microsoft documentation for [DeployIfNotExists](https://learn.microsoft.com/en-us/azure/governance/policy/concepts/effects#deployifnotexists)

### Feedback  
Please reach out to us if you have any feedback. We hope, the article is helpful for you.  
E-Mail: mohamed.elashkr@gmail.com

References:  
https://learn.microsoft.com/en-us/azure/governance/policy/overview
https://learn.microsoft.com/en-us/azure/governance/policy/concepts/effects#deployifnotexists
