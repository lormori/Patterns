using System;

namespace Patterns
{
    public class PooledObject<T> : IDisposable where T : IResettable
    {
        // -----------------------------------------------------------------
        // Data
        // -----------------------------------------------------------------
        private ConcurrentPool<T> mConcurrentPool;
        private readonly T mPooledObject;

        // -----------------------------------------------------------------
        // Constructor
        // -----------------------------------------------------------------
        public PooledObject( T inOnbject, ConcurrentPool<T> inConcurrentPool )
        {
            mPooledObject = inOnbject;
            mConcurrentPool = inConcurrentPool ?? throw new Exception("[Pooled Object] Concurrent Pool is null");
        }

        // -----------------------------------------------------------------
        // IDisposable Interface
        // -----------------------------------------------------------------
        public void Dispose()
        {
            mPooledObject.Reset();
            mConcurrentPool.Return( this );   
        }

        // -----------------------------------------------------------------
        public T Value
        {
            get
            {
                return mPooledObject;
            }
        }
    }
}
