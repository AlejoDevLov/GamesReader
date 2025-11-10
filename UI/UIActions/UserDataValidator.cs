namespace GamesReader.UI.UIActions
{
    public class UserDataValidator
    {
        private readonly IEnumerable<string> _validFileNames;
        private readonly IUI _ui;

        public UserDataValidator(IEnumerable<string> validFileNames, IUI ui)
        {
            _validFileNames = validFileNames;
            _ui = ui;
        }

        public bool CheckIfFileNameExists(string fileName)
        {
            return _validFileNames.Contains(fileName.ToLower());
        }

        public bool ValidateInput(string input)
        {
            if (input is null)
            {
                _ui.PrintLine("File name cannot be null.");
                return false;
            }
            else if (input.Trim() == string.Empty)
            {
                _ui.PrintLine("File name cannot be empty.");
                return false;
            }
            else if (!CheckIfFileNameExists(input))
            {
                _ui.PrintLine("File not found.");
                return false;
            }
            else
            {
                return CheckIfFileNameExists(input);
            }
        }
    }
}