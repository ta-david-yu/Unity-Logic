using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    public interface IVarTable
    {
        IEnumerable<IVar> Variables { get; }

        Var GetVar(string key);
        void SetVar(string key, IValueType data);

        void AddVar(string key, Type type);
    }
}
