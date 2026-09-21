using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200025B RID: 603
public class SkillColorBlockController : MonoBehaviour
{
	// Token: 0x06000FBD RID: 4029 RVA: 0x00095DB6 File Offset: 0x000941B6
	public SkillColorBlockController()
	{
	}

	// Token: 0x06000FBE RID: 4030 RVA: 0x00095DBE File Offset: 0x000941BE
	public void Init(bool ticked, Color color)
	{
		this.ColorTick.color = color;
		this.ColorTick.gameObject.SetActive(ticked);
	}

	// Token: 0x040010F6 RID: 4342
	public Image ColorTick;
}
