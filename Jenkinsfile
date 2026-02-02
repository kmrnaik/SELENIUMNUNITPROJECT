pipeline {
    agent any

    environment {
        // Define any environment variables here
        BUILD_DIR = "c:/SeleniumNUnitProject"
        TEST_RESULTS = "${BUILD_DIR}/bin/Debug/net10.0/TestResults"
    }

    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code...'
                checkout scm
            }
        }

        stage('Restore Dependencies') {
            steps {
                echo 'Restoring NuGet packages...'
                bat 'dotnet restore ${BUILD_DIR}/SeleniumNUnitProject.sln'
            }
        }

        stage('Build') {
            steps {
                echo 'Building the solution...'
                bat 'dotnet build ${BUILD_DIR}/SeleniumNUnitProject.sln --configuration Debug'
            }
        }

        stage('Run Tests') {
            steps {
                echo 'Running NUnit tests...'
                bat 'dotnet test ${BUILD_DIR}/SeleniumNUnitProject.sln --logger:trx --results-directory ${TEST_RESULTS}'
            }
        }

        stage('Publish Test Results') {
            steps {
                echo 'Publishing test results...'
                junit allowEmptyResults: true, testResults: "${TEST_RESULTS}/*.trx"
            }
        }

        stage('Archive Logs') {
            steps {
                echo 'Archiving logs and reports...'
                archiveArtifacts artifacts: '**/TestResults/*.html', allowEmptyArchive: true
            }
        }

        stage('Install Dependencies') {
            steps {
                echo 'Installing necessary dependencies...'
                bat 'dotnet tool install --global Selenium.WebDriver.ChromeDriver'
            }
        }
    }

    post {
        always {
            echo 'Cleaning up workspace...'
            cleanWs()
        }
        success {
            echo 'Build completed successfully!'
        }
        failure {
            echo 'Build failed. Please check the logs.'
        }
    }
}