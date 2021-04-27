﻿namespace ApplyToBecomeInternal.Models.Shared
{
	public enum NavigationTarget
	{
		[Navigation(content: "Back to all conversion projects", url: "/projectlist")]
		ProjectsList,
		[Navigation(content: "Back", url: "/project-notes/{id}")]
		ProjectNotes
	}
}
