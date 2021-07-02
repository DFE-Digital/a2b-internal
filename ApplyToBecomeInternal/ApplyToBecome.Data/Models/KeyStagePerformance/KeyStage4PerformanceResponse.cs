﻿namespace ApplyToBecome.Data.Models.KeyStagePerformance
{
	public class KeyStage4PerformanceResponse
	{
		public string Year { get; set; }
		public DisadvantagedPupilsResponse SipAttainment8score { get; set; }
		public DisadvantagedPupilsResponse SipAttainment8scoreenglish { get; set; }
		public DisadvantagedPupilsResponse SipAttainment8scoremaths { get; set; }
		public DisadvantagedPupilsResponse SipAttainment8scoreebacc { get; set; }
		public DisadvantagedPupilsResponse SipNumberofpupilsprogress8 { get; set; }
		public decimal? SipProgress8upperconfidence { get; set; }
		public decimal? SipProgress8lowerconfidence { get; set; }
		public DisadvantagedPupilsResponse SipProgress8english { get; set; }
		public DisadvantagedPupilsResponse SipProgress8maths { get; set; }
		public DisadvantagedPupilsResponse SipProgress8ebacc { get; set; }
		public DisadvantagedPupilsResponse SipProgress8Score { get; set; }
		public DisadvantagedPupilsResponse NationalAverageA8Score { get; set; }
		public DisadvantagedPupilsResponse NationalAverageA8English { get; set; }
		public DisadvantagedPupilsResponse NationalAverageA8Maths { get; set; }
		public DisadvantagedPupilsResponse NationalAverageA8EBacc { get; set; }
		public DisadvantagedPupilsResponse NationalAverageP8PupilsIncluded { get; set; }
		public DisadvantagedPupilsResponse NationalAverageP8Score { get; set; }
		public decimal? NationalAverageP8LowerConfidence { get; set; }
		public decimal? NationalAverageP8UpperConfidence { get; set; }
		public DisadvantagedPupilsResponse NationalAverageP8English { get; set; }
		public DisadvantagedPupilsResponse NationalAverageP8Maths { get; set; }
		public DisadvantagedPupilsResponse NationalAverageP8Ebacc { get; set; }
		public DisadvantagedPupilsResponse NationalAverage { get; set; }
	}
}
