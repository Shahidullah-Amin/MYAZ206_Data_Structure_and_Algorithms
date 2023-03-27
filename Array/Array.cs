using System;
using System.Collections;

namespace Array
{
    public class Array : ICloneable, IEnumerable
    {
        private Object[] InnerList;

        private int position = 0;
        private bool isNull = true;
        public int Length => InnerList.Length;

        public Array(int defaultSize=2)
        {
            InnerList = new Object[defaultSize];
        }
        public Array(params Object[] array) : this(array.Length)
        {
            System.Array.Copy(array , InnerList , array.Length);
        }
        public Array(IEnumerable _array) : this()
        {
            foreach(var value in _array)
            {
                this.Add(value);
            }
        }
        public Object GetValue(int index)
        {
            if(index >=0  && index < InnerList.Length)
            {
            return InnerList[index];

            }
            throw new ArgumentOutOfRangeException("Index");
        }
        public void SetValue(Object value, int index)
        {
            if(index >=0 && index< InnerList.Length)
            {
                InnerList[index] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index");
            }
        }
        public void Add(Object obj)
        {
            if (arrayIsNull(position) && isNull)
            {
                if (position == InnerList.Length-1)
                {
                    DoubleArray();
                }
                InnerList[position] = obj;
                position++;
            }
            else
            {
                isNull = false;
                if (InnerList[InnerList.Length - 1] == null)
                {
                    position = InnerList.Length - 1;
                    InnerList[position++] = obj;
                }
                else
                {
                    position = InnerList.Length;
                    ExtendArray();
                    InnerList[position++] = obj;
                }
            }
        }
        public Object Remove(Object obj)
        {
            if (Find(obj))
            {

                var temp = obj;
                int index = System.Array.IndexOf(InnerList, obj);

                InnerList[index] = null;

                var newArray = new Object[InnerList.Length];
                int nullValues = 0;
                int count = 0;



                foreach (var item in InnerList)
                {
                    if (item == null)
                    {
                        nullValues++;
                    }
                    else
                    {
                        newArray[count] = item;
                        count++;
                    }
                }

                InnerList = newArray;
                position = count;

                if (count == InnerList.Length / 2)
                {
                    HalfArray(count);
                }
        
                return temp;
            }
            return null;
        }
        public bool Find(Object obj)
        {
            foreach (var item in InnerList)
            {
                if (item.Equals(obj))
                {
                    return true;
                }
            }
            return false;
        }
        private void ExtendArray()
        {
            var _array = new Object[InnerList.Length + 1];
            System.Array.Copy(InnerList, _array, InnerList.Length);
            InnerList = _array;
        }
        private bool arrayIsNull(int pos)
        {
            if (pos != InnerList.Length)
            {
                for (int i = pos; i < InnerList.Length; i++)
                {
                    if (InnerList[i] != null)
                    {
                        return false;
                    }
                }
                return true;

            }
            return false;

        }
        private void DoubleArray()
        {
            var _array = new Object[InnerList.Length * 2];
            System.Array.Copy(InnerList, _array, InnerList.Length);
            InnerList = _array;
        }
        private void HalfArray(int _position)
        {
            var new_array = new Object[_position];
            System.Array.Copy(InnerList, new_array, _position);
            InnerList = new_array;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public IEnumerator GetEnumerator()
        {
            return InnerList.Take(this.TakeSize(InnerList)).GetEnumerator();
        }
        public int IndexOf(Object obj)
        {
            for (int x = 0; x < InnerList.Length; x++)
            {
                if (InnerList[x].Equals(obj))
                {
                    return x;
                }
            }
            return -1;
        }
        
        public void AddFirst(Object obj)
        {
            var array_ = new Object[InnerList.Length + 1];
            array_[0] = obj;

            for(int i =1;  i < array_.Length; i++)
            {
                array_[i] = InnerList[i-1];
            }

            InnerList = array_;
        }


        private int TakeSize(Object[] arr)
        {
            for(int i =arr.Length-1; i >= 0; i--)
            {
                if (arr[i] != null)
                {
                    return i + 1;
                }
            }
            return 1;
        }

    }


    public class Array<T> : IEnumerable<T> , ICloneable
    {


        private T[] InnerList;

        private int position=0;
        public int Length => InnerList.Length;

        public Array(int defaultSize = 2)
        {
            InnerList = new T[defaultSize];
        }

        public Array(params T[] array) : this(array.Length)
        {
            System.Array.Copy(array, InnerList, array.Length);
        }


        public T GetValue(int index)
        {
            if (index >= 0 && index < InnerList.Length)
            {
                return InnerList[index];
            }
            throw new ArgumentOutOfRangeException("Index");
        }

        public void SetValue(T value, int index)
        {
            if(index>=0 && index < InnerList.Length)
            {
                InnerList[index] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }


        public void Add(T value)
        {
            if (ArrayIsNull(position))
            {
                InnerList[position] = value;
            }
            else
            {
                position = InnerList.Length;
                ExtendArray(position);
                InnerList[position] = value;
            }

            position++;
            if(position == InnerList.Length)    
                DoubleArray();
            
        }

        private void ExtendArray(int _position)
        {
            var _array = new T[_position+1];
            System.Array.Copy(InnerList, _array, _position);
            InnerList = _array;
        }

        private void DoubleArray()
        {
            var _array = new T[InnerList.Length*2];
            System.Array.Copy(InnerList, _array, InnerList.Length);
            InnerList = _array;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var item in InnerList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private bool ArrayIsNull(int _position)
        {


            if (InnerList[0].GetType() == typeof(int))
            {
                for(int x=_position; x<InnerList.Length; x++)
                {
                    if (InnerList[x] is 0)
                    {
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            else { 
                for(int i = _position; i<InnerList.Length; i++)
                {
                    if (InnerList[i] !=null)
                        return false;
                }
                return true;
            }
            
        }


        public static void Copy(IEnumerable source_array, IEnumerable destination_array, int length)
        {
            int _length = 0;
            foreach (var item in source_array)
            {
                _length++;
            }

            var _array = new Object[length];

            int i = 0;
            foreach(var value in source_array)
            {
                if (i != length)
                {
                    _array[i] = value;
                    i++;
                }
                else
                {
                    break;
                }
            }


            destination_array = _array;
        }
    }

}