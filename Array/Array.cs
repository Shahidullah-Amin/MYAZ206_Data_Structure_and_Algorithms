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
                if (item.ToString() == obj.ToString())
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

            for (int i = pos; i < InnerList.Length; i++)
            {
                if (InnerList[i] != null)
                {
                    return false;
                }
            }
            return true;
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
            return InnerList.GetEnumerator();
        }
    }
}