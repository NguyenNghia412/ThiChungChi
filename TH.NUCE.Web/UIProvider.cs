using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.FileSystem;
using System.Collections;
using System.Web.UI.WebControls;

namespace TH.NUCE.Web
{
    public sealed class UIProvider
    {

        #region Web Control Tools

        /// <summary>
        /// This function will return a combo box binded with the information of a portal's folder set.
        /// </summary>
        /// <param name="cbBoxToBind">The control to bind</param>
        /// <param name="portalId">The portal to search</param>
        /// <returns>The binded combobox</returns>
        public static DropDownList GetFolderBindedComboBox(DropDownList cbBoxToBind, int portalId)
        {
            ArrayList arrFolders = FileSystemUtils.GetFolders(portalId);
            foreach (FolderInfo objFolder in arrFolders)
            {
                ListItem objFolderItem = new ListItem();
                if (objFolder.FolderPath.Length == 0)
                    objFolderItem.Text = "Root";
                else
                {
                    objFolderItem.Text = objFolder.FolderPath;
                }
                objFolderItem.Value = objFolder.FolderPath;
                cbBoxToBind.Items.Add(objFolderItem);
            }
            return cbBoxToBind;
        }

        /// <summary>
        /// This function will return a string that hold the selected value of a list box.
        /// </summary>
        /// <param name="strStart">The delimit can be used.</param>
        /// <param name="listBox">The list box that needs to get value.</param>
        /// <returns>The process string</returns>
        public static string GetListBoxSelectedItems(string strStart, ListBox listBox)
        {
            string strItems = strStart;
            foreach (ListItem objItem in listBox.Items)
            {
                if (objItem.Selected == true)
                {
                    strItems = strItems + objItem.Value + strStart;
                }
            }
            if (strItems == strStart)
            {
                strItems = "";
            }
            return strItems;
        }

        /// <summary>
        /// This function will return a string that hold the selected value of a list box.
        /// </summary>
        /// <param name="strStart">The delimit can be used.</param>
        /// <param name="listBox">The list box that needs to get value.</param>
        /// <returns>The process string</returns>
        public static string GetListBoxSelectedItems(string strStart, CheckBoxList listBox)
        {
            string strItems = strStart;
            foreach (ListItem objItem in listBox.Items)
            {
                if (objItem.Selected == true)
                {
                    strItems = strItems + objItem.Value + strStart;
                }
            }
            if (strItems == strStart)
            {
                strItems = "";
            }
            return strItems;
        }

        /// <summary>
        /// This function will return a string that hold the unselected value of a list box.
        /// </summary>
        /// <param name="strStart">The delimit can be used.</param>
        /// <param name="listBox">The list box that needs to get value.</param>
        /// <returns>The process string</returns>
        public static string GetListBoxUnselectedItems(string strLimiter, ListBox listBox)
        {
            string strItems = strLimiter;
            foreach (ListItem objItem in listBox.Items)
            {
                if (objItem.Selected == false)
                {
                    strItems = strItems + objItem.Value + strLimiter;
                }
            }
            if (strItems == strLimiter)
            {
                strItems = "";
            }
            return strItems;
        }

        /// <summary>
        /// This function will return a string that hold the items of a list box.
        /// </summary>
        /// <param name="strStart">The delimit can be used.</param>
        /// <param name="listBox">The list box that needs to get value.</param>
        /// <returns>The process string</returns>
        public static string GetListBoxItems(string strLimiter, ListBox listBox)
        {
            string strItems = strLimiter;
            foreach (ListItem objItem in listBox.Items)
            {
                strItems = strItems + objItem.Value + strLimiter;
            }
            if (strItems == strLimiter)
            {
                strItems = "";
            }
            return strItems;
        }

        public static void BindListBox(CheckBoxList cboList, string strToBind)
        {
            foreach (ListItem objItem in cboList.Items)
            {
                if (strToBind.Contains("," + objItem.Value.ToString() + ","))
                {
                    objItem.Selected = true;
                }
            }
        }

        public static void BindCboBox(DropDownList cboBox, string strValue)
        {
            cboBox.ClearSelection();
            foreach (ListItem objItem in cboBox.Items)
            {
                if (strValue == objItem.Value.ToString())
                {
                    objItem.Selected = true;
                    break;
                }
            }
        }


        public static int GetIntFromCboBox(DropDownList cboBox, int altValue)
        {
            int result;
            string value = cboBox.SelectedValue;
            if (!int.TryParse(value, out result))
                result = altValue;
            return result;

        }
        #endregion
    }
}