using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public Button[] selectionButtons;
    public Transform currentSelection;
    public Transform whatWasSelected;


    private void Start()
    {
        currentSelection.GetComponent<Drag>().enabled = true;
    }

    public void Activate(Button button)
    {
        foreach (Button btn in selectionButtons)
        {
            btn.interactable = true;
        }
        button.interactable = false;

        whatWasSelected = currentSelection;
        currentSelection = button.GetComponent<SelectionButton>().square.transform;

        whatWasSelected.GetComponent<Drag>().enabled = false;
        currentSelection.GetComponent<Drag>().enabled = true;

        whatWasSelected.GetComponent<Line>().EndLine();
    }
}
