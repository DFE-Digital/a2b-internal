using ApplyToBecome.Data;
using ApplyToBecomeInternal.Models.Navigation;
using ApplyToBecomeInternal.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ApplyToBecomeInternal.Pages.TaskList
{
	public class GenerateHTBTemplateModel : PageModel
    {
		private readonly IProjects _projects;

		public ProjectViewModel Project { get; set; }
		public NavigationViewModel Navigation { get; set; }

		public GenerateHTBTemplateModel(IProjects projects)
		{
			_projects = projects;
		}

		public void OnGet(int id)
		{
			var project = _projects.GetProjectById(id);
			Project = new ProjectViewModel(project);
			var templateData = new[] { new KeyValuePair<string, string>("id", Project.Id) };
			Navigation = new NavigationViewModel(NavigationTarget.PreviewHTBTemplate, templateData);
		}
	}
}