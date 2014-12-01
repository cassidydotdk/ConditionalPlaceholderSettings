using System.Linq;
using Sitecore.Data;
using Sitecore.Rules.Actions;

namespace ConditionalPlaceholderSettings.Actions
{
    public class BlockRendering<T> : RuleAction<T> where T : PlaceholderRuleContext
    {
        public ID RenderingId { get; set; }

        public BlockRendering()
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
            if (item != null && !ruleContext.BlockedRenderings.Any(i => i.ID.Equals(item.ID)))
            {
                ruleContext.BlockedRenderings.Add(item);
            }
        }
    }
}