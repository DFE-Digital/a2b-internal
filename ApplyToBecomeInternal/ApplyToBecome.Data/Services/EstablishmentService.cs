﻿using ApplyToBecome.Data.Models.Establishment;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApplyToBecome.Data.Services
{
	public class EstablishmentService : IGetEstablishment
	{
		private readonly HttpClient _httpClient;
		private readonly ILogger<SchoolPerformanceService> _logger;

		public EstablishmentService(IHttpClientFactory httpClientFactory, ILogger<SchoolPerformanceService> logger)
		{
			_httpClient = httpClientFactory.CreateClient("TramsClient");
			_logger = logger;
		}

		public async Task<EstablishmentResponse> GetEstablishmentByUrn(string urn)
		{
			var response = await _httpClient.GetAsync($"/establishment/urn/{urn}");
			if (!response.IsSuccessStatusCode)
			{
				_logger.LogWarning("Unable to get establishment data for establishment with URN: {urn}", urn);
				return new EstablishmentResponse();
			}

			return await response.Content.ReadFromJsonAsync<EstablishmentResponse>();
		}
	}
}