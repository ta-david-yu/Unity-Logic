using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace DYLogic
{
    [CustomPropertyDrawer(typeof(TableVarReferenceBase), true)]
    [CustomPropertyDrawer(typeof(FilterVarTableTypeAttribute))]
    public class FilteredTableVarReferenceDrawer : TableVarReferenceDrawer
    {
        protected override IEnumerable<string> getListOfVarKeys(IVarTable table)
        {
            var filteredTypes = (attribute as FilterVarTableTypeAttribute).FilterTypes;
            return table.Vars.Where((ivar) => filteredTypes.Contains(ivar.Data.GetType())).Select((ivar) => ivar.Key);
        }
    }
}

