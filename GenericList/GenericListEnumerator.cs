using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericList
{
    internal class GenericListEnumerator<X> : IEnumerator<X>
    {

        private GenericList<X> genericList;

        /// <summary>
        /// With this index we can easily keep track of our data.
        /// It starts at -1 because of the way foreach loop works:
        /// It first invokes MoveNext method then it reaches current value.
        /// </summary>
        private int genericListIndex = -1;


        public GenericListEnumerator(GenericList<X> genericList)
        {
            this.genericList = genericList;
        }

        /// <summary>
        /// Returns current value(value of a location in genericList specified by genericListIndex).
        /// </summary>
        public X Current
        {
            get
            {
                return genericList.GetElement(genericListIndex);
            }
        }

        /// <summary>
        /// Not completely sure what this does. It does not seem like I need it...
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// I made implementation so that it clears local genericList and resets index.
        /// </summary>
        public void Dispose()
        {
            genericList.Clear();
            this.Reset();
        }

        /// <summary>
        /// This method moves to next element in genericList and returns value dependent on if index exited the genericList or not.
        /// </summary>
        /// <returns>Returns true if genericListIndex can be moved by 1. Returns false if it can't.</returns>
        public bool MoveNext()
        {
            if (genericListIndex + 1 >= genericList.Count)
            {
                this.Reset();
                return false;
            }
            else
            {
                genericListIndex++;
                return true;
            }
        }

        /// <summary>
        /// Resets the index(as it says in documentation).
        /// </summary>
        public void Reset()
        {
            genericListIndex = -1;
        }
    }
}