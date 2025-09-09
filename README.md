# disable-send-icon-when-editor-text-reaches-certain-length-xamarin.forms-chat
This sample demonstrates how to disable the send icon when the editor text reaches a certain length in Xamarin.Forms Chat (SfChat).

## Sample

```xaml

    <ContentPage.Content>
        <sfChat:SfChat x:Name="sfChat"
                       Messages="{Binding Messages}"
                       CurrentUser="{Binding CurrentUser}"   
                       ShowIncomingMessageAvatar="True"
                       ShowOutgoingMessageAvatar="True">
            <sfChat:SfChat.Behaviors>
                <local:SfChatBehavior/>
            </sfChat:SfChat.Behaviors>
        </sfChat:SfChat>
    </ContentPage.Content

Behavior:

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

```

## Requirements to run the demo

To run the demo, refer to [System Requirements for Xamarin](https://help.syncfusion.com/xamarin/system-requirements)

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
