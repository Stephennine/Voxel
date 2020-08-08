using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 存储SBB的树结构
/// </summary>
public class TreeNode<T> 
{
    private T Tdata;
    private List<TreeNode<T>> nodes;
    public T Data
    {
        get
        {
            return Tdata;
        }
        set
        {
            Tdata = value;
        }
    }
    public List<TreeNode<T>> ChildNodes
    {
        get
        {
            //if (nodes.Count == 0) return null;
             return nodes;
        }
        set
        {
            nodes = value;
        }
    }
    public TreeNode(T data, List<TreeNode<T>> ns)
    {
        Tdata = data;
        nodes = ns;
    }
    public TreeNode(T data)
    {
        Tdata = data;
        nodes = new List<TreeNode<T>>();
    }
    public TreeNode()
    {
        Tdata = default;
        nodes = new List<TreeNode<T>>();
    }
    //public SBB GetCollidedSBB()
    //{
    //    //没有子节点，说明这个节点是最后的节点
    //    if(nodes.Count==0)
    //    {
    //        return Tdata;
    //    }
    //    foreach (var item in nodes)
    //    {

    //    }
    //}
    
}
