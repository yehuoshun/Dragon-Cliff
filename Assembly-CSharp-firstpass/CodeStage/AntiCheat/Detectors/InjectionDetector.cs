using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace CodeStage.AntiCheat.Detectors
{
	// Token: 0x0200000C RID: 12
	[AddComponentMenu("Code Stage/Anti-Cheat Toolkit/Injection Detector")]
	[HelpURL("http://codestage.net/uas_files/actk/api/class_code_stage_1_1_anti_cheat_1_1_detectors_1_1_injection_detector.html")]
	public class InjectionDetector : ActDetectorBase
	{
		// Token: 0x06000045 RID: 69 RVA: 0x00005651 File Offset: 0x00003A51
		private InjectionDetector()
		{
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005659 File Offset: 0x00003A59
		public static void StartDetection()
		{
			if (InjectionDetector.Instance != null)
			{
				InjectionDetector.Instance.StartDetectionInternal(null, null);
			}
			else
			{
				UnityEngine.Debug.LogError("[ACTk] Injection Detector: can't be started since it doesn't exists in scene or not yet initialized!");
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005686 File Offset: 0x00003A86
		public static void StartDetection(UnityAction callback)
		{
			InjectionDetector.GetOrCreateInstance.StartDetectionInternal(callback, null);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005694 File Offset: 0x00003A94
		public static void StartDetection(UnityAction<string> callback)
		{
			InjectionDetector.GetOrCreateInstance.StartDetectionInternal(null, callback);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000056A2 File Offset: 0x00003AA2
		public static void StopDetection()
		{
			if (InjectionDetector.Instance != null)
			{
				InjectionDetector.Instance.StopDetectionInternal();
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000056BE File Offset: 0x00003ABE
		public static void Dispose()
		{
			if (InjectionDetector.Instance != null)
			{
				InjectionDetector.Instance.DisposeInternal();
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000056DA File Offset: 0x00003ADA
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000056E1 File Offset: 0x00003AE1
		public static InjectionDetector Instance
		{
			[CompilerGenerated]
			get
			{
				return InjectionDetector.<Instance>k__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				InjectionDetector.<Instance>k__BackingField = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000056EC File Offset: 0x00003AEC
		private static InjectionDetector GetOrCreateInstance
		{
			get
			{
				if (InjectionDetector.Instance != null)
				{
					return InjectionDetector.Instance;
				}
				if (ActDetectorBase.detectorsContainer == null)
				{
					ActDetectorBase.detectorsContainer = new GameObject("Anti-Cheat Toolkit Detectors");
				}
				InjectionDetector.Instance = ActDetectorBase.detectorsContainer.AddComponent<InjectionDetector>();
				return InjectionDetector.Instance;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00005742 File Offset: 0x00003B42
		private void Awake()
		{
			InjectionDetector.instancesInScene++;
			if (this.Init(InjectionDetector.Instance, "Injection Detector"))
			{
				InjectionDetector.Instance = this;
			}
			SceneManager.sceneLoaded += this.OnLevelWasLoadedNew;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000577C File Offset: 0x00003B7C
		protected override void OnDestroy()
		{
			base.OnDestroy();
			InjectionDetector.instancesInScene--;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00005790 File Offset: 0x00003B90
		private void OnLevelWasLoadedNew(Scene scene, LoadSceneMode mode)
		{
			this.OnLevelLoadedCallback();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00005798 File Offset: 0x00003B98
		private void OnLevelLoadedCallback()
		{
			if (InjectionDetector.instancesInScene < 2)
			{
				if (!this.keepAlive)
				{
					this.DisposeInternal();
				}
			}
			else if (!this.keepAlive && InjectionDetector.Instance != this)
			{
				this.DisposeInternal();
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000057E8 File Offset: 0x00003BE8
		private void StartDetectionInternal(UnityAction callback, UnityAction<string> callbackWithArgument)
		{
			if (this.isRunning)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Injection Detector: already running!", this);
				return;
			}
			if (!base.enabled)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Injection Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!", this);
				return;
			}
			if ((callback != null || callbackWithArgument != null) && this.detectionEventHasListener)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Injection Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?", this);
			}
			if (callback == null && callbackWithArgument == null && !this.detectionEventHasListener)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Injection Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.", this);
				base.enabled = false;
				return;
			}
			this.detectionAction = callback;
			this.detectionActionWithArgument = callbackWithArgument;
			this.started = true;
			this.isRunning = true;
			if (this.allowedAssemblies == null)
			{
				this.LoadAndParseAllowedAssemblies();
			}
			if (this.signaturesAreNotGenuine)
			{
				this.OnCheatingDetected("signatures");
				return;
			}
			string cause;
			if (!this.FindInjectionInCurrentAssemblies(out cause))
			{
				AppDomain.CurrentDomain.AssemblyLoad += this.OnNewAssemblyLoaded;
			}
			else
			{
				this.OnCheatingDetected(cause);
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000058E2 File Offset: 0x00003CE2
		protected override void StartDetectionAutomatically()
		{
			this.StartDetectionInternal(null, null);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000058EC File Offset: 0x00003CEC
		protected override void PauseDetector()
		{
			this.isRunning = false;
			AppDomain.CurrentDomain.AssemblyLoad -= this.OnNewAssemblyLoaded;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000590C File Offset: 0x00003D0C
		protected override void ResumeDetector()
		{
			if (this.detectionAction == null && this.detectionActionWithArgument == null && !this.detectionEventHasListener)
			{
				return;
			}
			this.isRunning = true;
			AppDomain.CurrentDomain.AssemblyLoad += this.OnNewAssemblyLoaded;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00005958 File Offset: 0x00003D58
		protected override void StopDetectionInternal()
		{
			if (!this.started)
			{
				return;
			}
			AppDomain.CurrentDomain.AssemblyLoad -= this.OnNewAssemblyLoaded;
			this.detectionAction = null;
			this.detectionActionWithArgument = null;
			this.started = false;
			this.isRunning = false;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00005998 File Offset: 0x00003D98
		protected override void DisposeInternal()
		{
			base.DisposeInternal();
			if (InjectionDetector.Instance == this)
			{
				InjectionDetector.Instance = null;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000059B6 File Offset: 0x00003DB6
		private void OnCheatingDetected(string cause)
		{
			if (this.detectionActionWithArgument != null)
			{
				this.detectionActionWithArgument(cause);
			}
			base.OnCheatingDetected();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000059D5 File Offset: 0x00003DD5
		private void OnNewAssemblyLoaded(object sender, AssemblyLoadEventArgs args)
		{
			if (!this.AssemblyAllowed(args.LoadedAssembly))
			{
				this.OnCheatingDetected(args.LoadedAssembly.FullName);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000059FC File Offset: 0x00003DFC
		private bool FindInjectionInCurrentAssemblies(out string cause)
		{
			cause = null;
			bool result = false;
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			if (assemblies.Length == 0)
			{
				cause = "no assemblies";
				result = true;
			}
			else
			{
				foreach (Assembly assembly in assemblies)
				{
					if (!this.AssemblyAllowed(assembly))
					{
						cause = assembly.FullName;
						result = true;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00005A6C File Offset: 0x00003E6C
		private bool AssemblyAllowed(Assembly ass)
		{
			string name = ass.GetName().Name;
			int assemblyHash = this.GetAssemblyHash(ass);
			bool result = false;
			for (int i = 0; i < this.allowedAssemblies.Length; i++)
			{
				InjectionDetector.AllowedAssembly allowedAssembly = this.allowedAssemblies[i];
				if (allowedAssembly.name == name && Array.IndexOf<int>(allowedAssembly.hashes, assemblyHash) != -1)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00005AE0 File Offset: 0x00003EE0
		private void LoadAndParseAllowedAssemblies()
		{
			TextAsset textAsset = (TextAsset)Resources.Load("fndid", typeof(TextAsset));
			if (textAsset == null)
			{
				this.signaturesAreNotGenuine = true;
				return;
			}
			string[] separator = new string[]
			{
				":"
			};
			MemoryStream memoryStream = new MemoryStream(textAsset.bytes);
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			int num = binaryReader.ReadInt32();
			this.allowedAssemblies = new InjectionDetector.AllowedAssembly[num];
			for (int i = 0; i < num; i++)
			{
				string text = binaryReader.ReadString();
				text = ObscuredString.EncryptDecrypt(text, "Elina");
				string[] array = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				int num2 = array.Length;
				if (num2 <= 1)
				{
					this.signaturesAreNotGenuine = true;
					binaryReader.Close();
					memoryStream.Close();
					return;
				}
				string name = array[0];
				int[] array2 = new int[num2 - 1];
				for (int j = 1; j < num2; j++)
				{
					array2[j - 1] = int.Parse(array[j]);
				}
				this.allowedAssemblies[i] = new InjectionDetector.AllowedAssembly(name, array2);
			}
			binaryReader.Close();
			memoryStream.Close();
			Resources.UnloadAsset(textAsset);
			this.hexTable = new string[256];
			for (int k = 0; k < 256; k++)
			{
				this.hexTable[k] = k.ToString("x2");
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00005C50 File Offset: 0x00004050
		private int GetAssemblyHash(Assembly ass)
		{
			AssemblyName name = ass.GetName();
			byte[] publicKeyToken = name.GetPublicKeyToken();
			string text;
			if (publicKeyToken.Length >= 8)
			{
				text = name.Name + this.PublicKeyTokenToString(publicKeyToken);
			}
			else
			{
				text = name.Name;
			}
			int num = 0;
			int length = text.Length;
			for (int i = 0; i < length; i++)
			{
				num += (int)text[i];
				num += num << 10;
				num ^= num >> 6;
			}
			num += num << 3;
			num ^= num >> 11;
			return num + (num << 15);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00005CE4 File Offset: 0x000040E4
		private string PublicKeyTokenToString(byte[] bytes)
		{
			string text = string.Empty;
			for (int i = 0; i < 8; i++)
			{
				text += this.hexTable[(int)bytes[i]];
			}
			return text;
		}

		// Token: 0x04000073 RID: 115
		internal const string COMPONENT_NAME = "Injection Detector";

		// Token: 0x04000074 RID: 116
		internal const string FINAL_LOG_PREFIX = "[ACTk] Injection Detector: ";

		// Token: 0x04000075 RID: 117
		protected UnityAction<string> detectionActionWithArgument;

		// Token: 0x04000076 RID: 118
		private static int instancesInScene;

		// Token: 0x04000077 RID: 119
		private bool signaturesAreNotGenuine;

		// Token: 0x04000078 RID: 120
		private InjectionDetector.AllowedAssembly[] allowedAssemblies;

		// Token: 0x04000079 RID: 121
		private string[] hexTable;

		// Token: 0x0400007A RID: 122
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static InjectionDetector <Instance>k__BackingField;

		// Token: 0x0200000D RID: 13
		private class AllowedAssembly
		{
			// Token: 0x0600005F RID: 95 RVA: 0x00005D1B File Offset: 0x0000411B
			public AllowedAssembly(string name, int[] hashes)
			{
				this.name = name;
				this.hashes = hashes;
			}

			// Token: 0x0400007B RID: 123
			public readonly string name;

			// Token: 0x0400007C RID: 124
			public readonly int[] hashes;
		}
	}
}
