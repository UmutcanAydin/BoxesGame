using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LangButton : MonoBehaviour
{
    public void setLanguage(int languageIndex)
    {
        StartCoroutine(LanguageSelect(languageIndex));
    }

    private IEnumerator LanguageSelect(int languageIndex)
    {
        yield return LocalizationSettings.InitializationOperation;

        int i = languageIndex;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[i];
    }
}
