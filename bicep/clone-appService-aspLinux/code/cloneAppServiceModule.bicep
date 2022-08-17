param aseName string
param aspName string
param name string
param location string
param linuxFxVersion string
param sourceWebAppId string

@allowed([
  'None'
  'SystemAssigned'
  'SystemAssigned, UserAssigned'
  'UserAssigned'
])
param identityType string

//create app sevice for Linux
resource appServiceLinuxRes 'Microsoft.Web/sites@2021-03-01' = {
  name: name
  location: location
  identity: {
    type: identityType
  }
  properties: {
    siteConfig: {
      linuxFxVersion: linuxFxVersion
      alwaysOn: true
    }
    serverFarmId: aspExisted.id
    clientAffinityEnabled: false
    hostingEnvironmentProfile: {
      id: aseExisted.id
    }
    cloningInfo: {
      sourceWebAppId: sourceWebAppId
    }

  }
  tags: {
  }
  dependsOn: []
}

resource aseExisted 'Microsoft.Web/hostingEnvironments@2021-03-01' existing = {
  name: aseName
}

resource aspExisted 'Microsoft.Web/serverfarms@2021-03-01' existing = {
  name: aspName
}
