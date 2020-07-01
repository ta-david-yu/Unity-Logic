using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    public interface IVarTable
    {
        IEnumerable<IVar> Vars { get; }

        Var GetVar(string key);
        void SetVar(string key, IValueType data);
    }
}
