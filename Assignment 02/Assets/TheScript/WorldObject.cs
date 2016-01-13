using UnityEngine;
using System.Collections.Generic;

public class WorldObject : MonoBehaviour
{
    struct OBJ
    {
        public Vector2 pos;
        public Vector2 size;

        public OBJ(Vector2 pos, Vector2 size)
        {
            this.pos = pos;
            this.size = size;
        }
    }

    public Texture2D tree;
    private List<OBJ> OBJList = new List<OBJ>();

	// Use this for initialization
	void Start ()
    {
        for(int a = 0; a < 100; ++a)
        {
            Vector2 pos = new Vector2(a * tree.width, a * tree.height);
            pos.y *= -1;
            Vector2 size = new Vector2(100, 100);

            OBJ obj = new OBJ(pos, size);
            OBJList.Add(obj);
        }
	}


    void OnGUI()
    {
        foreach(OBJ obj in OBJList)
        {
            Graphics.DrawTexture(new Rect(obj.pos, obj.size), tree);
        }
    }
}
