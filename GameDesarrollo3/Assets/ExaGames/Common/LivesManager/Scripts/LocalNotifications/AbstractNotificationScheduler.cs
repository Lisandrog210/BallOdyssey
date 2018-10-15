using System;
using UnityEngine;

namespace ExaGames.Common.TimeBasedLifeSystem.LocalNotifications {
	/// <summary>
	/// Base class for notification schedulers.
	/// </summary>
	public abstract class AbstractNotificationScheduler {
		/// <summary>
		/// Key to identify the LivesManager notification among others.
		/// </summary>
		protected const string LOCAL_NOTIF_KEY = "ExaGames.TimeBasedLifeSystem";

		/// <summary>
		/// Local notification settings set in the Inspector.
		/// </summary>
		protected NotificationSettingsStruct NotificationSettings;

		/// <summary>
		/// Initializes an instance of a derived class from <see cref="AbstractNotificationScheduler"/>.
		/// </summary>
		/// <param name="notificationSettings">Settings for notifications.</param>
		public AbstractNotificationScheduler(NotificationSettingsStruct notificationSettings) {
			if(notificationSettings==null) throw new ArgumentNullException("notificationSettings");
			NotificationSettings = notificationSettings;
		}

		/// <summary>
		/// Schedules a notification to inform the player on lives replenished.
		/// </summary>
		public void ScheduleNotification(double secondsDelay) {
			if (!NotificationSettings.AllowLocalNotifications) return;
			if (string.IsNullOrEmpty(NotificationSettings.AlertBody)) {
				Debug.LogError("Could not schedule local notification because the AlertBody property has not been set.");
				return;
			}
			ClearNotification();
			if(NotificationSettings.ConsoleDebugging) Debug.LogFormat("Scheduling local notification in {0} seconds from now.", secondsDelay);
			ScheduleDeviceNotification(secondsDelay);
		}

		/// <summary>
		/// Clears the LivesManager local notification if previously set.
		/// </summary>
		public abstract void ClearNotification();

		/// <summary>
		/// When implemented by a derived class, schedules a notification to be sent to the device.
		/// </summary>
		/// <param name="secondsDelay">Seconds to wait for the notification.</param>
		protected abstract void ScheduleDeviceNotification(double secondsDelay);
	}
}