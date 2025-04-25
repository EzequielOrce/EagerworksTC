using Microsoft.Playwright;

namespace AutomationExerciseTests.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task GoToAsync()
        {
            await _page.GotoAsync("https://automationexercise.com/");
        }

        public async Task GoToLoginPageAsync()
        {
            await _page.ClickAsync("text=Signup / Login");
        }
    }
}
