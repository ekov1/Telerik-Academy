using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BuildTree.Tree
{
    public interface IGraphNode<T>
    {
        T Value { get; }

        IGraphNode<T> Parent { get; set; }

        IList<IGraphNode<T>> Children { get; }

        IGraphNode<T> AddChild(T child);

        IGraphNode<T> RemoveChild(T child);

        IGraphNode<T> AddChild(IGraphNode<T> subtree);

        IGraphNode<T> RemoveChild(IGraphNode<T> child);

        IEnumerator<IGraphNode<T>> GetEnumerator();
    }
}
