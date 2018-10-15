namespace ExaGames.Common.TimeBasedLifeSystem.LocalNotifications {
	public static class NotificationSchedulerFactory {
		/// <summary>
		/// Creates a notification scheduler depending on the target platform.
		/// </summary>
		/// <param name="notificationSettings">Settings for notifications.</param>
		/// <returns>The notification scheduler.</returns>
		public static AbstractNotificationScheduler CreateScheduler(NotificationSettingsStruct notificationSettings) {
			AbstractNotificationScheduler result = null;
#if UNITY_IOS
			result = new IosNotificationScheduler(notificationSettings);
#elif UNITY_ANDROID
			result = new AndroidNotificationScheduler(notificationSettings);
#else
			result = new UnknownPlatformNotificationScheduler(notificationSettings);
#endif
			return result;
		}
	}
}