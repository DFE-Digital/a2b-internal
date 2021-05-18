using ApplyToBecome.Data;
using ApplyToBecomeInternal.Models.Navigation;
using ApplyToBecomeInternal.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApplyToBecomeInternal.Pages.TaskList2
{
	public class IndexModel : PageModel
    {
		private readonly IProjects _projects;

		public ProjectViewModel Project { get; set; }
		public SubMenuViewModel SubMenu { get; set; }
		public NavigationViewModel Navigation { get; set; }

		public IndexModel(IProjects projects)
		{
			_projects = projects;
		}

		public void OnGet(int id)
        {
			var project = _projects.GetProjectById(id);
			var projectViewModel = new ProjectViewModel(project);
			Project = projectViewModel;
			SubMenu = new SubMenuViewModel(projectViewModel.Id, SubMenuPage.TaskList);
			Navigation = new NavigationViewModel(NavigationTarget.ProjectsList);
		}
    }
}
