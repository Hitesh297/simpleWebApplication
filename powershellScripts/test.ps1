	import-module webadministration

	$AppPoolName="SimpleWebApp"
	$SiteFolderPath="C:\inetpub\wwwroot\SimpleWebApp"
	

	if(Test-Path IIS:\AppPools\$AppPoolName)
	{
	"AppPool already Exists"
	}
	else
	{
	"AppPool is not present"
	"Creating new AppPool"
	New-WebAppPool "$AppPoolName" -Force
	"setting identity as Network Service"
	Set-ItemProperty IIS:\AppPools\$AppPoolName -name processModel.identityType -value 2
	}

	
	# Stop the app pool before changing the settings
	
	# if ((Get-WebAppPoolState -name $AppPoolName).value -ne 'Stopped') {
	
			# Stop-WebAppPool -Name $AppPoolName
			# Write-Host "app pool stopped"
		 # } 
		 

		 $website="Default Web Site"
		  Write-Host "creating application"
		  #get-webapplication -Name "SurveyAPI"
		 if ((Get-WebApplication -Name $AppPoolName) -eq $null) {
		# Create the Web Application
		New-WebApplication -Name $AppPoolName -Site 'Default Web Site' -PhysicalPath $SiteFolderPath -ApplicationPool $AppPoolName
		Write-Host "$AppPoolName application created"
		}
		else
		{
		Write-Host "$AppPoolName application already exists"
		}
		
		# Check if application pool is already started
		# if ((Get-WebAppPoolState -name $AppPoolName).value -ne 'Started') {
			# Start-WebAppPool -Name $AppPoolName
			# Write-Host "starting the app pool"
		 # }

