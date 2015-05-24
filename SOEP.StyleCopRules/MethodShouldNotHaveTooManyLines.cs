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
    public class MethodShouldNotHaveTooManyLines : SourceAnalyzer
    {
        public readonly static string MaximumMethodLineCountSettingName = "MaximumMethodLineCount";
        private readonly static int MaximumMethodLineCountDefaultValue = 50;
        private readonly static string RuleName = string.Empty;
        private readonly static int LineCountOfMethodHeaderAndTwoCurlyBracket = 3;

        public override ICollection<IPropertyControlPage> SettingsPages
        {
            get
            {
                return new IPropertyControlPage[] { new MethodShouldNotHaveTooManyLinesSettingsPage(this) };
            }
        }
        private int MaximumMethodLineCount { get; set; }

        static MethodShouldNotHaveTooManyLines()
        {
            RuleName = typeof(MethodShouldNotHaveTooManyLines).Name;
        }

        public override void AnalyzeDocument(CodeDocument document)
        {
            CsDocument csharpDocument = (CsDocument)document;
            if (csharpDocument.RootElement != null && !csharpDocument.RootElement.Generated)
            {
                LoadMaximumMethodLineCount(document.Settings);

                csharpDocument.WalkDocument(new CodeWalkerElementVisitor<object>(this.VisitElement), null, null);
            }
        }

        private void LoadMaximumMethodLineCount(Settings settings)
        {
            IntProperty maximumMethodLineCountProperty = this.GetSetting(settings, MaximumMethodLineCountSettingName) as IntProperty;
            if (maximumMethodLineCountProperty != null)
            {
                MaximumMethodLineCount = maximumMethodLineCountProperty.Value;
            }
            else
            {
                MaximumMethodLineCount = MaximumMethodLineCountDefaultValue;
            }
        }

        private bool VisitElement(CsElement element, CsElement parentElement, object context)
        {
            if (element.ElementType == ElementType.Method)
            {
                int numberOfLinesInMethod = element.Location.LineSpan - LineCountOfMethodHeaderAndTwoCurlyBracket;
                if (numberOfLinesInMethod > MaximumMethodLineCount)
                {
                    this.AddViolation(element, RuleName, element.Declaration.Name, numberOfLinesInMethod, MaximumMethodLineCount);
                }
            }
            return true;
        }
    }
}
