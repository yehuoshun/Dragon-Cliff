using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000252 RID: 594
public class StoredCandidatesPanelController : ResidentPanelController
{
	// Token: 0x06000F6C RID: 3948 RVA: 0x0009479A File Offset: 0x00092B9A
	public StoredCandidatesPanelController()
	{
	}

	// Token: 0x06000F6D RID: 3949 RVA: 0x000947A2 File Offset: 0x00092BA2
	private void Awake()
	{
		this.StoreAncientResidentToggle.isOn = this.GetAdditionalData(UIAdditionalDataKey.StoreAncientResident, false);
		this.StoreLegendaryResidentToggle.isOn = this.GetAdditionalData(UIAdditionalDataKey.StoreLegendaryResident, false);
	}

	// Token: 0x06000F6E RID: 3950 RVA: 0x000947D2 File Offset: 0x00092BD2
	private void Start()
	{
		this.Init();
	}

	// Token: 0x06000F6F RID: 3951 RVA: 0x000947DA File Offset: 0x00092BDA
	private void OnEnable()
	{
		this.Init();
	}

	// Token: 0x06000F70 RID: 3952 RVA: 0x000947E4 File Offset: 0x00092BE4
	public void Init()
	{
		IOrderedEnumerable<ResidentCandidate> orderedEnumerable = from c in GameWorld.instance.PlayerProfile.StoredCandidates
		orderby c.CreatedOnDay
		select c;
		IEnumerator enumerator = this.CardContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				transform.GetComponent<ResidentItemBaseController>().ClearChildren();
				transform.gameObject.PoolDestroy(PoolType.StoredCandidateItem);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		foreach (ResidentCandidate residentCandidate in orderedEnumerable)
		{
			GameObject gameObject = this.PoolObject(PoolType.StoredCandidateItem, default(Vector3));
			gameObject.GetComponent<ResidentItemBaseController>().Init(residentCandidate.Candidate);
			gameObject.transform.SetParent(this.CardContainer, false);
			gameObject.transform.localScale = Vector3.one;
			gameObject.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
		}
	}

	// Token: 0x06000F71 RID: 3953 RVA: 0x0009492C File Offset: 0x00092D2C
	public void ToggleStoreAncient()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.StoreAncientResident, this.StoreAncientResidentToggle.isOn);
	}

	// Token: 0x06000F72 RID: 3954 RVA: 0x00094952 File Offset: 0x00092D52
	public void ToggleStoreLegendary()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.StoreLegendaryResident, this.StoreLegendaryResidentToggle.isOn);
	}

	// Token: 0x06000F73 RID: 3955 RVA: 0x00094978 File Offset: 0x00092D78
	[CompilerGenerated]
	private static int <Init>m__0(ResidentCandidate c)
	{
		return c.CreatedOnDay;
	}

	// Token: 0x040010B8 RID: 4280
	public Toggle StoreAncientResidentToggle;

	// Token: 0x040010B9 RID: 4281
	public Toggle StoreLegendaryResidentToggle;

	// Token: 0x040010BA RID: 4282
	[CompilerGenerated]
	private static Func<ResidentCandidate, int> <>f__am$cache0;
}
