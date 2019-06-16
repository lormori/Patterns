using System;

namespace Patterns
{
    public class DummyClass : IResettable
    {
        // -----------------------------------------------------------------
        // Data
        // -----------------------------------------------------------------
        int[] mValues;

        // -----------------------------------------------------------------
        // Constructors
        // -----------------------------------------------------------------
        public DummyClass()
        {
            Random random = new Random();

            mValues = new int[ 10000 ];

            for( int index = 0; index < mValues.Length; ++index )
            {
                mValues[ index ] = random.Next();
            }
        }

        // -----------------------------------------------------------------
        // IResettable interface
        // -----------------------------------------------------------------
        public void Reset()
        {
            
        }
    }
}
