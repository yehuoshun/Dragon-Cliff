using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Token: 0x020009C6 RID: 2502
public static class GameLoader
{
	// Token: 0x06004466 RID: 17510 RVA: 0x001BB4A7 File Offset: 0x001B98A7
	private static string GetPath(string fileName)
	{
		return Application.persistentDataPath + fileName;
	}

	// Token: 0x06004467 RID: 17511 RVA: 0x001BB4B4 File Offset: 0x001B98B4
	private static List<string> GetBackupPaths(string fileName)
	{
		string arg = Application.persistentDataPath + fileName + "_bak_timely";
		List<string> list = new List<string>();
		for (int i = 1; i < 11; i++)
		{
			list.Add(arg + i);
		}
		return list;
	}

	// Token: 0x06004468 RID: 17512 RVA: 0x001BB500 File Offset: 0x001B9900
	public static List<PlayerProfileLoadDetails> LoadProfiles()
	{
		List<PlayerProfileLoadDetails> list = new List<PlayerProfileLoadDetails>();
		PlayerProfile.CurrentKey = (double)UnityEngine.Random.Range(3, 25);
		foreach (GameLoader.SaveFileName saveFileName in GameLoader._saves_old)
		{
			string path = GameLoader.GetPath(saveFileName.New);
			string path2 = GameLoader.GetPath(saveFileName.Old);
			List<string> backupPaths = GameLoader.GetBackupPaths(saveFileName.New);
			List<string> backupPaths2 = GameLoader.GetBackupPaths(saveFileName.Old);
			IEnumerable<string> source = backupPaths;
			if (GameLoader.<>f__mg$cache0 == null)
			{
				GameLoader.<>f__mg$cache0 = new Func<string, bool>(File.Exists);
			}
			var list2 = (from f in source.Where(GameLoader.<>f__mg$cache0)
			select new
			{
				file = f,
				time = File.GetLastWriteTime(f)
			}).ToList();
			if (list2.Count == 0)
			{
				IEnumerable<string> source2 = backupPaths2;
				if (GameLoader.<>f__mg$cache1 == null)
				{
					GameLoader.<>f__mg$cache1 = new Func<string, bool>(File.Exists);
				}
				list2 = (from f in source2.Where(GameLoader.<>f__mg$cache1)
				select new
				{
					file = f,
					time = File.GetLastWriteTime(f)
				}).ToList();
			}
			else
			{
				IEnumerable<string> source3 = backupPaths2;
				if (GameLoader.<>f__mg$cache2 == null)
				{
					GameLoader.<>f__mg$cache2 = new Func<string, bool>(File.Exists);
				}
				foreach (string path3 in source3.Where(GameLoader.<>f__mg$cache2).ToList<string>())
				{
					File.Delete(path3);
				}
			}
			list2.Sort((f1, f2) => -DateTime.Compare(f1.time, f2.time));
			PlayerProfileLoadDetails playerProfileLoadDetails = new PlayerProfileLoadDetails
			{
				RecentBackup = null,
				FileName = saveFileName.New,
				Profile = null
			};
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			bool flag = false;
			if (File.Exists(path))
			{
				FileStream fileStream = File.Open(path, FileMode.Open);
				try
				{
					PlayerProfile playerProfile = (PlayerProfile)binaryFormatter.Deserialize(fileStream);
					playerProfile.ClearUpData();
					playerProfileLoadDetails.Profile = playerProfile;
					fileStream.Close();
					File.Copy(path, path + "_bak", true);
					flag = true;
				}
				catch (Exception ex)
				{
					fileStream.Close();
					SteamExceptionHandle.Handle(new Exception("Player profile load error!" + ex.Message, ex), 0u);
					File.Copy(path, path + "_bak" + Guid.NewGuid().ToString(), true);
					playerProfileLoadDetails.Profile = null;
				}
			}
			if (!flag && File.Exists(path2))
			{
				FileStream fileStream2 = File.Open(path2, FileMode.Open);
				try
				{
					PlayerProfile playerProfile2 = (PlayerProfile)binaryFormatter.Deserialize(fileStream2);
					playerProfile2.ClearUpData();
					playerProfileLoadDetails.Profile = playerProfile2;
					fileStream2.Close();
					File.Copy(path2, path2 + "_bak", true);
				}
				catch (Exception ex2)
				{
					fileStream2.Close();
					SteamExceptionHandle.Handle(new Exception("Player profile load error!" + ex2.Message, ex2), 0u);
					File.Copy(path2, path2 + "_bak" + Guid.NewGuid().ToString(), true);
					playerProfileLoadDetails.Profile = null;
				}
			}
			if (flag && File.Exists(path2))
			{
				File.Delete(path2);
			}
			int num = 0;
			while (num < list2.Count && playerProfileLoadDetails.RecentBackup == null)
			{
				var <>__AnonType = list2[num];
				if (<>__AnonType != null)
				{
					FileStream fileStream3 = File.Open(<>__AnonType.file, FileMode.Open);
					try
					{
						PlayerProfile playerProfile3 = (PlayerProfile)binaryFormatter.Deserialize(fileStream3);
						playerProfile3.ClearUpData();
						playerProfileLoadDetails.RecentBackup = playerProfile3;
						fileStream3.Close();
					}
					catch (Exception ex3)
					{
						fileStream3.Close();
						SteamExceptionHandle.Handle(new Exception("Player profile backup load error!" + ex3.Message, ex3), 0u);
						playerProfileLoadDetails.RecentBackup = null;
					}
				}
				num++;
			}
			list.Add(playerProfileLoadDetails);
		}
		return list;
	}

	// Token: 0x06004469 RID: 17513 RVA: 0x001BB9A0 File Offset: 0x001B9DA0
	public static void ResetAllSaves()
	{
		foreach (PlayerProfileLoadDetails playerProfileLoadDetails in GameLoader.LoadProfiles())
		{
			string path = GameLoader.GetPath(playerProfileLoadDetails.FileName);
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
	}

	// Token: 0x0600446A RID: 17514 RVA: 0x001BBA14 File Offset: 0x001B9E14
	public static PlayerProfile Load(PlayerProfile details, string fileName)
	{
		if (details == null)
		{
			details = PlayerProfile.InitPlayer(fileName);
			details.ClearUpData();
			if (!TestingProcessor.InTesting)
			{
				details.Save();
			}
		}
		else
		{
			details.ClearUpData();
		}
		GameLoader.CurrentLoadedProfile = details;
		return details;
	}

	// Token: 0x0600446B RID: 17515 RVA: 0x001BBA4C File Offset: 0x001B9E4C
	public static void ResetSave(PlayerProfileLoadDetails details)
	{
		string path = GameLoader.GetPath(details.FileName);
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	// Token: 0x0600446C RID: 17516 RVA: 0x001BBA78 File Offset: 0x001B9E78
	// Note: this type is marked as 'beforefieldinit'.
	static GameLoader()
	{
	}

	// Token: 0x0600446D RID: 17517 RVA: 0x001BBAFA File Offset: 0x001B9EFA
	[CompilerGenerated]
	private static <>__AnonType7<string, DateTime> <LoadProfiles>m__0(string f)
	{
		return new
		{
			file = f,
			time = File.GetLastWriteTime(f)
		};
	}

	// Token: 0x0600446E RID: 17518 RVA: 0x001BBB08 File Offset: 0x001B9F08
	[CompilerGenerated]
	private static <>__AnonType7<string, DateTime> <LoadProfiles>m__1(string f)
	{
		return new
		{
			file = f,
			time = File.GetLastWriteTime(f)
		};
	}

	// Token: 0x0600446F RID: 17519 RVA: 0x001BBB16 File Offset: 0x001B9F16
	[CompilerGenerated]
	private static int <LoadProfiles>m__2(<>__AnonType7<string, DateTime> f1, <>__AnonType7<string, DateTime> f2)
	{
		return -DateTime.Compare(f1.time, f2.time);
	}

	// Token: 0x0400339B RID: 13211
	public static List<GameLoader.SaveFileName> _saves_old = new List<GameLoader.SaveFileName>
	{
		new GameLoader.SaveFileName
		{
			Old = "/save_1.sav",
			New = "/save_1.dragon"
		},
		new GameLoader.SaveFileName
		{
			Old = "/save_2.sav",
			New = "/save_2.dragon"
		},
		new GameLoader.SaveFileName
		{
			Old = "/save_3.sav",
			New = "/save_3.dragon"
		}
	};

	// Token: 0x0400339C RID: 13212
	public static PlayerProfile CurrentLoadedProfile;

	// Token: 0x0400339D RID: 13213
	[CompilerGenerated]
	private static Func<string, bool> <>f__mg$cache0;

	// Token: 0x0400339E RID: 13214
	[CompilerGenerated]
	private static Func<string, bool> <>f__mg$cache1;

	// Token: 0x0400339F RID: 13215
	[CompilerGenerated]
	private static Func<string, bool> <>f__mg$cache2;

	// Token: 0x040033A0 RID: 13216
	[CompilerGenerated]
	private static Func<string, <>__AnonType7<string, DateTime>> <>f__am$cache0;

	// Token: 0x040033A1 RID: 13217
	[CompilerGenerated]
	private static Func<string, <>__AnonType7<string, DateTime>> <>f__am$cache1;

	// Token: 0x040033A2 RID: 13218
	[CompilerGenerated]
	private static Comparison<<>__AnonType7<string, DateTime>> <>f__am$cache2;

	// Token: 0x020009C7 RID: 2503
	public class SaveFileName
	{
		// Token: 0x06004470 RID: 17520 RVA: 0x001BBB2A File Offset: 0x001B9F2A
		public SaveFileName()
		{
		}

		// Token: 0x17000DA7 RID: 3495
		// (get) Token: 0x06004471 RID: 17521 RVA: 0x001BBB32 File Offset: 0x001B9F32
		// (set) Token: 0x06004472 RID: 17522 RVA: 0x001BBB3A File Offset: 0x001B9F3A
		public string Old
		{
			[CompilerGenerated]
			get
			{
				return this.<Old>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<Old>k__BackingField = value;
			}
		}

		// Token: 0x17000DA8 RID: 3496
		// (get) Token: 0x06004473 RID: 17523 RVA: 0x001BBB43 File Offset: 0x001B9F43
		// (set) Token: 0x06004474 RID: 17524 RVA: 0x001BBB4B File Offset: 0x001B9F4B
		public string New
		{
			[CompilerGenerated]
			get
			{
				return this.<New>k__BackingField;
			}
			[CompilerGenerated]
			set
			{
				this.<New>k__BackingField = value;
			}
		}

		// Token: 0x040033A3 RID: 13219
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string <Old>k__BackingField;

		// Token: 0x040033A4 RID: 13220
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string <New>k__BackingField;
	}
}
