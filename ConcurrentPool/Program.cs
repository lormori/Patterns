using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class Program
    {
        static void Main( string[] args )
        {
            ConcurrentPool<DummyClass> pool = new ConcurrentPool<DummyClass>( () => new DummyClass() );

            Parallel.For( 0, 10000, ( index ) =>
            {
                using( PooledObject<DummyClass> DummyClass = pool.Get() )
                {
                    Process( DummyClass.Value );
                }
            }
            );
        }

        static void Process( DummyClass dummyClass )
        {
            Console.WriteLine( "Processing Dummy Class" );
        }
    }
}
