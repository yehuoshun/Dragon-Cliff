using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200014F RID: 335
public class BattleTutorialController : MonoBehaviour
{
	// Token: 0x06000919 RID: 2329 RVA: 0x000799AF File Offset: 0x00077DAF
	public BattleTutorialController()
	{
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x000799B8 File Offset: 0x00077DB8
	private void OnEnable()
	{
		if (TownManager.Instance.Ui.IsInTown)
		{
			TownManager.Instance.Ui.ShowBattle();
		}
		TownManager.Instance.Ui.GameSpeedPanel.Pause();
		this.ChangeStatus(BattleTutorialStatus.Rage);
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.BattleTutorialTriggered, true);
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x00079A20 File Offset: 0x00077E20
	private void Update()
	{
		if (this._status == BattleTutorialStatus.Rage && Input.GetMouseButtonDown(0))
		{
			this.ChangeStatus(BattleTutorialStatus.Tactic);
		}
		else if (this._status == BattleTutorialStatus.Tactic && Input.GetMouseButtonDown(0))
		{
			this.ChangeStatus(BattleTutorialStatus.Speed);
		}
		else if (this._status == BattleTutorialStatus.Speed && Input.GetMouseButtonDown(0))
		{
			this.Close();
		}
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x00079A90 File Offset: 0x00077E90
	private void ChangeStatus(BattleTutorialStatus status)
	{
		this._status = status;
		this.RageObjs.ForEach(delegate(GameObject o)
		{
			o.SetActive(status == BattleTutorialStatus.Rage);
		});
		this.SpeedObjs.ForEach(delegate(GameObject o)
		{
			o.SetActive(status == BattleTutorialStatus.Speed);
		});
		this.TacticObjs.ForEach(delegate(GameObject o)
		{
			o.SetActive(status == BattleTutorialStatus.Tactic);
		});
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x00079AFB File Offset: 0x00077EFB
	public void Close()
	{
		this.ChangeStatus(BattleTutorialStatus.End);
		TownManager.Instance.Ui.GameSpeedPanel.ToCurrentSpeed();
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000BCC RID: 3020
	public List<GameObject> RageObjs;

	// Token: 0x04000BCD RID: 3021
	public List<GameObject> SpeedObjs;

	// Token: 0x04000BCE RID: 3022
	public List<GameObject> TacticObjs;

	// Token: 0x04000BCF RID: 3023
	private BattleTutorialStatus _status;

	// Token: 0x02000C1D RID: 3101
	[CompilerGenerated]
	private sealed class <ChangeStatus>c__AnonStorey0
	{
		// Token: 0x06005200 RID: 20992 RVA: 0x00079B24 File Offset: 0x00077F24
		public <ChangeStatus>c__AnonStorey0()
		{
		}

		// Token: 0x06005201 RID: 20993 RVA: 0x00079B2C File Offset: 0x00077F2C
		internal void <>m__0(GameObject o)
		{
			o.SetActive(this.status == BattleTutorialStatus.Rage);
		}

		// Token: 0x06005202 RID: 20994 RVA: 0x00079B3D File Offset: 0x00077F3D
		internal void <>m__1(GameObject o)
		{
			o.SetActive(this.status == BattleTutorialStatus.Speed);
		}

		// Token: 0x06005203 RID: 20995 RVA: 0x00079B4E File Offset: 0x00077F4E
		internal void <>m__2(GameObject o)
		{
			o.SetActive(this.status == BattleTutorialStatus.Tactic);
		}

		// Token: 0x04004010 RID: 16400
		internal BattleTutorialStatus status;
	}
}
