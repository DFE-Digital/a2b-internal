﻿using ApplyToBecomeInternal.Extensions;
using ApplyToBecomeInternal.Models.Navigation;
using FluentAssertions;
using Xunit;

namespace ApplyToBecomeInternal.Tests.Extensions
{
	public class NavigationExtensionsTest
	{

		[Theory]
		[InlineData(NavigationTarget.ProjectsList, "Back to all conversion projects", "/projectlist")]
		[InlineData(NavigationTarget.ProjectNotes, "Back", "/project-notes/{id}")]
		[InlineData(NavigationTarget.PreviewHTBTemplate, "Back", "/task-list/{id}/preview-headteacher-board-template")]
		[InlineData(NavigationTarget.TaskList, "Back", "/task-list/{id}")]
		public void CustomNavigationAttribute_NavigationEnum_ReturnAttributeValues(NavigationTarget navigation, string expectedCopy, string expectedUrl)
		{
			var actual = navigation.GetContent();
			actual.Content.Should().Be(expectedCopy);
			actual.Url.Should().Be(expectedUrl);
		}
	}
}
