using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeStage.AntiCheat.Detectors
{
	// Token: 0x0200000B RID: 11
	[AddComponentMenu("")]
	public abstract class ActDetectorBase : MonoBehaviour
	{
		// Token: 0x06000036 RID: 54 RVA: 0x00005445 File Offset: 0x00003845
		protected ActDetectorBase()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00005462 File Offset: 0x00003862
		public bool IsRunning
		{
			get
			{
				return this.isRunning;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000546C File Offset: 0x0000386C
		private void Start()
		{
			if (ActDetectorBase.detectorsContainer == null && base.gameObject.name == "Anti-Cheat Toolkit Detectors")
			{
				ActDetectorBase.detectorsContainer = base.gameObject;
			}
			if (this.autoStart && !this.started)
			{
				this.StartDetectionAutomatically();
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000054CA File Offset: 0x000038CA
		private void OnEnable()
		{
			if (!this.started || (!this.detectionEventHasListener && this.detectionAction == null && !this.DetectorHasAdditionalCallbacks()))
			{
				return;
			}
			this.ResumeDetector();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000054FF File Offset: 0x000038FF
		private void OnDisable()
		{
			if (!this.started)
			{
				return;
			}
			this.PauseDetector();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005513 File Offset: 0x00003913
		private void OnApplicationQuit()
		{
			this.DisposeInternal();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000551C File Offset: 0x0000391C
		protected virtual void OnDestroy()
		{
			this.StopDetectionInternal();
			if (base.transform.childCount == 0 && base.GetComponentsInChildren<Component>().Length <= 2)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else if (base.name == "Anti-Cheat Toolkit Detectors" && base.GetComponentsInChildren<ActDetectorBase>().Length <= 1)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000558C File Offset: 0x0000398C
		protected virtual bool Init(ActDetectorBase instance, string detectorName)
		{
			if (instance != null && instance != this && instance.keepAlive)
			{
				Debug.LogWarning("[ACTk] " + base.name + ": self-destroying, other instance already exists & only one instance allowed!", base.gameObject);
				UnityEngine.Object.Destroy(this);
				return false;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			return true;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000055F0 File Offset: 0x000039F0
		protected virtual void DisposeInternal()
		{
			UnityEngine.Object.Destroy(this);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000055F8 File Offset: 0x000039F8
		protected virtual bool DetectorHasAdditionalCallbacks()
		{
			return false;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000055FC File Offset: 0x000039FC
		internal virtual void OnCheatingDetected()
		{
			if (this.detectionAction != null)
			{
				this.detectionAction();
			}
			if (this.detectionEventHasListener)
			{
				this.detectionEvent.Invoke();
			}
			if (this.autoDispose)
			{
				this.DisposeInternal();
			}
			else
			{
				this.StopDetectionInternal();
			}
		}

		// Token: 0x06000041 RID: 65
		protected abstract void StartDetectionAutomatically();

		// Token: 0x06000042 RID: 66
		protected abstract void StopDetectionInternal();

		// Token: 0x06000043 RID: 67
		protected abstract void PauseDetector();

		// Token: 0x06000044 RID: 68
		protected abstract void ResumeDetector();

		// Token: 0x04000067 RID: 103
		protected const string CONTAINER_NAME = "Anti-Cheat Toolkit Detectors";

		// Token: 0x04000068 RID: 104
		protected const string MENU_PATH = "Code Stage/Anti-Cheat Toolkit/";

		// Token: 0x04000069 RID: 105
		protected const string GAME_OBJECT_MENU_PATH = "GameObject/Create Other/Code Stage/Anti-Cheat Toolkit/";

		// Token: 0x0400006A RID: 106
		protected static GameObject detectorsContainer;

		// Token: 0x0400006B RID: 107
		[Tooltip("Automatically start detector. Detection Event will be called on detection.")]
		public bool autoStart = true;

		// Token: 0x0400006C RID: 108
		[Tooltip("Detector will survive new level (scene) load if checked.")]
		public bool keepAlive = true;

		// Token: 0x0400006D RID: 109
		[Tooltip("Automatically dispose Detector after firing callback.")]
		public bool autoDispose = true;

		// Token: 0x0400006E RID: 110
		[SerializeField]
		protected UnityEvent detectionEvent;

		// Token: 0x0400006F RID: 111
		protected UnityAction detectionAction;

		// Token: 0x04000070 RID: 112
		[SerializeField]
		protected bool detectionEventHasListener;

		// Token: 0x04000071 RID: 113
		protected bool started;

		// Token: 0x04000072 RID: 114
		protected bool isRunning;
	}
}
