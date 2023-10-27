using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundContoller : MonoBehaviour
{
    Material M_B;
    Material M_M;
    Material M_T;

    [SerializeField] float Bottom_Speed;
    [SerializeField] float Middle_Speed;
    [SerializeField] float Top_Speed;

    GameObject GroundCategori;

    private void Awake()
    {
        GroundCategori = GameObject.Find("BackGround");

        Transform TR_B = GroundCategori.transform.GetChild(0);
        Transform TR_M = GroundCategori.transform.GetChild(1);
        Transform TR_T = GroundCategori.transform.GetChild(2);

        SpriteRenderer SP_B = TR_B.GetComponent<SpriteRenderer>();
        SpriteRenderer SP_M = TR_M.GetComponent<SpriteRenderer>();
        SpriteRenderer SP_T = TR_T.GetComponent<SpriteRenderer>();

        M_B = SP_B.material;
        M_M = SP_M.material;
        M_T = SP_T.material;

    }
    

   
    void Update()
    {
        Vector2 VEC_B = M_B.mainTextureOffset;
        Vector2 VEC_M = M_M.mainTextureOffset;
        Vector2 VEC_T = M_T.mainTextureOffset;

        VEC_B.y = Mathf.Repeat(VEC_B.y, 1f);
        VEC_M.y = Mathf.Repeat(VEC_M.y, 1f);
        VEC_T.y = Mathf.Repeat(VEC_T.y, 1f);

        VEC_B += new Vector2(0, Bottom_Speed * Time.deltaTime);
        VEC_M += new Vector2(0, Middle_Speed * Time.deltaTime);
        VEC_T += new Vector2(0, Top_Speed * Time.deltaTime);

        M_B.mainTextureOffset = VEC_B;
        M_M.mainTextureOffset = VEC_M;
        M_T.mainTextureOffset = VEC_T;


    }
}
