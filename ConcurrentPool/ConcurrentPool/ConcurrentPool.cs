using System;
using System.Collections.Concurrent;

namespace Patterns
{
    public class ConcurrentPool<T> where T : IResettable
    {
        // -----------------------------------------------------------------
        // Data
        // -----------------------------------------------------------------
        ConcurrentBag<PooledObject<T>> mPool = new ConcurrentBag<PooledObject<T>>();
        Func<T> mFactory;

        // -----------------------------------------------------------------
        // Constructors
        // -----------------------------------------------------------------
        public ConcurrentPool( Func<T> inFactory )
        {
            mFactory = inFactory ?? throw new Exception( "[Concurrent Pool] Factory Function is null" );
        }

        // -----------------------------------------------------------------
        // Functions
        // -----------------------------------------------------------------
        public PooledObject<T> Get()
        {
            if( mPool.TryTake( out PooledObject<T> returnObject ) )
            {
                return returnObject;
            }

            T newObject = mFactory();
            PooledObject<T> pooledObject = new PooledObject<T>( newObject, this );

            return pooledObject;
        }

        // -----------------------------------------------------------------
        public void Return( PooledObject<T> inToReturn )
        {
            if( inToReturn != null )
            {
                mPool.Add( inToReturn );
            }
        }
    }
}
