using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class Program
    {
        // -----------------------------------------------------------------
        // Test Program
        // -----------------------------------------------------------------
        static void Main( string[] args )
        {
            ConcurrentPool<DummyClass> pool = new ConcurrentPool<DummyClass>( () => new DummyClass() );

            Parallel.For( 0, 10000, ( index ) =>
            {
                using( PooledObject<DummyClass> DummyClass = pool.Get() )
                {
                    ProcessDummy( DummyClass.Value );
                }
            }
            );
        }

        // -----------------------------------------------------------------
        static void ProcessDummy( DummyClass dummyClass )
        {
            // Dummy operation
        }
    }
}
