﻿using ApplyToBecome.Data.Models;
using ApplyToBecomeInternal.Models;
using FluentAssertions;
using Xunit;

namespace ApplyToBecomeInternal.Tests.Models
{
	public class TaskListViewModelTests
	{
		[Fact]
		public void Constructor_WithProject_SetsProperties()
		{
			var project = new Project()
			{
				School = new School
				{
					Name = "Test School",
					URN = "AS_102062"
				}
			};

			var projectViewModel = new TaskListViewModel(project);

			projectViewModel.SchoolName.Should().Be("Test School");
			projectViewModel.SchoolURN.Should().Be("AS_102062");
		}
	}
}