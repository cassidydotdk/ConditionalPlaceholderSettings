using Sitecore.Pipelines.GetPlaceholderRenderings;

namespace ConditionalPlaceholderSettings.Processors
{
    public class ApplyEditableFlag : ProcessorBase
    {
        public override void Process(GetPlaceholderRenderingsArgs args, PlaceholderRuleContext ruleContext)
        {
            if (!ruleContext.IsEditable)
            {
                args.HasPlaceholderSettings = false;
                args.PlaceholderRenderings = null;
            }
        }
    }
}