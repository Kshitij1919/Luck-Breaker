using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject Upper_Boundry;
    public Grid gridData;
    public GameObject[] cellPrefab;
    public Transform gridParent;
    public int fallFrequency;


    void Start()
    {
        SpawnLevel();
        gridParent.localPosition = gridData.offset;

        //StartCoroutine(MyFunction());

    }

    private void OnEnable()
    {
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_JUMP);
        GameController.Instance.SpawnBlock += SpawnNextBlock;

    }

    private void OnDisable()
    {
        GameController.Instance.SpawnBlock -= SpawnNextBlock;

    }

    //void Update()
    //{
    //    //StartCoroutine(MyFunction());

    //    //SpawnNextBlock();


    //}

    //public IEnumerator MyFunction()
    //{
    //    //if (GameController.Instance.rollDiceCount % 4 == 0)
    //    //{

    //    //}
    //    for (int i = 0; i < gridData.gridSize.x - 3; i++)
    //    {
    //        SpawnNextBlock();
    //        yield return new WaitForSeconds(2f);
    //    }


    //}

    void SpawnLevel()
    {
        for (int y = 0; y < gridData.gridSize.y; ++y)
        {
            for (int x = 0; x < gridData.gridSize.x; ++x)
            {
                int _rnd = Random.Range(0, cellPrefab.Length);
                GameObject obj = Instantiate(cellPrefab[_rnd], gridParent, false);
                obj.transform.localPosition = new Vector2(((x*gridData.cellSize.x)+(x*gridData.gapOffset.x)), ((y * gridData.cellSize.y) + (y * gridData.gapOffset.y)));
                obj.name = "( " + x + ", " + y + " )";
                
                GameController.Instance.list.Add(obj);
            }
        }
    }

    public void SpawnNextBlock()
    {

        Upper_Boundry.SetActive(false);
        //GameObject nextBlock = (GameObject)Instantiate(Resources.Load(GetRandomBlock(), typeof(GameObject)), gridData.offset, Quaternion.identity);

        for (int y = (int)gridData.gridSize.y; y < gridData.gridSize.y + 1; ++y)
        {
            for (int x = 0; x < gridData.gridSize.x; ++x)
            {

                int _rnd = Random.Range(0, cellPrefab.Length);
                GameObject obj = Instantiate(cellPrefab[_rnd], gridParent, false);

                obj.transform.localPosition = new Vector2(((x * gridData.cellSize.x) + (x * gridData.gapOffset.x)), ((y * gridData.cellSize.y) + (y * gridData.gapOffset.y + 695)));

                obj.name = (" " + x);

                GameController.Instance.list.Add(obj);

            }
        }

        StartCoroutine("SettingActive");
    }

    IEnumerator SettingActive()
    {
        yield return new WaitForSeconds(1.2f);
        Upper_Boundry.SetActive(true);
    }

    

    //public bool IsGameOver()
    //{
    //    return GameController.Instance.list.Count > ((gridData.maxGridSize.x * gridData.maxGridSize.y) - gridData.maxGridSize.x);
    //}


    //public void SpawnNextBlock()
    //{
    //    GameObject nextBlock = (GameObject)Instantiate(Resources.Load(GetRandomBlock(), typeof(GameObject)), gridData.offset, Quaternion.identity);
    //}

    //string GetRandomBlock()
    //{
    //    int randomBlock = Random.Range(0, 1);

    //    string randomBlockName = "Prefabs/Blocks_1";

    //    switch(randomBlock)
    //    {
    //        case 1:
    //            randomBlockName = "Prefabs/Blocks_1";
    //            break;

    //        case 2:
    //            randomBlockName = "Prefabs/Blocks_2";
    //            break;

    //        //case 3:
    //        //    randomBlockName = "Blocks_3";
    //        //    break;

    //        //case 4:
    //        //    randomBlockName = "Blocks_4";
    //        //    break;

    //        //case 5:
    //        //    randomBlockName = "Blocks_5";
    //        //    break;
    //    }

    //    return randomBlockName;
    //}
}
