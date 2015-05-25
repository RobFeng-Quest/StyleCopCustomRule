using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StyleCop;

namespace SOEP.StyleCopRules
{

    public partial class MethodsShouldNotHaveTooManyLinesSettingsPage : UserControl, IPropertyControlPage
    {
        private bool dirty;

        private MethodsShouldNotHaveTooManyLines Analyzer { get; set; }
        public PropertyControl StyleCopTabControl { get; set; }
        public bool Dirty
        {
            get
            {
                return this.dirty;
            }
            set
            {
                if (this.dirty != value)
                {
                    this.dirty = value;
                    this.StyleCopTabControl.DirtyChanged();
                }
            }
        }
        public string TabName
        {
            get { return "MethodShouldNotHaveTooManyLines Rule"; }
        }

        public MethodsShouldNotHaveTooManyLinesSettingsPage(MethodsShouldNotHaveTooManyLines Analyzer)
        {
            this.Analyzer = Analyzer;

            InitializeComponent();
        }

        public void Initialize(PropertyControl propertyControl)
        {
            // Save the property control. 
            this.StyleCopTabControl = propertyControl;

            // Load the current settings and initialize the controls on the form.
            this.InitializeSettings();

            // Put the form into 'not-dirty' state.  
            this.dirty = false;
            this.StyleCopTabControl.DirtyChanged();
        }

        public bool Apply()
        {
            if (this.Analyzer != null)
            {
                this.Analyzer.SetSetting(
                    this.StyleCopTabControl.LocalSettings,
                    new IntProperty(
                        this.Analyzer,
                        MethodsShouldNotHaveTooManyLines.MaximumMethodLineCountSettingName,
                        (int)this.nudMaxMethodLineCount.Value));
            }

            this.dirty = false;
            this.StyleCopTabControl.DirtyChanged();

            return true;
        }

        private void InitializeSettings()
        {
            // Load the current setting
            IntProperty maximumMethodLineCountSettingProperty = this.Analyzer.GetSetting(
                this.StyleCopTabControl.MergedSettings,
                MethodsShouldNotHaveTooManyLines.MaximumMethodLineCountSettingName) as IntProperty;

            if (maximumMethodLineCountSettingProperty != null)
            {
                // Set the value of the property into an edit box on the page.
                this.nudMaxMethodLineCount.Value = maximumMethodLineCountSettingProperty.Value;
            }
        }

        private void nudMaxMethodLineCount_ValueChanged(object sender, EventArgs e)
        {
            this.dirty = true;
            this.StyleCopTabControl.DirtyChanged();
        }

        public bool PreApply()
        {
            return true;
        }

        public void Activate(bool activated)
        {
            // Nothing to do
        }

        public void PostApply(bool wasDirty)
        {
            // Nothing to do
        }

        public void RefreshSettingsOverrideState()
        {
            // Nothing to do
        }
    }
}
