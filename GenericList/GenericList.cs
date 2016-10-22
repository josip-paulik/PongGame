using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;

        //This index enables fast adding into array and also points to an index after the last item.
        //Also finds free space radically fast(it is already pointing to it).
        //This might not be perfect implementation...
        private int _internalStorageIndex = 0;


        /// <summary>
        /// This constructor creates new IntegerList by initaliazing its private field with size 4.
        /// </summary>
        public GenericList()
        {
            _internalStorage = new X[4];
        }

        /// <summary>
        /// This constructor creates new IntegerList by initaliazing its private field with size given by initialSize.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if given parameter is negative</exception>
        /// <param name="initalSize">How much size private field will take. Must not be negative.</param>
        public GenericList(int initalSize)
        {
            if (initalSize < 0)
            {
                throw new ArgumentException("Argument musn't be negative.");
            }
            else
            {
                _internalStorage = new X[initalSize];
            }
        }

        /// <summary>
        /// This method returns number of items in the private field.
        /// </summary>
        public int Count
        {
            get
            {
                return _internalStorageIndex;
            }
        }

        /// <summary>
        /// This method adds item in private field onto its last place. Also manages capacity.
        /// It manages it by doubling up its size when array is out of space.
        /// </summary>
        /// <param name="item">Item which we want to store.</param>
        public void Add(X item)
        {
            if (_internalStorageIndex >= _internalStorage.Length - 1)
            {
                Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
            }

            _internalStorage[_internalStorageIndex] = item;
            _internalStorageIndex++;
        }

        /// <summary>
        /// This method clears whole private field
        /// </summary>
        public void Clear()
        {
            Array.Clear(_internalStorage, 0, this.Count);
            _internalStorageIndex = 0;

        }

        /// <summary>
        /// Searches for an element inside private field and returns the result of a search.
        /// </summary>
        /// <param name="item">What to search for.</param>
        /// <returns>Result of a search - true or false.</returns>
        public bool Contains(X item)
        {
            for (int i = 0; i < _internalStorageIndex; i++)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns specified element at searched index.
        /// </summary>
        /// 
        /// <param name="index">Searched index.</param>
        /// 
        /// <returns>Element which is on the specified index or it throws exception</returns>
        /// 
        /// <exception cref="IndexOutOfRangeException">
        /// This Exception will be thrown when index is an illegal value
        /// </exception>
        public X GetElement(int index)
        {
            if (index >= 0 && index < _internalStorageIndex)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range of this GenericList.");
            }
        }



        /// <summary>
        /// This method returns index(location) of a searched item in private field.
        /// </summary>
        /// <param name="item">Item to be searched in private field.</param>
        /// <returns>Index of searched element or -1 if item is not found.</returns>
        public int IndexOf(X item)
        {
            for (int i = 0; i < _internalStorageIndex; i++)
            {
                if (item.Equals(_internalStorage[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// This method removes an item from list using number to be removed as paramter.
        /// </summary>
        /// <param name="item">Number that needs to be deleted.</param>
        /// <returns>Returns false if number is not found inside private field.</returns>
        public bool Remove(X item)
        {
            int indexOfRemoval = this.IndexOf(item);
            if (indexOfRemoval == -1)
            {
                return false;
            }
            return RemoveAt(indexOfRemoval);
        }

        /// <summary>
        /// This method removes an item from list using index(place) where the number is niside private field.
        /// </summary>
        /// <param name="index">Place where the number will be removed.</param>
        /// <returns>Returns false if number could not be removed due to invalid index given.</returns>
        public bool RemoveAt(int index)
        {
            if (index >= this.Count || index < 0)
            {
                return false;
            }

            for (int i = index; i < _internalStorageIndex - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }


            _internalStorageIndex--;

            //This is reason why it is not perfect implementation.
            //I now have to remove loose element after moving left all elements of array that are right of element which had to be removed.
            Array.Clear(_internalStorage, _internalStorageIndex, 1);

            return true;
        }

        // IEnumerable <X> implementation
        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
