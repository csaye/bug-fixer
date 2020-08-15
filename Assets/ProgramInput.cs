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
            SelectField();
        }

        private void Update()
        {
            CheckSubmit();
        }

        public void SelectField()
        {
            inputField.ActivateInputField();
        }

        private void CheckSubmit()
        {
            if (Input.GetKeyDown("return"))
            {
                string output = ParseCommand(inputField.text);
                pastInputText.text = $"{output}\n" + pastInputText.text;
                inputField.text = "";
                inputField.ActivateInputField();
            }
        }

        private string ParseCommand(string command)
        {
            string[] words = GetWords(command);
            
            switch (words[0])
            {
                case "quit":
                    Application.Quit();
                    return "Quitting...";
                case "save":
                    return "Error: could not save.";
                case "help":
                    return "Note to self: password is 7832";
                case "7832":
                    return "Successfully saved!";
                default:
                    return "Error: unknown command.";
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
