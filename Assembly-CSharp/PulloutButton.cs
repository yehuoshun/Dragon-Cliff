using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000364 RID: 868
public class PulloutButton : MonoBehaviour
{
	// Token: 0x06001772 RID: 6002 RVA: 0x000B6198 File Offset: 0x000B4598
	public PulloutButton()
	{
	}

	// Token: 0x06001773 RID: 6003 RVA: 0x000B61A0 File Offset: 0x000B45A0
	private void OnEnable()
	{
	}

	// Token: 0x06001774 RID: 6004 RVA: 0x000B61A2 File Offset: 0x000B45A2
	private void Start()
	{
		this._button = base.GetComponent<Button>();
		this._button.onClick.AddListener(new UnityAction(this.Pullout));
	}

	// Token: 0x06001775 RID: 6005 RVA: 0x000B61CC File Offset: 0x000B45CC
	private void Pullout()
	{
		if (!this._pulloutInprogress)
		{
			this._pulloutInprogress = true;
			BattleManager.instance.PullBackClicked();
			IEnumerator enumerator = GameWorld.instance.GetCurrentAdventure().PullOff().GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
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
			this._pulloutInprogress = false;
		}
	}

	// Token: 0x04001763 RID: 5987
	private Button _button;

	// Token: 0x04001764 RID: 5988
	private bool _pulloutInprogress;
}
