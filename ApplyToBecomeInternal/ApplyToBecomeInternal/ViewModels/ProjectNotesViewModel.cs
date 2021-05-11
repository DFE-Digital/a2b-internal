using ApplyToBecomeInternal.Models.Navigation;

namespace ApplyToBecomeInternal.ViewModels
{
	public class ProjectNotesViewModel
	{

		public ProjectNotesViewModel(ProjectViewModel project)
		{
			Project = project;
			SubMenu = new SubMenuViewModel(project.Id, SubMenuPage.ProjectNotes);
			Navigation = new NavigationViewModel(NavigationTarget.ProjectsList);
		}

		public ProjectViewModel Project { get; }
		public SubMenuViewModel SubMenu { get; }
		public NavigationViewModel Navigation { get; set; }
	}
}