using System;
using UnityEngine;

// Token: 0x02000A24 RID: 2596
public class UnscaledTimeParticle : MonoBehaviour
{
	// Token: 0x060046BB RID: 18107 RVA: 0x001CF9C0 File Offset: 0x001CDDC0
	public UnscaledTimeParticle()
	{
	}

	// Token: 0x060046BC RID: 18108 RVA: 0x001CF9C8 File Offset: 0x001CDDC8
	private void Awake()
	{
		this._particle = base.GetComponent<ParticleSystem>();
	}

	// Token: 0x060046BD RID: 18109 RVA: 0x001CF9D6 File Offset: 0x001CDDD6
	private void Start()
	{
		this._lastTime = (double)Time.realtimeSinceStartup;
	}

	// Token: 0x060046BE RID: 18110 RVA: 0x001CF9E4 File Offset: 0x001CDDE4
	private void Update()
	{
		if (!this._particle.main.loop)
		{
			if (Time.timeScale < 0.01f)
			{
				this._particle.Simulate(Time.unscaledDeltaTime, true, false);
			}
		}
		else if (this._particle.main.loop)
		{
			if (Time.timeScale < 0.01f)
			{
				this._particle.Simulate(Time.unscaledDeltaTime, true, false);
			}
			if (Time.timeScale > 0.01f)
			{
				this._particle.Simulate(Time.unscaledDeltaTime, true, false);
			}
		}
	}

	// Token: 0x040038F7 RID: 14583
	private double _lastTime;

	// Token: 0x040038F8 RID: 14584
	private ParticleSystem _particle;
}
