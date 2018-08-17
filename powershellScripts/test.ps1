	import-module webadministration

	$AppPoolName="SimpleWebApp"
	$SiteFolderPath="C:\inetpub\wwwroot\SimpleWebApp"
    $website="Default Web Site"
	$ManagedPipelineMode="Integrated"
	$ManagedRuntimeVersion="v4.0"
	$Enable32= $false
	$IdentityType="NetworkService"
	
	if(Test-Path IIS:\AppPools\$AppPoolName)
	{
	"AppPool already Exists, deleting the AppPool"
	$manager = Get-IISServerManager
	$manager.ApplicationPools[$AppPoolName].Delete()
	$manager.CommitChanges()
	}
	
	"Creating new app pool with provided configurations"
	$manager = Get-IISServerManager
	$pool = $manager.ApplicationPools.Add($AppPoolName)
	$pool.ManagedPipelineMode = $ManagedPipelineMode
	$pool.ManagedRuntimeVersion = $ManagedRuntimeVersion
	$pool.Enable32BitAppOnWin64 = $Enable32
	$pool.AutoStart = $true
	$pool.StartMode = "OnDemand"
	$pool.ProcessModel.IdentityType = $IdentityType
	$manager.CommitChanges()
	"App pool created succesfully"
	
	if ((Get-WebApplication -Name $AppPoolName) -eq $null) {
	"Creating Application on IIS"
	New-Item -Type Application -Path "IIS:\Sites\$website\$AppPoolName" -physicalPath $SiteFolderPath
	Write-Host "$AppPoolName application created"
	}
	else
	{
	Write-Host "$AppPoolName application already Exists"
	}
	
	Write-Host "Assigning App Pool: $AppPoolName to Application : $AppPoolName"
	Set-ItemProperty -Path "IIS:\Sites\$website\$AppPoolName" -name "applicationPool" -value $AppPoolName
	
	
	#  Anonymous: system.webServer/security/authentication/anonymousAuthentication
	#  Basic:     system.webServer/security/authentication/basicAuthentication
	#  Windows:   system.webServer/security/authentication/windowsAuthentication
	Write-Host "Setting application authentication as Windows Authenticated"
	Set-WebConfigurationProperty `
    -Filter "/system.webServer/security/authentication/windowsAuthentication" `
    -Name "enabled" `
    -Value $true `
    -Location "$website/$AppPoolName" `
    -PSPath IIS:\    # We are using the root (applicationHost.config) file

C:\Users\Hitesh\Downloads\software\jfrog.exe rt c rt-server-1 --url=http://localhost:8081/artifactory --user=admin --password=admin
	
C:\Users\Hitesh\Downloads\software\jfrog.exe rt use rt-server-1

C:\Users\Hitesh\Downloads\software\jfrog.exe rt upload bin\\ msbuild-local/SimpleWebApplication/ --flat=false --build-name=SimpleWebApplication --build-number=636701083926556180 
	
	
	
	
	
	
	
	
	# Stop the app pool before changing the settings
	
	# if ((Get-WebAppPoolState -name $AppPoolName).value -ne 'Stopped') {
	
			# Stop-WebAppPool -Name $AppPoolName
			# Write-Host "app pool stopped"
		 # } 
		 
		 # Write-Host "creating application"
		 # if ((Get-WebApplication -Name $AppPoolName) -eq $null) {
	
		# New-WebApplication -Name $AppPoolName -Site 'Default Web Site' -PhysicalPath $SiteFolderPath -ApplicationPool $AppPoolName
		# Write-Host "$AppPoolName application created"
		# }
		# else
		# {
		# Write-Host "$AppPoolName application already exists"
		# }
		
		# Check if application pool is already started
		# if ((Get-WebAppPoolState -name $AppPoolName).value -ne 'Started') {
			# Start-WebAppPool -Name $AppPoolName
			# Write-Host "starting the app pool"
		 # }

