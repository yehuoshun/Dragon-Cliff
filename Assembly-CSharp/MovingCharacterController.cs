using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200030D RID: 781
public abstract class MovingCharacterController : MonoBehaviour
{
	// Token: 0x060014D9 RID: 5337 RVA: 0x000A8826 File Offset: 0x000A6C26
	protected MovingCharacterController()
	{
	}

	// Token: 0x17000108 RID: 264
	// (get) Token: 0x060014DA RID: 5338 RVA: 0x000A8861 File Offset: 0x000A6C61
	// (set) Token: 0x060014DB RID: 5339 RVA: 0x000A8869 File Offset: 0x000A6C69
	public bool FollowPath
	{
		[CompilerGenerated]
		get
		{
			return this.<FollowPath>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<FollowPath>k__BackingField = value;
		}
	}

	// Token: 0x060014DC RID: 5340
	public abstract IEnumerator ArrivedDestination();

	// Token: 0x060014DD RID: 5341 RVA: 0x000A8872 File Offset: 0x000A6C72
	private void Awake()
	{
		this.Animator = base.GetComponentInChildren<Animator>();
	}

	// Token: 0x060014DE RID: 5342 RVA: 0x000A8880 File Offset: 0x000A6C80
	protected void UpdateSprites(CharacterBasicAppearance appearance)
	{
		Sprite[] array = Resources.LoadAll<Sprite>(FilePath.CharacterImagePath + appearance.Path);
		if (array.Length == 0)
		{
			throw new Exception(FilePath.CharacterImagePath + appearance.Path + " not exist, please check.");
		}
		this.SouthLeft.sprite = array[appearance.SouthLeft];
		this.SouthMiddle.sprite = array[appearance.SouthMiddle];
		this.SouthRight.sprite = array[appearance.SouthRight];
		this.WestLeft.sprite = array[appearance.WestLeft];
		this.WestMiddle.sprite = array[appearance.WestMiddle];
		this.WestRight.sprite = array[appearance.WestRight];
		this.EastLeft.sprite = array[appearance.EastLeft];
		this.EastMiddle.sprite = array[appearance.EastMiddle];
		this.EastRight.sprite = array[appearance.EastRight];
		this.NorthLeft.sprite = array[appearance.NorthLeft];
		this.NorthMiddle.sprite = array[appearance.NorthMiddle];
		this.NorthRight.sprite = array[appearance.NorthRight];
	}

	// Token: 0x060014DF RID: 5343 RVA: 0x000A89AC File Offset: 0x000A6DAC
	protected void Moving()
	{
		if (this.Path.Count == 0)
		{
			base.StartCoroutine(this.ArrivedDestination());
			return;
		}
		float num = Vector3.Distance(this.Path[this.CurrentPoint].position, base.transform.position);
		Vector3 normalized = (this.Path[this.CurrentPoint].position - base.transform.position).normalized;
		this.AnimateMove(normalized.x, normalized.y);
		if (num <= this.ReachDist)
		{
			this.CurrentPoint++;
		}
		if (this.CurrentPoint >= this.Path.Count)
		{
			this.CurrentPoint = 0;
			this.Path.Clear();
			base.StartCoroutine(this.ArrivedDestination());
		}
	}

	// Token: 0x060014E0 RID: 5344 RVA: 0x000A8A90 File Offset: 0x000A6E90
	protected void StartToMove(List<Transform> path)
	{
		this.Path = path;
		this.FollowPath = true;
	}

	// Token: 0x060014E1 RID: 5345 RVA: 0x000A8AA0 File Offset: 0x000A6EA0
	protected void AnimateIdle()
	{
		Vector2 vector = new Vector2((float)UnityEngine.Random.Range(-1, 2), (float)UnityEngine.Random.Range(-1, 2));
		if (vector.x == 0f && vector.y == 0f)
		{
			vector.y = -1f;
		}
		if (Math.Abs(vector.y) == Math.Abs(vector.x) && vector.y != 0f)
		{
			vector.x = 0f;
		}
		this.Animator.SetFloat("xLastMove", vector.x);
		this.Animator.SetFloat("yLastMove", vector.y);
		this.Animator.SetBool("isMoving", false);
	}

	// Token: 0x060014E2 RID: 5346 RVA: 0x000A8B6C File Offset: 0x000A6F6C
	protected void AnimateMove(float xInput, float yInput)
	{
		bool flag = Math.Abs(xInput) > 0.1f || Math.Abs(yInput) > 0.1f;
		Vector2 vector = default(Vector2);
		if (flag)
		{
			Vector3 a = new Vector3(xInput, yInput, 0f);
			base.transform.position += a * this._currentSpeed * Time.deltaTime;
			if (xInput > 0.5f || xInput < -0.5f)
			{
				vector = new Vector2(xInput, 0f);
			}
			if (yInput > 0.5f || yInput < -0.5f)
			{
				vector = new Vector2(0f, yInput);
			}
			if (xInput > 0.5f)
			{
				xInput = 1f;
				yInput = 0f;
			}
			if (xInput < -0.5f)
			{
				xInput = -1f;
				yInput = 0f;
			}
			if (yInput > 0.5f)
			{
				yInput = 1f;
				xInput = 0f;
			}
			if (yInput < -0.5f)
			{
				yInput = -1f;
				xInput = 0f;
			}
			this.Animator.SetFloat("xInput", xInput);
			this.Animator.SetFloat("yInput", yInput);
			this.Animator.SetFloat("xLastMove", vector.x);
			this.Animator.SetFloat("yLastMove", vector.y);
		}
		this.Animator.SetBool("isMoving", flag);
	}

	// Token: 0x060014E3 RID: 5347 RVA: 0x000A8CF0 File Offset: 0x000A70F0
	protected IEnumerator Wait()
	{
		yield return new WaitForSeconds(1f);
		yield break;
	}

	// Token: 0x060014E4 RID: 5348 RVA: 0x000A8D04 File Offset: 0x000A7104
	protected bool Waited(float seconds)
	{
		this._timerMax = seconds;
		this._timer += Time.deltaTime;
		if (this._timer >= this._timerMax)
		{
			this._timer = 0f;
			this._timerMax = 0f;
			return true;
		}
		return false;
	}

	// Token: 0x040014E5 RID: 5349
	public float ReachDist = 0.5f;

	// Token: 0x040014E6 RID: 5350
	public float Speed = 5f;

	// Token: 0x040014E7 RID: 5351
	public float MinSpeed = 0.5f;

	// Token: 0x040014E8 RID: 5352
	public float MaxSpeed = 2f;

	// Token: 0x040014E9 RID: 5353
	protected float _currentSpeed;

	// Token: 0x040014EA RID: 5354
	public SpriteRenderer SouthLeft;

	// Token: 0x040014EB RID: 5355
	public SpriteRenderer SouthMiddle;

	// Token: 0x040014EC RID: 5356
	public SpriteRenderer SouthRight;

	// Token: 0x040014ED RID: 5357
	public SpriteRenderer WestLeft;

	// Token: 0x040014EE RID: 5358
	public SpriteRenderer WestMiddle;

	// Token: 0x040014EF RID: 5359
	public SpriteRenderer WestRight;

	// Token: 0x040014F0 RID: 5360
	public SpriteRenderer EastLeft;

	// Token: 0x040014F1 RID: 5361
	public SpriteRenderer EastMiddle;

	// Token: 0x040014F2 RID: 5362
	public SpriteRenderer EastRight;

	// Token: 0x040014F3 RID: 5363
	public SpriteRenderer NorthLeft;

	// Token: 0x040014F4 RID: 5364
	public SpriteRenderer NorthMiddle;

	// Token: 0x040014F5 RID: 5365
	public SpriteRenderer NorthRight;

	// Token: 0x040014F6 RID: 5366
	protected List<Transform> Path;

	// Token: 0x040014F7 RID: 5367
	protected int CurrentPoint;

	// Token: 0x040014F8 RID: 5368
	protected bool IsDead = true;

	// Token: 0x040014F9 RID: 5369
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <FollowPath>k__BackingField;

	// Token: 0x040014FA RID: 5370
	protected Animator Animator;

	// Token: 0x040014FB RID: 5371
	private float _timer;

	// Token: 0x040014FC RID: 5372
	private float _timerMax;

	// Token: 0x02000C87 RID: 3207
	[CompilerGenerated]
	private sealed class <Wait>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600531F RID: 21279 RVA: 0x000A8D54 File Offset: 0x000A7154
		[DebuggerHidden]
		public <Wait>c__Iterator0()
		{
		}

		// Token: 0x06005320 RID: 21280 RVA: 0x000A8D5C File Offset: 0x000A715C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(1f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x1700119A RID: 4506
		// (get) Token: 0x06005321 RID: 21281 RVA: 0x000A8DB8 File Offset: 0x000A71B8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700119B RID: 4507
		// (get) Token: 0x06005322 RID: 21282 RVA: 0x000A8DC0 File Offset: 0x000A71C0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005323 RID: 21283 RVA: 0x000A8DC8 File Offset: 0x000A71C8
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005324 RID: 21284 RVA: 0x000A8DD8 File Offset: 0x000A71D8
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040040BA RID: 16570
		internal object $current;

		// Token: 0x040040BB RID: 16571
		internal bool $disposing;

		// Token: 0x040040BC RID: 16572
		internal int $PC;
	}
}
