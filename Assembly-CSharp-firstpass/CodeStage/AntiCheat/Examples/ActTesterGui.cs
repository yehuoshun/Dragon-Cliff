using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using CodeStage.AntiCheat.Detectors;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;
using UnityEngine.Events;

namespace CodeStage.AntiCheat.Examples
{
	// Token: 0x02000003 RID: 3
	[AddComponentMenu("")]
	public class ActTesterGui : MonoBehaviour
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002088 File Offset: 0x00000488
		public ActTesterGui()
		{
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021C6 File Offset: 0x000005C6
		public void OnSpeedHackDetected()
		{
			this.speedHackDetected = true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021CF File Offset: 0x000005CF
		public void OnTimeCheatingDetected()
		{
			this.timeCheatingDetected = true;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021D8 File Offset: 0x000005D8
		private void OnTimeCheatingError()
		{
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021DA File Offset: 0x000005DA
		public void OnInjectionDetected()
		{
			this.injectionDetected = true;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021E3 File Offset: 0x000005E3
		public void OnInjectionDetectedWithCause(string cause)
		{
			this.injectionDetected = true;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000021EC File Offset: 0x000005EC
		public void OnObscuredTypeCheatingDetected()
		{
			this.obscuredTypeCheatDetected = true;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000021F5 File Offset: 0x000005F5
		public void OnWallHackDetected()
		{
			this.wallHackCheatDetected = true;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000021FE File Offset: 0x000005FE
		private void OnValidate()
		{
			if (Application.isPlaying)
			{
				ObscuredPrefs.CryptoKey = this.prefsEncryptionKey;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002215 File Offset: 0x00000615
		private void Awake()
		{
			ObscuredPrefs.CryptoKey = this.prefsEncryptionKey;
			ObscuredPrefs.onAlterationDetected = new Action(this.SavesAlterationDetected);
			ObscuredPrefs.onPossibleForeignSavesDetected = new Action(this.ForeignSavesDetected);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002244 File Offset: 0x00000644
		private void Start()
		{
			this.ObscuredStringExample();
			this.ObscuredIntExample();
			this.ObscuredFloatExample();
			this.ObscuredVector3Example();
			this.logBuilder.Length = 0;
			this.logBuilder.AppendLine("[ACTk] ObscuredDecimal value from inspector: " + this.obscuredDecimal);
			this.logBuilder.AppendLine("[ACTk] ObscuredBool value from inspector: " + this.obscuredBool);
			this.logBuilder.AppendLine("[ACTk] ObscuredLong value from inspector: " + this.obscuredLong);
			this.logBuilder.AppendLine("[ACTk] ObscuredDouble value from inspector: " + this.obscuredDouble);
			this.logBuilder.AppendLine("[ACTk] ObscuredVector2 value from inspector: " + this.obscuredVector2);
			base.Invoke("RandomizeObscuredVars", UnityEngine.Random.Range(1f, 10f));
			TimeCheatingDetector.SetErrorCallback(new UnityAction(this.OnTimeCheatingError));
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002348 File Offset: 0x00000748
		private void RandomizeObscuredVars()
		{
			this.obscuredInt.RandomizeCryptoKey();
			this.obscuredFloat.RandomizeCryptoKey();
			this.obscuredString.RandomizeCryptoKey();
			this.obscuredVector3.RandomizeCryptoKey();
			base.Invoke("RandomizeObscuredVars", UnityEngine.Random.Range(1f, 10f));
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000239C File Offset: 0x0000079C
		private void ObscuredStringExample()
		{
			this.logBuilder.Length = 0;
			this.logBuilder.AppendLine("[ACTk] <b>[ ObscuredString test ]</b>");
			ObscuredString.SetNewCryptoKey("I LOVE MY GIRLz");
			string text = "the Goscurry is not a lie ;)";
			this.logBuilder.AppendLine("Original string:\n" + text);
			ObscuredString obscuredString = text;
			this.logBuilder.AppendLine("How your string is stored in memory when obscured:\n" + obscuredString.GetEncrypted());
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002410 File Offset: 0x00000810
		private void ObscuredIntExample()
		{
			this.logBuilder.Length = 0;
			this.logBuilder.AppendLine("[ACTk] <b>[ ObscuredInt test ]</b>");
			ObscuredInt.SetNewCryptoKey(434523);
			int num = 5;
			this.logBuilder.AppendLine("Original lives count: " + num);
			ObscuredInt obscuredInt = num;
			this.logBuilder.AppendLine("How your lives count is stored in memory when obscured: " + obscuredInt.GetEncrypted());
			ObscuredInt.SetNewCryptoKey(666);
			num = obscuredInt;
			obscuredInt -= 2;
			obscuredInt = obscuredInt + num + 10;
			obscuredInt /= 2;
			obscuredInt = ++obscuredInt;
			ObscuredInt.SetNewCryptoKey(999);
			obscuredInt = ++obscuredInt;
			obscuredInt = --obscuredInt;
			this.logBuilder.AppendLine(string.Concat(new object[]
			{
				"Lives count after few usual operations: ",
				obscuredInt,
				" (",
				obscuredInt.ToString("X"),
				"h)"
			}));
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002530 File Offset: 0x00000930
		private void ObscuredFloatExample()
		{
			this.logBuilder.Length = 0;
			this.logBuilder.AppendLine("[ACTk] <b>[ ObscuredFloat test ]</b>");
			ObscuredFloat.SetNewCryptoKey(404);
			float num = 99.9f;
			this.logBuilder.AppendLine("Original health bar: " + num);
			ObscuredFloat obscuredFloat = num;
			this.logBuilder.AppendLine("How your health bar is stored in memory when obscured: " + obscuredFloat.GetEncrypted());
			ObscuredFloat.SetNewCryptoKey(666);
			obscuredFloat += 6f;
			obscuredFloat -= 1.5f;
			obscuredFloat = ++obscuredFloat;
			obscuredFloat = --obscuredFloat;
			obscuredFloat = --obscuredFloat;
			obscuredFloat = num - obscuredFloat + 10.5f;
			this.logBuilder.AppendLine("Health bar after few usual operations: " + obscuredFloat);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002624 File Offset: 0x00000A24
		private void ObscuredVector3Example()
		{
			this.logBuilder.Length = 0;
			this.logBuilder.AppendLine("[ACTk] <b>[ ObscuredVector3 test ]</b>");
			ObscuredVector3.SetNewCryptoKey(404);
			Vector3 vector = new Vector3(54.1f, 64.3f, 63.2f);
			this.logBuilder.AppendLine("Original position: " + vector);
			ObscuredVector3.RawEncryptedVector3 encrypted = vector.GetEncrypted();
			this.logBuilder.AppendLine(string.Concat(new object[]
			{
				"How your position is stored in memory when obscured: (",
				encrypted.x,
				", ",
				encrypted.y,
				", ",
				encrypted.z,
				")"
			}));
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000026FD File Offset: 0x00000AFD
		private void SavesAlterationDetected()
		{
			this.savesAlterationDetected = true;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002706 File Offset: 0x00000B06
		private void ForeignSavesDetected()
		{
			this.foreignSavesDetected = true;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002710 File Offset: 0x00000B10
		private void OnGUI()
		{
			GUIStyle guistyle = new GUIStyle(GUI.skin.label);
			guistyle.alignment = TextAnchor.UpperCenter;
			GUILayout.BeginArea(new Rect(10f, 5f, (float)(Screen.width - 20), (float)(Screen.height - 10)));
			GUILayout.Label("<color=\"#0287C8\"><b>Anti-Cheat Toolkit Sandbox</b></color>", guistyle, new GUILayoutOption[0]);
			GUILayout.Label("Here you can overview common ACTk features and try to cheat something yourself.", guistyle, new GUILayoutOption[0]);
			GUILayout.Space(5f);
			this.currentTab = GUILayout.Toolbar(this.currentTab, this.tabs, new GUILayoutOption[0]);
			if (this.currentTab == 0)
			{
				GUILayout.Label("ACTk offers own collection of the secure types to let you protect your variables from <b>ANY</b> memory hacking tools (Cheat Engine, ArtMoney, GameCIH, Game Guardian, etc.).", new GUILayoutOption[0]);
				GUILayout.Space(5f);
				using (new HorizontalLayout(new GUILayoutOption[0]))
				{
					GUILayout.Label("<b>Obscured types:</b>\n<color=\"#75C4EB\">" + this.GetAllSimpleObscuredTypes() + "</color>", new GUILayoutOption[]
					{
						GUILayout.MinWidth(130f)
					});
					GUILayout.Space(10f);
					using (new VerticalLayout(GUI.skin.box))
					{
						GUILayout.Label("Below you can try to cheat few variables of the regular types and their obscured (secure) analogues (you may change initial values from Tester object inspector):", new GUILayoutOption[0]);
						GUILayout.Space(10f);
						using (new HorizontalLayout(new GUILayoutOption[0]))
						{
							GUILayout.Label("<b>string:</b> " + this.regularString, new GUILayoutOption[]
							{
								GUILayout.Width(250f)
							});
							if (GUILayout.Button("Add random value", new GUILayoutOption[0]))
							{
								this.regularString += (char)UnityEngine.Random.Range(97, 122);
							}
							if (GUILayout.Button("Reset", new GUILayoutOption[0]))
							{
								this.regularString = string.Empty;
							}
						}
						using (new HorizontalLayout(new GUILayoutOption[0]))
						{
							GUILayout.Label("<b>ObscuredString:</b> " + this.obscuredString, new GUILayoutOption[]
							{
								GUILayout.Width(250f)
							});
							if (GUILayout.Button("Add random value", new GUILayoutOption[0]))
							{
								this.obscuredString += (char)UnityEngine.Random.Range(97, 122);
							}
							if (GUILayout.Button("Reset", new GUILayoutOption[0]))
							{
								this.obscuredString = string.Empty;
							}
						}
						GUILayout.Space(10f);
						using (new HorizontalLayout(new GUILayoutOption[0]))
						{
							GUILayout.Label("<b>int:</b> " + this.regularInt, new GUILayoutOption[]
							{
								GUILayout.Width(250f)
							});
							if (GUILayout.Button("Add random value", new GUILayoutOption[0]))
							{
								this.regularInt += UnityEngine.Random.Range(1, 100);
							}
							if (GUILayout.Button("Reset", new GUILayoutOption[0]))
							{
								this.regularInt = 0;
							}
						}
						using (new HorizontalLayout(new GUILayoutOption[0]))
						{
							GUILayout.Label("<b>ObscuredInt:</b> " + this.obscuredInt, new GUILayoutOption[]
							{
								GUILayout.Width(250f)
							});
							if (GUILayout.Button("Add random value", new GUILayoutOption[0]))
							{
								this.obscuredInt += UnityEngine.Random.Range(1, 100);
							}
							if (GUILayout.Button("Reset", new GUILayoutOption[0]))
							{
								this.obscuredInt = 0;
							}
						}
						GUILayout.Space(10f);
						using (new HorizontalLayout(new GUILayoutOption[0]))
						{
							GUILayout.Label("<b>float:</b> " + this.regularFloat, new GUILayoutOption[]
							{
								GUILayout.Width(250f)
							});
							if (GUILayout.Button("Add random value", new GUILayoutOption[0]))
							{
								this.regularFloat += UnityEngine.Random.Range(1f, 100f);
							}
							if (GUILayout.Button("Reset", new GUILayoutOption[0]))
							{
								this.regularFloat = 0f;
							}
						}
						using (new HorizontalLayout(new GUILayoutOption[0]))
						{
							GUILayout.Label("<b>ObscuredFloat:</b> " + this.obscuredFloat, new GUILayoutOption[]
							{
								GUILayout.Width(250f)
							});
							if (GUILayout.Button("Add random value", new GUILayoutOption[0]))
							{
								this.obscuredFloat += UnityEngine.Random.Range(1f, 100f);
							}
							if (GUILayout.Button("Reset", new GUILayoutOption[0]))
							{
								this.obscuredFloat = 0f;
							}
						}
						GUILayout.Space(10f);
						using (new HorizontalLayout(new GUILayoutOption[0]))
						{
							GUILayout.Label("<b>Vector3:</b> " + this.regularVector3, new GUILayoutOption[]
							{
								GUILayout.Width(250f)
							});
							if (GUILayout.Button("Add random value", new GUILayoutOption[0]))
							{
								this.regularVector3 += UnityEngine.Random.insideUnitSphere;
							}
							if (GUILayout.Button("Reset", new GUILayoutOption[0]))
							{
								this.regularVector3 = Vector3.zero;
							}
						}
						using (new HorizontalLayout(new GUILayoutOption[0]))
						{
							GUILayout.Label("<b>ObscuredVector3:</b> " + this.obscuredVector3, new GUILayoutOption[]
							{
								GUILayout.Width(250f)
							});
							if (GUILayout.Button("Add random value", new GUILayoutOption[0]))
							{
								this.obscuredVector3 += UnityEngine.Random.insideUnitSphere;
							}
							if (GUILayout.Button("Reset", new GUILayoutOption[0]))
							{
								this.obscuredVector3 = Vector3.zero;
							}
						}
					}
				}
			}
			else if (this.currentTab == 1)
			{
				GUILayout.Label("ACTk has secure layer for the PlayerPrefs: <color=\"#75C4EB\">ObscuredPrefs</color>. It protects data from view, detects any cheating attempts, optionally locks data to the current device and supports additional data types.", new GUILayoutOption[0]);
				GUILayout.Space(5f);
				using (new HorizontalLayout(new GUILayoutOption[0]))
				{
					GUILayout.Label("<b>Supported types:</b>\n" + this.GetAllObscuredPrefsDataTypes(), new GUILayoutOption[]
					{
						GUILayout.MinWidth(130f)
					});
					using (new VerticalLayout(GUI.skin.box))
					{
						GUILayout.Label("Below you can try to cheat both regular PlayerPrefs and secure ObscuredPrefs:", new GUILayoutOption[0]);
						using (new VerticalLayout(new GUILayoutOption[0]))
						{
							GUILayout.Label("<color=\"#FF4040\"><b>PlayerPrefs:</b></color>\neasy to cheat, only 3 supported types", guistyle, new GUILayoutOption[0]);
							GUILayout.Space(5f);
							if (string.IsNullOrEmpty(this.regularPrefs))
							{
								this.LoadRegularPrefs();
							}
							using (new HorizontalLayout(new GUILayoutOption[0]))
							{
								GUILayout.Label(this.regularPrefs, new GUILayoutOption[]
								{
									GUILayout.Width(270f)
								});
								using (new VerticalLayout(new GUILayoutOption[0]))
								{
									using (new HorizontalLayout(new GUILayoutOption[0]))
									{
										if (GUILayout.Button("Save", new GUILayoutOption[0]))
										{
											this.SaveRegularPrefs();
										}
										if (GUILayout.Button("Load", new GUILayoutOption[0]))
										{
											this.LoadRegularPrefs();
										}
									}
									if (GUILayout.Button("Delete", new GUILayoutOption[0]))
									{
										this.DeleteRegularPrefs();
									}
								}
							}
						}
						GUILayout.Space(5f);
						using (new VerticalLayout(new GUILayoutOption[0]))
						{
							GUILayout.Label("<color=\"#02C85F\"><b>ObscuredPrefs:</b></color>\nsecure, lot of additional types and extra options", guistyle, new GUILayoutOption[0]);
							GUILayout.Space(5f);
							if (string.IsNullOrEmpty(this.obscuredPrefs))
							{
								this.LoadObscuredPrefs();
							}
							using (new HorizontalLayout(new GUILayoutOption[0]))
							{
								GUILayout.Label(this.obscuredPrefs, new GUILayoutOption[]
								{
									GUILayout.Width(270f)
								});
								using (new VerticalLayout(new GUILayoutOption[0]))
								{
									using (new HorizontalLayout(new GUILayoutOption[0]))
									{
										if (GUILayout.Button("Save", new GUILayoutOption[0]))
										{
											this.SaveObscuredPrefs();
										}
										if (GUILayout.Button("Load", new GUILayoutOption[0]))
										{
											this.LoadObscuredPrefs();
										}
									}
									if (GUILayout.Button("Delete", new GUILayoutOption[0]))
									{
										this.DeleteObscuredPrefs();
									}
									using (new HorizontalLayout(new GUILayoutOption[0]))
									{
										GUILayout.Label("LockToDevice level", new GUILayoutOption[0]);
									}
									this.savesLock = GUILayout.SelectionGrid(this.savesLock, new string[]
									{
										ObscuredPrefs.DeviceLockLevel.None.ToString(),
										ObscuredPrefs.DeviceLockLevel.Soft.ToString(),
										ObscuredPrefs.DeviceLockLevel.Strict.ToString()
									}, 3, new GUILayoutOption[0]);
									ObscuredPrefs.lockToDevice = (ObscuredPrefs.DeviceLockLevel)this.savesLock;
									GUILayout.Space(5f);
									using (new HorizontalLayout(new GUILayoutOption[0]))
									{
										ObscuredPrefs.preservePlayerPrefs = GUILayout.Toggle(ObscuredPrefs.preservePlayerPrefs, "preservePlayerPrefs", new GUILayoutOption[0]);
									}
									using (new HorizontalLayout(new GUILayoutOption[0]))
									{
										ObscuredPrefs.emergencyMode = GUILayout.Toggle(ObscuredPrefs.emergencyMode, "emergencyMode", new GUILayoutOption[0]);
									}
									using (new HorizontalLayout(new GUILayoutOption[0]))
									{
										ObscuredPrefs.readForeignSaves = GUILayout.Toggle(ObscuredPrefs.readForeignSaves, "readForeignSaves", new GUILayoutOption[0]);
									}
									GUILayout.Space(5f);
									GUILayout.Label(string.Concat(new object[]
									{
										"<color=\"",
										(!this.savesAlterationDetected) ? "#02C85F" : "#FF4040",
										"\">Saves modification detected: ",
										this.savesAlterationDetected,
										"</color>"
									}), new GUILayoutOption[0]);
									GUILayout.Label(string.Concat(new object[]
									{
										"<color=\"",
										(!this.foreignSavesDetected) ? "#02C85F" : "#FF4040",
										"\">Foreign saves detected: ",
										this.foreignSavesDetected,
										"</color>"
									}), new GUILayoutOption[0]);
								}
							}
						}
						GUILayout.Space(5f);
					}
				}
			}
			else
			{
				GUILayout.Label("ACTk is able to detect some types of cheating to let you take action on the cheating players. This example scene has all possible detectors and all of them are automatically start on scene start.", new GUILayoutOption[0]);
				GUILayout.Space(5f);
				using (new VerticalLayout(GUI.skin.box))
				{
					GUILayout.Label("<b>Speed Hack Detector</b>", new GUILayoutOption[0]);
					GUILayout.Label("Allows to detect Cheat Engine's speed hack (and maybe some other speed hack tools) usage.", new GUILayoutOption[0]);
					GUILayout.Label(string.Concat(new object[]
					{
						"Running: ",
						SpeedHackDetector.Instance.IsRunning,
						"\n<color=\"",
						(!this.speedHackDetected) ? "#02C85F" : "#FF4040",
						"\">Detected: ",
						this.speedHackDetected.ToString().ToLower(),
						"</color>"
					}), new GUILayoutOption[0]);
					GUILayout.Space(10f);
					using (new GUILayout.HorizontalScope(new GUILayoutOption[0]))
					{
						GUILayout.Label("<b>Time Cheating Detector</b> (updates once per 1 min by default)", new GUILayoutOption[0]);
						if (GUILayout.Button("Force check", new GUILayoutOption[]
						{
							GUILayout.Width(100f)
						}) && TimeCheatingDetector.Instance != null && !TimeCheatingDetector.Instance.IsCheckingForCheat)
						{
							TimeCheatingDetector.Instance.ForceCheck();
						}
					}
					GUILayout.Label("Allows to detect system time change to cheat some long-term processes (building progress, etc.).", new GUILayoutOption[0]);
					GUILayout.Label(string.Concat(new object[]
					{
						"Running: ",
						TimeCheatingDetector.Instance.IsRunning,
						"\n<color=\"",
						(!this.timeCheatingDetected) ? "#02C85F" : "#FF4040",
						"\">Detected: ",
						this.timeCheatingDetected.ToString().ToLower(),
						"</color>"
					}), new GUILayoutOption[0]);
					GUILayout.Space(10f);
					GUILayout.Label("<b>Obscured Cheating Detector</b>", new GUILayoutOption[0]);
					GUILayout.Label("Detects cheating of any Obscured type (except ObscuredPrefs, it has own detection features) used in project.", new GUILayoutOption[0]);
					GUILayout.Label(string.Concat(new object[]
					{
						"Running: ",
						ObscuredCheatingDetector.Instance.IsRunning,
						"\n<color=\"",
						(!this.obscuredTypeCheatDetected) ? "#02C85F" : "#FF4040",
						"\">Detected: ",
						this.obscuredTypeCheatDetected.ToString().ToLower(),
						"</color>"
					}), new GUILayoutOption[0]);
					GUILayout.Space(10f);
					GUILayout.Label("<b>WallHack Detector</b>", new GUILayoutOption[0]);
					GUILayout.Label("Detects common types of wall hack cheating: walking through the walls (Rigidbody and CharacterController modules), shooting through the walls (Raycast module), looking through the walls (Wireframe module).", new GUILayoutOption[0]);
					GUILayout.Label(string.Concat(new object[]
					{
						"Running: ",
						WallHackDetector.Instance.IsRunning,
						"\n<color=\"",
						(!this.wallHackCheatDetected) ? "#02C85F" : "#FF4040",
						"\">Detected: ",
						this.wallHackCheatDetected.ToString().ToLower(),
						"</color>"
					}), new GUILayoutOption[0]);
					GUILayout.Space(10f);
					GUILayout.Label("<b>Injection Detector</b>", new GUILayoutOption[0]);
					GUILayout.Label("Allows to detect foreign managed assemblies in your application.", new GUILayoutOption[0]);
					GUILayout.Label(string.Concat(new object[]
					{
						"Running: ",
						InjectionDetector.Instance != null && InjectionDetector.Instance.IsRunning,
						"\n<color=\"",
						(!this.injectionDetected) ? "#02C85F" : "#FF4040",
						"\">Detected: ",
						this.injectionDetected.ToString().ToLower(),
						"</color>"
					}), new GUILayoutOption[0]);
				}
			}
			GUILayout.EndArea();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000390C File Offset: 0x00001D0C
		private string GetAllSimpleObscuredTypes()
		{
			string result = "Can't use reflection here, sorry :(";
			string types = string.Empty;
			if (string.IsNullOrEmpty(this.allSimpleObscuredTypes))
			{
				Assembly assembly2 = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault((Assembly assembly) => assembly.GetName().Name == "Assembly-CSharp-firstpass");
				if (assembly2 != null)
				{
					IEnumerable<Type> source = from t in assembly2.GetTypes()
					where t.IsPublic && t.Namespace == "CodeStage.AntiCheat.ObscuredTypes" && t.Name != "ObscuredPrefs"
					select t;
					source.ToList<Type>().ForEach(delegate(Type t)
					{
						if (types.Length > 0)
						{
							types = types + "\n" + t.Name;
						}
						else
						{
							types += t.Name;
						}
					});
					if (!string.IsNullOrEmpty(types))
					{
						result = types;
						this.allSimpleObscuredTypes = types;
					}
					else
					{
						this.allSimpleObscuredTypes = result;
					}
				}
			}
			else
			{
				result = this.allSimpleObscuredTypes;
			}
			return result;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000039EF File Offset: 0x00001DEF
		private string GetAllObscuredPrefsDataTypes()
		{
			return "int\nfloat\nstring\n<color=\"#75C4EB\">uint\ndouble\ndecimal\nlong\nulong\nbool\nbyte[]\nVector2\nVector3\nQuaternion\nColor\nRect</color>";
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000039F8 File Offset: 0x00001DF8
		private void LoadRegularPrefs()
		{
			this.regularPrefs = "int: " + PlayerPrefs.GetInt("money", -1) + "\n";
			string text = this.regularPrefs;
			this.regularPrefs = string.Concat(new object[]
			{
				text,
				"float: ",
				PlayerPrefs.GetFloat("lifeBar", -1f),
				"\n"
			});
			this.regularPrefs = this.regularPrefs + "string: " + PlayerPrefs.GetString("name", "No saved PlayerPrefs!");
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003A92 File Offset: 0x00001E92
		private void SaveRegularPrefs()
		{
			PlayerPrefs.SetInt("money", 456);
			PlayerPrefs.SetFloat("lifeBar", 456.789f);
			PlayerPrefs.SetString("name", "Hey, there!");
			PlayerPrefs.Save();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003AC6 File Offset: 0x00001EC6
		private void DeleteRegularPrefs()
		{
			PlayerPrefs.DeleteKey("money");
			PlayerPrefs.DeleteKey("lifeBar");
			PlayerPrefs.DeleteKey("name");
			PlayerPrefs.Save();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00003AEC File Offset: 0x00001EEC
		private void LoadObscuredPrefs()
		{
			byte[] byteArray = ObscuredPrefs.GetByteArray("demoByteArray", 0, 4);
			this.obscuredPrefs = "int: " + ObscuredPrefs.GetInt("money", -1) + "\n";
			string text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"float: ",
				ObscuredPrefs.GetFloat("lifeBar", -1f),
				"\n"
			});
			this.obscuredPrefs = this.obscuredPrefs + "string: " + ObscuredPrefs.GetString("name", "No saved ObscuredPrefs!") + "\n";
			text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"bool: ",
				ObscuredPrefs.GetBool("gameComplete", false),
				"\n"
			});
			text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"uint: ",
				ObscuredPrefs.GetUInt("demoUint", 0u),
				"\n"
			});
			text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"long: ",
				ObscuredPrefs.GetLong("demoLong", -1L),
				"\n"
			});
			text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"double: ",
				ObscuredPrefs.GetDouble("demoDouble", -1.0),
				"\n"
			});
			text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"Vector2: ",
				ObscuredPrefs.GetVector2("demoVector2", Vector2.zero),
				"\n"
			});
			text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"Vector3: ",
				ObscuredPrefs.GetVector3("demoVector3", Vector3.zero),
				"\n"
			});
			text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"Quaternion: ",
				ObscuredPrefs.GetQuaternion("demoQuaternion", Quaternion.identity),
				"\n"
			});
			text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"Rect: ",
				ObscuredPrefs.GetRect("demoRect", new Rect(0f, 0f, 0f, 0f)),
				"\n"
			});
			text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"Color: ",
				ObscuredPrefs.GetColor("demoColor", Color.black),
				"\n"
			});
			text = this.obscuredPrefs;
			this.obscuredPrefs = string.Concat(new object[]
			{
				text,
				"byte[]: {",
				byteArray[0],
				",",
				byteArray[1],
				",",
				byteArray[2],
				",",
				byteArray[3],
				"}"
			});
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003E78 File Offset: 0x00002278
		private void SaveObscuredPrefs()
		{
			ObscuredPrefs.SetInt("money", 123);
			ObscuredPrefs.SetFloat("lifeBar", 123.456f);
			ObscuredPrefs.SetString("name", "Goscurry is not a lie ;)");
			ObscuredPrefs.SetBool("gameComplete", true);
			ObscuredPrefs.SetUInt("demoUint", 1234567891u);
			ObscuredPrefs.SetLong("demoLong", 1234567891234567890L);
			ObscuredPrefs.SetDouble("demoDouble", 1.234567890123456);
			ObscuredPrefs.SetVector2("demoVector2", Vector2.one);
			ObscuredPrefs.SetVector3("demoVector3", Vector3.one);
			ObscuredPrefs.SetQuaternion("demoQuaternion", Quaternion.Euler(new Vector3(10f, 20f, 30f)));
			ObscuredPrefs.SetRect("demoRect", new Rect(1.5f, 2.6f, 3.7f, 4.8f));
			ObscuredPrefs.SetColor("demoColor", Color.red);
			ObscuredPrefs.SetByteArray("demoByteArray", new byte[]
			{
				44,
				104,
				43,
				32
			});
			ObscuredPrefs.Save();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003F88 File Offset: 0x00002388
		private void DeleteObscuredPrefs()
		{
			ObscuredPrefs.DeleteKey("money");
			ObscuredPrefs.DeleteKey("lifeBar");
			ObscuredPrefs.DeleteKey("name");
			ObscuredPrefs.DeleteKey("gameComplete");
			ObscuredPrefs.DeleteKey("demoUint");
			ObscuredPrefs.DeleteKey("demoLong");
			ObscuredPrefs.DeleteKey("demoDouble");
			ObscuredPrefs.DeleteKey("demoVector2");
			ObscuredPrefs.DeleteKey("demoVector3");
			ObscuredPrefs.DeleteKey("demoQuaternion");
			ObscuredPrefs.DeleteKey("demoRect");
			ObscuredPrefs.DeleteKey("demoColor");
			ObscuredPrefs.DeleteKey("demoByteArray");
			ObscuredPrefs.Save();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000401C File Offset: 0x0000241C
		private void OnApplicationQuit()
		{
			this.DeleteRegularPrefs();
			this.DeleteObscuredPrefs();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000402A File Offset: 0x0000242A
		[CompilerGenerated]
		private static bool <GetAllSimpleObscuredTypes>m__0(Assembly assembly)
		{
			return assembly.GetName().Name == "Assembly-CSharp-firstpass";
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00004041 File Offset: 0x00002441
		[CompilerGenerated]
		private static bool <GetAllSimpleObscuredTypes>m__1(Type t)
		{
			return t.IsPublic && t.Namespace == "CodeStage.AntiCheat.ObscuredTypes" && t.Name != "ObscuredPrefs";
		}

		// Token: 0x04000002 RID: 2
		private const string RED_COLOR = "#FF4040";

		// Token: 0x04000003 RID: 3
		private const string GREEN_COLOR = "#02C85F";

		// Token: 0x04000004 RID: 4
		private const string PREFS_STRING = "name";

		// Token: 0x04000005 RID: 5
		private const string PREFS_INT = "money";

		// Token: 0x04000006 RID: 6
		private const string PREFS_FLOAT = "lifeBar";

		// Token: 0x04000007 RID: 7
		private const string PREFS_BOOL = "gameComplete";

		// Token: 0x04000008 RID: 8
		private const string PREFS_UINT = "demoUint";

		// Token: 0x04000009 RID: 9
		private const string PREFS_LONG = "demoLong";

		// Token: 0x0400000A RID: 10
		private const string PREFS_DOUBLE = "demoDouble";

		// Token: 0x0400000B RID: 11
		private const string PREFS_VECTOR2 = "demoVector2";

		// Token: 0x0400000C RID: 12
		private const string PREFS_VECTOR3 = "demoVector3";

		// Token: 0x0400000D RID: 13
		private const string PREFS_QUATERNION = "demoQuaternion";

		// Token: 0x0400000E RID: 14
		private const string PREFS_RECT = "demoRect";

		// Token: 0x0400000F RID: 15
		private const string PREFS_COLOR = "demoColor";

		// Token: 0x04000010 RID: 16
		private const string PREFS_BYTE_ARRAY = "demoByteArray";

		// Token: 0x04000011 RID: 17
		[Header("Regular variables")]
		public string regularString = "I'm regular string";

		// Token: 0x04000012 RID: 18
		public int regularInt = 1987;

		// Token: 0x04000013 RID: 19
		public float regularFloat = 2013.05237f;

		// Token: 0x04000014 RID: 20
		public Vector3 regularVector3 = new Vector3(10.5f, 11.5f, 12.5f);

		// Token: 0x04000015 RID: 21
		[Header("Obscured (secure) variables")]
		public ObscuredString obscuredString = "I'm obscured string";

		// Token: 0x04000016 RID: 22
		public ObscuredInt obscuredInt = 1987;

		// Token: 0x04000017 RID: 23
		public ObscuredFloat obscuredFloat = 2013.05237f;

		// Token: 0x04000018 RID: 24
		public ObscuredVector3 obscuredVector3 = new Vector3(10.5f, 11.5f, 12.5f);

		// Token: 0x04000019 RID: 25
		public ObscuredBool obscuredBool = true;

		// Token: 0x0400001A RID: 26
		public ObscuredLong obscuredLong = 945678987654123345L;

		// Token: 0x0400001B RID: 27
		public ObscuredDouble obscuredDouble = 9.45678987654;

		// Token: 0x0400001C RID: 28
		public ObscuredVector2 obscuredVector2 = new Vector2(8.5f, 9.5f);

		// Token: 0x0400001D RID: 29
		public ObscuredDecimal obscuredDecimal = 503.4521m;

		// Token: 0x0400001E RID: 30
		[Header("Other")]
		public string prefsEncryptionKey = "change me!";

		// Token: 0x0400001F RID: 31
		private readonly string[] tabs = new string[]
		{
			"Variables protection",
			"Saves protection",
			"Cheating detectors"
		};

		// Token: 0x04000020 RID: 32
		private int currentTab;

		// Token: 0x04000021 RID: 33
		private string allSimpleObscuredTypes;

		// Token: 0x04000022 RID: 34
		private string regularPrefs;

		// Token: 0x04000023 RID: 35
		private string obscuredPrefs;

		// Token: 0x04000024 RID: 36
		private int savesLock;

		// Token: 0x04000025 RID: 37
		private bool savesAlterationDetected;

		// Token: 0x04000026 RID: 38
		private bool foreignSavesDetected;

		// Token: 0x04000027 RID: 39
		private bool injectionDetected;

		// Token: 0x04000028 RID: 40
		private bool speedHackDetected;

		// Token: 0x04000029 RID: 41
		private bool timeCheatingDetected;

		// Token: 0x0400002A RID: 42
		private bool obscuredTypeCheatDetected;

		// Token: 0x0400002B RID: 43
		private bool wallHackCheatDetected;

		// Token: 0x0400002C RID: 44
		private readonly StringBuilder logBuilder = new StringBuilder();

		// Token: 0x0400002D RID: 45
		[CompilerGenerated]
		private static Func<Assembly, bool> <>f__am$cache0;

		// Token: 0x0400002E RID: 46
		[CompilerGenerated]
		private static Func<Type, bool> <>f__am$cache1;

		// Token: 0x020001C6 RID: 454
		[CompilerGenerated]
		private sealed class <GetAllSimpleObscuredTypes>c__AnonStorey0
		{
			// Token: 0x06000C30 RID: 3120 RVA: 0x00004076 File Offset: 0x00002476
			public <GetAllSimpleObscuredTypes>c__AnonStorey0()
			{
			}

			// Token: 0x06000C31 RID: 3121 RVA: 0x00004080 File Offset: 0x00002480
			internal void <>m__0(Type t)
			{
				if (this.types.Length > 0)
				{
					this.types = this.types + "\n" + t.Name;
				}
				else
				{
					this.types += t.Name;
				}
			}

			// Token: 0x040009DF RID: 2527
			internal string types;
		}
	}
}
