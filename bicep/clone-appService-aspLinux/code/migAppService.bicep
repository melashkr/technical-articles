param sourceSubId string
param sourceRgName string
param sourceWebAppName string
param targetAseName string
param targetAspName string
param targetAppName string
param location string
param linuxFxVersion string
param identityType string
param deployName string = 'deploy-apps${utcNow('yyyyMMdd_HHmmss')}'

module createAppServiceRes 'cloneAppServiceModule.bicep' = {
  name: deployName
  params: {
    aseName: targetAseName
    aspName: targetAspName
    linuxFxVersion: linuxFxVersion
    location: location
    name: targetAppName
    sourceWebAppId: sourceWebApp.id
    identityType: identityType
  }
}

resource sourceWebApp 'Microsoft.Web/sites@2021-03-01' existing = {
  scope: resourceGroup(sourceSubId, sourceRgName)
  name: sourceWebAppName
}
