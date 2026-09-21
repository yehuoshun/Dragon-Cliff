using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace CodeStage.AntiCheat.Detectors
{
	// Token: 0x0200000E RID: 14
	[AddComponentMenu("Code Stage/Anti-Cheat Toolkit/Obscured Cheating Detector")]
	[HelpURL("http://codestage.net/uas_files/actk/api/class_code_stage_1_1_anti_cheat_1_1_detectors_1_1_obscured_cheating_detector.html")]
	public class ObscuredCheatingDetector : ActDetectorBase
	{
		// Token: 0x06000060 RID: 96 RVA: 0x00005D31 File Offset: 0x00004131
		private ObscuredCheatingDetector()
		{
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00005D65 File Offset: 0x00004165
		public static void StartDetection()
		{
			if (ObscuredCheatingDetector.Instance != null)
			{
				ObscuredCheatingDetector.Instance.StartDetectionInternal(null);
			}
			else
			{
				UnityEngine.Debug.LogError("[ACTk] Obscured Cheating Detector: can't be started since it doesn't exists in scene or not yet initialized!");
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00005D91 File Offset: 0x00004191
		public static void StartDetection(UnityAction callback)
		{
			ObscuredCheatingDetector.GetOrCreateInstance.StartDetectionInternal(callback);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00005D9E File Offset: 0x0000419E
		public static void StopDetection()
		{
			if (ObscuredCheatingDetector.Instance != null)
			{
				ObscuredCheatingDetector.Instance.StopDetectionInternal();
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005DBA File Offset: 0x000041BA
		public static void Dispose()
		{
			if (ObscuredCheatingDetector.Instance != null)
			{
				ObscuredCheatingDetector.Instance.DisposeInternal();
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00005DD6 File Offset: 0x000041D6
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00005DDD File Offset: 0x000041DD
		public static ObscuredCheatingDetector Instance
		{
			[CompilerGenerated]
			get
			{
				return ObscuredCheatingDetector.<Instance>k__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				ObscuredCheatingDetector.<Instance>k__BackingField = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00005DE8 File Offset: 0x000041E8
		private static ObscuredCheatingDetector GetOrCreateInstance
		{
			get
			{
				if (ObscuredCheatingDetector.Instance != null)
				{
					return ObscuredCheatingDetector.Instance;
				}
				if (ActDetectorBase.detectorsContainer == null)
				{
					ActDetectorBase.detectorsContainer = new GameObject("Anti-Cheat Toolkit Detectors");
				}
				ObscuredCheatingDetector.Instance = ActDetectorBase.detectorsContainer.AddComponent<ObscuredCheatingDetector>();
				return ObscuredCheatingDetector.Instance;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00005E3E File Offset: 0x0000423E
		internal static bool ExistsAndIsRunning
		{
			get
			{
				return ObscuredCheatingDetector.Instance != null && ObscuredCheatingDetector.Instance.IsRunning;
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005E57 File Offset: 0x00004257
		private void Awake()
		{
			ObscuredCheatingDetector.instancesInScene++;
			if (this.Init(ObscuredCheatingDetector.Instance, "Obscured Cheating Detector"))
			{
				ObscuredCheatingDetector.Instance = this;
			}
			SceneManager.sceneLoaded += this.OnLevelWasLoadedNew;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00005E91 File Offset: 0x00004291
		protected override void OnDestroy()
		{
			base.OnDestroy();
			ObscuredCheatingDetector.instancesInScene--;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00005EA5 File Offset: 0x000042A5
		private void OnLevelWasLoadedNew(Scene scene, LoadSceneMode mode)
		{
			this.OnLevelLoadedCallback();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00005EB0 File Offset: 0x000042B0
		private void OnLevelLoadedCallback()
		{
			if (ObscuredCheatingDetector.instancesInScene < 2)
			{
				if (!this.keepAlive)
				{
					this.DisposeInternal();
				}
			}
			else if (!this.keepAlive && ObscuredCheatingDetector.Instance != this)
			{
				this.DisposeInternal();
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00005F00 File Offset: 0x00004300
		private void StartDetectionInternal(UnityAction callback)
		{
			if (this.isRunning)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Obscured Cheating Detector: already running!", this);
				return;
			}
			if (!base.enabled)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Obscured Cheating Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!", this);
				return;
			}
			if (callback != null && this.detectionEventHasListener)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Obscured Cheating Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?", this);
			}
			if (callback == null && !this.detectionEventHasListener)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Obscured Cheating Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.", this);
				base.enabled = false;
				return;
			}
			this.detectionAction = callback;
			this.started = true;
			this.isRunning = true;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005F90 File Offset: 0x00004390
		protected override void StartDetectionAutomatically()
		{
			this.StartDetectionInternal(null);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00005F99 File Offset: 0x00004399
		protected override void PauseDetector()
		{
			this.isRunning = false;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005FA2 File Offset: 0x000043A2
		protected override void ResumeDetector()
		{
			if (this.detectionAction == null && !this.detectionEventHasListener)
			{
				return;
			}
			this.isRunning = true;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00005FC2 File Offset: 0x000043C2
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

		// Token: 0x06000072 RID: 114 RVA: 0x00005FE5 File Offset: 0x000043E5
		protected override void DisposeInternal()
		{
			base.DisposeInternal();
			if (ObscuredCheatingDetector.Instance == this)
			{
				ObscuredCheatingDetector.Instance = null;
			}
		}

		// Token: 0x0400007D RID: 125
		internal const string COMPONENT_NAME = "Obscured Cheating Detector";

		// Token: 0x0400007E RID: 126
		internal const string FINAL_LOG_PREFIX = "[ACTk] Obscured Cheating Detector: ";

		// Token: 0x0400007F RID: 127
		private static int instancesInScene;

		// Token: 0x04000080 RID: 128
		[Tooltip("Max allowed difference between encrypted and fake values in ObscuredFloat. Increase in case of false positives.")]
		public float floatEpsilon = 0.0001f;

		// Token: 0x04000081 RID: 129
		[Tooltip("Max allowed difference between encrypted and fake values in ObscuredVector2. Increase in case of false positives.")]
		public float vector2Epsilon = 0.1f;

		// Token: 0x04000082 RID: 130
		[Tooltip("Max allowed difference between encrypted and fake values in ObscuredVector3. Increase in case of false positives.")]
		public float vector3Epsilon = 0.1f;

		// Token: 0x04000083 RID: 131
		[Tooltip("Max allowed difference between encrypted and fake values in ObscuredQuaternion. Increase in case of false positives.")]
		public float quaternionEpsilon = 0.1f;

		// Token: 0x04000084 RID: 132
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static ObscuredCheatingDetector <Instance>k__BackingField;
	}
}
