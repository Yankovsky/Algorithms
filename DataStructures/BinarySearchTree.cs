using System.Collections.Generic;

namespace DataStructures
{
    public class BinarySearchTree
    {
        private BinarySearchTree _right;
        private BinarySearchTree _left;
        private int? _data;

        private BinarySearchTree(int data)
        {
            _data = data;
        }

        public BinarySearchTree(IEnumerable<int> list)
        {
            foreach (var element in list)
                Insert(element);
        }

        public void Insert(int newData)
        {
            if (_data == null)
                _data = newData;
            else
            {
                if (newData <= _data)
                    if (_left != null)
                        _left.Insert(newData);
                    else
                        _left = new BinarySearchTree(newData);
                else
                    if (_right != null)
                        _right.Insert(newData);
                    else
                        _right = new BinarySearchTree(newData);
            }
        }

        public IList<int> Traversal(TraversalOrder traversalOrder = TraversalOrder.Straight)
        {
            var list = new List<int>();
            if (traversalOrder == TraversalOrder.Straight)
            {
                if (_left != null)
                    list.AddRange(_left.Traversal());
                list.Add(_data.Value);
                if (_right != null)
                    list.AddRange(_right.Traversal());
            }
            else if (traversalOrder == TraversalOrder.Reverse)
            {
                if (_left != null)
                    list.AddRange(_left.Traversal());
                list.Add(_data.Value);
                if (_right != null)
                    list.AddRange(_right.Traversal());
            }
            return list;
        }
    }

    public enum TraversalOrder
    {
        Straight,
        Reverse
    }
}
