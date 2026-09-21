using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace CodeStage.AntiCheat.Detectors
{
	// Token: 0x02000010 RID: 16
	[AddComponentMenu("Code Stage/Anti-Cheat Toolkit/Time Cheating Detector")]
	[HelpURL("http://codestage.net/uas_files/actk/api/class_code_stage_1_1_anti_cheat_1_1_detectors_1_1_time_cheating_detector.html")]
	public class TimeCheatingDetector : ActDetectorBase
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00006510 File Offset: 0x00004910
		private TimeCheatingDetector()
		{
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00006578 File Offset: 0x00004978
		public bool IsCheckingForCheat
		{
			get
			{
				return this.checkingForCheat;
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00006580 File Offset: 0x00004980
		public static void StartDetection()
		{
			if (TimeCheatingDetector.Instance != null)
			{
				TimeCheatingDetector.Instance.StartDetectionInternal(null, null, TimeCheatingDetector.Instance.interval);
			}
			else
			{
				UnityEngine.Debug.LogError("[ACTk] Time Cheating Detector: can't be started since it doesn't exists in scene or not yet initialized!");
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000065B7 File Offset: 0x000049B7
		public static void StartDetection(UnityAction detectionCallback, UnityAction errorCallback = null)
		{
			TimeCheatingDetector.StartDetection(detectionCallback, errorCallback, TimeCheatingDetector.GetOrCreateInstance.interval);
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000065CA File Offset: 0x000049CA
		public static void StartDetection(UnityAction detectionCallback, int interval)
		{
			TimeCheatingDetector.StartDetection(detectionCallback, null, interval);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000065D4 File Offset: 0x000049D4
		public static void StartDetection(UnityAction detectionCallback, UnityAction errorCallback, int interval)
		{
			TimeCheatingDetector.GetOrCreateInstance.StartDetectionInternal(detectionCallback, errorCallback, interval);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000065E3 File Offset: 0x000049E3
		public static void StopDetection()
		{
			if (TimeCheatingDetector.Instance != null)
			{
				TimeCheatingDetector.Instance.StopDetectionInternal();
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000065FF File Offset: 0x000049FF
		public static void SetErrorCallback(UnityAction errorCallback)
		{
			if (TimeCheatingDetector.Instance != null)
			{
				TimeCheatingDetector.Instance.errorAction = errorCallback;
			}
			else
			{
				UnityEngine.Debug.LogError("[ACTk] Time Cheating Detector: Can't set error callback since detector is not created or initialized yet.");
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000662B File Offset: 0x00004A2B
		public static void Dispose()
		{
			if (TimeCheatingDetector.Instance != null)
			{
				TimeCheatingDetector.Instance.DisposeInternal();
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00006647 File Offset: 0x00004A47
		// (set) Token: 0x06000095 RID: 149 RVA: 0x0000664E File Offset: 0x00004A4E
		public static TimeCheatingDetector Instance
		{
			[CompilerGenerated]
			get
			{
				return TimeCheatingDetector.<Instance>k__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				TimeCheatingDetector.<Instance>k__BackingField = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00006658 File Offset: 0x00004A58
		private static TimeCheatingDetector GetOrCreateInstance
		{
			get
			{
				if (TimeCheatingDetector.Instance != null)
				{
					return TimeCheatingDetector.Instance;
				}
				if (ActDetectorBase.detectorsContainer == null)
				{
					ActDetectorBase.detectorsContainer = new GameObject("Anti-Cheat Toolkit Detectors");
				}
				TimeCheatingDetector.Instance = ActDetectorBase.detectorsContainer.AddComponent<TimeCheatingDetector>();
				return TimeCheatingDetector.Instance;
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000066AE File Offset: 0x00004AAE
		private void Awake()
		{
			TimeCheatingDetector.instancesInScene++;
			if (this.Init(TimeCheatingDetector.Instance, "Time Cheating Detector"))
			{
				TimeCheatingDetector.Instance = this;
			}
			SceneManager.sceneLoaded += this.OnLevelWasLoadedNew;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000066E8 File Offset: 0x00004AE8
		protected override void OnDestroy()
		{
			base.OnDestroy();
			TimeCheatingDetector.instancesInScene--;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000066FC File Offset: 0x00004AFC
		private void OnLevelWasLoadedNew(Scene scene, LoadSceneMode mode)
		{
			this.OnLevelLoadedCallback();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006704 File Offset: 0x00004B04
		private void OnLevelLoadedCallback()
		{
			if (TimeCheatingDetector.instancesInScene < 2)
			{
				if (!this.keepAlive)
				{
					this.DisposeInternal();
				}
			}
			else if (!this.keepAlive && TimeCheatingDetector.Instance != this)
			{
				this.DisposeInternal();
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00006754 File Offset: 0x00004B54
		private void Update()
		{
			if (!this.started || !this.isRunning)
			{
				return;
			}
			this.timeElapsed += Time.unscaledDeltaTime;
			if (this.timeElapsed >= (float)(this.interval * 60))
			{
				this.timeElapsed = 0f;
				this.CheckForCheat();
				return;
			}
			if (this.asyncResultQueue == null || this.asyncResultQueue.Count == 0)
			{
				return;
			}
			object obj = this.lockObject;
			lock (obj)
			{
				while (this.asyncResultQueue.Count > 0)
				{
					TimeCheatingDetector.AsyncCallbackData item = this.asyncResultQueue.Dequeue();
					this.resultList.Add(item);
				}
			}
			if (this.resultList.Count > 0)
			{
				foreach (TimeCheatingDetector.AsyncCallbackData asyncCallbackData in this.resultList)
				{
					asyncCallbackData.callback(asyncCallbackData.data);
				}
				this.resultList.Clear();
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00006898 File Offset: 0x00004C98
		public void ForceCheck()
		{
			if (!this.started || !this.isRunning)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Time Cheating Detector: Detector should be started to use ForceCheck().");
				return;
			}
			if (this.IsCheckingForCheat)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Time Cheating Detector: Can't force cheating check since another check is already in progress.");
				return;
			}
			this.timeElapsed = 0f;
			this.CheckForCheat();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000068F0 File Offset: 0x00004CF0
		private void StartDetectionInternal(UnityAction detectionCallback, UnityAction errorCallback, int checkInterval)
		{
			if (this.isRunning)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Time Cheating Detector: already running!", this);
				return;
			}
			if (!base.enabled)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Time Cheating Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!", this);
				return;
			}
			if (detectionCallback != null && this.detectionEventHasListener)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Time Cheating Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?", this);
			}
			if (detectionCallback == null && !this.detectionEventHasListener)
			{
				UnityEngine.Debug.LogWarning("[ACTk] Time Cheating Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.", this);
				base.enabled = false;
				return;
			}
			this.timeElapsed = 0f;
			this.detectionAction = detectionCallback;
			this.errorAction = errorCallback;
			this.interval = checkInterval;
			this.started = true;
			this.isRunning = true;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006999 File Offset: 0x00004D99
		protected override void StartDetectionAutomatically()
		{
			this.StartDetectionInternal(null, null, this.interval);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000069A9 File Offset: 0x00004DA9
		protected override void PauseDetector()
		{
			this.isRunning = false;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000069B2 File Offset: 0x00004DB2
		protected override void ResumeDetector()
		{
			if (this.detectionAction == null && !this.detectionEventHasListener)
			{
				return;
			}
			this.isRunning = true;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000069D2 File Offset: 0x00004DD2
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

		// Token: 0x060000A2 RID: 162 RVA: 0x000069F8 File Offset: 0x00004DF8
		protected override void DisposeInternal()
		{
			if (TimeCheatingDetector.Instance == this)
			{
				TimeCheatingDetector.Instance = null;
			}
			if (this.asyncSocket != null && this.asyncSocket.Connected)
			{
				this.asyncSocket.Close();
			}
			base.DisposeInternal();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00006A47 File Offset: 0x00004E47
		private void CheckForCheat()
		{
			if (!this.isRunning)
			{
				return;
			}
			this.checkingForCheat = true;
			this.GetOnlineTimeAsync("pool.ntp.org", new Action<double>(this.OnTimeGot));
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00006A74 File Offset: 0x00004E74
		private void OnTimeGot(double onlineTime)
		{
			this.checkingForCheat = false;
			if (!this.started || !this.isRunning)
			{
				return;
			}
			if (onlineTime <= 0.0)
			{
				if (this.errorAction != null)
				{
					this.errorAction();
				}
				return;
			}
			double localTime = this.GetLocalTime();
			TimeSpan timeSpan = new TimeSpan((long)onlineTime * 10000L);
			TimeSpan timeSpan2 = new TimeSpan((long)localTime * 10000L);
			double value = timeSpan.TotalMinutes - timeSpan2.TotalMinutes;
			if (Math.Abs(value) > (double)this.threshold)
			{
				this.OnCheatingDetected();
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00006B14 File Offset: 0x00004F14
		public static double GetOnlineTime(string server)
		{
			double result;
			try
			{
				byte[] array = new byte[48];
				array[0] = 27;
				IPAddress[] addressList = Dns.GetHostEntry(server).AddressList;
				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				socket.Connect(new IPEndPoint(addressList[0], 123));
				socket.ReceiveTimeout = 3000;
				socket.Send(array);
				socket.Receive(array);
				socket.Close();
				ulong num = (ulong)array[40] << 24 | (ulong)array[41] << 16 | (ulong)array[42] << 8 | (ulong)array[43];
				ulong num2 = (ulong)array[44] << 24 | (ulong)array[45] << 16 | (ulong)array[46] << 8 | (ulong)array[47];
				result = num * 1000.0 + num2 * 1000.0 / 4294967296.0;
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"[ACTk] Time Cheating Detector: Could not get NTP time from ",
					server,
					" =/\n",
					ex
				}));
				result = -1.0;
			}
			return result;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00006C30 File Offset: 0x00005030
		public void GetOnlineTimeAsync(string server, Action<double> callback)
		{
			try
			{
				IPAddress[] addressList = Dns.GetHostEntry(server).AddressList;
				if (addressList.Length == 0)
				{
					UnityEngine.Debug.Log("[ACTk] Time Cheating Detector: Could not resolve IP from the host " + server + " =/");
					callback(-1.0);
				}
				else
				{
					if (this.asyncSocket == null)
					{
						this.asyncSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
					}
					this.targetHost = server;
					IPAddress ipaddress = addressList[0];
					byte[] addressBytes = ipaddress.GetAddressBytes();
					if (addressBytes != this.targetIP)
					{
						this.targetEndpoint = new IPEndPoint(ipaddress, 123);
						this.targetIP = addressBytes;
					}
					if (this.connectArgs == null)
					{
						this.connectArgs = new SocketAsyncEventArgs();
						this.connectArgs.Completed += this.OnSocketConnected;
					}
					this.connectArgs.RemoteEndPoint = this.targetEndpoint;
					this.asyncSocket.ReceiveTimeout = 3000;
					this.getOnlineTimeCallback = callback;
					this.asyncSocket.ConnectAsync(this.connectArgs);
				}
			}
			catch
			{
				callback(-1.0);
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00006D58 File Offset: 0x00005158
		private void OnSocketConnected(object sender, SocketAsyncEventArgs e)
		{
			if (e.SocketError != SocketError.Success)
			{
				UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"[ACTk] Time Cheating Detector: Could not get NTP time from ",
					this.targetHost,
					" =/\n",
					e
				}));
				this.SocketAsyncResult(-1.0);
				return;
			}
			if (!this.started || !this.isRunning)
			{
				return;
			}
			this.ntpData[0] = 27;
			if (this.sendArgs == null)
			{
				this.sendArgs = new SocketAsyncEventArgs();
				this.sendArgs.Completed += this.OnSocketSend;
				this.sendArgs.UserToken = this.asyncSocket;
				this.sendArgs.SetBuffer(this.ntpData, 0, 48);
			}
			this.sendArgs.RemoteEndPoint = this.targetEndpoint;
			this.asyncSocket.SendAsync(this.sendArgs);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00006E44 File Offset: 0x00005244
		private void OnSocketSend(object sender, SocketAsyncEventArgs e)
		{
			if (!this.started || !this.isRunning)
			{
				return;
			}
			if (e.SocketError == SocketError.Success)
			{
				if (e.LastOperation == SocketAsyncOperation.Send)
				{
					if (this.receiveArgs == null)
					{
						this.receiveArgs = new SocketAsyncEventArgs();
						this.receiveArgs.Completed += this.OnSocketReceive;
						this.receiveArgs.UserToken = this.asyncSocket;
						this.receiveArgs.SetBuffer(this.ntpData, 0, 48);
					}
					this.receiveArgs.RemoteEndPoint = this.targetEndpoint;
					this.asyncSocket.ReceiveAsync(this.receiveArgs);
				}
			}
			else
			{
				UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"[ACTk] Time Cheating Detector: Could not get NTP time from ",
					this.targetHost,
					" =/\n",
					e
				}));
				this.SocketAsyncResult(-1.0);
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00006F38 File Offset: 0x00005338
		private void OnSocketReceive(object sender, SocketAsyncEventArgs e)
		{
			if (!this.started || !this.isRunning)
			{
				return;
			}
			this.ntpData = e.Buffer;
			ulong num = (ulong)this.ntpData[40] << 24 | (ulong)this.ntpData[41] << 16 | (ulong)this.ntpData[42] << 8 | (ulong)this.ntpData[43];
			ulong num2 = (ulong)this.ntpData[44] << 24 | (ulong)this.ntpData[45] << 16 | (ulong)this.ntpData[46] << 8 | (ulong)this.ntpData[47];
			double time = num * 1000.0 + num2 * 1000.0 / 4294967296.0;
			this.SocketAsyncResult(time);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00007000 File Offset: 0x00005400
		private void SocketAsyncResult(double time)
		{
			if (this.getOnlineTimeCallback != null)
			{
				object obj = this.lockObject;
				lock (obj)
				{
					TimeCheatingDetector.AsyncCallbackData item = default(TimeCheatingDetector.AsyncCallbackData);
					item.callback = this.getOnlineTimeCallback;
					item.data = time;
					this.asyncResultQueue.Enqueue(item);
				}
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000706C File Offset: 0x0000546C
		private double GetLocalTime()
		{
			return DateTime.UtcNow.Subtract(this.date1900).TotalMilliseconds;
		}

		// Token: 0x04000096 RID: 150
		internal const string COMPONENT_NAME = "Time Cheating Detector";

		// Token: 0x04000097 RID: 151
		private const string LOG_PREFIX = "[ACTk] Time Cheating Detector: ";

		// Token: 0x04000098 RID: 152
		private const string TIME_SERVER = "pool.ntp.org";

		// Token: 0x04000099 RID: 153
		private const int NTP_DATA_BUFFER_LENGTH = 48;

		// Token: 0x0400009A RID: 154
		private static int instancesInScene;

		// Token: 0x0400009B RID: 155
		private readonly DateTime date1900 = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		// Token: 0x0400009C RID: 156
		private readonly Queue<TimeCheatingDetector.AsyncCallbackData> asyncResultQueue = new Queue<TimeCheatingDetector.AsyncCallbackData>(1);

		// Token: 0x0400009D RID: 157
		private readonly List<TimeCheatingDetector.AsyncCallbackData> resultList = new List<TimeCheatingDetector.AsyncCallbackData>(1);

		// Token: 0x0400009E RID: 158
		private readonly object lockObject = new object();

		// Token: 0x0400009F RID: 159
		private float timeElapsed;

		// Token: 0x040000A0 RID: 160
		protected UnityAction errorAction;

		// Token: 0x040000A1 RID: 161
		[Tooltip("Time (in minutes) between detector checks.")]
		[Range(0.1f, 60f)]
		public int interval = 1;

		// Token: 0x040000A2 RID: 162
		[Tooltip("Maximum allowed difference between online and offline time, in minutes.")]
		public int threshold = 65;

		// Token: 0x040000A3 RID: 163
		private Socket asyncSocket;

		// Token: 0x040000A4 RID: 164
		private Action<double> getOnlineTimeCallback;

		// Token: 0x040000A5 RID: 165
		private string targetHost;

		// Token: 0x040000A6 RID: 166
		private byte[] targetIP;

		// Token: 0x040000A7 RID: 167
		private IPEndPoint targetEndpoint;

		// Token: 0x040000A8 RID: 168
		private byte[] ntpData = new byte[48];

		// Token: 0x040000A9 RID: 169
		private SocketAsyncEventArgs connectArgs;

		// Token: 0x040000AA RID: 170
		private SocketAsyncEventArgs sendArgs;

		// Token: 0x040000AB RID: 171
		private SocketAsyncEventArgs receiveArgs;

		// Token: 0x040000AC RID: 172
		private bool checkingForCheat;

		// Token: 0x040000AD RID: 173
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static TimeCheatingDetector <Instance>k__BackingField;

		// Token: 0x02000011 RID: 17
		private struct AsyncCallbackData
		{
			// Token: 0x040000AE RID: 174
			public Action<double> callback;

			// Token: 0x040000AF RID: 175
			public double data;
		}
	}
}
