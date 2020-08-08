using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Runtime.InteropServices;

public class CollisionDetect : MonoBehaviour
{
    private TreeNode<SBB> head_obj;//头结点，最大的bounding box
    private PenSphere head_pen;//运动物体的头结点
    public GameObject Pen;
    // Start is called before the first frame update
    void Start()
    {
        SBB headSbb = new SBB(new Vector3(-0.186f, 0, -0.286f), 1.8f / 2);

        SBB childSbb1 = new SBB(Vector3.zero, 1 / 2);
        TreeNode<SBB> childtree1 = new TreeNode<SBB>(childSbb1);
        SBB childSbb2 = new SBB(new Vector3(0, 0, -0.3f), 1.2f / 2);
        TreeNode<SBB> childtree2 = new TreeNode<SBB>(childSbb2);
        SBB childSbb3 = new SBB(new Vector3(-0.4f, 0, 0), 1 / 2);
        TreeNode<SBB> childtree3 = new TreeNode<SBB>(childSbb3);
        SBB childSbb4 = new SBB(new Vector3(-0.4f, 0.1f, -0.6f), 0.8f / 2);
        TreeNode<SBB> childtree4 = new TreeNode<SBB>(childSbb4);
        List<TreeNode<SBB>> treeNodes = new List<TreeNode<SBB>>
        {
            childtree1,
            childtree2,
            childtree3,
            childtree4
        };
        head_obj = new TreeNode<SBB>(headSbb, treeNodes);
        Vector gtt = ToVector(Pen.transform.position, Vector3.zero);
        var trans = Pen.GetComponentsInChildren<Transform>();
        List<SBB> penspheresbb = new List<SBB>();
        int i = 0;
        foreach (var item in trans)
        {
            i++;
            if (i == 1) continue;//第一个为自己，删除
            SBB pensphere = new SBB(item.localPosition, item.localScale.x / 2);
            Debug.Log(pensphere.Center.ToString() + " " + pensphere.Radius);
            penspheresbb.Add(pensphere);
        }
        head_pen = new PenSphere(gtt, penspheresbb);
    }
    Vector3 direction;
    // Update is called once per frame
    void Update()
    {
        Vector gtt = ToVector(Pen.transform.position, Vector3.zero);
        head_pen.Gtt = gtt;
        List<SBB> penSBB = head_pen.GetSBB();//获取运动工具的SBB

        direction = Vector3.zero;
        foreach (var pensbb in penSBB)
        {
            TreeNodeCollison(pensbb, head_obj);           
        }
    }
    public bool IsCollision(SBB tool,SBB obj)
    {
        float x_dif = tool.Center.x - obj.Center.x;
        float y_dif = tool.Center.y - obj.Center.y;
        float z_dif = tool.Center.z - obj.Center.z;
        float r_t = tool.Radius + obj.Radius;

        if(x_dif*x_dif+y_dif*y_dif+z_dif*z_dif<r_t*r_t)
        {
            return true;
        }
        return false;
    }
    public void TreeNodeCollison(SBB penSBB ,TreeNode<SBB> treeNode)
    {
        
        if (penSBB.IsCollied(treeNode.Data))//碰撞了，才能执行子节点的碰撞检测
        {
            if(treeNode.ChildNodes.Count==0)//说明是最后一个节点，可以计算力觉
            {
                direction += penSBB.IsColliedVec(treeNode.Data);//力觉方向
               // Debug.Log(direction.ToString());
            }
            else
            {
                var treechildnodes = treeNode.ChildNodes;
                foreach (var childnode in treechildnodes)
                {
                    TreeNodeCollison(penSBB, childnode);
                }
            }
        }
    }
    private Vector ToVector(Vector3 pos, Vector3 euler)
    {
        Vector vec = DenseVector.Create(6, 0);
        for (int i = 0; i < 3; i++)
        {
            vec[i] = pos[i];
            vec[i + 3] = euler[i];
        }
        return vec;
    }
    private void OnGUI()
    {
        GUIStyle gui_style = new GUIStyle();
        gui_style.fontSize = 15;
        GUI.Label(new Rect(20, 50, 200, 100), direction.ToString("F4"), gui_style);
    }
}
