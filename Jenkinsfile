pipeline {
	agent any
	
	environment {
		BuildConfiguration="Debug"
	}

	stages {
		stage('Build') {
			steps {
				sh "dotnet build -c $BuildConfiguration"
			}
		}

		stage('Test') {
			steps {
				sh 'dotnet test -c $BuildConfiguration --no-build'
			}
		}

		
		stage('Pack') {
			steps {
				sh 'dotnet pack Tgs.Core.Infrastructures.Utility/Tgs.Core.Infrastructures.Utility.csproj -c $BuildConfiguration --no-build --no-restore'
			}
		}
		
		stage('Push Nuget') {   
			steps {
				sh  'dotnet nuget push Tgs.Core.Infrastructures.Utility/bin/$BuildConfiguration/*.nupkg --source "raypro" --skip-duplicate'
			}
		}
	}
}
