using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Tree;

class Program {

    public static void Main(string[] args) {
        TreeData();
    }

    public static void ListData()
    {
        Console.WriteLine("List data structure execution: ");

        //add-remove part
        List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        list.Add(-50);
        list.Add(-1);
        list.Add(-20);

        list.RemoveAt(0);

        //print-lambda expressions
        list.ForEach(numbers => Console.Write(numbers + " , "));

        //[ Linq ] aggregate [ Avg,Where,OrderBy/Recommended-Sorting-Way ] section
        Console.WriteLine("\nAverage: " + list.Average());

        Console.WriteLine("Filtering: " + string.Join(", ", list.Where(n => n > 0)));
        Console.WriteLine("Sorting: " + string.Join(", ", list.OrderBy(n => n > 0)));

        //Contains, Exists, Find, FindAll, Any, All
        Console.WriteLine("Is list have 80? " + list.Contains(80));
        Console.WriteLine("Is we have number greater than 20 ? " + list.Exists(n => n > 20));


        Console.WriteLine("Show first numbers that be greater than 1: " + list.Find(n => n > 1));
        Console.WriteLine("Show all numbers greater than 1: " + string.Join(", ", list.FindAll(n => n > -5)));

        Console.WriteLine("Is all items in the list that be greater than 0? " + list.All(n => n > 0) + "\n");
        Console.WriteLine("Is we have any number greater than 20 ? " + list.Any(n => n > 20));

    }
    public static void HashTableData(){
        Hashtable table = new Hashtable();// Collection-Based [ recommended to use dictionary ]
        table.Add(1,"Ahmed Al Darabee");
        table.Add(2, "Mohammed Hilal");
        table.Add(3,"Alex");

        table.Remove(3);

        foreach (DictionaryEntry tb in table){
            Console.WriteLine($"Key {tb.Key} Value {tb.Value}");
        }
    }
    public static void DictionaryData(){
        Console.WriteLine("\nDictionary Data Structure\n");
        Dictionary<string,int> dictionary = new Dictionary<string,int>(); //O(1)

        dictionary.Add("Ahmed", 1);
        dictionary.Add("Ahmed1", 11);
        dictionary.Add("Mohammed", 2);
        dictionary.Add("Ali", 3);
        dictionary.Add("Osama", 4);
        dictionary.Remove("Osama");

        var Users = dictionary.Select((info) => new {info.Key, info.Value});
        var IsExist = dictionary.Any((info) => info.Key == "Ali");

        Console.WriteLine($"Is Ali exist? {IsExist} \n Uniqueness results: ");
        foreach (var item in Users){
            Console.WriteLine($"User name: {item.Key} with ID: {item.Value}");
        }
    }
    public static void HashSetData(){
        Console.WriteLine("\nHashSet Data Structure");
        HashSet<string> hashSet = new HashSet<string>();
        hashSet.Add("Ahmed");
        hashSet.Add("Olombia");
        hashSet.Add("Ahmed");
        hashSet.Add("Mohammed");
        hashSet.Add("Ali");
        hashSet.Add("Osama");
        hashSet.Add("Othman");
        hashSet.Add("Omia");

        Console.WriteLine("\nNote: No-Indexing Support! ");
        //hashSet[1] = "";
        hashSet.Remove("Ali");
        Console.Write("\nResults:");

        var filtering = hashSet.Where(set => set.StartsWith("O"));

        foreach (var item in filtering){
            Console.Write($"{item} ");
        }

        Console.WriteLine("\nIs Ali exist in hash set? " + hashSet.Contains("Ali"));

        Console.Write("\nRemove Duplication Approach: ");
        int[] arr = new int[] { 1,2,22,3,2,4,5,5,5,9,10};
        HashSet<int> list = new HashSet<int>(arr);

        foreach (var item in list){
            Console.Write($" {item} ");
        }
        Console.WriteLine("\n\nUnion/Intersection/Differences/Symmetric more than one lists");
        
        HashSet<int> set1 = new HashSet<int>(){ 1, 2, 22, 3, 2, 4, 5, 5, 5, 9, 10,11,19 };
        HashSet<int> set2 = new HashSet<int>() { 11, 15, 15, 19, 11,4,5 };

        //set1.UnionWith(set2);
        //set1.IntersectWith(set2);
        //set1.ExceptWith(set2); - it will calculate differences between sets where if set 1 have element not exists in set 2 , it will show it
        
        set1.SymmetricExceptWith(set2); // if set 1 have elements in set 2 it will not showing it!

        Console.Write("\nUnion/Intersection/Differences/Symmetric Result: ");
        foreach (var item in set1){
            Console.Write($"{item} ");
        }

        Console.WriteLine("\n\nSo Finally, is both sets have the same data? " + set1.SetEquals(set2));
        Console.WriteLine("\nIs set 2 subset of set 1? " + set2.IsSubsetOf(set1));
        Console.WriteLine("\nIs set 2 superset of set 1? " + set2.IsSupersetOf(set1));
        Console.WriteLine("\nIs set 1 overlaps of set 1? " + set1.Overlaps(set2));

        Console.WriteLine("\n");
    }
    public static void SordListData(){
        //Binary - Searching of data and fast data retrieving, but slow data additionally
        Console.WriteLine("\nSorted List Data Structure\n");
        SortedList<int, string> list = new SortedList<int,string>(){
            {1,"One"},
            {2,"One"},
            {3,"Three"},
            {4,"One"},
            {5,"Four"},
            {6,"Three"},
            {7,"Three"},
            {8,"Three"},
        };

        list[5] = "Fifth";

        var group = list.GroupBy(lt => lt.Value);
        foreach (var lt in group){
            Console.WriteLine($"{lt.Key} repeated {lt.Count()} time.");
        }
    }
    public static void SortedSetData(){
        SortedSet<int> lt = new SortedSet<int>(); // better than sorted list!
        lt.Add(10);
        lt.Add(2);
        lt.Add(0);
        lt.Add(8);
        lt.Add(5);
        lt.Add(11);
        lt.Add(2);
        lt.Add(1);

        //lt[0] = 11; No-Indexing Supporting

        Console.Write("Sorted Result: ");
        foreach (var ls in lt){
            Console.Write($" {ls} ");
        }
    }
    public static void SortedDictionaryData() {
        //better than sorted list in custom operations !!!
        SortedDictionary<int,string> lt = new SortedDictionary<int,string>();
        lt.Add(1,"Amman");
        lt.Add(2,"Irbid");
        lt.Add(3,"Ajlon");
        lt.Add(4,"Karak");
        lt.Add(5,"Balqa");

        lt[3] = "Ajloun";

        Console.Write("Sorted Dictionary Result: ");
        foreach (var ls in lt){
            Console.Write($" ( {ls.Key},{ls.Value} ) ");
        }
    }
    public static void ObservableCollectionData(){
        ObservableCollection<string> Items = new ObservableCollection<string>();
        Items.CollectionChanged += ItemSubscriber!; // Any changes that happening in Items Object, call this subscriber

        Items.Add("Moving Test...");
        Items.Add("Test 1");
        Items.Add("Test 2");
        Items.Add("Test 3");
        Items.Add("Test 4");
        Items.Add("Test 5");
        Items.Insert(1,"Test New");
        Items.Move(0, 4);

        Console.Write("\nObservable Collection Content: ");
        for (int i = 0; i < Items.Count; i++){
            Console.Write($" {Items[i]} ");
        }
    }
    public static void ItemSubscriber(object sender, NotifyCollectionChangedEventArgs e ){
        switch (e.Action){
            case NotifyCollectionChangedAction.Add:
                Console.WriteLine("\nAdd action is happening now...");
                foreach (var item in e.NewItems!){
                    Console.WriteLine($"\t-{item}");
                }
                break;

            case NotifyCollectionChangedAction.Remove:
                Console.WriteLine("\nRemoving action is happening now...");
                foreach (var item in e.OldItems!){
                    Console.WriteLine($"\t-{item}");
                }
                break;

            case NotifyCollectionChangedAction.Replace:
                Console.WriteLine("\nReplacement action is happening now...");
                foreach (var item in e.OldItems!){
                    Console.WriteLine($"\t-{item}");
                }
                Console.WriteLine("New replacement value: ");
                foreach (var item in e.NewItems!){
                    Console.WriteLine($"\t-{item}");
                }
                break;

            case NotifyCollectionChangedAction.Move:
                Console.WriteLine("\nMoving action is happening now...");
                Console.WriteLine($"From Index {e.OldStartingIndex} to {e.NewStartingIndex}");
                break;
        }
    }
    public static void StackData(){
        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(5);
        stack.Pop();
        stack.Push(9);
        stack.Push(0);
        stack.Pop();
        stack.Pop();
        stack.Push(91);
        stack.Push(92);
        stack.Push(93);
        stack.Push(97);
        stack.Pop();

        Console.WriteLine("Last Inserted Item: " + stack.Peek());

        Console.Write("Stack Result: ");
        foreach (var item in stack){
            Console.Write($" {item} ");
        }

        Console.WriteLine("\n");
    }
    public static void QueueData(){
        Queue<int> queue = new Queue<int>();
        
        queue.Enqueue(1);
        queue.Enqueue(4);
        queue.Enqueue(8);
        queue.Enqueue(0);
        queue.Enqueue(2);

        queue.Dequeue();

        Console.WriteLine($"Queue Peek [ First Item Added ]: {queue.Peek()}");

        Console.Write("\nQueue Result: ");
        foreach (var item in queue){
            Console.Write($" {item} ");
        }
    }
    public static void LinkedListData(){
        LinkedList<int> list = new LinkedList<int>();

        //start adding data in sequence way: 1 -> 2 -> 3
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        //Also, i can added in the first location to be as :  0 -> 1 -> 2 -> 3
        list.AddFirst(0);

        Console.Write("\nHead -> ");
        foreach (var Node in list){
            Console.Write($" {Node} -> ");
        }
        Console.Write(" Null\n");

        //Now, reverse elements

        Console.Write("\nReversing Nodes: ");
        LinkedListNode<int> current = list.Last!;
        while (current != null){
            Console.Write($" {current.Value} -> ");
            current = current.Previous!;
        }
        Console.Write(" Null\n");
    }
    public static void BitArrayData(){
        BitArray bitArrOne = new BitArray(new bool[] {true,false,true,false });
        BitArray bitArrTwo = new BitArray(new bool[] {false, false, true, false });

        Console.WriteLine("1- " + BoolToBinary(bitArrOne));
        Console.WriteLine("2- " + BoolToBinary(bitArrTwo));

        Console.WriteLine("------[ AND Operation ]------");
        BitArrayOperationExecution(bitArrOne,bitArrTwo,"AND");

        Console.WriteLine("\n1- " + BoolToBinary(bitArrOne));
        Console.WriteLine("2- " + BoolToBinary(bitArrTwo));

        Console.WriteLine("------[ OR Operation ]------");
        BitArrayOperationExecution(bitArrOne, bitArrTwo, "OR");

        Console.WriteLine("\n1- " + BoolToBinary(bitArrOne));
        Console.WriteLine("2- " + BoolToBinary(bitArrTwo));

        Console.WriteLine("------[ XOR Operation ]------");
        BitArrayOperationExecution(bitArrOne, bitArrTwo, "XOR");

    }
    public static string BoolToBinary(BitArray arr){
        char[] result = new char[arr.Length];

        for (int i = 0; i < arr.Length; i++){
            result[i] = arr[i] ? '1' : '0';
        }
        return new string(result);
    }
    public static void BitArrayOperationExecution(BitArray arr1, BitArray arr2, string operation){
        BitArray handlerResult = new BitArray(arr1);
        switch (operation){
            case "AND":
                handlerResult.And(arr2);
                Console.WriteLine(BoolToBinary(handlerResult));
                break;
            case "OR":
                handlerResult.Or(arr2);
                Console.WriteLine(BoolToBinary(handlerResult));
                break;
            case "XOR":
                handlerResult.Xor(arr2);
                Console.WriteLine(BoolToBinary(handlerResult));
                break;
            default:
                Console.WriteLine("Oops, There are not operation selected");
                break;
        }
    }
    public static void JaggedArrayData(){
        //better than multi dimensional array about memory-managements
        int[][] jaggedArrayHandler = new int[3][]; 

        jaggedArrayHandler[0] = new int[]{ 1,2,3,1,1,1};
        jaggedArrayHandler[1] = new int[] { 2, 4, 4, 4, 2, 0 };
        jaggedArrayHandler[2] = new int[] { 1, 1, 0, 0, 0, 0 };

        for (int i = 0; i < jaggedArrayHandler.Length; i++){
            for (int j = 0; j < jaggedArrayHandler[i].Length; j++){
                Console.Write($" {jaggedArrayHandler[i][j]} ");
            }
            Console.WriteLine();
        }
    }
    public static void TupleData(){
        //that used when you want to return multi-data with difference type at the same time

        (int, string, double) person = (1,"Ahmed Al Darabee",25.6);

        Console.WriteLine("Person Info: ");
        Console.WriteLine("\nId: " + person.Item1);
        Console.WriteLine("Name: " + person.Item2);
        Console.WriteLine("Grade: " + person.Item3 + " / 30.0");
    }

    public static void TreeData(){
        var companyTree         = new Tree<string>("CEO");
        var financeDepartment   = new Node<string>("CFO");
        var technicalDepartment = new Node<string>("CTO");
        var marketingDepartment = new Node<string>("CMO");

        companyTree.Root.AddChildren(financeDepartment);
        companyTree.Root.AddChildren(technicalDepartment);
        companyTree.Root.AddChildren(marketingDepartment);

        financeDepartment.AddChildren(new Node<string>("Accounting Department"));
        
        technicalDepartment.AddChildren(new Node<string>("Software Engineering Department"));
        technicalDepartment.AddChildren(new Node<string>("Software Testing Department"));
        technicalDepartment.AddChildren(new Node<string>("Software Designing Department"));
        technicalDepartment.AddChildren(new Node<string>("Software Deployment Department"));

        marketingDepartment.AddChildren(new Node<string>("Social Media Department"));
        marketingDepartment.AddChildren(new Node<string>("Sales Department"));

        companyTree.ReplaceNode("Accounting Department", "Finance Department");
        companyTree.ReplaceNode("Sooftware Deployment Department", "DevOps Department");
        
        companyTree.FindNode("Software Deployment Department");
        companyTree.RemoveNode("Saales Department");
        
        Console.WriteLine("\nTree after all operation: \n");
        companyTree.DisplayTree();
    }
}