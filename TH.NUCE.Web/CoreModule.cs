using DotNetNuke.Entities.Modules;
using System;
namespace TH.NUCE.Web
{
    public class CoreModule : PortalModuleBase
    {
        #region Initialization

        public CoreType GetCoreType(int typeId)
        {
            string cacheKey;
            CoreType objType;
            cacheKey = "THCore_" + typeId.ToString();
            if (Cache[cacheKey] == null)
            {
                objType = new CoreType(typeId);
                Cache.Insert(cacheKey, objType);
            }
            else
            {
                objType = (CoreType)Cache[cacheKey];
            }
            return objType;
        }

        #endregion

        /// <summary>
        /// Decide if the current user is a super user.
        /// </summary>
        /// <returns>true if the current user is a host user or an admin user.</returns>
        public bool GetSuperMode()
        {
            return this.UserInfo.IsSuperUser;
        }

        /// <summary>
        /// Load int setting
        /// </summary>
        /// <param name="strKey">setting key</param>
        /// <param name="defaultValue">the default value (usually the setting default value)</param>
        /// <returns>the setting int value</returns>
        public int LoadIntSetting(string strKey, int defaultValue)
        {
            int intResult;
            if (Settings[strKey] == null || !int.TryParse(Settings[strKey].ToString(), out intResult))
                intResult = defaultValue;
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

            if (Settings[strKey] == null)
                strResult = defaultValue;
            else strResult = Settings[strKey].ToString();

            return strResult;
        }

        public string LoadXSLSettings(string strKey, string defaultValue, bool blnDefaultXsl)
        {
            string customXsl;
            if (Settings[strKey] == null)
                customXsl = defaultValue;
            else
            {
                string xslPath = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, Settings[strKey].ToString());
                if (Settings[strKey].ToString().Length == 0 || !System.IO.File.Exists(xslPath))
                    customXsl = defaultValue;
                else
                {
                    customXsl = Settings[strKey].ToString();
                    customXsl = "~/Portals/" + this.PortalId.ToString() + "/" + customXsl;
                }
            }
            if (blnDefaultXsl)
                customXsl = defaultValue;

            return customXsl;
        }

        public string LoadXSLReplacement(string defaultValue, string replaceValue)
        {
            string customXsl;

            string xslPath = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, replaceValue);
            if (replaceValue.ToString().Length == 0 || !System.IO.File.Exists(xslPath))
                customXsl = defaultValue;
            else
            {
                string directory = "/Portals/" + this.PortalId.ToString() + "/";
                if (replaceValue.Contains(directory))
                {
                    customXsl = "~" + replaceValue;
                }
                else
                {
                    customXsl = "~/Portals/" + this.PortalId.ToString() + "/" + replaceValue;
                }

            }

            return customXsl;
        }

        /// <summary>
        /// Load bool setting
        /// </summary>
        /// <param name="strSettingKey">the setting key</param>
        /// <returns>if the setting value is found, return it, otherwise return true.</returns>
        public bool LoadBaseTrueSetting(string strSettingKey)
        {
            bool blReturnResult;
            if (Settings[strSettingKey] == null)
                blReturnResult = true;
            else
                blReturnResult = "True".Equals(Settings[strSettingKey]);
            return blReturnResult;
        }

        public DateTime LoadDateTimeSetting(string strSettingKey, string dtmDefault)
        {
            DateTime result = DateTime.Now;
            if (Settings[strSettingKey] == null || !DateTime.TryParse(Settings[strSettingKey].ToString(), out result))
            {
                result = DateTime.Parse(dtmDefault);
            }

            return result;
        }

        /// <summary>
        /// Load bool setting
        /// </summary>
        /// <param name="strSettingKey">the setting key</param>
        /// <returns>if the setting value is found, return it, otherwise return false.</returns>
        public bool LoadBaseFalseSetting(string strSettingKey)
        {
            bool blReturnResult;
            blReturnResult = "True".Equals(Settings[strSettingKey]);
            return blReturnResult;
        }
    }
}