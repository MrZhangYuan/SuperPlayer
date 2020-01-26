using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace SuperApp.Shell.Controls
{
        public static class WpfUIHelper
        {
                public static void EnumVisual(Visual myVisual)
                {
                        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myVisual); i++)
                        {
                                // Retrieve child visual at specified index value.
                                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myVisual, i);

                                // Do processing of the child visual object.

                                // Enumerate children of the child visual object.
                                EnumVisual(childVisual);
                        }
                }

                public static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
                {
                        int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
                        for (int i = 0; i < childrenCount; i++)
                        {
                                var child = VisualTreeHelper.GetChild(parent, i);

                                var childType = child as T;
                                if (childType != null)
                                {
                                        yield return childType;
                                }

                                foreach (var other in FindVisualChildren<T>(child))
                                {
                                        yield return other;
                                }
                        }
                }

                public static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
                {
                        // get parent item
                        DependencyObject parentObject = VisualTreeHelper.GetParent(child);

                        // we’ve reached the end of the tree
                        if (parentObject == null) return null;

                        // check if the parent matches the type we’re looking for
                        T parent = parentObject as T;
                        if (parent != null)
                        {
                                return parent;
                        }
                        else
                        {
                                // use recursion to proceed with next level
                                return FindVisualParent<T>(parentObject);
                        }
                }

                /// <summary>
                /// Finds a Child of a given item in the visual tree. 
                /// </summary>
                /// <param name="parent">A direct parent of the queried item.</param>
                /// <typeparam name="T">The type of the queried item.</typeparam>
                /// <param name="childName">x:Name or Name of child. </param>
                /// <returns>The first parent item that matches the submitted type parameter. 
                /// If not matching item can be found, 
                /// a null parent is being returned.</returns>
                public static T FindChild<T>(DependencyObject parent, string childName)
                   where T : DependencyObject
                {
                        // Confirm parent and childName are valid. 
                        if (parent == null) return null;

                        T foundChild = null;

                        int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
                        for (int i = 0; i < childrenCount; i++)
                        {
                                var child = VisualTreeHelper.GetChild(parent, i);
                                // If the child is not of the request child type child
                                T childType = child as T;
                                if (childType == null)
                                {
                                        // recursively drill down the tree
                                        foundChild = FindChild<T>(child, childName);

                                        // If the child is found, break so we do not overwrite the found child. 
                                        if (foundChild != null) break;
                                }
                                else if (!string.IsNullOrEmpty(childName))
                                {
                                        var frameworkElement = child as FrameworkElement;
                                        // If the child's name is set for search
                                        if (frameworkElement != null)
                                        {
                                                if (frameworkElement.Name == childName)
                                                {
                                                        // if the child's name is of the request name
                                                        foundChild = (T)child;
                                                        break;
                                                }
                                                else
                                                {
                                                        foundChild = FindChild<T>(child, childName);
                                                        if (foundChild != null)
                                                        {
                                                                break;
                                                        }
                                                }
                                        }
                                }
                                else
                                {
                                        // child element found.
                                        foundChild = (T)child;
                                        break;
                                }
                        }

                        return foundChild;
                }
        }

}
