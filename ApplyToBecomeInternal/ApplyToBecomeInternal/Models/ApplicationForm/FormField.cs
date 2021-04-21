namespace ApplyToBecomeInternal.Models.ApplicationForm
{
	public class FormField
	{
		public FormField(string title, string content)
		{
			Title = title;
			Content = content;
		}

		public string Title { get; }
		public string Content { get; }
	}
}