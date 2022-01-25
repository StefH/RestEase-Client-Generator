using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace RestEaseClientGeneratorBlazorApp.Components
{
    public abstract class BaseField<TValue> : ComponentBase
    {
        private TValue _value;

        [Parameter]
        public TValue Value
        {
            get => _value;

            set
            {
                if (Equals(_value, value))
                {
                    return;
                }
                _value = value;
                ValueChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }

        [Parameter]
        public Expression<Func<TValue>> For { get; set; }

        protected string Label { get; private set; }

        protected string? Tooltip { get; private set; }

        protected string PropertyName { get; private set; }

        protected override void OnParametersSet()
        {
            if (For == null)
            {
                throw new InvalidOperationException($"{GetType()} requires a value for the {nameof(For)} parameter.");
            }

            if (!(For.Body is MemberExpression memberExpression))
            {
                throw new InvalidOperationException($"{GetType()} should define a MemberExpression for the {nameof(For)} parameter.");
            }

            var property = memberExpression.Member;

            PropertyName = property.Name;

            var displayNameProperty = property.GetCustomAttribute<DisplayNameAttribute>();
            Label = displayNameProperty?.DisplayName ?? PropertyName;

            var descriptionAttribute = property.GetCustomAttribute<DescriptionAttribute>();
            Tooltip = descriptionAttribute?.Description;
        }
    }
}