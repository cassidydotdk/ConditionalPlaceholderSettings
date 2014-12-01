using Sitecore.Pipelines.GetPlaceholderRenderings;

namespace ConditionalPlaceholderSettings.Processors
{
    public abstract class ProcessorBase
    {
        public void Process(GetPlaceholderRenderingsArgs args)
        {
            var ruleContext = GetRuleContext(args);
            if (ruleContext != null)
            {
                Process(args, ruleContext);
            }
        }

        public abstract void Process(GetPlaceholderRenderingsArgs args, PlaceholderRuleContext ruleContext);

        protected virtual PlaceholderRuleContext GetRuleContext(GetPlaceholderRenderingsArgs args)
        {
            return args.CustomData[Constants.RuleContextKey] as PlaceholderRuleContext;
        }

        protected void SetRuleContext(GetPlaceholderRenderingsArgs args, PlaceholderRuleContext ruleContext)
        {
            args.CustomData[Constants.RuleContextKey] = ruleContext;
        }
    }
}
