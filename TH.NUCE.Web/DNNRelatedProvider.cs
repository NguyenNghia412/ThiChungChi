using DotNetNuke.Entities.Users;
using DotNetNuke.Security.Roles;
using DotNetNuke.Services.FileSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH.NUCE.Web
{
    public sealed class DNNRelatedProvider
    {
        public static bool GetIsSuperMode(UserInfo objUserInfor)
        {
            RoleController objRoleController = new RoleController();
            string[] strRoles;
            bool isAdmin = false;
            int i;

            strRoles = objRoleController.GetRolesByUser(objUserInfor.UserID, objUserInfor.PortalID);
            for (i = 0; i < strRoles.Length; i++)
            {
                if (strRoles[i] == "Administrators")
                {
                    isAdmin = true;
                    break;
                }
            }
            if (isAdmin || objUserInfor.IsSuperUser)
                return true;
            else
                return false;
        }

        public static string GetFilePath(string strFile, int portalId)
        {
            if (strFile != "")
            {
                FileController objFileController = new FileController();
                DotNetNuke.Services.FileSystem.FileInfo objXSLFile = objFileController.GetFileById(int.Parse(strFile.Replace("FileID=", "")), portalId);
                return string.Format("{0}{1}", objXSLFile.Folder, objXSLFile.FileName);
            }
            else
            {
                return "";
            }
        }

        public static string GetFileID(string fileUrl, int portalId)
        {
            if (fileUrl != "")
            {
                FileController objFileController = new FileController();
                int intFileID = objFileController.ConvertFilePathToFileId(string.Format("{0}", fileUrl), portalId);
                return string.Format("FileID={0}", intFileID);
            }
            else
            {
                return "";
            }
        }

        public static string GetProcessedPortalAlias(string portalAlias)
        {
            try
            {
                return portalAlias.Replace("http://", "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetJoinedArrayRoles(string[] strArr, string limiter, int portalId)
        {
            Array.Sort(strArr);
            string strBatch = limiter;
            RoleController objRC = new RoleController();
            RoleInfo objRI;
            int i;
            for (i = 0; i < strArr.Length; i++)
            {
                objRI = objRC.GetRoleByName(portalId, strArr[i]);
                strBatch = strBatch + objRI.RoleID.ToString() + limiter;
            }

            if (strBatch == limiter)
                strBatch = "";

            if (strBatch.StartsWith(limiter))
                strBatch = strBatch.Remove(0, 1);

            if (strBatch.EndsWith(limiter))
                strBatch = strBatch.Remove((strBatch.Length - 1), 1);

            return strBatch;
        }

        public static string GetJoinedArrayRoles(int userId, string limiter, int portalId)
        {
            RoleController objRC = new RoleController();
            RoleInfo objRI;

            ArrayList objList = objRC.GetUserRoles(portalId, userId, true);

            string strBatch = limiter;
            string[] strArray = new string[objList.Count];
            int i;
            for (i = 0; i < objList.Count; i++)
            {
                objRI = (RoleInfo)objList[i];
                strArray[i] = objRI.RoleID.ToString();
            }
            Array.Sort(strArray);
            for (i = 0; i < strArray.Length; i++)
            {
                strBatch = strBatch + strArray[i] + limiter;
            }
            if (strBatch == limiter)
                strBatch = "";

            if (strBatch.StartsWith(limiter))
                strBatch = strBatch.Remove(0, 1);

            if (strBatch.EndsWith(limiter))
                strBatch = strBatch.Remove((strBatch.Length - 1), 1);

            return strBatch;
        }
    }
}