using TMPro;
using UnityEngine;

namespace BugFixer
{
    public class ProgramInput : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI pastInputText = null;

        private TMP_InputField inputField;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
            inputField.ActivateInputField();
        }

        private void Update()
        {
            CheckSubmit();
        }

        private void CheckSubmit()
        {
            if (Input.GetKeyDown("return"))
            {
                pastInputText.text = $"{inputField.text}\n" + pastInputText.text;
                inputField.text = "";
                inputField.ActivateInputField();
            }
        }
    }
}
