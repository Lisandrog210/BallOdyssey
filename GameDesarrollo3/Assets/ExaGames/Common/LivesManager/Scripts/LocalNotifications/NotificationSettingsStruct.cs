using System;
using UnityEngine;

namespace ExaGames.Common.TimeBasedLifeSystem.LocalNotifications {
	/// <summary>
	/// Notification settings container.
	/// </summary>
	[Serializable]
	public class NotificationSettingsStruct {
		/// <summary>
		/// Indicates wether the lives manager should support local notifications.
		/// </summary>
		[Tooltip("Indicates wether the lives manager should support local notifications.")]
		public bool AllowLocalNotifications = true;
		/// <summary>
		/// Custom alert action for the scheduled notifications.
		/// </summary>
		[Tooltip("Custom alert action for the scheduled notifications.")]
		public string AlertAction;
		/// <summary>
		/// Custom text for scheduled notifications.
		/// </summary>
		[Tooltip("Custom text for scheduled notifications.")]
		public string AlertBody = "All lives have been recovered!";
		/// <summary>
		/// When set to true, logs the activity of the notification scheduler to the console.
		/// </summary>
		[Tooltip("When checked, logs the activity of the notification scheduler to the console.")]
		public bool ConsoleDebugging = true;
	}
}