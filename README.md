# EagerworksTC
Eagerworks QA Automation - Technical Challenge.
This project contains both UI tests (using Playwright) and API tests (using NUnit and HTTP client) for the Automation Exercise website.


## Table of Contents

- [How to Run the Tests](#how-to-run-the-tests)

- [Test Descriptions](#test-descriptions)
  - [UI Tests](#ui-tests)
  - [API Tests](#api-tests)
- [Improvements](#improvements)




## How to Run the Tests

### 1. Clone the Repository

```bash
git clone https://github.com/EzequielOrce/EagerworksTC
```
### 2. Install Dependencies

```bash
dotnet add package Microsoft.Playwright
dotnet add package NUnit
dotnet add package Newtonsoft.Json
dotnet tool install --global Microsoft.Playwright.CLI
playwright install
```
### 3. Execute Tests 
#### All tests (UI+Api)
```bash
dotnet test
```
#### Run Only UI Tests (Playwright)
```bash
dotnet test --filter "Category=UI"
```
#### Run Only API Tests
```bash
dotnet test --filter "Category=API"
```

## Test Descriptions

### UI Tests
```bash
Signup Test: Automates the user signup process with valid data and verifies account creation.

Login Test: Automates login with valid credentials and checks for successful login.
```
**Warning**: this tests need to be run in order, since the Login test uses the user created on the Signup Test. This should be addressed to give tests indepence on each other.


### API Tests
```bash
Get List of Users: Validates that the /api/users?page=2 endpoint returns a list of users, checking status code, headers, response time, and presence of user data.

Get Single User: Validates that the /api/users/2 endpoint returns the correct user details, checking status code, headers, response time, and email structure
```

## Improvements

- Constants are hardcoded. This might present problems on future scalability

- Urls are plain text on the code, this might present future security problems, urls should be environment variables
- Tests are not independent, as written before, robust tests should not need an specific order to run, if any of them need to be run in isoliation it should not present problems.
- For visual validation, the headless property should be set to false, Playwirght has this property on true as defult. 

