﻿namespace Fonlow.CodeDom.Web
{
	public class CodeGenSettingsBase
	{
		public CodeGenConfig ApiSelections { get; set; }
	}

	/// <summary>
	/// What CodeGenController is expecting 
	/// </summary>
	public class CodeGenSettings : CodeGenSettingsBase
	{
		public CodeGenOutputs ClientApiOutputs { get; set; }
	}

	/// <summary>
	/// For cherry picking APIs and data models 
	/// </summary>
	public class CodeGenConfig
	{
		public string[] ExcludedControllerNames { get; set; }

		/// <summary>
		/// Assembly names without file extension
		/// </summary>
		public string[] DataModelAssemblyNames
		{ get; set; }

		/// <summary>
		/// Cherry picking methods of POCO classes
		/// </summary>
		public int? CherryPickingMethods { get; set; }

	}

	/// <summary>
	/// Client APIs as output for C#, jQuery and NG etc.
	/// </summary>
	public class CodeGenOutputs
	{
		/// <summary>
		/// Assuming the client API project is the sibling of Web API project. Relative path to the WebApi project should be fine.
		/// </summary>
		public string ClientLibraryProjectFolderName { get; set; }

		/// <summary>
		/// For .NET client, generate both async and sync functions for each Web API function
		/// </summary>
		public bool GenerateBothAsyncAndSync { get; set; }

		/// <summary>
		/// Whether the Web API return string as string, rather than JSON object which is a double quoted string.
		/// </summary>
		public bool StringAsString { get; set; }

		/// <summary>
		/// Whether to conform to the camel casing convention of javascript and JSON.
		/// If not defined, WebApiClientGen will check if GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver is Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver;
		/// If CamelCasePropertyNamesContractResolver is presented, camelCasing will be used. If not, no camelCasing transformation will be used.
		/// </summary>
		public bool? CamelCase { get; set; }

		public string CSClientNamespaceSuffix { get; set; } = ".Client";

		public JSPlugin[] Plugins { get; set; }
	}

	/// <summary>
	/// A DTO class, not part of the CodeGen.json 
	/// </summary>
	public class JSOutput : CodeGenSettingsBase
	{
		/// <summary>
		/// Whether to conform to the camel casing convention of javascript and JSON.
		/// If not defined, WebApiClientGen will check if GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver is Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver;
		/// If CamelCasePropertyNamesContractResolver is presented, camelCasing will be used. If not, no camelCasing transformation will be used.
		/// </summary>
		public bool? CamelCase { get; set; }

		public string JSPath { get; set; }

		public bool AsModule { get; set; }

		///// <summary>
		///// HTTP content type used in POST of HTTP of NG2. so text/plain could be used to avoid preflight in CORS.
		///// </summary>
		public string ContentType { get; set; }

		public bool StringAsString { get; set; }

		public string ClientNamespaceSuffix { get; set; } = ".Client";
	}

	public class JSPlugin
	{
		public string AssemblyName { get; set; }

		public string TargetDir { get; set; }

		public string TSFile { get; set; }

		///// <summary>
		///// HTTP content type used in POST of HTTP of NG2. so text/plain could be used to avoid preflight in CORS.
		///// </summary>
		public string ContentType { get; set; }

		/// <summary>
		/// True to have "export namespace"; false to have "namespace". jQuery wants "namespace".
		/// </summary>
		public bool AsModule { get; set; }

		public string ClientNamespaceSuffix { get; set; } = ".Client";
	}
}
