using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Comparers;
using Sitecore.Data.Items;
using Sitecore.Pipelines.GetPlaceholderRenderings;

namespace ConditionalPlaceholderSettings.Processors
{
    public class ApplyAllowedRenderings : ProcessorBase
    {
        public override void Process(GetPlaceholderRenderingsArgs args, PlaceholderRuleContext ruleContext)
        {
            if (ruleContext.AllowedRenderings.Count == 0 && !ruleContext.IsEditable)
            {
                return;
            }

            var itemIdComparer = new ItemIdComparer();
            args.PlaceholderRenderings = args.PlaceholderRenderings ?? new List<Item>();

            foreach (var allowedRendering in ruleContext.AllowedRenderings)
            {
                if (!args.PlaceholderRenderings.Contains(allowedRendering, itemIdComparer))
                {
                    args.PlaceholderRenderings.Add(allowedRendering);
                }
            }
        }
    }
}