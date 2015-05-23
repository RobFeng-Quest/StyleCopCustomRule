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
    public class MethodsShouldNotHaveTooManyLines : SourceAnalyzer
    {
        private readonly static string RuleName = string.Empty;
        private readonly static int LineCountOfMethodHeaderAndTwoCurlyBracket = 3;

        static MethodsShouldNotHaveTooManyLines()
        {
            RuleName = typeof(MethodsShouldNotHaveTooManyLines).Name;
        }

        private int MaximumMethodLineCount { get; set; }

        public override void AnalyzeDocument(CodeDocument document)
        {
            CsDocument csharpDocument = (CsDocument)document;
            if (csharpDocument.RootElement != null && !csharpDocument.RootElement.Generated)
            {
                IntProperty maximumMethodLineCountProperty = this.GetSetting(document.Settings, "MaximumMethodLineCount") as IntProperty;
                if (maximumMethodLineCountProperty == null)
                {
                    maximumMethodLineCountProperty = this.GetRuleSetting(document.Settings, RuleName, "MaximumMethodLineCount") as IntProperty;
                
                }
                if (maximumMethodLineCountProperty != null)
                {
                    MaximumMethodLineCount = maximumMethodLineCountProperty.Value;
                }
                else
                {
                    MaximumMethodLineCount = 5;
                }

                csharpDocument.WalkDocument(
                    new CodeWalkerElementVisitor<object>(this.VisitElement),
                    new CodeWalkerStatementVisitor<object>(this.VisitStatement),
                    new CodeWalkerExpressionVisitor<object>(this.VisitExpression));
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

        private bool VisitStatement(Statement statement, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context)
        {
            return true;
        }

        private bool VisitExpression(Expression expression, Expression parentExpression, Statement parentStatement, CsElement parentElement, object context)
        {
            return true;
        }

    }

}
