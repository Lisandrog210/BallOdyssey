using UnityEngine;

namespace ExaGames.Common.TimeBasedLifeSystem.LocalNotifications {
	public class UnknownPlatformNotificationScheduler : AbstractNotificationScheduler {
		public UnknownPlatformNotificationScheduler(NotificationSettingsStruct notificationSettings) : base(notificationSettings) { }

		public override void ClearNotification() {}

		protected override void ScheduleDeviceNotification(double secondsDelay) {
			Debug.LogWarning("Notification won't be scheduled because the target platform is not supported.");
		}
	}
}