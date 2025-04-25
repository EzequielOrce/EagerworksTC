using AutomationExerciseTests.Pages;
using NUnit.Framework;

namespace AutomationExerciseTests.UiTests
{
    public class LoginTests : TestBase
    {
        [Test]
        public async Task Login_WithValidCredentials_ShouldSucceed()
        {
            var home = new HomePage(Page);
            var login = new LoginPage(Page);
            var email = await File.ReadAllTextAsync("temp_email.txt");

            await home.GoToAsync();
            await home.GoToLoginPageAsync();
            await login.LoginAsync(email, "123456");

            Assert.That(await login.IsLoginSuccessfulAsync(), Is.True, "login error.");

            File.Delete("temp_email.txt");
        }
    }
}
