using System;

namespace Patterns
{
    public class DummyClass
    {
        int[] mValues;

        public DummyClass()
        {
            Random random = new Random();

            mValues = new int[ 10000 ];

            for( int index = 0; index < mValues.Length; ++index )
            {
                mValues[ index ] = random.Next();
            }
        }
    }
}
