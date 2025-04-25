using Microsoft.Playwright;

namespace AutomationExerciseTests.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task LoginAsync(string email, string password)
        {
            await _page.FillAsync("input[data-qa='login-email']", email);
            await _page.FillAsync("input[data-qa='login-password']", password);
            await _page.ClickAsync("button[data-qa='login-button']");
        }

        public async Task<bool> IsLoginSuccessfulAsync()
        {
            return await _page.Locator("text=Logged in as").IsVisibleAsync();
        }
    }
}
