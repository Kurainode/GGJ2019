using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryPageLoader : MonoBehaviour
{

    public TextAsset[] diaryPages;
    private int currentPage = 0;

    [Header("References")]
    public TMPro.TextMeshProUGUI diaryText;

    // Start is called before the first frame update
    void Start()
    {
        diaryText.text = diaryPages[currentPage].text;
    }

    public void NextPage()
    {
        if (currentPage < diaryPages.Length - 1)
        {
            currentPage += 1;
            diaryText.text = diaryPages[currentPage].text;
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage -= 1;
            diaryText.text = diaryPages[currentPage].text;
        }
    }
}
