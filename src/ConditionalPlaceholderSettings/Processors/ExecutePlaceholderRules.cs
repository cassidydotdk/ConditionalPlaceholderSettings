using System;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Pipelines.GetPlaceholderRenderings;
using Sitecore.Rules;

namespace ConditionalPlaceholderSettings.Processors
{
    public class ExecutePlaceholderRules : ProcessorBase
    {
        public string FolderId { get; set; }

        public override void Process(GetPlaceholderRenderingsArgs args, PlaceholderRuleContext ruleContext)
        {
            var rules = CreateRuleList(args);

            using (new DeviceSwitcher(ruleContext.Device))
            using (new ContextItemSwitcher(ruleContext.Item))
            {
                rules.Run(ruleContext);
            }

            SetRuleContext(args, ruleContext);
        }

        protected RuleList<PlaceholderRuleContext> CreateRuleList(GetPlaceholderRenderingsArgs args)
        {
            var ruleFolder = args.ContentDatabase.GetItem(FolderId);

            if (ruleFolder == null)
            {
                throw new InvalidOperationException("Placeholder settings rule folder could not be found.");
            }

            return RuleFactory.GetRules<PlaceholderRuleContext>(ruleFolder, "Rule");
        }

        protected override PlaceholderRuleContext GetRuleContext(GetPlaceholderRenderingsArgs args)
        {
            return new PlaceholderRuleContext(args);
        }
    }
}