﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blish_HUD.Strings.GameServices.Modules {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RepoAndPkgManagement {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RepoAndPkgManagement() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Blish_HUD.Strings.GameServices.Modules.RepoAndPkgManagement", typeof(RepoAndPkgManagement).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A newer version of this module is available..
        /// </summary>
        internal static string PkgRepo_PackageRelationship_CanUpdate {
            get {
                return ResourceManager.GetString("PkgRepo_PackageRelationship_CanUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This module is installed and up to date..
        /// </summary>
        internal static string PkgRepo_PackageRelationship_CurrentVersion {
            get {
                return ResourceManager.GetString("PkgRepo_PackageRelationship_CurrentVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only Show Installed Modules.
        /// </summary>
        internal static string PkgRepo_ProviderExtraOption_FilterInstalledModules {
            get {
                return ResourceManager.GetString("PkgRepo_ProviderExtraOption_FilterInstalledModules", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only Show Modules With Updates.
        /// </summary>
        internal static string PkgRepo_ProviderExtraOption_FilterModulesWithUpdates {
            get {
                return ResourceManager.GetString("PkgRepo_ProviderExtraOption_FilterModulesWithUpdates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only Show Modules Not Installed.
        /// </summary>
        internal static string PkgRepo_ProviderExtraOption_FilterNotInstalledModules {
            get {
                return ResourceManager.GetString("PkgRepo_ProviderExtraOption_FilterNotInstalledModules", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only Show Supported Versions.
        /// </summary>
        internal static string PkgRepo_ProviderExtraOption_FilterSupportedVersions {
            get {
                return ResourceManager.GetString("PkgRepo_ProviderExtraOption_FilterSupportedVersions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Force Reload Repository.
        /// </summary>
        internal static string PkgRepo_ProviderExtraOption_ReloadRepository {
            get {
                return ResourceManager.GetString("PkgRepo_ProviderExtraOption_ReloadRepository", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Module Repo.
        /// </summary>
        internal static string PkgRepoSection {
            get {
                return ResourceManager.GetString("PkgRepoSection", resourceCulture);
            }
        }
    }
}
