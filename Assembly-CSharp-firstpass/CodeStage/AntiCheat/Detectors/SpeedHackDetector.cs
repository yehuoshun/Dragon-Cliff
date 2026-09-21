using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace CodeStage.AntiCheat.Detectors
{
	// Token: 0x0200000F RID: 15
	[AddComponentMenu("Code Stage/Anti-Cheat Toolkit/Speed Hack Detector")]
	[HelpURL("http://codestage.net/uas_files/actk/api/class_code_stage_1_1_anti_cheat_1_1_detectors_1_1_speed_hack_detector.html")]
	public class SpeedHackDetector : ActDetectorBase
	{
		// Token: 0x06000073 RID: 115 RVA: 0x00006003 File Offset: 0x00004403
		private SpeedHackDetector()
		{
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00006028 File Offset: 0x00004428
		public static void StartDetection()
		{
			if (SpeedHackDetector.Instance != null)
			{
				SpeedHackDetector.Instance.StartDetectionInternal(null, SpeedHackDetector.Instance.interval, SpeedHackDetector.Instance.maxFalsePositives, SpeedHackDetector.Instance.coolDown);
			}
			else
			{
				UnityEngine.Debug.LogError("[ACTk] Speed Hack Detector: can't be started since it doesn't exists in scene or not yet initialized!");
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000607D File Offset: 0x0000447D
		public static void StartDetection(UnityAction callback)
		{
			SpeedHackDetector.StartDetection(callback, SpeedHackDetector.GetOrCreateInstance.interval);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000608F File Offset: 0x0000448F
		public static void StartDetection(UnityAction callback, float interval)
		{
			SpeedHackDetector.StartDetection(callback, interval, SpeedHackDetector.GetOrCreateInstance.maxFalsePositives);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000060A2 File Offset: 0x000044A2
		public static void StartDetection(UnityAction callback, float interval, byte maxFalsePositives)
		{
			SpeedHackDetector.StartDetection(callback, interval, maxFalsePositives, SpeedHackDetector.GetOrCreateInstance.coolDown);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000060B6 File Offset: 0x000044B6
		public static void StartDetection(UnityAction callback, float interval, byte maxFalsePositives, int coolDown)
		{
			SpeedHackDetector.GetOrCreateInstance.StartDetectionInternal(callback, interval, maxFalsePositives, coolDown);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000060C6 File Offset: 0x000044C6
		public static void StopDetection()
		{
			if (SpeedHackDetector.Instance != null)
			{
				SpeedHackDetector.Instance.StopDetectionInternal();
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000060E2 File Offset: 0x000044E2
		public static void Dispose()
		{
			if (SpeedHackDetector.Instance != null)
			{
				SpeedHackDetector.Instance.DisposeInternal();
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600007B RID: 123 RVA: 0x000060FE File Offset: 0x000044FE
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00006105 File Offset: 0x00004505
		public static SpeedHackDetector Instance
		{
			[CompilerGenerated]
			get
			{
				return SpeedHackDetector.<Instance>k__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				SpeedHackDetector.<Instance>k__BackingField = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00006110 File Offset: 0x00004510
		private static SpeedHackDetector GetOrCreateInstance
		{
			get
			{
				if (SpeedHackDetector.Instance != null)
				{
					return SpeedHackDetector.Instance;
				}
				if (ActDetectorBase.detectorsContainer == null)
				{
					ActDetectorBase.detectorsContainer = new GameObject("Anti-Cheat Toolkit Detectors");
				}
				SpeedHackDetector.Instance = ActDetectorBase.detectorsContainer.AddComponent<SpeedHackDetector>();
				return SpeedHackDetector.Instance;
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00006166 File Offset: 0x00004566
		private void Awake()
		{
			SpeedHackDetector.instancesInScene++;
			if (this.Init(SpeedHackDetector.Instance, "Speed Hack Detector"))
			{
				SpeedHackDetector.Instance = this;
			}
			SceneManager.sceneLoaded += this.OnLevelWasLoadedNew;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000061A0 File Offset: 0x000045A0
		protected override void OnDestroy()
		{
			base.OnDestroy();
			SpeedHackDetector.instancesInScene--;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000061B4 File Offset: 0x000045B4
		private void OnLevelWasLoadedNew(Scene scene, LoadSceneMode mode)
		{
			this.OnLevelLoadedCallback();
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000061BC File Offset: 0x000045BC
		private void OnLevelLoadedCallback()
		{
			if (SpeedHackDetector.instancesInScene < 2)
			{
				if (!this.keepAlive)
				{
					this.DisposeInternal();
				}
			}
			else if (!this.keepAlive && SpeedHackDetector.Instance != this)
			{
				this.DisposeInternal();
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000620B File Offset: 0x0000460B
		private void OnApplicationPause(bool pause)
		{
			if (!pause)
			{
				this.ResetStartTicks();
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000621C File Offset: 0x0000461C
		private void Update()
		{
			if (!this.isRunning)
			{
				return;
			}
			long ticks = DateTime.UtcNow.Ticks;
			long num = ticks - this.prevTicks;
			if (num < 0L || num > 10000000L)
			{
				this.ResetStartTicks();
				return;
			}
			this.prevTicks = ticks;
			long num2 = (long)(this.interval * 1E+07f);
			if (ticks - this.prevIntervalTicks < num2)
			{
				return;
			}
			long num3 = ticks - this.ticksOnStart;
			long num4 = (long)Environment.TickCount * 10000L;
			bool flag = Mathf.Abs((float)(num4 - this.vulnerableTicksOnStart - num3)) > 5000000f;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			bool flag2 = Math.Abs((float)num3 / 1E+07f - (realtimeSinceStartup - this.vulnerableTimeOnStart)) > 0.5f;
			if (flag || flag2)
			{
				this.currentFalsePositives += 1;
				if (this.currentFalsePositives > this.maxFalsePositives)
				{
					this.OnCheatingDetected();
				}
				else
				{
					this.currentCooldownShots = 0;
					this.ResetStartTicks();
				}
			}
			else if (this.currentFalsePositives > 0 && this.coolDown > 0)
			{
				this.currentCooldownShots++;
				if (this.currentCooldownShots >= this.coolDown)
				{
					this.currentFalsePositives = 0;
				}
			}
			this.prevIntervalTicks = ticks;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00006378 File Offset: 0x00004778
		private void StartDetectionInternal(UnityAction callback, float checkInterval, byte falsePositives, int shotsTillCooldown)
		{
			if (this.isRunning)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Speed Hack Detector: already running!", this);
				return;
			}
			if (!base.enabled)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Speed Hack Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!", this);
				return;
			}
			if (callback != null && this.detectionEventHasListener)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Speed Hack Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?", this);
			}
			if (callback == null && !this.detectionEventHasListener)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Speed Hack Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.", this);
				base.enabled = false;
				return;
			}
			this.detectionAction = callback;
			this.interval = checkInterval;
			this.maxFalsePositives = falsePositives;
			this.coolDown = shotsTillCooldown;
			this.ResetStartTicks();
			this.currentFalsePositives = 0;
			this.currentCooldownShots = 0;
			this.started = true;
			this.isRunning = true;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00006432 File Offset: 0x00004832
		protected override void StartDetectionAutomatically()
		{
			this.StartDetectionInternal(null, this.interval, this.maxFalsePositives, this.coolDown);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000644D File Offset: 0x0000484D
		protected override void PauseDetector()
		{
			this.isRunning = false;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00006456 File Offset: 0x00004856
		protected override void ResumeDetector()
		{
			if (this.detectionAction == null && !this.detectionEventHasListener)
			{
				return;
			}
			this.isRunning = true;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00006476 File Offset: 0x00004876
		protected override void StopDetectionInternal()
		{
			if (!this.started)
			{
				return;
			}
			this.detectionAction = null;
			this.started = false;
			this.isRunning = false;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00006499 File Offset: 0x00004899
		protected override void DisposeInternal()
		{
			base.DisposeInternal();
			if (SpeedHackDetector.Instance == this)
			{
				SpeedHackDetector.Instance = null;
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000064B8 File Offset: 0x000048B8
		private void ResetStartTicks()
		{
			this.ticksOnStart = DateTime.UtcNow.Ticks;
			this.vulnerableTicksOnStart = (long)Environment.TickCount * 10000L;
			this.prevTicks = this.ticksOnStart;
			this.prevIntervalTicks = this.ticksOnStart;
			this.vulnerableTimeOnStart = Time.realtimeSinceStartup;
		}

		// Token: 0x04000085 RID: 133
		internal const string COMPONENT_NAME = "Speed Hack Detector";

		// Token: 0x04000086 RID: 134
		internal const string FINAL_LOG_PREFIX = "[ACTk] Speed Hack Detector: ";

		// Token: 0x04000087 RID: 135
		private const long TICKS_PER_SECOND = 10000000L;

		// Token: 0x04000088 RID: 136
		private const int THRESHOLD = 5000000;

		// Token: 0x04000089 RID: 137
		private const float THRESHOLD_FLOAT = 0.5f;

		// Token: 0x0400008A RID: 138
		private static int instancesInScene;

		// Token: 0x0400008B RID: 139
		[Tooltip("Time (in seconds) between detector checks.")]
		public float interval = 1f;

		// Token: 0x0400008C RID: 140
		[Tooltip("Maximum false positives count allowed before registering speed hack.")]
		public byte maxFalsePositives = 3;

		// Token: 0x0400008D RID: 141
		[Tooltip("Amount of sequential successful checks before clearing internal false positives counter.\nSet 0 to disable Cool Down feature.")]
		public int coolDown = 30;

		// Token: 0x0400008E RID: 142
		private byte currentFalsePositives;

		// Token: 0x0400008F RID: 143
		private int currentCooldownShots;

		// Token: 0x04000090 RID: 144
		private long ticksOnStart;

		// Token: 0x04000091 RID: 145
		private long vulnerableTicksOnStart;

		// Token: 0x04000092 RID: 146
		private long prevTicks;

		// Token: 0x04000093 RID: 147
		private long prevIntervalTicks;

		// Token: 0x04000094 RID: 148
		private float vulnerableTimeOnStart;

		// Token: 0x04000095 RID: 149
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static SpeedHackDetector <Instance>k__BackingField;
	}
}
