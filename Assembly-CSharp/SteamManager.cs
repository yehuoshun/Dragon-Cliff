using System;
using System.Text;
using Steamworks;
using UnityEngine;

// Token: 0x020009FC RID: 2556
[DisallowMultipleComponent]
public class SteamManager : MonoBehaviour
{
	// Token: 0x0600457E RID: 17790 RVA: 0x001C1B7B File Offset: 0x001BFF7B
	public SteamManager()
	{
	}

	// Token: 0x17000DB8 RID: 3512
	// (get) Token: 0x0600457F RID: 17791 RVA: 0x001C1B83 File Offset: 0x001BFF83
	private static SteamManager Instance
	{
		get
		{
			if (SteamManager.s_instance == null)
			{
				return new GameObject("SteamManager").AddComponent<SteamManager>();
			}
			return SteamManager.s_instance;
		}
	}

	// Token: 0x17000DB9 RID: 3513
	// (get) Token: 0x06004580 RID: 17792 RVA: 0x001C1BAA File Offset: 0x001BFFAA
	public static bool Initialized
	{
		get
		{
			return SteamManager.Instance.m_bInitialized;
		}
	}

	// Token: 0x06004581 RID: 17793 RVA: 0x001C1BB6 File Offset: 0x001BFFB6
	private static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		Debug.LogWarning(pchDebugText);
	}

	// Token: 0x06004582 RID: 17794 RVA: 0x001C1BC0 File Offset: 0x001BFFC0
	private void Awake()
	{
		if (SteamManager.s_instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		SteamManager.s_instance = this;
		if (SteamManager.s_EverInialized)
		{
			throw new Exception("Tried to Initialize the SteamAPI twice in one session!");
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (!Packsize.Test())
		{
			Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
		}
		if (!DllCheck.Test())
		{
			Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
		}
		try
		{
			if (SteamAPI.RestartAppIfNecessary((AppId_t)758190u))
			{
				Application.Quit();
				return;
			}
		}
		catch (DllNotFoundException arg)
		{
			Debug.LogError("[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.\n" + arg, this);
			Application.Quit();
			return;
		}
		this.m_bInitialized = SteamAPI.Init();
		if (!this.m_bInitialized)
		{
			Debug.LogError("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);
			return;
		}
		SteamManager.s_EverInialized = true;
	}

	// Token: 0x06004583 RID: 17795 RVA: 0x001C1CB0 File Offset: 0x001C00B0
	private void OnEnable()
	{
		if (SteamManager.s_instance == null)
		{
			SteamManager.s_instance = this;
		}
		if (!this.m_bInitialized)
		{
			return;
		}
		if (this.m_SteamAPIWarningMessageHook == null)
		{
			this.m_SteamAPIWarningMessageHook = new SteamAPIWarningMessageHook_t(SteamManager.SteamAPIDebugTextHook);
			SteamClient.SetWarningMessageHook(this.m_SteamAPIWarningMessageHook);
		}
	}

	// Token: 0x06004584 RID: 17796 RVA: 0x001C1D07 File Offset: 0x001C0107
	private void OnDestroy()
	{
		if (SteamManager.s_instance != this)
		{
			return;
		}
		SteamManager.s_instance = null;
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamAPI.Shutdown();
	}

	// Token: 0x06004585 RID: 17797 RVA: 0x001C1D31 File Offset: 0x001C0131
	private void Update()
	{
		if (!this.m_bInitialized)
		{
			return;
		}
		SteamAPI.RunCallbacks();
	}

	// Token: 0x040034C3 RID: 13507
	private static SteamManager s_instance;

	// Token: 0x040034C4 RID: 13508
	private static bool s_EverInialized;

	// Token: 0x040034C5 RID: 13509
	private bool m_bInitialized;

	// Token: 0x040034C6 RID: 13510
	private SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;
}
