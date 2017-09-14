using System;

namespace Pikit.Domain.Core
{
	public abstract class DisposableBase
			: IDisposable
	{
		// https://msdn.microsoft.com/en-us/library/ms244737.aspx
		protected bool _disposed;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~DisposableBase()
		{
			Dispose(false);
		}

		protected void Dispose(bool disposing)
		{
			if (disposing)
			{
				DoDispose();
			}

			DoDisposeNative();

			this._disposed = true;
		}

		protected virtual void DoDispose()
		{
		}

		protected virtual void DoDisposeNative()
		{
		}
	}
}