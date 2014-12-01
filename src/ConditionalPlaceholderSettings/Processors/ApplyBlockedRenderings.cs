using System.Linq;
using Sitecore.Data.Comparers;
using Sitecore.Pipelines.GetPlaceholderRenderings;

namespace ConditionalPlaceholderSettings.Processors
{
    public class ApplyBlockedRenderings : ProcessorBase
    {
        public override void Process(GetPlaceholderRenderingsArgs args, PlaceholderRuleContext ruleContext)
        {
            if (args.PlaceholderRenderings == null || ruleContext.BlockedRenderings.Count == 0 || !ruleContext.IsEditable)
            {
                return;
            }

            var comparer = new ItemIdComparer();
            args.PlaceholderRenderings.RemoveAll(i => ruleContext.BlockedRenderings.Contains(i, comparer));
        }
    }
}