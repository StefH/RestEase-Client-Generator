using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using RestEaseClientGenerator.Extensions;

namespace RestEaseClientGeneratorBlazorApp.Components
{
    public abstract class BaseEnumField<TEnumValue> : BaseField<TEnumValue>
    {
        public Dictionary<TEnumValue, string> Values { get; } = new Dictionary<TEnumValue, string>();

        [Parameter]
        public EventCallback<TEnumValue> Changed { get; set; }

        protected BaseEnumField()
        {
            foreach (TEnumValue @enum in Enum.GetValues(typeof(TEnumValue)))
            {
                Values.Add(@enum, (@enum as Enum).GetDescription());
            }
        }

        void OnCheckedValueChanged(string value)
        {
           // checkedValue = value;
        }
    }
}