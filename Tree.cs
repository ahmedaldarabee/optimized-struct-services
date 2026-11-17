using System.Xml.Linq;

namespace Tree {
    public class Node<T> {
        public T Data { get; set; }
        public List<Node<T>> Children { get; set; }
        //List<Node<T>>: The idea behind this section is to identify the addresses of the nodes, whether they represent the parent or the child, each possessing the same characteristics as the primary parent.
        
        public Node(T data){
            this.Data = data;
            this.Children = new List<Node<T>>();
        }

        public void AddChildren(Node<T> node){
            this.Children.Add(node);
        }

        public bool RemoveChildren(T node){
            //Is the value exist among the direct child of this node?
            var targetNode = this.Children.FirstOrDefault((child) => EqualityComparer<T>.Default.Equals(child.Data, node));
            
            if (targetNode != null){
                this.Children.Remove(targetNode);
                return true;
            }

            foreach (var child in this.Children){
                var isRemoved = child.RemoveChildren(node);
                if (isRemoved){
                    return true;
                }
            }

            return false;
        }

        public bool Replace(T oldNode, T newNode){

            if(newNode == null){
                return false;
            }

            var target = this.Children.FirstOrDefault(c => EqualityComparer<T>.Default.Equals(c.Data, oldNode));

            if (target != null){
                target.Data = newNode;
                return true;
            }

            foreach (var child in this.Children){
                var isReplaced = child.Replace(oldNode, newNode);
                if (isReplaced == true){
                    return true;
                }
            }

            return false;
        }

        public Node<T> Find(T value){
            //[ EqualityComparer<T>.Default.Equals ] safely compare generic values without depending on the '==' operator, which may fail for certain types.
            if (EqualityComparer<T>.Default.Equals(this.Data, value)){
                return this;//that mean it will return full object reference with owned child and data from memory
            }

            foreach (var child in this.Children){
                var isFound = child.Find(value);//here, [ this  result ] it will stored in isFound!

                if(isFound != null){
                    return isFound;
                }
            }

            return null!;
        }

        
    }

    public class Tree<T> {
        public Node<T> Root { get; private set; }
        public Tree(T root){
            this.Root = new Node<T>(root);
        }

        public void DisplayTree(){
            DisplayTree(this.Root);
        }

        public void FindNode(T Value){
            var isExist = this.Root?.Find(Value)!;
            
            if (isExist != null){
                Console.WriteLine($"\n[ {Value} ] is exist");
            }
            else{
                Console.WriteLine($"\nOops, there are no node called : {Value}");
            }
        }
        public void ReplaceNode(T exist, T newValue){
            var isFound = this.Root?.Find(exist)!;
            
            if (isFound == null){
                Console.WriteLine($"\nOops, there are no node called : {exist}");
                return;
            }

            var isExist = this.Root?.Replace(exist, newValue);

            if (isExist != null){
                Console.WriteLine($"\n[ {exist} ] replaced with {newValue} successfully");
            }
        }

        public void RemoveNode(T Value){
            if (EqualityComparer<T>.Default.Equals(this.Root.Data, Value)){
                Console.WriteLine("\n[ Error ] Cannot remove the Root node directly!");
                return;
            }

            var isRemoved = this.Root.RemoveChildren(Value);

            if (isRemoved){
                Console.WriteLine($"\n[ {Value} ] is removed successfully");
            }
            else{
                Console.WriteLine($"\nOops, there are no node called : {Value}");
            }
        }

        private void DisplayTree(Node<T> node, string intent = ""){
            Console.WriteLine(intent + "- "+ node.Data);
            foreach (var key in node.Children){
                DisplayTree(key, intent + " | ");
            }
        }
    }
}