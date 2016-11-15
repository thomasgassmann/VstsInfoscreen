namespace System.Linq
{
    using Collections.Generic;
    using System;

    /// <summary>
    /// Contains all <see cref="IEnumerable{T}"/> extensions.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Gets all nodes of a tree like structure.
        /// </summary>
        /// <typeparam name="T">The type of the tree.</typeparam>
        /// <param name="rootNode">The root node to extend.</param>
        /// <param name="childrenSelector">The children selector.</param>
        /// <returns>Returns all childrens recursively.</returns>
        public static IEnumerable<T> Descendants<T>(this T rootNode, Func<T, IEnumerable<T>> childrenSelector)
        {
            var nodes = new Stack<T>(new[] { rootNode });
            while (nodes.Any())
            {
                var node = nodes.Pop();
                yield return node;
                foreach (var subNode in childrenSelector(node) ?? new List<T>())
                {
                    nodes.Push(subNode);
                }
            }
        }
    }
}