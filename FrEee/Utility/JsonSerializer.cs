using FrEee.Utility.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace FrEee.Utility
{
	public class JsonSerializer
	{
		static JsonSerializer()
		{
			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
				Formatting = Formatting.Indented,
				MissingMemberHandling = MissingMemberHandling.Ignore,
				ObjectCreationHandling = ObjectCreationHandling.Auto,
				TypeNameHandling = TypeNameHandling.All,
				TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple,
				ContractResolver = new JsonContractResolver()
			};
		}

		public object? DeserializeFromString(string s)
		{
			var list = JsonConvert.DeserializeObject<List<object>>(s);
			if (list.Count == 0)
				return null;
			var first = list[0];
			if (first == null)
				return null;
			// TODO - make IData and ISimpleDataObject implement a common interface
			if (first is ISimpleDataObject f)
			{
				foreach (var item in list)
				{
					if (item is ISimpleDataObject dobj)
					{
						dobj.Context = f.Context;
						foreach (var r in dobj.SimpleData.Values.OfType<IDataReference>())
							r.Context = f.Context;
					}
					if (item is IData data)
						f.Context.Add(data.Value);
				}
			}
			foreach (var item in list.OfType<ISimpleDataObject>())
				item.InitializeValue();
			if (first is ISimpleDataObject fsdo)
				return fsdo.Value;
			if (first is IData fData)
				return fData.Value;
			return first;
		}

		public string SerializeToString(object o)
		{
			var ctx = new ObjectGraphContext();
			var kos = new List<object?>();
			var parser = new ObjectGraphParser();
			if (o == null)
			{
				// do nothing
			}
			else if (o.GetType().IsScalar())
				kos.Add(DataScalar.Create(o));
			else
			{
				Action<object> Parser_StartObject = x =>
				{
					if (!x.GetType().IsScalar())
					{
						var dobj = SimpleDataObject.Create(x, ctx);
						kos.Add(dobj);
					}
				};
				parser.StartObject += new ObjectGraphParser.ObjectDelegate(Parser_StartObject);
				parser.Parse(o);
			}
			foreach (var dobj in kos.OfType<ISimpleDataObject>())
				dobj.InitializeData(ctx);
			return JsonConvert.SerializeObject(kos);
		}


		static JsonSerializerSettings SimpleConverterSettings =  new JsonSerializerSettings
			{
				ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
				Formatting = Formatting.Indented,
				MissingMemberHandling = MissingMemberHandling.Ignore,
				ObjectCreationHandling = ObjectCreationHandling.Auto,
				TypeNameHandling = TypeNameHandling.None,
				TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple, 
				ContractResolver = new JsonContractResolver()
			};

		/// <summary>
		/// Simple Json serializer access. Use this for Script Json serialization. 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string SerializeObject(object obj)
		{
			return JsonConvert.SerializeObject(obj,SimpleConverterSettings); 
		}
		/// <summary>
		/// Simple json deserializer access. Use this for Script Json serialization. 
		/// </summary> 
		/// <typeparam name="T"></typeparam>
		/// <param name="json"></param>
		/// <returns></returns>
		public static T? DeserializeObject<T>(string json)
		{
			return JsonConvert.DeserializeObject<T>(json, SimpleConverterSettings); 
		}
	}
}
