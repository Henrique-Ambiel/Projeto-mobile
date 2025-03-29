using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MinCheckListSystem
{
    private GameObject minCheckList;
    private GameObject maxCheckList;

    
    public MinCheckListSystem(GameObject minCheckList)
    {
        this.minCheckList = minCheckList;
        
    }
}
public class MaxCheckListSytem
{
    private GameObject maxCheckList;

    public MaxCheckListSytem(GameObject maxCheckList)
    {
        this.maxCheckList = maxCheckList;
    }

}