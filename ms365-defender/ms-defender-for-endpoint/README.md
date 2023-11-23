# Definition MS defender for endpoint (EP)

Microsoft Defender for Endpoint is an enterprise endpoint security platform designed to help enterprise networks prevent, detect, investigate, and respond to advanced threats.

Example endpoints may include laptops, phones, tablets, PCs, access points, routers, and firewalls

## Benefits for MS defender for EP

Security team can use this dashboard for
- Visbility, Reporting
- Investigation and hunting
- Automated investigation and response
- Event Correlation Detection
- Threat and vulnerability management
- Signal exchange
- Security analytics

## Benetifs for Defender for endpoint sensors
Defender for endpoint sensors gathera security-related events from onboard endpoints and send those events to customer’s tenants. The only thing needed is an internet connection.

All security endpoint generates security events,  this includes threat vulnerability management,
Detect unmanaged devices. 

![alt text](https://github.com/melashkr/technical-articles/blob/main/ms365-defender/ms-defender-for-endpoint/images/defender-for-endpoints-sensors.PNG?row=true "MS Defender 365 componants")

## Plans for MS Defender for Endpoints
Microsoft Defender for Endpoint is available in two plans, Defender for Endpoint Plan 1 and Plan 2. A new Microsoft Defender Vulnerability Management add-on is now available for Plan 2

Comparing the capabilities of both plans and Defender for Business:
Defender for EP Plan 1 | Defender for EP Plan 2 | Defender for Business* |
---------------------- | ---------------------- | -------------------- | 
Next-generation protection (includes antimalware and antivirus) | All of the Defender for Endpoint Plan 1 capabilities, plus: |  Antispam protection |
Attack surface reduction |  Device discovery |  Antimalware protection |
Manual response actions  | Device inventory | Next-generation protection |
Centralized management | Core Defender Vulnerability Management capabilities | Attack surface reduction |
Security reports |  Threat Analytics | Endpoint detection and response |
APIs |  Automated investigation and response | Automated investigation and response |
Support for Windows 10, Windows 11, iOS, Android OS, and macOS devices | Advanced hunting | Vulnerability management |
 |  Endpoint detection and response | Centralized reporting |
 |  Endpoint Attack Notifications | APIs (for integration with custom apps or reporting solutions) |
 |  Support for Windows (client only) and non-Windows platforms (macOS, iOS, Android, and Linux) |  Integration with Microsoft 365 Lighthouse |
 
*)  Services optimized for small and medium-sized businesses (with up to 300 employees) 

**Mixed licensing scenarios**: If you have Defender for Endpoint Plan 1 and Plan 2 in your tenant, the ability to manage your subscription settings across client devices is now in **preview**! This new capability enables you to
- Apply either Defender for Endpoint Plan 1 or Plan 2 settings to all your client devices
- Use mixed mode, and apply Defender for Endpoint Plan 1 settings to some client devices, and Defender for Endpoint Plan 2 to other client devices

**Microsoft Dfender for business vs MS 365 Business Premium**
TODO: screen shot

## Integration with microsoft solutions
Defender for Endpoint directly integrates with various Microsoft solutions, including:
- Microsoft Defender for Cloud
- Microsoft Sentinel
- Intune
- Microsoft Defender for Cloud Apps
- Microsoft Defender for Identity
- Microsoft Defender for Office
- Skype for Business

## Pricing tier

Microsoft Defender for Cloud is free for the first 30 days. Any usage beyond 30 days will be automatically charged as per the pricing scheme below

Time |Defender for EP Plan 1 | Defender for EP Plan 2 | Defender for Business |
-----|---------------------- | ---------------------- | -------------------- | 
Per Hour | 0.007 € per Server |  0.019 € per Server  | -- |
Per Day  |  0.007*24 h =  ~ **0.168** €  per Server |  0.019*24 h = ~ **0.456** € per Server  | -- |
Per Month| 0.168 * 30 d = ~ 5,04 per Server | 0.456*30 d= ~ **13.68** € per Server | 2.80 € per user/per month* |

*) Includes 5 devices per user. It is possible to test it for 30 days without charge

The charge will be calculated only for running servers for Defender for PE P1 & P2

## MS 365 Subscriptions and Licesing
MS 365 componants, for more infor click here 

https://www.microsoft.com/licensing/terms/productoffering/Microsoft365/MCA

Enterprise Mobility + Security E3/E5: for more infor click here 

https://www.microsoft.com/licensing/terms/productoffering/EnterpriseMobilitySecurity/MCA#Addons

Windows Desktop Operating System: for more infor click here 

https://www.microsoft.com/licensing/terms/productoffering/WindowsDesktopOperatingSystem/MCA#LicenseModel

## Next features

[what is new for MS defender for Endpoint ](https://learn.microsoft.com/en-us/microsoft-365/security/defender-endpoint/whats-new-in-microsoft-defender-endpoint?view=o365-worldwide)

References:
- Overview of Microsoft Defender for Endpoint Plan 1

https://learn.microsoft.com/en-us/microsoft-365/security/defender-endpoint/defender-endpoint-plan-1?view=o365-worldwide

- Compare Microsoft endpoint security plans

https://learn.microsoft.com/en-us/microsoft-365/security/defender-endpoint/defender-endpoint-plan-1-2?view=o365-worldwide

- Pricing for Defender for Cloud

https://azure.microsoft.com/en-us/pricing/details/defender-for-cloud/

- Microsoft Defender for Business

https://learn.microsoft.com/en-us/microsoft-365/security/defender-business/mdb-overview?view=o365-worldwide

- Pricing for Microsft Defender for Business

https://www.microsoft.com/de-de/security/business/endpoint-security/microsoft-defender-business?market=de

- The Microsoft 365 admin center

https://admin.microsoft.com


