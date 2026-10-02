pipeline {
    agent any
    environment {
        DOTNET_CLI_HOME="C:\\Program Files\\dotnet"
    }
    stages {
        stage("Checkout") {
            steps {
                checkout scm
            }

        }
        stage("Restore") {
            steps {
                bat "dotnet restore JWTWithCoreApis.sln"
            }
        }

        stage("Build") {
            steps {
                bat "dotnet build JWTWithCoreApis.sln --configuration Release"
            }
        }
        stage("Test") {
            steps {
                bat "dotnet test --no-restore --configuration Release"
            }
        }
        stage("Publish") {
            steps {
                bat "dotnet publish --no-restore --configuration Release --output .\\publish"
            }
        }
        stage("Deployment") {
            steps {
                // bat 'del /q /s "C:\\inetpub\\wwwroot\\WebApp\\"'
                // bat '"xcopy /E /Y /I "publish\\*" "C:\\inetpub\\wwwroot\\WebApp\\"'
                bat '''
                        if exist "C:\\inetpub\\wwwroot\\WebApp" rmdir /q /s "C:\\inetpub\\wwwroot\\WebApp"
                        mkdir "C:\\inetpub\\wwwroot\\WebApp"
                    '''
                bat "C:\\Windows\\System32\\xcopy.exe /E /Y /I publish\\* C:\\inetpub\\wwwroot\\WebApp\\"
            }
        }
    }
    post {
        success {
            echo "Build, Test, Publish Stages Completed Successfully."
        }
    }
}
