using System.Collections;

namespace Tests
{
    public class ArrayTests
    {


        private Array.Array _array;

        public ArrayTests()
        {
            _array = new Array.Array(1, 2, 4, 5);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(16)]
        [InlineData(32)]
        public void ArrayTest01(int defaultSize)
        {
            var array = new Array.Array(defaultSize);

            Assert.Equal(defaultSize, array.Length);
        }


        [Fact]
        public void ArrayTestParamsConstructor()
        {
            var array = new Array.Array(1, 2, 3, 4, 5, 6, 7);


            Assert.Equal(7, array.Length);
        }

        [Fact]
        public void Array_Get_Set_Value_Test()
        {
            var array = new Array.Array();

            array.Add(10);
            array.Add(20);
            array.Add(4);
            array.Add(5);
            array.Add(6);


            Assert.Equal(10, array.GetValue(0));
            Assert.Equal(20, array.GetValue(1));
            Assert.Equal(array.Length, 8);


        }

        [Fact]
        public void Cloneable_Attribute()
        {
            var array = new Array.Array(12, 34, 54, 3);

            var clonedArray = array.Clone() as Array.Array;


            Assert.Equal(array, clonedArray);
            Assert.Equal(array.Length, clonedArray.Length);
        }

        [Fact]
        public void EnumeratorArrayTest()
        {
            var array = new Array.Array(1, 2, 3, 4);
            string stringArray = "";

            for (int x = 0; x < array.Length; x++)
            {
                if (x == 0)
                {
                    stringArray += "{" + array.GetValue(x);
                }
                else if (x == array.Length - 1)
                {
                    stringArray += ", " + array.GetValue(x) + "}";
                }
                else
                {
                    stringArray += ", " + array.GetValue(x);
                }

            }
            Assert.Equal("{1, 2, 3, 4}", stringArray);
        }



        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(16)]
        public void ArrayConstructorTest(int arraySize)
        {
            var array = new Array.Array(arraySize);

            Assert.Equal(arraySize, array.Length);
        }



        [Fact]
        public void Array_Double_Array_Test()
        {
            // Length = 2
            var array = new Array.Array();

            array.Add(1);
            array.Add(2);
            array.Add(3);

            Assert.Equal(array.Length, 4);
            Assert.Equal(array.GetValue(0), 1);
            Assert.Equal(array.GetValue(1), 2);
            Assert.Equal(array.GetValue(2), 3);
        }

        [Fact]
        public void Array_Extended_Array_Test()
        {

            _array.Add(6);
            _array.Add(7);
            _array.Add(8);

            Assert.Equal(_array.Length, 7);
            Assert.Equal(_array.GetValue(6), 8);
        }

        [Fact]
        public void Array_Remove_with_Argument()
        {
            var array = new Array.Array(1, 12, 3, 4, 9, 5, 4, 5);



            array.Remove(1);
            array.Remove(12);
            array.Remove(3);
            array.Remove(4);
            array.Add(16);

            string numbers = "";

            foreach (var item in array)
            {
                numbers += item;
            }
            Assert.Equal(array.GetValue(0), 9);
            Assert.Equal(array.GetValue(4), 16);
            Assert.Equal(array.Length, 5);
            Assert.Equal(numbers, "954516");

        }

        [Fact]
        public void Array_Find_Function()
        {
            var array = new Array.Array(12, 3, 4, 54, 4);

            Object a1 = 1;
            Object a2 = 1;

            Assert.Equal(a1, a2);
        }

        [Fact]
        public void Array_Take_function_Test_with_Remove()
        {
            var array = new Array.Array();

            array.Add("Mohammad");
            array.Add("Ahmad");
            array.Add("Mustafa");
            array.Add("Omar");
            array.Add("Emran");

            array.Remove("Emran");
            array.Remove("Mohammad");
            array.Add("Ibrahim");

            string array_string = "";

            foreach (var name in array)
            {
                array_string += name + "_";
            }


            Assert.Equal("Ahmad_Mustafa_Omar_Ibrahim_", array_string);
            Assert.Equal(array.GetValue(0), "Ahmad");
            Assert.Equal(array.GetValue(3), "Ibrahim");
            Assert.Equal(array.Length, 8);
        }


        [Fact]
        public void IEnumerable_Constructor_Test()
        {
            List<string> names = new List<string>(){ "Mohammad", "Ahmad", "Ali", "Mustafa", "Emran" };



            var array = new Array.Array(names);

            var string_names = "";

            foreach(var name in array)
            {
                string_names += name+"_";
            }

            Assert.Equal("Mohammad_Ahmad_Ali_Mustafa_Emran_", string_names);
            Assert.Equal(array.GetValue(4), "Emran");
            Assert.Equal(array.Length, 8);
        }

        [Fact]
        public void Test_IndexOf_function()
        {
            var array = new Array.Array("Emran", "Mustafa","Kamran");


            Assert.Equal(array.IndexOf("Mustafa") , 1);
        }


        [Fact]
        public void AddFirst_Function_Test()
        {
            var array = new Array.Array( "c", "d","e");


            array.AddFirst("b");
            array.AddFirst("a");

            string letters = "";

            foreach(var item in array)
            {
                letters += item;
            }

            Assert.Equal("abcde", letters);
        }

    }
}