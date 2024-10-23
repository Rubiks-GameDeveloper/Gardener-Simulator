using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlantItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemId;
    [SerializeField] private Button selectButton;
    public Button GetSelectButton() => selectButton;
    public void SetStartData(Item item)
    {
        var plantItem = (PlantItem)item;
        itemName.text = plantItem.name;
        itemId.text = plantItem.GetId().ToString();
    }
}
