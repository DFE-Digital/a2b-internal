using ApplyToBecome.Data.Models.KeyStagePerformance;
using ApplyToBecome.Data.Services;
using ApplyToBecomeInternal.Services;
using ApplyToBecomeInternal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ApplyToBecomeInternal.Pages.TaskList
{
	public class IndexModel : BaseAcademyConversionProjectPageModel
    {
		private readonly KeyStagePerformanceService _keyStagePerformanceService;
		private readonly ErrorService _errorService;

		public IndexModel(KeyStagePerformanceService keyStagePerformanceService, IAcademyConversionProjectRepository repository, ErrorService errorService) : base(repository)
		{
			_keyStagePerformanceService = keyStagePerformanceService;
			_errorService = errorService;
		}

		public TaskListViewModel TaskList { get; set; }
		public bool ShowGenerateHtbTemplateError;

		public override async Task<IActionResult> OnGetAsync(int id)
		{
			await SetProject(id);
			var keyStagePerformance = await _keyStagePerformanceService.GetKeyStagePerformance(Project.SchoolURN);

			// 16 plus = 6, All-through = 7, Middle deemed primary = 3, Middle deemed secondary = 5, Not applicable = 0, Nursery = 1, Primary = 2, Secondary = 4
			TaskList = TaskListViewModel.Build(Project);
			TaskList.HasKeyStage2PerformanceTables = keyStagePerformance.KeyStage2?.Any(HasKeyStage2PerformanceTables) ?? false;
			TaskList.HasKeyStage4PerformanceTables = false;
			TaskList.HasKeyStage5PerformanceTables = false;

			return Page();
		}

		public string SuccessPage
		{
			get
			{
				return TempData[nameof(SuccessPage)].ToString();
			}
			set
			{
				TempData[nameof(SuccessPage)] = value;
			}
		}

		public async Task<IActionResult> OnPostAsync(int id)
		{
			await SetProject(id);
			if (Project.HeadTeacherBoardDate == null)
            {
	            ShowGenerateHtbTemplateError = true;
            	_errorService.AddError($"/task-list/{Project.Id}/confirm-school-trust-information-project-dates#head-teacher-board-date",
            		"Set an HTB date before you generate your document");
                await OnGetAsync(int.Parse(Project.Id));
                return Page();
            }
			return RedirectToPage(SuccessPage, new { id });
		}

		private bool HasKeyStage2PerformanceTables(KeyStage2PerformanceResponse keyStage2Performance)
		{
			return HasValue(keyStage2Performance.PercentageMeetingExpectedStdInRWM)
				|| HasValue(keyStage2Performance.PercentageAchievingHigherStdInRWM)
				|| HasValue(keyStage2Performance.ReadingProgressScore)
				|| HasValue(keyStage2Performance.WritingProgressScore)
				|| HasValue(keyStage2Performance.MathsProgressScore);
		}

		private bool HasValue(DisadvantagedPupilsResponse disadvantagedPupilsResponse)
		{
			return !string.IsNullOrEmpty(disadvantagedPupilsResponse.NotDisadvantaged)
				|| !string.IsNullOrEmpty(disadvantagedPupilsResponse.Disadvantaged);
		}
	}
}
