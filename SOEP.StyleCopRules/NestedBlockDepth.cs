using StyleCop;
using StyleCop.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEP.StyleCopRules
{
    [SourceAnalyzer(typeof(CsParser))]
    public class NestedBlockDepth : SourceAnalyzer
    {
        public readonly static string MaximumNestedBlockDepthSettingName = "MaximumNestedBlockDepth";
        private readonly static int MaximumNestedBlockDepthDefaultValue = 5;
        private readonly static string RuleName = string.Empty;
        private readonly static int ExtraNestedBlockDepth = 1;

        public override ICollection<IPropertyControlPage> SettingsPages
        {
            get
            {
                return new IPropertyControlPage[] { new NestedBlockDepthSettingsPageSettingsPage(this) };
            }
        }
        private int MaximumNestedBlockDepth { get; set; }

        static NestedBlockDepth()
        {
            RuleName = typeof(NestedBlockDepth).Name;
        }

        public override void AnalyzeDocument(CodeDocument document)
        {
            CsDocument csharpDocument = (CsDocument)document;
            if (csharpDocument.RootElement != null && !csharpDocument.RootElement.Generated)
            {
                LoadMaximumNestedBlockDepth(document.Settings);

                csharpDocument.WalkDocument(new CodeWalkerElementVisitor<object>(this.VisitElement), null, null);
            }
        }

        private void LoadMaximumNestedBlockDepth(Settings settings)
        {
            IntProperty maximumMethodLineCountProperty = this.GetSetting(settings, MaximumNestedBlockDepthSettingName) as IntProperty;
            if (maximumMethodLineCountProperty != null)
            {
                MaximumNestedBlockDepth = maximumMethodLineCountProperty.Value;
            }
            else
            {
                MaximumNestedBlockDepth = MaximumNestedBlockDepthDefaultValue;
            }
        }

        private bool VisitElement(CsElement element, CsElement parentElement, object context)
        {
            if (element.ElementType == ElementType.Method)
            {
                int numberOfDepthInMethod = CalculateNestedBlockDepth(element);
                if (numberOfDepthInMethod > MaximumNestedBlockDepth)
                {
                    this.AddViolation(element, RuleName, MaximumNestedBlockDepth, numberOfDepthInMethod);
                }
            }
            return true;
        }

        private int CalculateNestedBlockDepth(CsElement element)
        {
            int currentLine = 0;
            List<int> allBlockLocation = new List<int>();
            foreach (CsToken token in element.Tokens)
            {     
                if (token.LineNumber == currentLine)
                {
                    continue;
                }

                if (token.CsTokenType == CsTokenType.WhiteSpace)
                {
                    continue;
                }

                currentLine = token.LineNumber;
                allBlockLocation.Add(token.Location.StartPoint.IndexOnLine);
            }

            IEnumerable<int> distinctBlockLocationList = allBlockLocation.Distinct();

            // Depth = Total - [ExtraNestedBlockDepth] 
            // [ExtraNestedBlockDepth]: Method header has a index count
            int dephtCount = distinctBlockLocationList.Count() - ExtraNestedBlockDepth;

            return dephtCount;
        }
    }
}
