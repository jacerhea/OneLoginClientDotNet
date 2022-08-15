using System;

namespace OneLogin.Types
{
	public class AppSummary
	{
		/// <summary>
		/// ID of the application
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Name of the application.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Indicates whether the app is visible.
		/// </summary>
		public bool? Visible { get; set; }

		/// <summary>
		/// ID of the apps underlying connector.
		/// </summary>
		public int? ConnectorId { get; set; }

		/// <summary>
		/// Type of app
		/// </summary>
		public AppAuthMethod? AuthMethod { get; set; }

		/// <summary>
		/// The date the app was created.
		/// </summary>
		public DateTime? CreatedAt { get; set; }

		/// <summary>
		/// The date the app was last updated.
		/// </summary>
		public DateTime? UpdatedAt { get; set; }
	}
}
