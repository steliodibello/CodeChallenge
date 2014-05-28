<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Bookings.Endpoint.Azure" generation="1" functional="0" release="0" Id="5efb95db-6255-4eb2-8138-db5ae9427a11" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="Bookings.Endpoint.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="Bookings.Endpoint:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/LB:Bookings.Endpoint:Endpoint1" />
          </inToChannel>
        </inPort>
        <inPort name="Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/LB:Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="">
          <maps>
            <mapMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </maps>
        </aCS>
        <aCS name="Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="">
          <maps>
            <mapMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </maps>
        </aCS>
        <aCS name="Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="">
          <maps>
            <mapMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </maps>
        </aCS>
        <aCS name="Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </maps>
        </aCS>
        <aCS name="Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </maps>
        </aCS>
        <aCS name="Bookings.EndpointInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/MapBookings.EndpointInstances" />
          </maps>
        </aCS>
        <aCS name="Certificate|Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" defaultValue="">
          <maps>
            <mapMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/MapCertificate|Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:Bookings.Endpoint:Endpoint1">
          <toPorts>
            <inPortMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Endpoint1" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput">
          <toPorts>
            <inPortMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp">
          <toPorts>
            <inPortMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" kind="Identity">
          <setting>
            <aCSMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </setting>
        </map>
        <map name="MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" kind="Identity">
          <setting>
            <aCSMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </setting>
        </map>
        <map name="MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" kind="Identity">
          <setting>
            <aCSMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </setting>
        </map>
        <map name="MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </setting>
        </map>
        <map name="MapBookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </setting>
        </map>
        <map name="MapBookings.EndpointInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.EndpointInstances" />
          </setting>
        </map>
        <map name="MapCertificate|Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" kind="Identity">
          <certificate>
            <certificateMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </certificate>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Bookings.Endpoint" generation="1" functional="0" release="0" software="C:\Users\debellos\Desktop\skypeTest\C#\Bookings.Endpoint.Azure\csx\Debug\roles\Bookings.Endpoint" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp" portRanges="3389" />
              <outPort name="Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/SW:Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;Bookings.Endpoint&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Bookings.Endpoint&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
            <storedcertificates>
              <storedCertificate name="Stored0Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
                </certificate>
              </storedCertificate>
            </storedcertificates>
            <certificates>
              <certificate name="Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
            </certificates>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.EndpointInstances" />
            <sCSPolicyFaultDomainMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.EndpointFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="Bookings.EndpointFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="Bookings.EndpointInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="697e5275-0a33-4c70-9978-63c65c78a1e6" ref="Microsoft.RedDog.Contract\ServiceContract\Bookings.Endpoint.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="35b06916-8a68-40fc-81bc-d93d8d2e1f79" ref="Microsoft.RedDog.Contract\Interface\Bookings.Endpoint:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint:Endpoint1" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="999e1265-c908-4e25-b709-40a61cb2d852" ref="Microsoft.RedDog.Contract\Interface\Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/Bookings.Endpoint.Azure/Bookings.Endpoint.AzureGroup/Bookings.Endpoint:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>