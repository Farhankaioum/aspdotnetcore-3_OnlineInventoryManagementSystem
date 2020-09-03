using System;
using System.Collections.Generic;
using System.Text;

namespace XYZ.InventoryManagementSystem.Data
{
    public interface ISqlServerDataProvider<T>
    {
        (IList<T> result, int total, int totalDisplay) GetData(string procedureName, IList<(string key, object value, bool isOut)> parameters);
    }
}
