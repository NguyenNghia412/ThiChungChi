using DotNetNuke.Entities.Modules;
using System;
using System.Web.UI.WebControls;

namespace TH.NUCE.Web
{
    public class CoreModuleSettings : ModuleSettingsBase
    {
        public CoreModuleSettings()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Get the selected int value from a combobox. if cannot found the selected value, return the default value.
        /// </summary>
        /// <param name="cboList">The combo box</param>
        /// <param name="intDefaultValue">The default value</param>
        /// <returns>The selected value.</returns>
        public int GetIntFromCboBox(DropDownList cboList, int intDefaultValue)
        {
            int intResult = -1;
            if (cboList.SelectedValue == null || !int.TryParse(cboList.SelectedValue, out intResult))
                intResult = intDefaultValue;
            return intResult;
        }

        /// <summary>
        /// Load string setting
        /// </summary>
        /// <param name="strKey">setting key</param>
        /// <param name="defaultValue">the default value (usually the setting default value)</param>
        /// <returns>the setting string value</returns>
        public string LoadStringSetting(string strKey, string defaultValue)
        {
            string strResult;

            if (ModuleSettings[strKey] == null)
                strResult = defaultValue;
            else strResult = ModuleSettings[strKey].ToString();

            return strResult;
        }

        /// <summary>
        /// Load int setting
        /// </summary>
        /// <param name="strKey">setting key</param>
        /// <param name="defaultValue">the default value (usually the setting default value)</param>
        /// <returns>the setting int value</returns>
        public int LoadIntSetting(string strSettingKey, int intDefaultValue)
        {
            int intReturnResult;
            if (ModuleSettings[strSettingKey] == null || !int.TryParse(ModuleSettings[strSettingKey].ToString(), out intReturnResult))
                intReturnResult = intDefaultValue;
            return intReturnResult;
        }

        /// <summary>
        /// Load bool setting
        /// </summary>
        /// <param name="strSettingKey">the setting key</param>
        /// <returns>if the setting value is found, return it, otherwise return true.</returns>
        public bool LoadBaseTrueSetting(string strSettingKey)
        {
            bool blReturnResult;
            if (ModuleSettings[strSettingKey] == null)
                blReturnResult = true;
            else
                blReturnResult = "True".Equals(ModuleSettings[strSettingKey]);
            return blReturnResult;
        }

        /// <summary>
        /// Load Dateime setting
        /// </summary>
        /// <param name="strSettingKey">the setting key</param>
        /// <param name="dtmSettingDefault">The default value</param>
        /// <returns></returns>
        public DateTime LoadDateTimeSetting(string strSettingKey, DateTime dtmSettingDefault)
        {
            DateTime dtm;
            if (ModuleSettings[strSettingKey] == null || !DateTime.TryParse(ModuleSettings[strSettingKey].ToString(), out dtm))
            {
                dtm = dtmSettingDefault;
            }
            return dtm;

        }

        /// <summary>
        /// Load bool setting
        /// </summary>
        /// <param name="strSettingKey">the setting key</param>
        /// <returns>if the setting value is found, return it, otherwise return false.</returns>
        public bool LoadBaseFalseSetting(string strSettingKey)
        {
            bool blReturnResult;
            blReturnResult = "True".Equals(ModuleSettings[strSettingKey]);
            return blReturnResult;
        }
    }
}