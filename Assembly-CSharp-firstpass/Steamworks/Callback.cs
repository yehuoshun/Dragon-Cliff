using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Steamworks
{
	// Token: 0x02000030 RID: 48
	public sealed class Callback<T> : IDisposable
	{
		// Token: 0x060002FF RID: 767 RVA: 0x0000F294 File Offset: 0x0000D694
		public Callback(Callback<T>.DispatchDelegate func, bool bGameServer = false)
		{
			this.m_bGameServer = bGameServer;
			this.BuildCCallbackBase();
			this.Register(func);
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000300 RID: 768 RVA: 0x0000F2D0 File Offset: 0x0000D6D0
		// (remove) Token: 0x06000301 RID: 769 RVA: 0x0000F308 File Offset: 0x0000D708
		private event Callback<T>.DispatchDelegate m_Func
		{
			add
			{
				Callback<T>.DispatchDelegate dispatchDelegate = this.m_Func;
				Callback<T>.DispatchDelegate dispatchDelegate2;
				do
				{
					dispatchDelegate2 = dispatchDelegate;
					dispatchDelegate = Interlocked.CompareExchange<Callback<T>.DispatchDelegate>(ref this.m_Func, (Callback<T>.DispatchDelegate)Delegate.Combine(dispatchDelegate2, value), dispatchDelegate);
				}
				while (dispatchDelegate != dispatchDelegate2);
			}
			remove
			{
				Callback<T>.DispatchDelegate dispatchDelegate = this.m_Func;
				Callback<T>.DispatchDelegate dispatchDelegate2;
				do
				{
					dispatchDelegate2 = dispatchDelegate;
					dispatchDelegate = Interlocked.CompareExchange<Callback<T>.DispatchDelegate>(ref this.m_Func, (Callback<T>.DispatchDelegate)Delegate.Remove(dispatchDelegate2, value), dispatchDelegate);
				}
				while (dispatchDelegate != dispatchDelegate2);
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000F33E File Offset: 0x0000D73E
		public static Callback<T> Create(Callback<T>.DispatchDelegate func)
		{
			return new Callback<T>(func, false);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000F347 File Offset: 0x0000D747
		public static Callback<T> CreateGameServer(Callback<T>.DispatchDelegate func)
		{
			return new Callback<T>(func, true);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000F350 File Offset: 0x0000D750
		~Callback()
		{
			this.Dispose();
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000F380 File Offset: 0x0000D780
		public void Dispose()
		{
			if (this.m_bDisposed)
			{
				return;
			}
			GC.SuppressFinalize(this);
			this.Unregister();
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

		// Token: 0x06000306 RID: 774 RVA: 0x0000F3E8 File Offset: 0x0000D7E8
		public void Register(Callback<T>.DispatchDelegate func)
		{
			if (func == null)
			{
				throw new Exception("Callback function must not be null.");
			}
			if ((this.m_CCallbackBase.m_nCallbackFlags & 1) == 1)
			{
				this.Unregister();
			}
			if (this.m_bGameServer)
			{
				this.SetGameserverFlag();
			}
			this.m_Func = func;
			NativeMethods.SteamAPI_RegisterCallback(this.m_pCCallbackBase.AddrOfPinnedObject(), CallbackIdentities.GetCallbackIdentity(typeof(T)));
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000F456 File Offset: 0x0000D856
		public void Unregister()
		{
			NativeMethods.SteamAPI_UnregisterCallback(this.m_pCCallbackBase.AddrOfPinnedObject());
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000F468 File Offset: 0x0000D868
		public void SetGameserverFlag()
		{
			CCallbackBase ccallbackBase = this.m_CCallbackBase;
			ccallbackBase.m_nCallbackFlags |= 2;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000F480 File Offset: 0x0000D880
		private void OnRunCallback(IntPtr pvParam)
		{
			try
			{
				this.m_Func((T)((object)Marshal.PtrToStructure(pvParam, typeof(T))));
			}
			catch (Exception e)
			{
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000F4D0 File Offset: 0x0000D8D0
		private void OnRunCallResult(IntPtr pvParam, bool bFailed, ulong hSteamAPICall)
		{
			try
			{
				this.m_Func((T)((object)Marshal.PtrToStructure(pvParam, typeof(T))));
			}
			catch (Exception e)
			{
				CallbackDispatcher.ExceptionHandler(e);
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000F520 File Offset: 0x0000D920
		private int OnGetCallbackSizeBytes()
		{
			return this.m_size;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000F528 File Offset: 0x0000D928
		private void BuildCCallbackBase()
		{
			this.VTable = new CCallbackBaseVTable
			{
				m_RunCallResult = new CCallbackBaseVTable.RunCRDel(this.OnRunCallResult),
				m_RunCallback = new CCallbackBaseVTable.RunCBDel(this.OnRunCallback),
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

		// Token: 0x04000181 RID: 385
		private CCallbackBaseVTable VTable;

		// Token: 0x04000182 RID: 386
		private IntPtr m_pVTable = IntPtr.Zero;

		// Token: 0x04000183 RID: 387
		private CCallbackBase m_CCallbackBase;

		// Token: 0x04000184 RID: 388
		private GCHandle m_pCCallbackBase;

		// Token: 0x04000185 RID: 389
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Callback<T>.DispatchDelegate m_Func;

		// Token: 0x04000186 RID: 390
		private bool m_bGameServer;

		// Token: 0x04000187 RID: 391
		private readonly int m_size = Marshal.SizeOf(typeof(T));

		// Token: 0x04000188 RID: 392
		private bool m_bDisposed;

		// Token: 0x02000031 RID: 49
		// (Invoke) Token: 0x0600030E RID: 782
		public delegate void DispatchDelegate(T param);
	}
}
