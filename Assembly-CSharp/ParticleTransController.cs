using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000F4 RID: 244
public class ParticleTransController : MonoBehaviour
{
	// Token: 0x060006C6 RID: 1734 RVA: 0x00069A31 File Offset: 0x00067E31
	public ParticleTransController()
	{
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x00069A44 File Offset: 0x00067E44
	private void Update()
	{
		if (this._canPlayParticle)
		{
			this._timer += Time.deltaTime;
			if (this._timer < this.Duration)
			{
				this.Activate();
			}
			else
			{
				this.Inactivate();
				this._timer = 0f;
				this._canPlayParticle = false;
			}
		}
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x00069AA4 File Offset: 0x00067EA4
	public void Activate()
	{
		foreach (GameObject gameObject in this._childrenParticles)
		{
			gameObject.SetActive(true);
		}
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x00069B00 File Offset: 0x00067F00
	public void Inactivate()
	{
		foreach (GameObject gameObject in this._childrenParticles)
		{
			gameObject.SetActive(false);
		}
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x00069B5C File Offset: 0x00067F5C
	public void Play()
	{
		if (this._childrenParticles == null)
		{
			this.Init();
		}
		this._canPlayParticle = true;
		this._timer = 0f;
		this.Inactivate();
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x00069B88 File Offset: 0x00067F88
	private void Init()
	{
		this._childrenParticles = new List<GameObject>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			this._childrenParticles.Add(base.transform.GetChild(i).gameObject);
		}
	}

	// Token: 0x040009DA RID: 2522
	public float Duration = 1f;

	// Token: 0x040009DB RID: 2523
	private List<GameObject> _childrenParticles;

	// Token: 0x040009DC RID: 2524
	private bool _canPlayParticle;

	// Token: 0x040009DD RID: 2525
	private float _timer;
}
