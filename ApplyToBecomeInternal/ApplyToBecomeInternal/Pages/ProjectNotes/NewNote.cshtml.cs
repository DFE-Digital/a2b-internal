using ApplyToBecome.Data;
using ApplyToBecome.Data.Models.ProjectNotes;
using ApplyToBecomeInternal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApplyToBecomeInternal.Pages.ProjectNotes
{
	public class NewNoteModel : BaseProjectPageModel
	{
		private readonly IProjectNotes _projectNotes;

		public NewNoteModel(IProjects projects, IProjectNotes projectNotes) : base(projects)
		{
			_projectNotes = projectNotes;
		}

		[BindProperty]
		public string subject { get; set; }

		[BindProperty]
		public string body { get; set; }

		public IActionResult OnPost(int id)
		{
			var note = new ProjectNote(subject, body);
			_projectNotes.SaveNote(id, note);
			TempData["newNote"] = true;
			return RedirectToPage(Links.ProjectNotes.Index.Page, new { id = id });
		}
	}
}
