using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.Message
{
	public class WeakReferenceManager
	{
		private static Dictionary<string, WeakReference> _references = new Dictionary<string, WeakReference>();

		public static void AddReference(string referenceName, object data)
		{
			_references[referenceName] = new WeakReference(data);
		}

		public static object GetReference(string referenceName)
		{
			if (_references.ContainsKey(referenceName) && _references[referenceName].IsAlive)
			{
				return _references[referenceName].Target;
			}
			return null;
		}
	}
}