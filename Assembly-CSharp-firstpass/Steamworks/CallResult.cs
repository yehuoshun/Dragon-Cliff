using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Steamworks
{
	// Token: 0x02000032 RID: 50
	public sealed class CallResult<T> : IDisposable
	{
		// Token: 0x06000311 RID: 785 RVA: 0x0000F5EB File Offset: 0x0000D9EB
		public CallResult(CallResult<T>.APIDispatchDelegate func = null)
		{
			this.m_Func = func;
			this.BuildCCallbackBase();
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000312 RID: 786 RVA: 0x0000F62C File Offset: 0x0000DA2C
		// (remove) Token: 0x06000313 RID: 787 RVA: 0x0000F664 File Offset: 0x0000DA64
		private event CallResult<T>.APIDispatchDelegate m_Func
		{
			add
			{
				CallResult<T>.APIDispatchDelegate apidispatchDelegate = this.m_Func;
				CallResult<T>.APIDispatchDelegate apidispatchDelegate2;
				do
				{
					apidispatchDelegate2 = apidispatchDelegate;
					apidispatchDelegate = Interlocked.CompareExchange<CallResult<T>.APIDispatchDelegate>(ref this.m_Func, (CallResult<T>.APIDispatchDelegate)Delegate.Combine(apidispatchDelegate2, value), apidispatchDelegate);
				}
				while (apidispatchDelegate != apidispatchDelegate2);
			}
			remove
			{
				CallResult<T>.APIDispatchDelegate apidispatchDelegate = this.m_Func;
				CallResult<T>.APIDispatchDelegate apidispatchDelegate2;
				do
				{
					apidispatchDelegate2 = apidispatchDelegate;
					apidispatchDelegate = Interlocked.CompareExchange<CallResult<T>.APIDispatchDelegate>(ref this.m_Func, (CallResult<T>.APIDispatchDelegate)Delegate.Remove(apidispatchDelegate2, value), apidispatchDelegate);
				}
				while (apidispatchDelegate != apidispatchDelegate2);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000314 RID: 788 RVA: 0x0000F69A File Offset: 0x0000DA9A
		public SteamAPICall_t Handle
		{
			get
			{
				return this.m_hAPICall;
			}
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0000F6A2 File Offset: 0x0000DAA2
		public static CallResult<T> Create(CallResult<T>.APIDispatchDelegate func = null)
		{
			return new CallResult<T>(func);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000F6AC File Offset: 0x0000DAAC
		~CallResult()
		{
			this.Dispose();
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000F6DC File Offset: 0x0000DADC
		public void Dispose()
		{
			if (this.m_bDisposed)
			{
				return;
			}
			GC.SuppressFinalize(this);
			this.Cancel();
			if (this.m_pVTable != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.m_pVTable);
			}
			if (this.m_pCCallbackBase.IsAllocated)
			{
				this.m_pCCallbackBase.Free();
			}
			this.m_bDisposed = true;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0000F744 File Offset: 0x0000DB44
		public void Set(SteamAPICall_t hAPICall, CallResult<T>.APIDispatchDelegate func = null)
		{
			if (func != null)
			{
				this.m_Func = func;
			}
			if (this.m_Func == null)
			{
				throw new Exception("CallResult function was null, you must either set it in the CallResult Constructor or in Set()");
			}
			if (this.m_hAPICall != SteamAPICall_t.Invalid)
			{
				NativeMethods.SteamAPI_UnregisterCallResult(this.m_pCCallbackBase.AddrOfPinnedObject(), (ulong)this.m_hAPICall);
			}
			this.m_hAPICall = hAPICall;
			if (hAPICall != SteamAPICall_t.Invalid)
			{
				NativeMethods.SteamAPI_RegisterCallResult(this.m_pCCallbackBase.AddrOfPinnedObject(), (ulong)hAPICall);
			}
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000F7D1 File Offset: 0x0000DBD1
		public bool IsActive()
		{
			return this.m_hAPICall != SteamAPICall_t.Invalid;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0000F7E3 File Offset: 0x0000DBE3
		public void Cancel()
		{
			if (this.m_hAPICall != SteamAPICall_t.Invalid)
			{
				NativeMethods.SteamAPI_UnregisterCallResult(this.m_pCCallbackBase.AddrOfPinnedObject(), (ulong)this.m_hAPICall);
				this.m_hAPICall = SteamAPICall_t.Invalid;
			}
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000F820 File Offset: 0x0000DC20
		public void SetGameserverFlag()
		{
			CCallbackBase ccallbackBase = this.m_CCallbackBase;
			ccallbackBase.m_nCallbackFlags |= 2;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000F838 File Offset: 0x0000DC38
		private void OnRunCallback(IntPtr pvParam)
		{
			this.m_hAPICall = SteamAPICall_t.Invalid;
			try
			{
				this.m_Func((T)((object)Marshal.PtrToStructure(pvParam, typeof(T))), false);
			}
			catch (Exception e)
			{
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000F894 File Offset: 0x0000DC94
		private void OnRunCallResult(IntPtr pvParam, bool bFailed, ulong hSteamAPICall_)
		{
			SteamAPICall_t x = (SteamAPICall_t)hSteamAPICall_;
			if (x == this.m_hAPICall)
			{
				this.m_hAPICall = SteamAPICall_t.Invalid;
				try
				{
					this.m_Func((T)((object)Marshal.PtrToStructure(pvParam, typeof(T))), bFailed);
				}
				catch (Exception e)
				{
					CallbackDispatcher.ExceptionHandler(e);
				}
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000F908 File Offset: 0x0000DD08
		private int OnGetCallbackSizeBytes()
		{
			return this.m_size;
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000F910 File Offset: 0x0000DD10
		private void BuildCCallbackBase()
		{
			this.VTable = new CCallbackBaseVTable
			{
				m_RunCallback = new CCallbackBaseVTable.RunCBDel(this.OnRunCallback),
				m_RunCallResult = new CCallbackBaseVTable.RunCRDel(this.OnRunCallResult),
				m_GetCallbackSizeBytes = new CCallbackBaseVTable.GetCallbackSizeBytesDel(this.OnGetCallbackSizeBytes)
			};
			this.m_pVTable = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCallbackBaseVTable)));
			Marshal.StructureToPtr(this.VTable, this.m_pVTable, false);
			this.m_CCallbackBase = new CCallbackBase
			{
				m_vfptr = this.m_pVTable,
				m_nCallbackFlags = 0,
				m_iCallback = CallbackIdentities.GetCallbackIdentity(typeof(T))
			};
			this.m_pCCallbackBase = GCHandle.Alloc(this.m_CCallbackBase, GCHandleType.Pinned);
		}

		// Token: 0x04000189 RID: 393
		private CCallbackBaseVTable VTable;

		// Token: 0x0400018A RID: 394
		private IntPtr m_pVTable = IntPtr.Zero;

		// Token: 0x0400018B RID: 395
		private CCallbackBase m_CCallbackBase;

		// Token: 0x0400018C RID: 396
		private GCHandle m_pCCallbackBase;

		// Token: 0x0400018D RID: 397
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CallResult<T>.APIDispatchDelegate m_Func;

		// Token: 0x0400018E RID: 398
		private SteamAPICall_t m_hAPICall = SteamAPICall_t.Invalid;

		// Token: 0x0400018F RID: 399
		private readonly int m_size = Marshal.SizeOf(typeof(T));

		// Token: 0x04000190 RID: 400
		private bool m_bDisposed;

		// Token: 0x02000033 RID: 51
		// (Invoke) Token: 0x06000321 RID: 801
		public delegate void APIDispatchDelegate(T param, bool bIOFailure);
	}
}
