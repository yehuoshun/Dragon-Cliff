using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000D55 RID: 3413
[CompilerGenerated]
internal sealed class <>__AnonType2<<Level>__T, <Items>__T>
{
	// Token: 0x06005729 RID: 22313 RVA: 0x00002342 File Offset: 0x00000742
	[DebuggerHidden]
	public <>__AnonType2(<Level>__T Level, <Items>__T Items)
	{
		this.<Level> = Level;
		this.<Items> = Items;
	}

	// Token: 0x1700125A RID: 4698
	// (get) Token: 0x0600572A RID: 22314 RVA: 0x00002358 File Offset: 0x00000758
	public <Level>__T Level
	{
		get
		{
			return this.<Level>;
		}
	}

	// Token: 0x1700125B RID: 4699
	// (get) Token: 0x0600572B RID: 22315 RVA: 0x00002360 File Offset: 0x00000760
	public <Items>__T Items
	{
		get
		{
			return this.<Items>;
		}
	}

	// Token: 0x0600572C RID: 22316 RVA: 0x00002368 File Offset: 0x00000768
	[DebuggerHidden]
	public override bool Equals(object obj)
	{
		var <>__AnonType = obj as <>__AnonType2<<Level>__T, <Items>__T>;
		return <>__AnonType != null && EqualityComparer<<Level>__T>.Default.Equals(this.<Level>, <>__AnonType.<Level>) && EqualityComparer<<Items>__T>.Default.Equals(this.<Items>, <>__AnonType.<Items>);
	}

	// Token: 0x0600572D RID: 22317 RVA: 0x000023BC File Offset: 0x000007BC
	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = ((-2128831035 ^ EqualityComparer<<Level>__T>.Default.GetHashCode(this.<Level>)) * 16777619 ^ EqualityComparer<<Items>__T>.Default.GetHashCode(this.<Items>)) * 16777619;
		num += num << 13;
		num ^= num >> 7;
		num += num << 3;
		num ^= num >> 17;
		return num + (num << 5);
	}

	// Token: 0x0600572E RID: 22318 RVA: 0x00002420 File Offset: 0x00000820
	[DebuggerHidden]
	public override string ToString()
	{
		string[] array = new string[6];
		array[0] = "{";
		array[1] = " Level = ";
		int num = 2;
		string text;
		if (this.<Level> != null)
		{
			<Level>__T <Level>__T = this.<Level>;
			text = <Level>__T.ToString();
		}
		else
		{
			text = string.Empty;
		}
		array[num] = text;
		array[3] = ", Items = ";
		int num2 = 4;
		string text2;
		if (this.<Items> != null)
		{
			<Items>__T <Items>__T = this.<Items>;
			text2 = <Items>__T.ToString();
		}
		else
		{
			text2 = string.Empty;
		}
		array[num2] = text2;
		array[5] = " }";
		return string.Concat(array);
	}

	// Token: 0x0400461D RID: 17949
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <Level>__T <Level>;

	// Token: 0x0400461E RID: 17950
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <Items>__T <Items>;
}
