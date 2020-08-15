using System.Linq;
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
                ParseCommand(inputField.text);
                pastInputText.text = $"{inputField.text}\n" + pastInputText.text;
                inputField.text = "";
                inputField.ActivateInputField();
            }
        }

        private void ParseCommand(string command)
        {
            string[] words = GetWords(command);
            
            switch (words[0])
            {
                case "quit":
                    Application.Quit();
                    break;
            }
        }

        private string[] GetWords(string command)
        {
            string[] words = command.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
            }

            return words;
        }
    }
}
