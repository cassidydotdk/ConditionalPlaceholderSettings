using Sitecore.Rules.Actions;

namespace ConditionalPlaceholderSettings.Actions
{
    internal class ForbidEditing<T> : RuleAction<T> where T : PlaceholderRuleContext
    {
        public override void Apply(T ruleContext)
        {
            ruleContext.IsEditable = false;
        }
    }
}