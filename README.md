BootstrapConfig
===============

BootstrapConfig is a library designed arouund bootstrapping configuration files at runtime.

Setup
-----

###Main (root of your application) app.config configuration
```XML
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="bootstrap.core" type="BootstrapConfig.BootstrapMagerConfigurationSection, BootstrapConfig.Core"/>
  </configSections>
  <bootstrap.core>    
    <directorySearcher type ="BoostrapConfig.DirectorySearcher, BootstrapConfig.Core"
      path="../../App_Config"
      searchPattern="*.config"
      recursive="true"/>
    <pathResolver type="BootstrapConfig.ExecPathResolver, BootstrapConfig.Core"/>
  </bootstrap.core>
</configuration>
```
###Master (root of your web application) web.config configuration