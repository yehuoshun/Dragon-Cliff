using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000155 RID: 341
public class BattleResourcePanelController : MonoBehaviour
{
	// Token: 0x0600093B RID: 2363 RVA: 0x0007A27B File Offset: 0x0007867B
	public BattleResourcePanelController()
	{
	}

	// Token: 0x0600093C RID: 2364 RVA: 0x0007A283 File Offset: 0x00078683
	public void Start()
	{
		this.Reset();
	}

	// Token: 0x0600093D RID: 2365 RVA: 0x0007A28B File Offset: 0x0007868B
	public void OpenPanel()
	{
		this.OpenSelectedPanel(true);
	}

	// Token: 0x0600093E RID: 2366 RVA: 0x0007A294 File Offset: 0x00078694
	public void ClosePanel()
	{
		this.OpenSelectedPanel(false);
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x0007A29D File Offset: 0x0007869D
	private void OpenSelectedPanel(bool open)
	{
		this.OpenButton.SetActive(!open);
		this.CloseButton.SetActive(open);
		this.Animator.SetBool("Open", open);
		if (open)
		{
			this.LogPanel.ClosePanel();
		}
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x0007A2DC File Offset: 0x000786DC
	public void UpdateAmount(List<ResourceUpdate> resources)
	{
		foreach (ResourceUpdate resourceUpdate in resources)
		{
			bool flag = false;
			IEnumerator enumerator2 = this.ResourceContainer.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object obj = enumerator2.Current;
					Transform transform = (Transform)obj;
					BattleResourceItemController component = transform.GetComponent<BattleResourceItemController>();
					if (component != null && component.Resource.ResourceType == resourceUpdate.ResourceType)
					{
						flag = true;
						component.UpdateAmount(resourceUpdate.ChangeAmount);
					}
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator2 as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			if (!flag)
			{
				BattleResourceItemController battleResourceItemController = UnityEngine.Object.Instantiate<BattleResourceItemController>(this.ResourcePre);
				battleResourceItemController.Init(resourceUpdate);
				battleResourceItemController.transform.SetParent(this.ResourceContainer, false);
			}
		}
	}

	// Token: 0x06000941 RID: 2369 RVA: 0x0007A3EC File Offset: 0x000787EC
	public void Reset()
	{
		IEnumerator enumerator = this.ResourceContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
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
		List<ResourceUpdate> resources = new List<ResourceUpdate>
		{
			new ResourceUpdate
			{
				ResourceType = ResourceType.Ore,
				ChangeAmount = 0.0
			},
			new ResourceUpdate
			{
				ResourceType = ResourceType.Leather,
				ChangeAmount = 0.0
			}
		};
		this.UpdateAmount(resources);
	}

	// Token: 0x04000BF0 RID: 3056
	public Transform ResourceContainer;

	// Token: 0x04000BF1 RID: 3057
	public BattleResourceItemController ResourcePre;

	// Token: 0x04000BF2 RID: 3058
	public Animator Animator;

	// Token: 0x04000BF3 RID: 3059
	public GameObject OpenButton;

	// Token: 0x04000BF4 RID: 3060
	public GameObject CloseButton;

	// Token: 0x04000BF5 RID: 3061
	public BattleLogPanelController LogPanel;
}
