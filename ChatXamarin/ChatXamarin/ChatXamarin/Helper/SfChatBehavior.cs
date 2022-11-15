using Syncfusion.ListView.XForms;
using Syncfusion.XForms.Chat;
using Syncfusion.XForms.EffectsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ChatXamarin
{
    public class SfChatBehavior : Behavior<SfChat>
    {
        #region Fields

        private SfChat sfChat = null;

        #endregion

        #region Overrides

        protected override void OnAttachedTo(SfChat bindable)
        {
            base.OnAttachedTo(bindable);
            sfChat = bindable;
            if (sfChat != null)
            {
                sfChat.Editor.TextChanged += Editor_TextChanged;
            }
        }

        protected override void OnDetachingFrom(SfChat bindable)
        {
            base.OnAttachedTo(bindable);
            sfChat.Editor.TextChanged -= Editor_TextChanged;
            sfChat = null;
           
        }

        #endregion

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            var editorGrid = this.sfChat.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name == "FooterView").GetValue(this.sfChat) as Grid;
            var inputView = editorGrid.Children.FirstOrDefault(x => x.GetType() == typeof(MessageInputView)) as MessageInputView;
            var border = (inputView as ContentView).Content;
            var grid = (border as ContentView).Content as Grid;
            if ((sender as Editor).Text.Length >= 40)
            {
                (grid.Children[2] as SendMessageView).IsVisible = false;
            }
            else
                ((grid.Children[2] as SendMessageView)).IsVisible = true;
        }
    }
}
