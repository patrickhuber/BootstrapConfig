#BootstrapConfig

BootstrapConfig is a library designed arouund bootstrapping configuration files at runtime.

##Setup

####Main (root of your application) app.config configuration
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="bootstrapConfig" type="BootstrapConfig.BootstrapMasterConfigurationSection, BootstrapConfig.Core"/>
  </configSections>
  <bootstrapConfig>    
    <directorySearcher type ="BoostrapConfig.DirectorySearcher, BootstrapConfig.Core"
      path="../../App_Config"
      searchPattern="*.config"
      recursive="true"/>
    <pathResolver type="BootstrapConfig.ExecPathResolver, BootstrapConfig.Core"/>
  </bootstrapConfig>
</configuration>
```
####Master (root of your web application) web.config configuration
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="bootstrapConfig" type="BootstrapConfig.BootstrapMasterConfigurationSection, BootstrapConfig.Core"/>
  </configSections>
  <bootstrapConfig>    
    <directorySearcher type ="BoostrapConfig.DirectorySearcher, BootstrapConfig.Core"
      path="~/App_Config"
      searchPattern="*.config"
      recursive="true"/>
    <pathResolver type="BootstrapConfig.Web.VirtualPathResolver, BootstrapConfig.Web"/>
  </bootstrapConfig>
</configuration>
```