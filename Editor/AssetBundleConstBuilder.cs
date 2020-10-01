﻿using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AssetBundleConst
{
    public static class AssetBundleConstBuilder
    {
        private const string HEADER_COMMENT = 
            "//-----------------------------------------------------------------------------//" + "\n"+
            "// This code is automatically generated by AssetBundleConstBuilder." + "\n"+
            "// Do not edit manually, but press the [Generate Const String Source] button " +
            "// in the Inspector of AssetbundleBuildSettings to generate it." + "\n"+
            "//-----------------------------------------------------------------------------//" + "\n";

        private const string NAMESPACE_HEADER = 
            "namespace AssetBundleConst" + "\n" +
            "{" + "\n";

        private const string CLASSNAME_BASE_HEADER = 
            "\t"+"public class ABConst_{0}" + "\n" +
            "\t{{" + "\n";
        
        private const string ASSETBUNDLE_NAME = "\t\t"+"public const string ASSETBUNDLE_NAME = \"{0}\";" + "\n";

        private const string ASSETBUNDLE_ASSET_KEY = "\t\t"+"public const string {0} = \"{1}\";" + "\n";

        private const string CLASSNAME_BASE_FOOTER = 
            "\t}" + "\n";
        
        private const string NAMESPACE_FOOTER = 
            "}" + "\n";

        static string ChangeToKeyString(string keyValue)
        {
            return keyValue.Replace(' ','.').Replace('/','.').Replace('.','_').ToUpper();
        }
        public static string CreateConstString(List<AssetBundleBuild> bundleList)
        {
            var strBuilder = new StringBuilder();

            strBuilder.Append(HEADER_COMMENT);
            strBuilder.AppendLine();
            strBuilder.Append(NAMESPACE_HEADER);
            strBuilder.AppendLine();

            for (int n = 0; n < bundleList.Count; ++n)
            {
                strBuilder.Append(string.Format(CLASSNAME_BASE_HEADER,bundleList[n].assetBundleName));
                strBuilder.Append(string.Format(ASSETBUNDLE_NAME,bundleList[n].assetBundleName));
                for (int key = 0; key < bundleList[n].addressableNames.Length; ++key)
                {
                    strBuilder.Append(string.Format(ASSETBUNDLE_ASSET_KEY,ChangeToKeyString(bundleList[n].addressableNames[key]),bundleList[n].addressableNames[key]));
                }
                strBuilder.Append(CLASSNAME_BASE_FOOTER);
            }
            
            strBuilder.Append(NAMESPACE_FOOTER);
            strBuilder.AppendLine();
            return strBuilder.ToString();
        }
    }
}
