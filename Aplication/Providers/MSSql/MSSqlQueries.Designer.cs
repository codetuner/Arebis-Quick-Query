﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Arebis.QuickQueryBuilder.Providers.MSSql {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class MSSqlQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MSSqlQueries() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Arebis.QuickQueryBuilder.Providers.MSSql.MSSqlQueries", typeof(MSSqlQueries).Assembly);
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
        ///   Looks up a localized string similar to SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE FROM [INFORMATION_SCHEMA].[COLUMNS]
        ///WHERE TABLE_SCHEMA = @Schema AND TABLE_NAME = @Table
        ///ORDER BY 1.
        /// </summary>
        internal static string RetrieveColumns {
            get {
                return ResourceManager.GetString("RetrieveColumns", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select user + &apos;@&apos; + @@servername.
        /// </summary>
        internal static string RetrieveConnectionName {
            get {
                return ResourceManager.GetString("RetrieveConnectionName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///   KCU1.TABLE_SCHEMA + &apos;.&apos; + KCU1.TABLE_NAME + &apos; (via &apos; + KCU1.CONSTRAINT_SCHEMA + &apos;.&apos; + KCU1.CONSTRAINT_NAME + &apos;)&apos;,
        ///   KCU1.CONSTRAINT_CATALOG AS &apos;CONSTRAINT_CATALOG&apos;,
        ///   KCU1.CONSTRAINT_SCHEMA + &apos;.&apos; + KCU1.CONSTRAINT_NAME AS &apos;CONSTRAINT_NAME&apos;,
        ///   KCU1.TABLE_CATALOG AS &apos;TABLE_CATALOG&apos;,
        ///   KCU1.TABLE_SCHEMA + &apos;.&apos; + KCU1.TABLE_NAME AS &apos;TABLE_NAME&apos;,
        ///   KCU1.COLUMN_NAME AS &apos;COLUMN_NAME&apos;,
        ///   KCU1.ORDINAL_POSITION AS &apos;ORDINAL_POSITION&apos;,
        ///   KCU2.CONSTRAINT_CATALOG AS &apos;UNIQUE_CONSTRAINT_CATALOG&apos;,
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RetrieveRelations {
            get {
                return ResourceManager.GetString("RetrieveRelations", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///   KCU2.TABLE_SCHEMA + &apos;.&apos; + KCU2.TABLE_NAME + &apos; (via &apos; + KCU1.CONSTRAINT_SCHEMA + &apos;.&apos; + KCU1.CONSTRAINT_NAME + &apos;)&apos;,
        ///   KCU1.CONSTRAINT_CATALOG AS &apos;CONSTRAINT_CATALOG&apos;,
        ///   KCU1.CONSTRAINT_SCHEMA + &apos;.&apos; + KCU1.CONSTRAINT_NAME AS &apos;CONSTRAINT_NAME&apos;,
        ///   KCU1.TABLE_CATALOG AS &apos;TABLE_CATALOG&apos;,
        ///   KCU1.TABLE_SCHEMA + &apos;.&apos; + KCU1.TABLE_NAME AS &apos;TABLE_NAME&apos;,
        ///   KCU1.COLUMN_NAME AS &apos;COLUMN_NAME&apos;,
        ///   KCU1.ORDINAL_POSITION AS &apos;ORDINAL_POSITION&apos;,
        ///   KCU2.CONSTRAINT_CATALOG AS &apos;UNIQUE_CONSTRAINT_CATALOG&apos;,
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RetrieveReverseRelations {
            get {
                return ResourceManager.GetString("RetrieveReverseRelations", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT DISTINCT NAME FROM [MASTER].[SYS].[DATABASES] WHERE HAS_DBACCESS(NAME)=1 ORDER BY 1.
        /// </summary>
        internal static string RetrieveSchemas {
            get {
                return ResourceManager.GetString("RetrieveSchemas", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TABLE_SCHEMA + &apos;.&apos; + TABLE_NAME, TABLE_TYPE FROM [INFORMATION_SCHEMA].[TABLES] ORDER BY 1.
        /// </summary>
        internal static string RetrieveTables {
            get {
                return ResourceManager.GetString("RetrieveTables", resourceCulture);
            }
        }
    }
}
