using System;
using UnityEngine;

// Token: 0x02000351 RID: 849
public class AnimatedTexture : MonoBehaviour
{
	// Token: 0x060016A5 RID: 5797 RVA: 0x000B235C File Offset: 0x000B075C
	public AnimatedTexture()
	{
	}

	// Token: 0x060016A6 RID: 5798 RVA: 0x000B236B File Offset: 0x000B076B
	private void Start()
	{
		this._material = base.GetComponent<Renderer>().material;
		this._offset = this._material.GetTextureOffset("_MainTex");
	}

	// Token: 0x060016A7 RID: 5799 RVA: 0x000B2394 File Offset: 0x000B0794
	private void FixedUpdate()
	{
		if (this.IsWalking)
		{
			if (this.AnimatedTextureType == AnimatedTextureType.Normal)
			{
				this._offset += this.Speed * Time.fixedDeltaTime * 2f;
			}
			else if (this.AnimatedTextureType == AnimatedTextureType.Vertical)
			{
				this._offset += new Vector2(BattleManager.instance.Spawner.Background.GroudMovingSpeed, this.Speed.y) * Time.fixedDeltaTime * 2f;
			}
			else if (this.AnimatedTextureType == AnimatedTextureType.Horizontal)
			{
				this._offset += new Vector2(this.Speed.x + BattleManager.instance.Spawner.Background.GroudMovingSpeed, this.Speed.y) * Time.fixedDeltaTime * 2f;
			}
			this._material.SetTextureOffset("_MainTex", this._offset);
		}
		else if (this.AnimatedTextureType == AnimatedTextureType.Horizontal)
		{
			this._offset += this.Speed * Time.fixedDeltaTime * 2f;
			this._material.SetTextureOffset("_MainTex", this._offset);
		}
		else if (this.AnimatedTextureType == AnimatedTextureType.Vertical)
		{
			this._offset += new Vector2(0f, this.Speed.y) * Time.fixedDeltaTime * 2f;
			this._material.SetTextureOffset("_MainTex", this._offset);
		}
	}

	// Token: 0x060016A8 RID: 5800 RVA: 0x000B256B File Offset: 0x000B096B
	public void StopMoving()
	{
		this.IsWalking = false;
	}

	// Token: 0x060016A9 RID: 5801 RVA: 0x000B2574 File Offset: 0x000B0974
	public void ContinueMoving()
	{
		this.IsWalking = true;
	}

	// Token: 0x040016B6 RID: 5814
	public AnimatedTextureType AnimatedTextureType;

	// Token: 0x040016B7 RID: 5815
	public Vector2 Speed;

	// Token: 0x040016B8 RID: 5816
	private Vector2 _offset;

	// Token: 0x040016B9 RID: 5817
	private Material _material;

	// Token: 0x040016BA RID: 5818
	protected bool IsWalking = true;
}
