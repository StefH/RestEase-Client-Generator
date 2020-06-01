﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace RestEaseClientGeneratorBlazorApp.Components
{
    public abstract class BaseField<TValue> : ComponentBase
    {
        [Parameter]
        public TValue Value { get; set; }

        [Parameter]
        public Expression<Func<TValue>> For { get; set; }

        protected string Label { get; private set; }

        protected string? Tooltip { get; private set; }

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

            var expression = (MemberExpression)For.Body;
            var property = expression.Member;

            var displayNameProperty = property.GetCustomAttribute<DisplayNameAttribute>();
            Label = displayNameProperty?.DisplayName ?? property.Name;

            var displayProperty = property.GetCustomAttribute<DescriptionAttribute>();
            Tooltip = displayProperty?.Description;
        }
    }
}