using Array.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class GenericListTests
    {

        [Fact]
        public void ListDefaultConstructorTest()
        {
            var list = new Array.Generics.List<string>();


            Assert.Equal(list.Length, 4);
            Assert.Equal(list.Count, 0);
        }

        [Fact]
        public void ListParamsConstructorTest()
        {
            var list = new Array.Generics.List<int>(1,2,4,2,5);

            Assert.Equal(list.Length, 5);
            Assert.Equal(4, list.GetValue(2));
            Assert.Equal(5, list.Count);

            //Assert.Collection<int>(list,

            //    item => Assert.Equal(1, item),
            //    item => Assert.Equal(2, item),
            //    item => Assert.Equal(4, item),
            //    item => Assert.Equal(2, item),
            //    item => Assert.Equal(5, item)
            //    );
        }

        [Fact]
        public void List_Add_Function_Test()
        {
            var list = new Array.Generics.List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Assert.Equal(list.GetValue(0),1);
            Assert.Equal(list.GetValue(1),2);
            Assert.Equal(list.GetValue(2),3);
            Assert.Equal(list.GetValue(3),4);

            Assert.Equal(list.Length, 4);

            list.Add(5);

            Assert.Equal(list.Length,8);

        }

        [Fact]
        public void List_Add_Function_with_Params_Const()
        {

            var list = new Array.Generics.List<int>(1, 2, 3, 4, 5);

            list.Add(6);

            Assert.Equal(list.GetValue(5), 6);

        }

        [Fact]
        public void Remove_Function_Test()
        {
            var list = new Array.Generics.List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Remove(5);
            list.Remove(2);
            list.Add(6);
            list.Add(8);
            list.Add(10);
            list.Remove(8);
            list.Remove(1);
            list.Add(11);

            Assert.Equal(list.Length, 8);
            
            Assert.Equal(list.GetValue(0), 3);
            Assert.Equal(list.GetValue(1), 4);
            Assert.Equal(list.GetValue(2), 6);
            Assert.Equal(list.GetValue(3), 10);
            Assert.Equal(list.GetValue(4), 11);

            list.Remove(4);

            Assert.Equal(list.Length, 4);

            Assert.Collection<int>(list,

                item => Assert.Equal(3, item),
                item => Assert.Equal(6, item),
                item => Assert.Equal(10, item),
                item => Assert.Equal(11, item));



        }

        [Fact]
        public void IEnumerable_T_Test()
        {
            var list = new Array.Generics.List<string>("Mohammad","Omar", "Kamran","Ibrahim", "Mustafa");
            int i = 0;

            foreach(var item in list)
            {
                Assert.Equal(item, list.GetValue(i));
                i++;
            }
        }

        [Fact]
        public void AddFirst_Function_Test()
        {
            var list = new Array.Generics.List<string>();

            list.AddFirst("Mustafa");
            list.AddFirst("Emran");
            list.AddFirst("Kamran");
            list.AddFirst("Ibrahim");
            list.AddFirst("Mohammad");

            Assert.Collection<string>(list,
                item => Assert.Equal(list.GetValue(0), "Mohammad"),
                item => Assert.Equal(list.GetValue(1), item),
                item => Assert.Equal(list.GetValue(2), item),
                item => Assert.Equal(list.GetValue(3), item),
                item => Assert.Equal(list.GetValue(4), "Mustafa"));
        }

        [Fact]
        public void IndexOf_Function_Test()
        {
            var list = new Array.Generics.List<string>();

            list.AddFirst("Mustafa");
            list.AddFirst("Emran");
            list.AddFirst("Kamran");
            list.AddFirst("Ibrahim");
            list.AddFirst("Mohammad");

            Assert.Equal(list.IndexOf("Kamran"), 2);
        }

        [Fact]
        public void Intersect_Function_Test()
        {
            var list_1 = new System.Collections.Generic.List<string>(){ "Mohammad","Ahmad", "Mohammad","Ibrahim","Emran","Omar"};
            var list_2 = new Array.Generics.List<string>("Mohammad", "Mustafa", "Emre", "Amir","Erdim","Omar");

            string[] intersected_list = list_2.Intersect(list_1);

            Assert.Equal(intersected_list[0], "Mohammad");
            Assert.Equal(intersected_list[1], "Omar");
        }

        [Fact]
        public void Union_Function_Test()
        {
            var list_1 = new System.Collections.Generic.List<string>() { "Mohammad", "Ahmad", "Mohammad", "Ibrahim", "Emran", "Omar" };
            var list_2 = new Array.Generics.List<string>("Mohammad", "Mustafa", "Emre", "Amir", "Erdim", "Omar");

            string[] intersected_list = list_2.Union(list_1);

            Assert.Collection<string>(intersected_list,
                item=>Assert.Equal(item , "Mohammad"),
                item=>Assert.Equal(item , "Ahmad"),
                item=>Assert.Equal(item , "Ibrahim"),
                item=>Assert.Equal(item , "Emran"),
                item=>Assert.Equal(item , "Omar"),
                item=>Assert.Equal(item , "Mustafa"),
                item=>Assert.Equal(item , "Emre"),
                item=>Assert.Equal(item , "Amir"),
                item=>Assert.Equal(item , "Erdim"),
                item=>Assert.Equal(item , null),
                item=>Assert.Equal(item , null),
                item=>Assert.Equal(item , null)
                );
        }



    }
}
