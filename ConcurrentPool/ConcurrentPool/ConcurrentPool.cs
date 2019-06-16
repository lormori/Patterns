using System;
using System.Collections.Concurrent;

namespace Patterns
{
    public class ConcurrentPool<T>
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
            mFactory = inFactory;
        }

        // -----------------------------------------------------------------
        // Functions
        // -----------------------------------------------------------------
        public PooledObject<T> Get()
        {
            if( mPool.TryTake( out PooledObject<T> returnObject ) )
            {
                Console.WriteLine( "Getting existing object" );
                return returnObject;
            }

            T newObject = mFactory();
            PooledObject<T> pooledObject = new PooledObject<T>( newObject, this );

            Console.WriteLine( "Instatiating new object" );
            return pooledObject;
        }

        // -----------------------------------------------------------------
        public void Return( PooledObject<T> inToReturn )
        {
            Console.WriteLine( "Returning object" );
            mPool.Add( inToReturn );
        }
    }
}
