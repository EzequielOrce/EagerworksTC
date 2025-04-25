using Microsoft.Playwright;

namespace AutomationExerciseTests.Pages
{
    public class SignupPage
    {
        private readonly IPage _page;

        public SignupPage(IPage page)
        {
            _page = page;
        }

        public async Task FillSignupFormAsync(string name, string email)
        {
            await _page.FillAsync("input[data-qa='signup-name']", name);
            await _page.FillAsync("input[data-qa='signup-email']", email);
            await _page.ClickAsync("button[data-qa='signup-button']");
        }

        public async Task FillAccountDetailsAsync(string password)
        {
            await _page.CheckAsync("#id_gender1");
            await _page.FillAsync("#password", password);
            await _page.SelectOptionAsync("#days", "1");
            await _page.SelectOptionAsync("#months", "1");
            await _page.SelectOptionAsync("#years", "2000");

            await _page.FillAsync("#first_name", "Renzo");
            await _page.FillAsync("#last_name", "Tester");
            await _page.FillAsync("#address1", "Calle Falsa 123");
            await _page.SelectOptionAsync("#country", "Canada");
            await _page.FillAsync("#state", "Ontario");
            await _page.FillAsync("#city", "Toronto");
            await _page.FillAsync("#zipcode", "12345");
            await _page.FillAsync("#mobile_number", "123456789");
            await _page.ClickAsync("button[data-qa='create-account']");
        }

        public async Task<bool> IsAccountCreatedAsync()
        {
            return await _page.Locator("text=Account Created!").IsVisibleAsync();
        }
    }
}
