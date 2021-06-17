using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace ApplyToBecomeInternal.Tests.Pages.GeneralInformation
{
	public class ViabilityIssuesIntegrationTests : BaseIntegrationTests
	{
		public ViabilityIssuesIntegrationTests(IntegrationTestingWebApplicationFactory factory) : base(factory) { }

		[Fact]
		public async Task Should_navigate_to_and_update_viability_issues()
		{
			var project = AddGetProject(p => p.ViabilityIssues = "No");
			var request = AddPatchProject(project, r => r.ViabilityIssues, "Yes");

			await OpenUrlAsync($"/task-list/{project.Id}/confirm-general-information");
			await NavigateAsync("Change", 1);

			Document.Url.Should().BeUrl($"/task-list/{project.Id}/confirm-general-information/viability-issues");
			Document.QuerySelector<IHtmlInputElement>("#viability-issues").IsChecked.Should().BeFalse();
			Document.QuerySelector<IHtmlInputElement>("#viability-issues-2").IsChecked.Should().BeTrue();

			Document.QuerySelector<IHtmlInputElement>("#viability-issues-2").IsChecked = false;
			Document.QuerySelector<IHtmlInputElement>("#viability-issues").IsChecked = true;

			Document.QuerySelector<IHtmlInputElement>("#viability-issues").IsChecked.Should().BeTrue();
			Document.QuerySelector<IHtmlInputElement>("#viability-issues-2").IsChecked.Should().BeFalse();

			await Document.QuerySelector<IHtmlFormElement>("form").SubmitAsync();

			Document.Url.Should().BeUrl($"/task-list/{project.Id}/confirm-general-information");
		}

		[Fact]
		public async Task Should_show_error_summary_when_there_is_an_API_error()
		{
			var project = AddGetProject();
			AddPatchError(project.Id);

			await OpenUrlAsync($"/task-list/{project.Id}/confirm-general-information/viability-issues");

			await Document.QuerySelector<IHtmlFormElement>("form").SubmitAsync();

			Document.QuerySelector(".govuk-error-summary").Should().NotBeNull();
		}

		[Fact]
		public async Task Should_navigate_back_to_viability_issues()
		{
			var project = AddGetProject();

			await OpenUrlAsync($"/task-list/{project.Id}/confirm-general-information/viability-issues");
			await NavigateAsync("Back");

			Document.Url.Should().BeUrl($"/task-list/{project.Id}/confirm-general-information");
		}
	}
}