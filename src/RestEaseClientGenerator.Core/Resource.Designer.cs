﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestEaseClientGenerator.Core {
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
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RestEaseClientGenerator.Core.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to http://central.maven.org/maven2/org/openapitools/openapi-generator-cli/4.1.2/openapi-generator-cli-4.1.2.jar.
        /// </summary>
        internal static string OpenApiGenerator_DownloadUrl {
            get {
                return ResourceManager.GetString("OpenApiGenerator_DownloadUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 45F0AEDA24983AC998878C4D8516CF48.
        /// </summary>
        internal static string OpenApiGenerator_MD5 {
            get {
                return ResourceManager.GetString("OpenApiGenerator_MD5", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://repo1.maven.org/maven2/io/swagger/codegen/v3/swagger-codegen-cli/3.0.11/swagger-codegen-cli-3.0.11.jar.
        /// </summary>
        internal static string SwaggerCodegenCli_DownloadUrl {
            get {
                return ResourceManager.GetString("SwaggerCodegenCli_DownloadUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 89E1C5F578CC0B7A5D430CDF8210AC44.
        /// </summary>
        internal static string SwaggerCodegenCli_MD5 {
            get {
                return ResourceManager.GetString("SwaggerCodegenCli_MD5", resourceCulture);
            }
        }
    }
}