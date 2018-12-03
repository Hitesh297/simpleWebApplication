node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat 'nuget restore SimpleWebApplication.sln -source http://localhost:8081/artifactory/api/nuget/nuget'
		bat "\"${tool 'MSBuild'}\" SimpleWebApplication.sln /p:Configuration=Release /P:PublishProfile=SimpleWebApp /P:DeployOnBuild=True /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"

	stage 'Archive'
		archive 'SimpleWebApp/SimpleWebApplication/bin/**'

}
