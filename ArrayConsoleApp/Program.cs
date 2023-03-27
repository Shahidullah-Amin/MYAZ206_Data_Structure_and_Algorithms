

var list_1 = new System.Collections.Generic.List<string>() { "Mohammad", "Ahmad", "Mohammad", "Ibrahim", "Emran", "Omar" };
var list_2 = new Array.Generics.List<string>("Mohammad", "Mustafa", "Emre", "Amir", "Erdim", "Omar");



foreach( var item in list_1.Except(list_2))
{
    Console.WriteLine(item);
}






//var list_a = new LinkedList.SingleLinkedList<string>("Shahidullah");
//var list_b = new LinkedList.SingleLinkedList<string>("Mohammad");

//var test_variable = list_a;

//list_a = list_b;

//list_a.Value = "Test";
//Console.WriteLine(list_b.Value);


//var list_A = new List<Product>()
//{
//    new Product(){Id = 1, CompanyName="Apple", ProductName= "Iphone X pro"},
//    new Product(){Id = 2, CompanyName="Samsung", ProductName= "Samsung S20 ultra"},
//    new Product(){Id = 3, CompanyName="DELL", ProductName= "dell Core i7 12th gen"},
//    new Product(){Id = 4, CompanyName="HP", ProductName= "hp Core i7 11th gen"},
//    new Product(){Id = 5, CompanyName="Samsung", ProductName= "Samsung S22 ultra promax"},
//    new Product(){Id = 6, CompanyName="Apple", ProductName= "Apple Iphone 13 promax"}
//};



//var list_B= new List<Product>()
//{
//    new Product(){Id = 1, CompanyName="Apple", ProductName= "Iphone X pro"},
//    new Product(){Id = 2, CompanyName="Samsung", ProductName= "Samsung S20 ultra"},
//    new Product(){Id = 3, CompanyName="DELL", ProductName= "dell Core i7 12th gen"},
//    new Product(){Id = 6, CompanyName="DELL", ProductName= "dell Core i5 10th gen"}
//};



//foreach(var product in list_A)
//{
//    if(list_B.Select(pro=> pro.CompanyName).Contains(product.CompanyName))
//    {
//        Console.WriteLine(product);
//    }
//}






















//string[] names = new string[5] { "Mohammad", "Ahmad", "Emran", "Kamran", "Omar" };



//for(int x =0;  x < names.Length; x++)
//{
//    for(int i =x; i < names.Length; i++)
//    {
//        if ((int)(char)names[x][0]> (int)(char)names[i][0])
//        {
//            var temp = names[x];
//            names[x] = names[i];
//            names[i] = temp;
//        }
//    }

//}


//foreach(string name in names)
//{
//    Console.WriteLine(name);
//}









//char[] array = new char[6] { 'A', 'B', 'C', 'D', 'E','A' };



//var result = "".ToList();

//result = result.ToList();

//foreach(var item in array)
//{
//    if (!Find(item))
//    {
//        result.Add(item);
//    }
//}










//foreach(var item in result)
//{
//    Console.Write(item);
//}




















//foreach(var i  in array)
//{

//}

//string Remove(string item)
//{
//    if (Find(item))
//    {

//        int index = System.Array.IndexOf(array , item);
//        array[index] = null;

//        string[] new_array = new string[array.Length-1];

//        int count = 0;

//        foreach(var value in array)
//        {
//            if(value != null)
//            {
//                new_array[count++] = value;
//            }
//        }

//        array = new_array;
//        return item;
//    }
//    return null;
//}


//bool Find(char a )
//{
//    foreach (var item in result.ToList())
//    {
//        if(item == a) return true;
//    }
//    return false;
//}

Console.ReadKey();