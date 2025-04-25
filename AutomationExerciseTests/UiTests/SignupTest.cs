using AutomationExerciseTests.Pages;
using NUnit.Framework;

namespace AutomationExerciseTests.UiTests
{
    public class SignupTests : TestBase
    {
        [Test]
        public async Task Signup_WithValidData_ShouldCreateAccount()
        {
            var home = new HomePage(Page);
            var signup = new SignupPage(Page);
            var email = $"user_{DateTime.Now.Ticks}@mail.com";

            await home.GoToAsync();
            await home.GoToLoginPageAsync();
            await signup.FillSignupFormAsync("RenzoTester", email);
            await signup.FillAccountDetailsAsync("123456");

            await File.WriteAllTextAsync("temp_email.txt", email);

            Assert.That(await signup.IsAccountCreatedAsync(), Is.True, "account not created.");
        }
    }
}
