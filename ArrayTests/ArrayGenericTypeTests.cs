using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ArrayGenericTypeTests
    {

        [Fact]
        public void GenericArray_Params_Constructor_Test()
        {
            var array = new Array.Array<int>(1,2,3,4,5,6,7);

            Assert.Equal(7,array.Length);
        }

        [Fact]
        public void IEnumerableGenericTest()
        {
            var array = new Array.Array<int>(1,2,3,4,5,6);




            string result = "";

            foreach(var item in array)
            {
                result += item;
            }

            Assert.Equal(result, "123456");
        }


        [Fact]
        public void GenericArray_Add_Function_Test()
        {
            var array = new Array.Array<int>();

            array.Add(1);
            array.Add(2);
            array.Add(3);


            Assert.Equal(array.Length, 4);
        }

    }
}
