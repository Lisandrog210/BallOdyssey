using System.Collections.Generic;
using UnityEngine;

namespace ExaGames.Common.TimeBasedLifeSystem.LocalNotifications {
	public class IosNotificationScheduler : AbstractNotificationScheduler {
#pragma warning disable 414
		private static readonly Dictionary<string, string> notificationOptions = new Dictionary<string, string>() {
			{LOCAL_NOTIF_KEY, "" }
		};
#pragma warning restore 414

		public IosNotificationScheduler(NotificationSettingsStruct notificationSettings) : base(notificationSettings) {
			// On creation, register for local notifications if set in the inspector.
			if (notificationSettings.AllowLocalNotifications) {
				if (NotificationSettings.ConsoleDebugging) Debug.Log("Registering game for local notifications.");
#if UNITY_IOS
				UnityEngine.iOS.NotificationServices.RegisterForNotifications(UnityEngine.iOS.NotificationType.Alert | UnityEngine.iOS.NotificationType.Badge | UnityEngine.iOS.NotificationType.Sound);
#else
				UnityEngine.Debug.LogError("Cannot use IosNotificationScheduler to schedule notifications because the target platform is not iOS.");
#endif
			}
		}

		public override void ClearNotification() {
#if UNITY_IOS
			UnityEngine.iOS.LocalNotification notifToCancel = null;
			var localNotifications = UnityEngine.iOS.NotificationServices.scheduledLocalNotifications;

			try {
				for (int i = 0; i < localNotifications.Length; i++) {
					if (localNotifications[i].userInfo != null && localNotifications[i].userInfo.Count > 0 && localNotifications[i].userInfo.Contains(LOCAL_NOTIF_KEY)) {
						notifToCancel = localNotifications[i];
						break;
					}
				}
			}
			finally {
				if (notifToCancel != null) {
					if (NotificationSettings.ConsoleDebugging) Debug.Log("Canceling previous notification.");
					UnityEngine.iOS.NotificationServices.CancelLocalNotification(notifToCancel);
				}
			}
#else
			UnityEngine.Debug.LogError("Cannot use IosNotificationScheduler to schedule notifications because the target platform is not iOS.");
#endif
		}

		protected override void ScheduleDeviceNotification(double secondsDelay) {
#if UNITY_IOS
			var notification = new UnityEngine.iOS.LocalNotification {
				fireDate = System.DateTime.Now.AddSeconds(secondsDelay),
				alertBody = NotificationSettings.AlertBody,
				soundName = UnityEngine.iOS.LocalNotification.defaultSoundName,
				userInfo = notificationOptions
			};
			if (!string.IsNullOrEmpty(NotificationSettings.AlertAction.Trim())) notification.alertAction = NotificationSettings.AlertAction.Trim();
			UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notification);
#else
			UnityEngine.Debug.LogError("Cannot use IosNotificationScheduler to schedule notifications because the target platform is not iOS");
#endif
		}
	}
}