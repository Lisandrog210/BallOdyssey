using System;
using UnityEngine;

#if ANDROID_NOTIFICATIONS
using Assets.SimpleAndroidNotifications;
#endif

namespace ExaGames.Common.TimeBasedLifeSystem.LocalNotifications {
	public class AndroidNotificationScheduler : AbstractNotificationScheduler {
		public AndroidNotificationScheduler(NotificationSettingsStruct notificationSettings) : base(notificationSettings) { }

		public override void ClearNotification() {
#if UNITY_ANDROID
	#if ANDROID_NOTIFICATIONS
			if (PlayerPrefs.HasKey(LOCAL_NOTIF_KEY)) {
				if (NotificationSettings.ConsoleDebugging) Debug.Log("Canceling previous notification.");
				NotificationManager.Cancel(PlayerPrefs.GetInt(LOCAL_NOTIF_KEY));
			}
	#else
			//UnityEngine.Debug.LogError("Cannot use AndroidNotificationScheduler to schedule notifications because the symbol ANDROID_NOTIFICATIONS is not defined. Please see Time-Based Life System's Readme file.");
	#endif
#else
			//UnityEngine.Debug.LogError("Cannot use AndroidNotificationScheduler to schedule notifications because the target platform is not Android.");
#endif
		}

		protected override void ScheduleDeviceNotification(double secondsDelay) {
#if UNITY_ANDROID
	#if ANDROID_NOTIFICATIONS
			PlayerPrefs.SetInt(
				LOCAL_NOTIF_KEY,
				NotificationManager.SendWithAppIcon(
					TimeSpan.FromSeconds(secondsDelay),
					Application.productName,
					NotificationSettings.AlertBody,
					new Color(0, 0.6f, 1),
					NotificationIcon.Star));
	#else
				UnityEngine.Debug.LogError("Cannot use AndroidNotificationScheduler to schedule notifications because the symbol ANDROID_NOTIFICATIONS is not defined. Please see Time-Based Life System's Readme file.");
	#endif
#else
			UnityEngine.Debug.LogError("Cannot use AndroidNotificationScheduler to schedule notifications because the target platform is not Android.");
#endif
		}
	}
}