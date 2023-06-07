using UnityEngine;

public class GroupLayout : MonoBehaviour
{
    public GameObject groupuielement;
    private void Start()
    {
        NoGroups();
        for (int i = 0; i+1 <= AdjustmentsGroups.GroupCount; i++)
        {
            var newObject = (GameObject) Instantiate(groupuielement, this.transform);
            newObject.name = AdjustmentsGroups.groupsarray[i];
        }
    }
    public void button()
    {
        var newObject = (GameObject)Instantiate(groupuielement, this.transform);
    }
    void NoGroups() 
    {
        if (AdjustmentsGroups.GroupCount == 0)
        {
            Debug.LogError("no groups were made");
        }
    }
}
