using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatLib : MonoBehaviour
{
    public MatProfile[] materialList;
    public List<string> materialNames;

    [ContextMenu("Update name")]
    public void CreateNumberList()
    {
        materialNames = new List<string>();
        for (int i = 0; i< materialList.Length; i++)
        {
            materialNames.Add(materialList[i].name);

        }
    }
}
