using ApplyToBecome.Data.Models.Application;
using ApplyToBecomeInternal.Extensions;
using System.Collections.Generic;

namespace ApplyToBecomeInternal.Models.ApplicationForm.Sections
{
	public class LandAndBuildingsSection : BaseFormSection
	{
		public LandAndBuildingsSection(Application application) : base("Land and buildings")
		{
			SubSections = new[]
			{
				new FormSubSection("Details", GenerateDetailsFields(application))
			};
		}

		private static IEnumerable<FormField> GenerateDetailsFields(Application application) =>
			new[] {
				new FormField("As far as you're aware, who owns or holds the school's buildings and land?", application.LandAndBuildings.BuildingAndLandOwner),
				new FormField("Are there any current planned building works?", application.LandAndBuildings.HasCurrentPlannedBuildingWorks.ToYesNoString()),
				new FormField("Are there any shared facilities on site?", application.LandAndBuildings.HasSharedFacilitiesOnSite.ToYesNoString()),
				new FormField("Has the school had any grants from Sport England, the Big Lottery Fund, or the Football Federation?",application.LandAndBuildings.HasSchoolGrants.ToYesNoString()),
				new FormField("Is the school part of a Private Finance Intiative (PFI) scheme?", application.LandAndBuildings.HasPrivateFinanceInitiativeScheme.ToYesNoString()),
				new FormField("Is the school part of a Priority School Building Programme?", application.LandAndBuildings.IsInPrioritySchoolBuildingProgramme.ToYesNoString()),
				new FormField("Is the school part of a Building Schools for the Future Programme?", application.LandAndBuildings.IsInBuildingSchoolsForFutureProgramme.ToYesNoString())
			};
	}
}