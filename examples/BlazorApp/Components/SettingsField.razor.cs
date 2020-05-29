using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components
{
    public partial class SettingsField<TValue>
    {
        [Parameter]
        public Expression<Func<TValue>> For { get; set; }

        private MemberExpression _expression;

        protected override void OnParametersSet()
        {
            if (For == null)
            {
                throw new InvalidOperationException($"{GetType()} requires a value for the {nameof(For)} parameter.");
            }

            if (!(For.Body is MemberExpression))
            {
                throw new InvalidOperationException($"{GetType()} should define a MemberExpression for the {nameof(For)} parameter.");
            }

            _expression = (MemberExpression)For.Body;
        }

        private string GetLabelText()
        {
            var property = _expression.Member;

            var displayProperty = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            return displayProperty?.Name ?? property.Name;
        }

        private Type GetPropertyType()
        {
            return _expression.Type;
        }

        private object GetValue()
        {
            return null;
        }
    }
}