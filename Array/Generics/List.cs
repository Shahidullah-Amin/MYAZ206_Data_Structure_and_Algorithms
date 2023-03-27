using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array.Generics
{
    public class List<T> : IEnumerable<T> , ICloneable
    {
        private T[] InnerList;
        private int index;
        public int Count => index;
        public int Length => InnerList.Length;

        public List(int defaultSize=4)
        {
            InnerList = new T[defaultSize];
            index = 0;
        }
        public List(params T[] array) : this(array.Length)
        {
            System.Array.Copy(array, InnerList, array.Length);
            index = InnerList.Length;
        }

        public T GetValue(int _indx)
        {
            if(_indx >= 0 && _indx < InnerList.Length)
            {
                return InnerList[_indx];
            }
            throw new ArgumentOutOfRangeException("Index");
        }
        public void SetValue(int _indx , T item)
        {
            if (_indx >= 0 && _indx < InnerList.Length)
            {
                InnerList[_indx] = item;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index");
            }
        }
        public void Add(T item)
        {
            if (index == InnerList.Length)
            {
                DoubleList();
            }
            InnerList[index] = item;
            index++;
        }

        public void AddFirst(T item)
        {
            if (index == InnerList.Length)
            {
                DoubleList();
            }

            var new_list = new T[InnerList.Length];
            new_list[0] = item;

            for (int i = 0; i < index; i++)
            {
                new_list[i + 1] = InnerList[i];
            }

            InnerList = new_list;

            index++;



            //  OR 👇

            /*index++;
            for(int i = index; i>0; i--)
            {
                var temp = InnerList[i];
                InnerList[i]= InnerList[i - 1];
                InnerList[i - 1] = temp;
            }
            InnerList[0] = item;*/
        }

        public void AddRange(IEnumerable<T> array)
        {
            foreach(var item in array)
            {
                this.Add(item);
            }
        }

        public bool Remove(T item)
        {
            if (Find(item))
            {
                int position = System.Array.IndexOf(InnerList, item);
                InnerList[position] = default(T);

                for(int i=position; i<InnerList.Length-1; i++)
                {
                    var temp = InnerList[i];
                    InnerList[i] = InnerList[i + 1];
                    InnerList[i + 1] = temp;
                }

                index--;

                if (index == InnerList.Length / 2)
                {
                    HalfList();
                }

                return true;
             }
            return false;
        }

        private void HalfList()
        {
            var _list = new T[InnerList.Length / 2];
            for(int i =0; i < _list.Length; i++)
            {
                _list[i] = InnerList[i];
            }
            InnerList = _list;
        }   

        private void DoubleList()
        {
            var _list = new T[2 * InnerList.Length];
            System.Array.Copy(InnerList, _list, InnerList.Length);
            InnerList = _list;
        }

        private bool Find(T item)
        {
            foreach(var value in InnerList)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool Find_In(T item, T[] array)
        {
            for(int i= 0; i<array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Take(index).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < InnerList.Length; i++)
            {
                if (item.Equals(InnerList[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public T[] Intersect(IEnumerable<T> array) 
        {
            var newlist = new T[InnerList.Length];
            int x = 0;
            
            foreach(var item in array.Intersect(InnerList))
            {
                newlist[x] = item;
                x++;
            }

            return newlist;
        }

        public T[] Union(IEnumerable<T> array)
        {
            var newList = new T[array.Count() + InnerList.Length];

            int x = 0;

            foreach (var item in array.Union(InnerList))
            {
                if (item !=null)
                {
                    newList[x] = item;
                    x++;
                }
            }
            return newList;
        }
    }



    public class Array<T> : IEnumerable<T>, ICloneable
    {


        private T[] InnerList;

        private int position = 0;
        public int Length => InnerList.Length;

        public Array(int defaultSize = 2)
        {
            InnerList = new T[defaultSize];
        }

        public Array(params T[] array) : this(array.Length)
        {
            System.Array.Copy(array, InnerList, array.Length);
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
            if (position == InnerList.Length)
                DoubleArray();

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
            if (index >= 0 && index < InnerList.Length)
            {
                InnerList[index] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }


        private void ExtendArray(int _position)
        {
            var _array = new T[_position + 1];
            System.Array.Copy(InnerList, _array, _position);
            InnerList = _array;
        }

        private void DoubleArray()
        {
            var _array = new T[InnerList.Length * 2];
            System.Array.Copy(InnerList, _array, InnerList.Length);
            InnerList = _array;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in InnerList)
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
                for (int x = _position; x < InnerList.Length; x++)
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

            else
            {
                for (int i = _position; i < InnerList.Length; i++)
                {
                    if (InnerList[i] != null)
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
            foreach (var value in source_array)
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
