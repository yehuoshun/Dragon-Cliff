using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000D56 RID: 3414
[CompilerGenerated]
internal sealed class <>__AnonType3<<Type>__T, <Items>__T>
{
	// Token: 0x0600572F RID: 22319 RVA: 0x000024BA File Offset: 0x000008BA
	[DebuggerHidden]
	public <>__AnonType3(<Type>__T Type, <Items>__T Items)
	{
		this.<Type> = Type;
		this.<Items> = Items;
	}

	// Token: 0x1700125C RID: 4700
	// (get) Token: 0x06005730 RID: 22320 RVA: 0x000024D0 File Offset: 0x000008D0
	public <Type>__T Type
	{
		get
		{
			return this.<Type>;
		}
	}

	// Token: 0x1700125D RID: 4701
	// (get) Token: 0x06005731 RID: 22321 RVA: 0x000024D8 File Offset: 0x000008D8
	public <Items>__T Items
	{
		get
		{
			return this.<Items>;
		}
	}

	// Token: 0x06005732 RID: 22322 RVA: 0x000024E0 File Offset: 0x000008E0
	[DebuggerHidden]
	public override bool Equals(object obj)
	{
		var <>__AnonType = obj as <>__AnonType3<<Type>__T, <Items>__T>;
		return <>__AnonType != null && EqualityComparer<<Type>__T>.Default.Equals(this.<Type>, <>__AnonType.<Type>) && EqualityComparer<<Items>__T>.Default.Equals(this.<Items>, <>__AnonType.<Items>);
	}

	// Token: 0x06005733 RID: 22323 RVA: 0x00002534 File Offset: 0x00000934
	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = ((-2128831035 ^ EqualityComparer<<Type>__T>.Default.GetHashCode(this.<Type>)) * 16777619 ^ EqualityComparer<<Items>__T>.Default.GetHashCode(this.<Items>)) * 16777619;
		num += num << 13;
		num ^= num >> 7;
		num += num << 3;
		num ^= num >> 17;
		return num + (num << 5);
	}

	// Token: 0x06005734 RID: 22324 RVA: 0x00002598 File Offset: 0x00000998
	[DebuggerHidden]
	public override string ToString()
	{
		string[] array = new string[6];
		array[0] = "{";
		array[1] = " Type = ";
		int num = 2;
		string text;
		if (this.<Type> != null)
		{
			<Type>__T <Type>__T = this.<Type>;
			text = <Type>__T.ToString();
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

	// Token: 0x0400461F RID: 17951
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <Type>__T <Type>;

	// Token: 0x04004620 RID: 17952
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <Items>__T <Items>;
}
