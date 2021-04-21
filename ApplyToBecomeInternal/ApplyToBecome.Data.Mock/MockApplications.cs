using ApplyToBecome.Data.Models;
using ApplyToBecome.Data.Models.Application;

namespace ApplyToBecome.Data.Mock
{
	public class MockApplications:IApplications
	{
		public Application GetApplication(string id)
		{
			return new Application{
				School = new School{
					Name = "St Wilfrid's Primary School"
				},
				Trust = new Trust{
					Name = "Dynamics Trust",
				},
				LeadApplicant = "Garth Brown",
				Details = new ApplicationDetails{
					EvidenceDocument = new Link("consent_dynamics.docx", "#"),
					ChangesToGovernance = false,
					ChangesAtLocalLevel = true
				}
			};
		}
	}
}