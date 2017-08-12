using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NReco.CF.Taste.Model;
using NReco.CF.Taste.Common;
using NReco.CF.Taste.Impl.Common;
using NReco.CF.Taste.Impl.Model;

using System.Data;

namespace NReco.Recommender.Examples.SqlDbSource {
	
	public class DataModelSqlLoader {

		IDbCommand SelectCmd;
		string UserIdFld;
		string ItemIdFld;
		string PrefValFld;

		public DataModelSqlLoader(IDbCommand selectCmd, string userIdField, string itemIdField, string prefValueField = null) {
			SelectCmd = selectCmd;
			UserIdFld = userIdField;
			ItemIdFld = itemIdField;
			PrefValFld = prefValueField;
		}

		public IDataModel Load() {
			var hasPrefVal = !String.IsNullOrEmpty(PrefValFld);

			FastByIDMap<IList<IPreference>> data = new FastByIDMap<IList<IPreference>>();
			using (var dbRdr = SelectCmd.ExecuteReader()) {
				while (dbRdr.Read()) {
					long userID = Convert.ToInt64(dbRdr[UserIdFld]);
					long itemID = Convert.ToInt64(dbRdr[ItemIdFld]);

					var userPrefs = data.Get(userID);
					if (userPrefs == null) {
						userPrefs = new List<IPreference>(3);
						data.Put(userID, userPrefs);
					}

					if (hasPrefVal) {
						var prefVal = Convert.ToSingle(dbRdr[PrefValFld]);
						userPrefs.Add( new GenericPreference(userID, itemID, prefVal) );
					} else {
						userPrefs.Add( new BooleanPreference(userID, itemID) );
					}
				}

			}

			var newData = new FastByIDMap<IPreferenceArray>( data.Count() );
			foreach (var entry in data.EntrySet()) {
				var prefList = (List<IPreference>) entry.Value;
				newData.Put( entry.Key, hasPrefVal ? 
					(IPreferenceArray)new GenericUserPreferenceArray(prefList) : 
					(IPreferenceArray)new BooleanUserPreferenceArray(prefList) );
			}
			return new GenericDataModel(newData);
		}

	}
}
