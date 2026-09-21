using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace CodeStage.AntiCheat.Detectors
{
	// Token: 0x02000012 RID: 18
	[AddComponentMenu("Code Stage/Anti-Cheat Toolkit/WallHack Detector")]
	[HelpURL("http://codestage.net/uas_files/actk/api/class_code_stage_1_1_anti_cheat_1_1_detectors_1_1_wall_hack_detector.html")]
	public class WallHackDetector : ActDetectorBase
	{
		// Token: 0x060000AC RID: 172 RVA: 0x00007094 File Offset: 0x00005494
		private WallHackDetector()
		{
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00007130 File Offset: 0x00005530
		// (set) Token: 0x060000AE RID: 174 RVA: 0x00007138 File Offset: 0x00005538
		public bool CheckRigidbody
		{
			get
			{
				return this.checkRigidbody;
			}
			set
			{
				if (this.checkRigidbody == value || !Application.isPlaying || !base.enabled || !base.gameObject.activeSelf)
				{
					return;
				}
				this.checkRigidbody = value;
				if (!this.started)
				{
					return;
				}
				this.UpdateServiceContainer();
				if (this.checkRigidbody)
				{
					this.StartRigidModule();
				}
				else
				{
					this.StopRigidModule();
				}
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000AF RID: 175 RVA: 0x000071AC File Offset: 0x000055AC
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x000071B4 File Offset: 0x000055B4
		public bool CheckController
		{
			get
			{
				return this.checkController;
			}
			set
			{
				if (this.checkController == value || !Application.isPlaying || !base.enabled || !base.gameObject.activeSelf)
				{
					return;
				}
				this.checkController = value;
				if (!this.started)
				{
					return;
				}
				this.UpdateServiceContainer();
				if (this.checkController)
				{
					this.StartControllerModule();
				}
				else
				{
					this.StopControllerModule();
				}
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00007228 File Offset: 0x00005628
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x00007230 File Offset: 0x00005630
		public bool CheckWireframe
		{
			get
			{
				return this.checkWireframe;
			}
			set
			{
				if (this.checkWireframe == value || !Application.isPlaying || !base.enabled || !base.gameObject.activeSelf)
				{
					return;
				}
				this.checkWireframe = value;
				if (!this.started)
				{
					return;
				}
				this.UpdateServiceContainer();
				if (this.checkWireframe)
				{
					this.StartWireframeModule();
				}
				else
				{
					this.StopWireframeModule();
				}
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x000072A4 File Offset: 0x000056A4
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x000072AC File Offset: 0x000056AC
		public bool CheckRaycast
		{
			get
			{
				return this.checkRaycast;
			}
			set
			{
				if (this.checkRaycast == value || !Application.isPlaying || !base.enabled || !base.gameObject.activeSelf)
				{
					return;
				}
				this.checkRaycast = value;
				if (!this.started)
				{
					return;
				}
				this.UpdateServiceContainer();
				if (this.checkRaycast)
				{
					this.StartRaycastModule();
				}
				else
				{
					this.StopRaycastModule();
				}
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00007320 File Offset: 0x00005720
		public static void StartDetection()
		{
			if (WallHackDetector.Instance != null)
			{
				WallHackDetector.Instance.StartDetectionInternal(null, WallHackDetector.Instance.spawnPosition, WallHackDetector.Instance.maxFalsePositives);
			}
			else
			{
				UnityEngine.Debug.LogError("[ACTk] WallHack Detector: can't be started since it doesn't exists in scene or not yet initialized!");
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00007360 File Offset: 0x00005760
		public static void StartDetection(UnityAction callback)
		{
			WallHackDetector.StartDetection(callback, WallHackDetector.GetOrCreateInstance.spawnPosition);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00007372 File Offset: 0x00005772
		public static void StartDetection(UnityAction callback, Vector3 spawnPosition)
		{
			WallHackDetector.StartDetection(callback, spawnPosition, WallHackDetector.GetOrCreateInstance.maxFalsePositives);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00007385 File Offset: 0x00005785
		public static void StartDetection(UnityAction callback, Vector3 spawnPosition, byte maxFalsePositives)
		{
			WallHackDetector.GetOrCreateInstance.StartDetectionInternal(callback, spawnPosition, maxFalsePositives);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00007394 File Offset: 0x00005794
		public static void StopDetection()
		{
			if (WallHackDetector.Instance != null)
			{
				WallHackDetector.Instance.StopDetectionInternal();
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000073B0 File Offset: 0x000057B0
		public static void Dispose()
		{
			if (WallHackDetector.Instance != null)
			{
				WallHackDetector.Instance.DisposeInternal();
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000073CC File Offset: 0x000057CC
		// (set) Token: 0x060000BC RID: 188 RVA: 0x000073D3 File Offset: 0x000057D3
		public static WallHackDetector Instance
		{
			[CompilerGenerated]
			get
			{
				return WallHackDetector.<Instance>k__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				WallHackDetector.<Instance>k__BackingField = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000BD RID: 189 RVA: 0x000073DC File Offset: 0x000057DC
		private static WallHackDetector GetOrCreateInstance
		{
			get
			{
				if (WallHackDetector.Instance != null)
				{
					return WallHackDetector.Instance;
				}
				if (ActDetectorBase.detectorsContainer == null)
				{
					ActDetectorBase.detectorsContainer = new GameObject("Anti-Cheat Toolkit Detectors");
				}
				WallHackDetector.Instance = ActDetectorBase.detectorsContainer.AddComponent<WallHackDetector>();
				return WallHackDetector.Instance;
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00007432 File Offset: 0x00005832
		private void Awake()
		{
			WallHackDetector.instancesInScene++;
			if (this.Init(WallHackDetector.Instance, "WallHack Detector"))
			{
				WallHackDetector.Instance = this;
			}
			SceneManager.sceneLoaded += this.OnLevelWasLoadedNew;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000746C File Offset: 0x0000586C
		protected override void OnDestroy()
		{
			base.OnDestroy();
			base.StopAllCoroutines();
			if (this.serviceContainer != null)
			{
				UnityEngine.Object.Destroy(this.serviceContainer);
			}
			if (this.wfMaterial != null)
			{
				this.wfMaterial.mainTexture = null;
				this.wfMaterial.shader = null;
				this.wfMaterial = null;
				this.wfShader = null;
				this.shaderTexture = null;
				this.targetTexture = null;
				this.renderTexture.DiscardContents();
				this.renderTexture.Release();
				this.renderTexture = null;
			}
			WallHackDetector.instancesInScene--;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000750F File Offset: 0x0000590F
		private void OnLevelWasLoadedNew(Scene scene, LoadSceneMode mode)
		{
			this.OnLevelLoadedCallback();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00007518 File Offset: 0x00005918
		private void OnLevelLoadedCallback()
		{
			if (WallHackDetector.instancesInScene < 2)
			{
				if (!this.keepAlive)
				{
					this.DisposeInternal();
				}
			}
			else if (!this.keepAlive && WallHackDetector.Instance != this)
			{
				this.DisposeInternal();
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00007568 File Offset: 0x00005968
		private void FixedUpdate()
		{
			if (!this.isRunning || !this.checkRigidbody || this.rigidPlayer == null)
			{
				return;
			}
			if (this.rigidPlayer.transform.localPosition.z > 1f)
			{
				this.rigidbodyDetections += 1;
				if (!this.Detect())
				{
					this.StopRigidModule();
					this.StartRigidModule();
				}
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000075E8 File Offset: 0x000059E8
		private void Update()
		{
			if (!this.isRunning || !this.checkController || this.charControllerPlayer == null)
			{
				return;
			}
			if (this.charControllerVelocity > 0f)
			{
				this.charControllerPlayer.Move(new Vector3(UnityEngine.Random.Range(-0.002f, 0.002f), 0f, this.charControllerVelocity));
				if (this.charControllerPlayer.transform.localPosition.z > 1f)
				{
					this.controllerDetections += 1;
					if (!this.Detect())
					{
						this.StopControllerModule();
						this.StartControllerModule();
					}
				}
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000076A0 File Offset: 0x00005AA0
		private void StartDetectionInternal(UnityAction callback, Vector3 servicePosition, byte falsePositivesInRow)
		{
			if (this.isRunning)
			{
				UnityEngine.Debug.LogWarning("[ACTk] WallHack Detector: already running!", this);
				return;
			}
			if (!base.enabled)
			{
				UnityEngine.Debug.LogWarning("[ACTk] WallHack Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!", this);
				return;
			}
			if (callback != null && this.detectionEventHasListener)
			{
				UnityEngine.Debug.LogWarning("[ACTk] WallHack Detector: has properly configured Detection Event in the inspector, but still get started with Action callback. Both Action and Detection Event will be called on detection. Are you sure you wish to do this?", this);
			}
			if (callback == null && !this.detectionEventHasListener)
			{
				UnityEngine.Debug.LogWarning("[ACTk] WallHack Detector: was started without any callbacks. Please configure Detection Event in the inspector, or pass the callback Action to the StartDetection method.", this);
				base.enabled = false;
				return;
			}
			this.detectionAction = callback;
			this.spawnPosition = servicePosition;
			this.maxFalsePositives = falsePositivesInRow;
			this.rigidbodyDetections = 0;
			this.controllerDetections = 0;
			this.wireframeDetections = 0;
			this.raycastDetections = 0;
			base.StartCoroutine(this.InitDetector());
			this.started = true;
			this.isRunning = true;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00007767 File Offset: 0x00005B67
		protected override void StartDetectionAutomatically()
		{
			this.StartDetectionInternal(null, this.spawnPosition, this.maxFalsePositives);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000777C File Offset: 0x00005B7C
		protected override void PauseDetector()
		{
			if (!this.isRunning)
			{
				return;
			}
			this.isRunning = false;
			this.StopRigidModule();
			this.StopControllerModule();
			this.StopWireframeModule();
			this.StopRaycastModule();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000077AC File Offset: 0x00005BAC
		protected override void ResumeDetector()
		{
			if (this.detectionAction == null && !this.detectionEventHasListener)
			{
				return;
			}
			this.isRunning = true;
			if (this.checkRigidbody)
			{
				this.StartRigidModule();
			}
			if (this.checkController)
			{
				this.StartControllerModule();
			}
			if (this.checkWireframe)
			{
				this.StartWireframeModule();
			}
			if (this.checkRaycast)
			{
				this.StartRaycastModule();
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000781B File Offset: 0x00005C1B
		protected override void StopDetectionInternal()
		{
			if (!this.started)
			{
				return;
			}
			this.PauseDetector();
			this.detectionAction = null;
			this.isRunning = false;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000783D File Offset: 0x00005C3D
		protected override void DisposeInternal()
		{
			base.DisposeInternal();
			if (WallHackDetector.Instance == this)
			{
				WallHackDetector.Instance = null;
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000785C File Offset: 0x00005C5C
		private void UpdateServiceContainer()
		{
			if (base.enabled && base.gameObject.activeSelf)
			{
				if (this.whLayer == -1)
				{
					this.whLayer = LayerMask.NameToLayer("Ignore Raycast");
				}
				if (this.raycastMask == -1)
				{
					this.raycastMask = LayerMask.GetMask(new string[]
					{
						"Ignore Raycast"
					});
				}
				if (this.serviceContainer == null)
				{
					this.serviceContainer = new GameObject("[WH Detector Service]");
					this.serviceContainer.layer = this.whLayer;
					this.serviceContainer.transform.position = this.spawnPosition;
					UnityEngine.Object.DontDestroyOnLoad(this.serviceContainer);
				}
				if ((this.checkRigidbody || this.checkController) && this.solidWall == null)
				{
					this.solidWall = new GameObject("SolidWall");
					this.solidWall.AddComponent<BoxCollider>();
					this.solidWall.layer = this.whLayer;
					this.solidWall.transform.SetParent(this.serviceContainer.transform, false);
					this.solidWall.transform.localScale = new Vector3(3f, 3f, 0.5f);
					this.solidWall.transform.localPosition = Vector3.zero;
				}
				else if (!this.checkRigidbody && !this.checkController && this.solidWall != null)
				{
					UnityEngine.Object.Destroy(this.solidWall);
				}
				if (this.checkWireframe && this.wfCamera == null)
				{
					if (this.wfShader == null)
					{
						this.wfShader = Shader.Find("Hidden/ACTk/WallHackTexture");
					}
					if (this.wfShader == null)
					{
						UnityEngine.Debug.LogError("[ACTk] WallHack Detector: can't find 'Hidden/ACTk/WallHackTexture' shader!\nPlease make sure you have it included at the Editor > Project Settings > Graphics.", this);
						this.checkWireframe = false;
					}
					else if (!this.wfShader.isSupported)
					{
						UnityEngine.Debug.LogWarning("[ACTk] WallHack Detector: can't detect wireframe cheats on this platform due to lack of needed shader support!", this);
						this.checkWireframe = false;
					}
					else
					{
						if (this.wfColor1 == Color.black)
						{
							this.wfColor1 = WallHackDetector.GenerateColor();
							do
							{
								this.wfColor2 = WallHackDetector.GenerateColor();
							}
							while (WallHackDetector.ColorsSimilar(this.wfColor1, this.wfColor2, 10));
						}
						if (this.shaderTexture == null)
						{
							this.shaderTexture = new Texture2D(4, 4, TextureFormat.RGB24, false);
							this.shaderTexture.filterMode = FilterMode.Point;
							Color[] array = new Color[16];
							for (int i = 0; i < 16; i++)
							{
								if (i < 8)
								{
									array[i] = this.wfColor1;
								}
								else
								{
									array[i] = this.wfColor2;
								}
							}
							this.shaderTexture.SetPixels(array, 0);
							this.shaderTexture.Apply();
						}
						if (this.renderTexture == null)
						{
							this.renderTexture = new RenderTexture(4, 4, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
							this.renderTexture.autoGenerateMips = false;
							this.renderTexture.filterMode = FilterMode.Point;
							this.renderTexture.Create();
						}
						if (this.targetTexture == null)
						{
							this.targetTexture = new Texture2D(4, 4, TextureFormat.RGB24, false);
							this.targetTexture.filterMode = FilterMode.Point;
						}
						if (this.wfMaterial == null)
						{
							this.wfMaterial = new Material(this.wfShader);
							this.wfMaterial.mainTexture = this.shaderTexture;
						}
						if (this.foregroundRenderer == null)
						{
							GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
							UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
							gameObject.name = "WireframeFore";
							gameObject.layer = this.whLayer;
							gameObject.transform.SetParent(this.serviceContainer.transform, false);
							gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.foregroundRenderer = gameObject.GetComponent<MeshRenderer>();
							this.foregroundRenderer.sharedMaterial = this.wfMaterial;
							this.foregroundRenderer.shadowCastingMode = ShadowCastingMode.Off;
							this.foregroundRenderer.receiveShadows = false;
							this.foregroundRenderer.enabled = false;
						}
						if (this.backgroundRenderer == null)
						{
							GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Quad);
							UnityEngine.Object.Destroy(gameObject2.GetComponent<MeshCollider>());
							gameObject2.name = "WireframeBack";
							gameObject2.layer = this.whLayer;
							gameObject2.transform.SetParent(this.serviceContainer.transform, false);
							gameObject2.transform.localPosition = new Vector3(0f, 0f, 1f);
							gameObject2.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
							this.backgroundRenderer = gameObject2.GetComponent<MeshRenderer>();
							this.backgroundRenderer.sharedMaterial = this.wfMaterial;
							this.backgroundRenderer.shadowCastingMode = ShadowCastingMode.Off;
							this.backgroundRenderer.receiveShadows = false;
							this.backgroundRenderer.enabled = false;
						}
						this.wfCamera = new GameObject("WireframeCamera").AddComponent<Camera>();
						this.wfCamera.gameObject.layer = this.whLayer;
						this.wfCamera.transform.SetParent(this.serviceContainer.transform, false);
						this.wfCamera.transform.localPosition = new Vector3(0f, 0f, -1f);
						this.wfCamera.clearFlags = CameraClearFlags.Color;
						this.wfCamera.backgroundColor = Color.black;
						this.wfCamera.orthographic = true;
						this.wfCamera.orthographicSize = 0.5f;
						this.wfCamera.nearClipPlane = 0.01f;
						this.wfCamera.farClipPlane = 2.1f;
						this.wfCamera.depth = 0f;
						this.wfCamera.renderingPath = RenderingPath.Forward;
						this.wfCamera.useOcclusionCulling = false;
						this.wfCamera.allowHDR = false;
						this.wfCamera.allowMSAA = false;
						this.wfCamera.targetTexture = this.renderTexture;
						this.wfCamera.enabled = false;
					}
				}
				else if (!this.checkWireframe && this.wfCamera != null)
				{
					UnityEngine.Object.Destroy(this.foregroundRenderer.gameObject);
					UnityEngine.Object.Destroy(this.backgroundRenderer.gameObject);
					this.wfCamera.targetTexture = null;
					UnityEngine.Object.Destroy(this.wfCamera.gameObject);
				}
				if (this.checkRaycast && this.thinWall == null)
				{
					this.thinWall = GameObject.CreatePrimitive(PrimitiveType.Plane);
					this.thinWall.name = "ThinWall";
					this.thinWall.layer = this.whLayer;
					this.thinWall.transform.SetParent(this.serviceContainer.transform, false);
					this.thinWall.transform.localScale = new Vector3(0.2f, 1f, 0.2f);
					this.thinWall.transform.localRotation = Quaternion.Euler(270f, 0f, 0f);
					this.thinWall.transform.localPosition = new Vector3(0f, 0f, 1.4f);
					UnityEngine.Object.Destroy(this.thinWall.GetComponent<Renderer>());
					UnityEngine.Object.Destroy(this.thinWall.GetComponent<MeshFilter>());
				}
				else if (!this.checkRaycast && this.thinWall != null)
				{
					UnityEngine.Object.Destroy(this.thinWall);
				}
			}
			else if (this.serviceContainer != null)
			{
				UnityEngine.Object.Destroy(this.serviceContainer);
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000804C File Offset: 0x0000644C
		private IEnumerator InitDetector()
		{
			yield return this.waitForEndOfFrame;
			this.UpdateServiceContainer();
			if (this.checkRigidbody)
			{
				this.StartRigidModule();
			}
			if (this.checkController)
			{
				this.StartControllerModule();
			}
			if (this.checkWireframe)
			{
				this.StartWireframeModule();
			}
			if (this.checkRaycast)
			{
				this.StartRaycastModule();
			}
			yield break;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00008068 File Offset: 0x00006468
		private void StartRigidModule()
		{
			if (!this.checkRigidbody)
			{
				this.StopRigidModule();
				this.UninitRigidModule();
				this.UpdateServiceContainer();
				return;
			}
			if (!this.rigidPlayer)
			{
				this.InitRigidModule();
			}
			if (this.rigidPlayer.transform.localPosition.z <= 1f && this.rigidbodyDetections > 0)
			{
				this.rigidbodyDetections = 0;
			}
			this.rigidPlayer.rotation = Quaternion.identity;
			this.rigidPlayer.angularVelocity = Vector3.zero;
			this.rigidPlayer.transform.localPosition = new Vector3(0.75f, 0f, -1f);
			this.rigidPlayer.velocity = this.rigidPlayerVelocity;
			base.Invoke("StartRigidModule", 4f);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00008144 File Offset: 0x00006544
		private void StartControllerModule()
		{
			if (!this.checkController)
			{
				this.StopControllerModule();
				this.UninitControllerModule();
				this.UpdateServiceContainer();
				return;
			}
			if (!this.charControllerPlayer)
			{
				this.InitControllerModule();
			}
			if (this.charControllerPlayer.transform.localPosition.z <= 1f && this.controllerDetections > 0)
			{
				this.controllerDetections = 0;
			}
			this.charControllerPlayer.transform.localPosition = new Vector3(-0.75f, 0f, -1f);
			this.charControllerVelocity = 0.01f;
			base.Invoke("StartControllerModule", 4f);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000081F9 File Offset: 0x000065F9
		private void StartWireframeModule()
		{
			if (!this.checkWireframe)
			{
				this.StopWireframeModule();
				this.UpdateServiceContainer();
				return;
			}
			if (!this.wireframeDetected)
			{
				base.Invoke("ShootWireframeModule", (float)this.wireframeDelay);
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00008230 File Offset: 0x00006630
		private void ShootWireframeModule()
		{
			base.StartCoroutine(this.CaptureFrame());
			base.Invoke("ShootWireframeModule", (float)this.wireframeDelay);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00008254 File Offset: 0x00006654
		private IEnumerator CaptureFrame()
		{
			this.wfCamera.enabled = true;
			yield return this.waitForEndOfFrame;
			this.foregroundRenderer.enabled = true;
			this.backgroundRenderer.enabled = true;
			RenderTexture previousActive = RenderTexture.active;
			RenderTexture.active = this.renderTexture;
			this.wfCamera.Render();
			this.foregroundRenderer.enabled = false;
			this.backgroundRenderer.enabled = false;
			while (!this.renderTexture.IsCreated())
			{
				yield return this.waitForEndOfFrame;
			}
			this.targetTexture.ReadPixels(new Rect(0f, 0f, 4f, 4f), 0, 0, false);
			this.targetTexture.Apply();
			RenderTexture.active = previousActive;
			if (this.wfCamera == null)
			{
				yield break;
			}
			this.wfCamera.enabled = false;
			if (!(this.targetTexture.GetPixel(0, 3) != this.wfColor1) && !(this.targetTexture.GetPixel(0, 1) != this.wfColor2) && !(this.targetTexture.GetPixel(3, 3) != this.wfColor1) && !(this.targetTexture.GetPixel(3, 1) != this.wfColor2) && !(this.targetTexture.GetPixel(1, 3) != this.wfColor1) && !(this.targetTexture.GetPixel(2, 3) != this.wfColor1) && !(this.targetTexture.GetPixel(1, 1) != this.wfColor2) && !(this.targetTexture.GetPixel(2, 1) != this.wfColor2))
			{
				if (this.wireframeDetections > 0)
				{
					this.wireframeDetections = 0;
				}
			}
			else
			{
				this.wireframeDetections += 1;
				this.wireframeDetected = this.Detect();
			}
			yield return null;
			yield break;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000826F File Offset: 0x0000666F
		private void StartRaycastModule()
		{
			if (!this.checkRaycast)
			{
				this.StopRaycastModule();
				this.UpdateServiceContainer();
				return;
			}
			base.Invoke("ShootRaycastModule", (float)this.raycastDelay);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000829C File Offset: 0x0000669C
		private void ShootRaycastModule()
		{
			if (Physics.RaycastNonAlloc(this.serviceContainer.transform.position, this.serviceContainer.transform.TransformDirection(Vector3.forward), this.rayHits, 1.5f, this.raycastMask) > 0)
			{
				if (this.raycastDetections > 0)
				{
					this.raycastDetections = 0;
				}
			}
			else
			{
				this.raycastDetections += 1;
				if (this.Detect())
				{
					return;
				}
			}
			base.Invoke("ShootRaycastModule", (float)this.raycastDelay);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000832F File Offset: 0x0000672F
		private void StopRigidModule()
		{
			if (this.rigidPlayer)
			{
				this.rigidPlayer.velocity = Vector3.zero;
			}
			base.CancelInvoke("StartRigidModule");
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000835C File Offset: 0x0000675C
		private void StopControllerModule()
		{
			if (this.charControllerPlayer)
			{
				this.charControllerVelocity = 0f;
			}
			base.CancelInvoke("StartControllerModule");
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00008384 File Offset: 0x00006784
		private void StopWireframeModule()
		{
			base.CancelInvoke("ShootWireframeModule");
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00008391 File Offset: 0x00006791
		private void StopRaycastModule()
		{
			base.CancelInvoke("ShootRaycastModule");
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000083A0 File Offset: 0x000067A0
		private void InitRigidModule()
		{
			GameObject gameObject = new GameObject("RigidPlayer");
			gameObject.AddComponent<CapsuleCollider>().height = 2f;
			gameObject.layer = this.whLayer;
			gameObject.transform.SetParent(this.serviceContainer.transform, false);
			gameObject.transform.localPosition = new Vector3(0.75f, 0f, -1f);
			this.rigidPlayer = gameObject.AddComponent<Rigidbody>();
			this.rigidPlayer.useGravity = false;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00008424 File Offset: 0x00006824
		private void InitControllerModule()
		{
			GameObject gameObject = new GameObject("ControlledPlayer");
			gameObject.AddComponent<CapsuleCollider>().height = 2f;
			gameObject.layer = this.whLayer;
			gameObject.transform.SetParent(this.serviceContainer.transform, false);
			gameObject.transform.localPosition = new Vector3(-0.75f, 0f, -1f);
			this.charControllerPlayer = gameObject.AddComponent<CharacterController>();
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000849A File Offset: 0x0000689A
		private void UninitRigidModule()
		{
			if (!this.rigidPlayer)
			{
				return;
			}
			UnityEngine.Object.Destroy(this.rigidPlayer.gameObject);
			this.rigidPlayer = null;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000084C4 File Offset: 0x000068C4
		private void UninitControllerModule()
		{
			if (!this.charControllerPlayer)
			{
				return;
			}
			UnityEngine.Object.Destroy(this.charControllerPlayer.gameObject);
			this.charControllerPlayer = null;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000084F0 File Offset: 0x000068F0
		private bool Detect()
		{
			bool result = false;
			if (this.controllerDetections > this.maxFalsePositives || this.rigidbodyDetections > this.maxFalsePositives || this.wireframeDetections > this.maxFalsePositives || this.raycastDetections > this.maxFalsePositives)
			{
				this.OnCheatingDetected();
				result = true;
			}
			return result;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000854C File Offset: 0x0000694C
		private static Color32 GenerateColor()
		{
			return new Color32((byte)UnityEngine.Random.Range(0, 256), (byte)UnityEngine.Random.Range(0, 256), (byte)UnityEngine.Random.Range(0, 256), byte.MaxValue);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000857C File Offset: 0x0000697C
		private static bool ColorsSimilar(Color32 c1, Color32 c2, int tolerance)
		{
			return Math.Abs((int)(c1.r - c2.r)) < tolerance && Math.Abs((int)(c1.g - c2.g)) < tolerance && Math.Abs((int)(c1.b - c2.b)) < tolerance;
		}

		// Token: 0x040000B0 RID: 176
		internal const string COMPONENT_NAME = "WallHack Detector";

		// Token: 0x040000B1 RID: 177
		internal const string FINAL_LOG_PREFIX = "[ACTk] WallHack Detector: ";

		// Token: 0x040000B2 RID: 178
		private const string SERVICE_CONTAINER_NAME = "[WH Detector Service]";

		// Token: 0x040000B3 RID: 179
		private const string WIREFRAME_SHADER_NAME = "Hidden/ACTk/WallHackTexture";

		// Token: 0x040000B4 RID: 180
		private const int SHADER_TEXTURE_SIZE = 4;

		// Token: 0x040000B5 RID: 181
		private const int RENDER_TEXTURE_SIZE = 4;

		// Token: 0x040000B6 RID: 182
		private readonly Vector3 rigidPlayerVelocity = new Vector3(0f, 0f, 1f);

		// Token: 0x040000B7 RID: 183
		private static int instancesInScene;

		// Token: 0x040000B8 RID: 184
		private readonly WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

		// Token: 0x040000B9 RID: 185
		[SerializeField]
		[Tooltip("Check for the \"walk through the walls\" kind of cheats made via Rigidbody hacks?")]
		private bool checkRigidbody = true;

		// Token: 0x040000BA RID: 186
		[SerializeField]
		[Tooltip("Check for the \"walk through the walls\" kind of cheats made via Character Controller hacks?")]
		private bool checkController = true;

		// Token: 0x040000BB RID: 187
		[SerializeField]
		[Tooltip("Check for the \"see through the walls\" kind of cheats made via shader or driver hacks (wireframe, color alpha, etc.)?")]
		private bool checkWireframe = true;

		// Token: 0x040000BC RID: 188
		[SerializeField]
		[Tooltip("Check for the \"shoot through the walls\" kind of cheats made via Raycast hacks?")]
		private bool checkRaycast = true;

		// Token: 0x040000BD RID: 189
		[Tooltip("Delay between Wireframe module checks, from 1 up to 60 secs.")]
		[Range(1f, 60f)]
		public int wireframeDelay = 10;

		// Token: 0x040000BE RID: 190
		[Tooltip("Delay between Raycast module checks, from 1 up to 60 secs.")]
		[Range(1f, 60f)]
		public int raycastDelay = 10;

		// Token: 0x040000BF RID: 191
		[Tooltip("World position of the container for service objects within 3x3x3 cube (drawn as red wire cube in scene).")]
		public Vector3 spawnPosition;

		// Token: 0x040000C0 RID: 192
		[Tooltip("Maximum false positives in a row for each detection module before registering a wall hack.")]
		public byte maxFalsePositives = 3;

		// Token: 0x040000C1 RID: 193
		private GameObject serviceContainer;

		// Token: 0x040000C2 RID: 194
		private GameObject solidWall;

		// Token: 0x040000C3 RID: 195
		private GameObject thinWall;

		// Token: 0x040000C4 RID: 196
		private Camera wfCamera;

		// Token: 0x040000C5 RID: 197
		private MeshRenderer foregroundRenderer;

		// Token: 0x040000C6 RID: 198
		private MeshRenderer backgroundRenderer;

		// Token: 0x040000C7 RID: 199
		private Color wfColor1 = Color.black;

		// Token: 0x040000C8 RID: 200
		private Color wfColor2 = Color.black;

		// Token: 0x040000C9 RID: 201
		private Shader wfShader;

		// Token: 0x040000CA RID: 202
		private Material wfMaterial;

		// Token: 0x040000CB RID: 203
		private Texture2D shaderTexture;

		// Token: 0x040000CC RID: 204
		private Texture2D targetTexture;

		// Token: 0x040000CD RID: 205
		private RenderTexture renderTexture;

		// Token: 0x040000CE RID: 206
		private int whLayer = -1;

		// Token: 0x040000CF RID: 207
		private int raycastMask = -1;

		// Token: 0x040000D0 RID: 208
		private Rigidbody rigidPlayer;

		// Token: 0x040000D1 RID: 209
		private CharacterController charControllerPlayer;

		// Token: 0x040000D2 RID: 210
		private float charControllerVelocity;

		// Token: 0x040000D3 RID: 211
		private byte rigidbodyDetections;

		// Token: 0x040000D4 RID: 212
		private byte controllerDetections;

		// Token: 0x040000D5 RID: 213
		private byte wireframeDetections;

		// Token: 0x040000D6 RID: 214
		private byte raycastDetections;

		// Token: 0x040000D7 RID: 215
		private bool wireframeDetected;

		// Token: 0x040000D8 RID: 216
		private readonly RaycastHit[] rayHits = new RaycastHit[10];

		// Token: 0x040000D9 RID: 217
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static WallHackDetector <Instance>k__BackingField;

		// Token: 0x020001C9 RID: 457
		[CompilerGenerated]
		private sealed class <InitDetector>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06000C32 RID: 3122 RVA: 0x000085D7 File Offset: 0x000069D7
			[DebuggerHidden]
			public <InitDetector>c__Iterator0()
			{
			}

			// Token: 0x06000C33 RID: 3123 RVA: 0x000085E0 File Offset: 0x000069E0
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					this.$current = this.waitForEndOfFrame;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				case 1u:
					base.UpdateServiceContainer();
					if (this.checkRigidbody)
					{
						base.StartRigidModule();
					}
					if (this.checkController)
					{
						base.StartControllerModule();
					}
					if (this.checkWireframe)
					{
						base.StartWireframeModule();
					}
					if (this.checkRaycast)
					{
						base.StartRaycastModule();
					}
					this.$PC = -1;
					break;
				}
				return false;
			}

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x06000C34 RID: 3124 RVA: 0x000086B4 File Offset: 0x00006AB4
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000C35 RID: 3125 RVA: 0x000086BC File Offset: 0x00006ABC
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06000C36 RID: 3126 RVA: 0x000086C4 File Offset: 0x00006AC4
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06000C37 RID: 3127 RVA: 0x000086D4 File Offset: 0x00006AD4
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x040009E1 RID: 2529
			internal WallHackDetector $this;

			// Token: 0x040009E2 RID: 2530
			internal object $current;

			// Token: 0x040009E3 RID: 2531
			internal bool $disposing;

			// Token: 0x040009E4 RID: 2532
			internal int $PC;
		}

		// Token: 0x020001CA RID: 458
		[CompilerGenerated]
		private sealed class <CaptureFrame>c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
		{
			// Token: 0x06000C38 RID: 3128 RVA: 0x000086DB File Offset: 0x00006ADB
			[DebuggerHidden]
			public <CaptureFrame>c__Iterator1()
			{
			}

			// Token: 0x06000C39 RID: 3129 RVA: 0x000086E4 File Offset: 0x00006AE4
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0u:
					this.wfCamera.enabled = true;
					this.$current = this.waitForEndOfFrame;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					return true;
				case 1u:
					this.foregroundRenderer.enabled = true;
					this.backgroundRenderer.enabled = true;
					previousActive = RenderTexture.active;
					RenderTexture.active = this.renderTexture;
					this.wfCamera.Render();
					this.foregroundRenderer.enabled = false;
					this.backgroundRenderer.enabled = false;
					break;
				case 2u:
					break;
				case 3u:
					this.$PC = -1;
					return false;
				default:
					return false;
				}
				if (!this.renderTexture.IsCreated())
				{
					this.$current = this.waitForEndOfFrame;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					return true;
				}
				this.targetTexture.ReadPixels(new Rect(0f, 0f, 4f, 4f), 0, 0, false);
				this.targetTexture.Apply();
				RenderTexture.active = previousActive;
				if (!(this.wfCamera == null))
				{
					this.wfCamera.enabled = false;
					bool detected = this.targetTexture.GetPixel(0, 3) != this.wfColor1 || this.targetTexture.GetPixel(0, 1) != this.wfColor2 || this.targetTexture.GetPixel(3, 3) != this.wfColor1 || this.targetTexture.GetPixel(3, 1) != this.wfColor2 || this.targetTexture.GetPixel(1, 3) != this.wfColor1 || this.targetTexture.GetPixel(2, 3) != this.wfColor1 || this.targetTexture.GetPixel(1, 1) != this.wfColor2 || this.targetTexture.GetPixel(2, 1) != this.wfColor2;
					if (!detected)
					{
						if (this.wireframeDetections > 0)
						{
							this.wireframeDetections = 0;
						}
					}
					else
					{
						WallHackDetector wallHackDetector = this;
						wallHackDetector.wireframeDetections += 1;
						this.wireframeDetected = base.Detect();
					}
					this.$current = null;
					if (!this.$disposing)
					{
						this.$PC = 3;
					}
					return true;
				}
				return false;
			}

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000C3A RID: 3130 RVA: 0x00008A29 File Offset: 0x00006E29
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x06000C3B RID: 3131 RVA: 0x00008A31 File Offset: 0x00006E31
			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06000C3C RID: 3132 RVA: 0x00008A39 File Offset: 0x00006E39
			[DebuggerHidden]
			public void Dispose()
			{
				this.$disposing = true;
				this.$PC = -1;
			}

			// Token: 0x06000C3D RID: 3133 RVA: 0x00008A49 File Offset: 0x00006E49
			[DebuggerHidden]
			public void Reset()
			{
				throw new NotSupportedException();
			}

			// Token: 0x040009E5 RID: 2533
			internal RenderTexture <previousActive>__0;

			// Token: 0x040009E6 RID: 2534
			internal bool <detected>__0;

			// Token: 0x040009E7 RID: 2535
			internal WallHackDetector $this;

			// Token: 0x040009E8 RID: 2536
			internal object $current;

			// Token: 0x040009E9 RID: 2537
			internal bool $disposing;

			// Token: 0x040009EA RID: 2538
			internal int $PC;
		}
	}
}
