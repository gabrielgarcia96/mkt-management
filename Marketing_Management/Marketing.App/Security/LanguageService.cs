//namespace Marketing.App.Security
//{
//    public class LanguageService
//    {
//        public event Action? OnLanguageChanged;

//        private string _currentLanguage = "en";

//        public string CurrentLanguage
//        {
//            get => _currentLanguage;
//            set
//            {
//                if (_currentLanguage != value)
//                {
//                    _currentLanguage = value;
//                    OnLanguageChanged?.Invoke();
//                }
//            }
//        }
//    }

//}

using Microsoft.AspNetCore.Components;

namespace Marketing.App.Security
{
    public class LanguageService
    {
        public event Action? OnLanguageChanged;

        private string _currentLanguage = "en";

        public string CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    OnLanguageChanged?.Invoke();
                }
            }
        }
    }
}
