using System;

namespace Patterns
{
    public class PooledObject<T> : IDisposable
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
            mConcurrentPool = inConcurrentPool;
            mPooledObject = inOnbject;
        }

        // -----------------------------------------------------------------
        // IDisposable Interfact
        // -----------------------------------------------------------------
        public void Dispose()
        {
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
