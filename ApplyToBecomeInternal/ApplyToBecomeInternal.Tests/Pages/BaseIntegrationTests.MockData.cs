﻿using ApplyToBecome.Data.Models;
using ApplyToBecomeInternal.Tests.Customisations;
using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SchoolPerformanceModel = ApplyToBecome.Data.Models.SchoolPerformance;

namespace ApplyToBecomeInternal.Tests.Pages
{
	public abstract partial class BaseIntegrationTests
	{
		protected IEnumerable<Project> AddGetProjects()
		{
			var projects = _fixture.CreateMany<Project>();
			_factory.AddGetWithJsonResponse("/conversion-projects", projects);
			return projects;
		}

		public Project AddGetProject(Action<Project> postSetup = null)
		{
			var project = _fixture.Create<Project>();
			if (postSetup != null)
			{
				postSetup(project);
			}
			_factory.AddGetWithJsonResponse($"/conversion-projects/{project.Id}", project);
			return project;
		}

		public (Project, UpdateProject) AddGetAndPatchProject<TProperty>(Expression<Func<UpdateProject, TProperty>> expression)
		{
			var project = _fixture.Create<Project>();
			var request = _fixture
				.Build<UpdateProject>()
				.OmitAutoProperties()
				.With(expression)
				.Create();

			_factory.AddGetWithJsonResponse($"/conversion-projects/{project.Id}", project);
			_factory.AddPatchWithJsonRequest($"/conversion-projects/{project.Id}", request, project);
			return (project, request);
		}

		public SchoolPerformanceModel AddGetSchoolPerformance(string urn)
		{
			_fixture.Customizations.Add(new OfstedRatingSpecimenBuilder());
			var establishmentMockData = _fixture.Create<EstablishmentMockData>();
			_factory.AddGetWithJsonResponse($"/establishment/urn/{urn}", establishmentMockData);
			return establishmentMockData.misEstablishment;
		}

		private class EstablishmentMockData
		{
			public SchoolPerformanceModel misEstablishment { get; set; }

			public DateTime ofstedLastInspection { get; set; }
		}
	}
}
