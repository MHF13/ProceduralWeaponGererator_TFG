using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMod : MonoBehaviour
{

    public class BlendShape
    {
        [HideInInspector]
        public string name;
        [Range(0, 100)]
        public int weightBS;
        private int weight0;

        public BlendShape(string _name)
        {
            name = _name;
            weightBS = 0;
            weight0 = 0;
        }

        public void setW0(int set) { weight0 = set; }
        public int getW0() { return weight0; }

    }

    public BlendShape[] blendShape;
    private int numBS;

    private SkinnedMeshRenderer meshRenderer;
    public void SetNewForm(int[] newBS)
    {
        for (int i = 0; i < newBS.Length; i++)
        {
            blendShape[i].weightBS = newBS[i];
        }
        UpdateForm();
    }

    private void UpdateForm()
    {
        int[] ret = new int[numBS];
        for (int i = 0; i < numBS; i++)
        {
            meshRenderer.SetBlendShapeWeight(i, blendShape[i].weightBS);
            blendShape[i].setW0(blendShape[i].weightBS);
            ret[i] = blendShape[i].weightBS;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();

        Mesh GunMesh = meshRenderer.sharedMesh;
        numBS = GunMesh.blendShapeCount;

        blendShape = new BlendShape[numBS];

        int[] ret = new int[numBS];
        for (int i = 0; i < numBS; i++)
        {
            string newName = GunMesh.GetBlendShapeName(i);
            blendShape[i] = new BlendShape(newName);
            ret[i] = blendShape[i].weightBS;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
