using System.Linq;
using Sitecore.Data;
using Sitecore.Rules.Actions;

namespace ConditionalPlaceholderSettings.Actions
{
    public class AddRendering<T> : RuleAction<T> where T : PlaceholderRuleContext
    {
        public ID RenderingId { get; set; }

        public AddRendering()
        {
            RenderingId = ID.Null;
        }

        public override void Apply(T ruleContext)
        {
            if (ID.IsNullOrEmpty(RenderingId))
            {
                return;
            }

            var item = ruleContext.ContentDatabase.GetItem(RenderingId);
            if (item != null && !ruleContext.AllowedRenderings.Any(i => i.ID.Equals(item.ID)))
            {
                ruleContext.AllowedRenderings.Add(item);
            }
        }
    }
}