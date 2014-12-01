using Sitecore.Rules.Conditions;

namespace ConditionalPlaceholderSettings.Conditions
{
    public class PlaceholderKey<T> : StringOperatorCondition<T> where T : PlaceholderRuleContext
    {
        public string Value { get; set; }

        protected override bool Execute(T ruleContext)
        {
            return Compare(ruleContext.PlaceholderKey, Value ?? string.Empty);
        }
    }
}