using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4
{
    //класс Node представляет узел в двоичном дереве.
    class Node
    {
        //свойства "value" для хранения данных узла
        public int value;
        //"left" и "right" для хранения ссылок на левый и правый дочерние узлы
        public Node left;
        public Node right;

        //Конструктор класса "Node" инициализирует свойство "value" и устанавливает для свойств "left" и "right" значение null.
        public Node(int data)
        {
            value = data;
            left = null;
            right = null;
        }
    }

    //Класс "Binarytree" представляет собой двоичное дерево.
    class Binarytree
    {
        //закрытый элемент "root" является ссылкой на корневой узел дерева.
        private Node root;

        //Конструктор класса "Binarytree" инициализирует свойство "root" значением null.
        public Binarytree()
        {
            root = null;
        }
        public void Print()
        {
            PrintRecursive(root, "", NodePosition.Center);
        }
        //Это вспомогательный метод класса Binarytree, который рекурсивно выводит значения узлов в бинарном дереве.
        private void PrintRecursive(Node currentNode, string indent, NodePosition position)
        {
            //Если текущий узел не равен null, метод выводит значение текущего узла, вызывает себя рекурсивно для левого потомка,
            //а затем вызывает себя рекурсивно для правого потомка.
            if (currentNode != null)
            {
                Console.Write(indent);
                if (position == NodePosition.Left)
                {
                    Console.Write("├─");
                    indent += "│  ";
                }
                else if (position == NodePosition.Right)
                {
                    Console.Write("└─");
                    indent += "   ";
                }
                Console.WriteLine(currentNode.value);

                // Рекурсивный вызов для элементов в левой ветке
                PrintRecursive(currentNode.left, indent, NodePosition.Left);

                // Рекурсивный вызов для элементов в правой ветке
                PrintRecursive(currentNode.right, indent, NodePosition.Right);
            }
        }

        private enum NodePosition
        {
            Center,
            Left,
            Right
        }
        //Метод "Insert" используется для вставки нового значения в двоичное дерево
        public void Insert(int value)
        {
            //Если дерево пусто, создается новый узел, который устанавливается в качестве корневого.
            if (root == null)
            {
                root = new Node(value);
            }
            //Иначе вызывается метод "InsertRecursive", чтобы вставить значение в соответствующую позицию в дереве.
            else
            {
                InsertRecursive(root, value);
            }
        }

        //Вспомогательный метод, который рекурсивно вставляет значение в двоичное дерево. 
        //Он сравнивает значение с текущим значением узла и перемещается по дереву к левому или правому дочернему узлу соответственно,
        //пока не найдет нулевую позицию для вставки нового узла.
        private void InsertRecursive(Node currentNode, int value)
        {
            if (value < currentNode.value)
            {
                if (currentNode.left == null)
                {
                    currentNode.left = new Node(value);
                }
                else
                {
                    InsertRecursive(currentNode.left, value);
                }
            }
            else
            {
                if (currentNode.right == null)
                {
                    currentNode.right = new Node(value);
                }
                else
                {
                    InsertRecursive(currentNode.right, value);
                }
            }
        }

        //Метод, который возвращает количество вхождений значения в дереве.
        public int CountOccurrences(int value)
        {
            return CountOccurrencesRecursive(root, value);
        }

        //Метод, который обходит дерево и подсчитывает вхождения значения.
        //Количество увеличивается всякий раз, когда найден узел с указанным значением.
        private int CountOccurrencesRecursive(Node currentNode, int value)
        {
            if (currentNode == null)
            {
                return 0;
            }

            int count = 0;
            if (currentNode.value == value)
            {
                count = 1;
            }

            count += CountOccurrencesRecursive(currentNode.left, value);
            count += CountOccurrencesRecursive(currentNode.right, value);
            return count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Cоздает экземпляр класса "Binarytree" и предлагает пользователю ввести значения для дерева
            Binarytree tree = new Binarytree();

            Console.Write("Введите значения для дерева разделенные пробелом: ");
            string input = Console.ReadLine();
            string[] values = input.Split(' ');

            foreach (string value in values)
            {
                int num = int.Parse(value);
                tree.Insert(num);
            }
            Console.Write("Введите значение для поиска: ");
            int searchValue = int.Parse(Console.ReadLine());
            int count = tree.CountOccurrences(searchValue);

            Console.WriteLine($"Значение найдено в дереве {count} раз(а)");

            Console.WriteLine("Элементы дерева: ");
            tree.Print();
             Console.WriteLine();
        }
    }
}