# Rest-API-GitHub-Tests
![image](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![image](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![image](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)
![image](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)
[![NUnit](https://img.shields.io/badge/tested%20with-NUnit-22B2B0.svg)](https://nunit.org/)

### This is a test project for **Back-End Test Automation** March 2024 Course @ SoftUni
---
## Project Description
This project is designed to test various functionalities of the GitHub API using RestSharp and NUnit. The purpose is to automate the testing of RESTful web services to ensure they work correctly and handle errors gracefully.

## Technologies Used
- **RestSharp**: A powerful library to simplify HTTP requests in .NET.
- **NUnit**: A popular unit testing framework for .NET applications.

## GitHub API Endpoints
- GitHub Issues provides the standard RESTful API endpoints, which you can access with HTTP client from [GitHub API edndpoints](https://api.github.com)
- This project tests various endpoints of the GitHub API.
- For a full list of available endpoints, refer to the [GitHub API documentation](https://docs.github.com/en/rest)

## GitHub API Project 
- **RestSharpServices**: Methods that interact with the GitHub API using RestSharp.
- **TestGitHubApi**: Tests to verify the functionality of the RestSharpServices methods.
- **Models**: These classes represent the data that the GitHub API will send and receive.

## Setting Up the RestSharp Client
The constructor takes three parameters:
- **BaseUrl**: The root URL of the GitHub API. This is where all API requests will start from.
- **Username**: Your GitHub username.
- **Token**: Your GitHub personal access token. This is used for authentication and allows you to interact with the GitHub API.

## Implementing API Methods and Tests
 **Incremental Approach**: To use this apprach you have to write one method, then immediately write the corresponding test to validate it. Then Repeat this process for each method. This approach helps to focus on one piece of functionality at a time and makes debugging easier.

## Contributing
Contributions are welcome! If you have any improvements or bug fixes, feel free to open a pull request.

## License
This project is licensed under the [MIT License](LICENSE). See the [LICENSE](LICENSE) file for details.

## Contact
For any questions or suggestions, please reach out to me or open an issue in the repository.
