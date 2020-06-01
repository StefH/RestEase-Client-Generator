using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using RestEaseClientGenerator.Settings;

namespace BlazorApp.Components
{
    public partial class SettingsField
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public object Value { get; set; }

        public bool ValueAsBool
        {
            get => Value as bool? ?? false;
            set => Value = value; //Convert.ChangeType(value, typeof(TValue));
        }

        public string ValueAsString
        {
            get => Value as string ?? string.Empty;
            set => Value = value;
        }

        [Parameter]
        public Expression<Func<object>> For { get; set; }

        private MemberExpression _expression;

        protected override void OnParametersSet()
        {
            if (For == null)
            {
                throw new InvalidOperationException($"{GetType()} requires a value for the {nameof(For)} parameter.");
            }

            Trace.WriteLine(For.ToString());
            Trace.WriteLine(For.Body?.ToString());

            if (!(For.Body is MemberExpression))
            {
                throw new InvalidOperationException($"{GetType()} should define a MemberExpression for the {nameof(For)} parameter.");
            }

            _expression = (MemberExpression)For.Body;
        }

        private string GetLabelText()
        {
            var property = _expression.Member;

            var displayProperty = property.GetCustomAttribute<DisplayAttribute>();
            return displayProperty?.Name ?? property.Name;
        }

        private string? GetTooltip()
        {
            var property = _expression.Member;

            var displayProperty = property.GetCustomAttribute<DescriptionAttribute>();
            return displayProperty?.Description;
        }

        private Type GetPropertyType()
        {
            return _expression.Type;
        }
    }
}