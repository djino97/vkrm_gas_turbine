using System.Collections.Generic;
using UnityEngine;

public class DismantlingDetail
{
    public Material defaultMaterialDetail;

    private Stack<string> disassemblyStack;
    private Stack<List<object>> invertedDisassemblyStack;

    private GameObject detail;

    public DismantlingDetail(string testDetail)
    {
        SequentialInstruction sequentialInstruction = new SequentialInstruction();
        invertedDisassemblyStack = new Stack<List<object>>();

        sequentialInstruction.GetInstruction(testDetail);
        disassemblyStack = sequentialInstruction.disassemblyStack;
    }

    public string GetNameDisassembledDetailGTU()
    {
        string nameDetail;

        nameDetail = disassemblyStack.Pop();
        detail = GameObject.Find(nameDetail);

        return nameDetail;
    }

    public void SaveCoordinatesDetailGTU(string nameDetail)
    {
        Vector3 detailPosition;

        detailPosition = GetCoordinatesDetail();
        invertedDisassemblyStack.Push(new List<object> { nameDetail, detailPosition });
    }

    private Vector3 GetCoordinatesDetail()
    {
        return detail.transform.localPosition;
    }

    public void SaveMaterialDetail()
    {
        if (detail.transform.childCount != 0)
            defaultMaterialDetail = detail.GetComponentInChildren<MeshRenderer>().material;
        else
            defaultMaterialDetail = detail.GetComponent<MeshRenderer>().material;
    }

    public void DetailHighlighing(GameObject detail, Material fade, float duration = 7.0f)
    {
        detail.GetComponent<MeshRenderer>().material = fade;
        detail.GetComponent<MeshRenderer>().material.SetFloat("_Outline", Mathf.PingPong(Time.time * 6, duration) * 2);
    }

    public void ChildeDetailHighlighing(GameObject childe, Material fade, float duration = 7.0f)
    {

        childe.GetComponent<MeshRenderer>().material = fade;
        childe.GetComponent<MeshRenderer>().material.SetFloat("_Outline", Mathf.PingPong(Time.time * 6, duration) * 2);
    }

    public void PutDefaultMaterialToTheDetail()
    {
        if (detail.transform.childCount != 0)
        {
            foreach (Transform childe in detail.transform)
                childe.GetComponent<MeshRenderer>().material = defaultMaterialDetail;
        }
        else
            detail.GetComponent<MeshRenderer>().material = defaultMaterialDetail;
    }

    public bool GetBooleanFinalPositionDetail()
    {
        Debug.Log(detail.transform.position.y);
        return detail.transform.position.y <= 4.2;
    }
}