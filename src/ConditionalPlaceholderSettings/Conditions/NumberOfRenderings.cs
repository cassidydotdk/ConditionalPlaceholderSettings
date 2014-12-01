using System;
using System.Linq;
using Sitecore.Rules.Conditions;

namespace ConditionalPlaceholderSettings.Conditions
{
    internal class NumberOfRenderings<T> : IntegerComparisonCondition<T> where T : PlaceholderRuleContext
    {
        protected override bool Execute(T ruleContext)
        {
            var item = ruleContext.Item;
            var comparer = StringComparer.OrdinalIgnoreCase;
            var renderings = item.Visualization.GetRenderings(ruleContext.Device, false);

            var renderingCount = renderings.Count(r =>
                comparer.Equals(r.Placeholder, ruleContext.PlaceholderKey) ||
                comparer.Equals(r.Placeholder, ruleContext.FullPlaceholderKey));


            return Compare(renderingCount);
        }
    }
}