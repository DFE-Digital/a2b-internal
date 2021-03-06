﻿using System;

namespace ApplyToBecomeInternal.Services.WordDocument
{
	public class DocumentTextAttribute : Attribute
	{
		private readonly string _placeholder;

		public DocumentTextAttribute(string placeholder)
		{
			_placeholder = placeholder;
		}

		public string Placeholder => $"[{_placeholder}]";

		public string Default { get; set; }
		public bool IsRichText { get; set; }
	}
}
