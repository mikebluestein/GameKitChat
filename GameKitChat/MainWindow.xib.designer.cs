// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace GameKitChat {
    
    
    // Base type probably should be MonoTouch.Foundation.NSObject or subclass
    [MonoTouch.Foundation.Register("AppDelegate")]
    public partial class AppDelegate {
        
        private MonoTouch.UIKit.UIWindow __mt_window;
        
        private MonoTouch.UIKit.UITextView __mt_chatLog;
        
        private MonoTouch.UIKit.UITextField __mt_chatText;
        
        private MonoTouch.UIKit.UIBarButtonItem __mt_joinButton;
        
        #pragma warning disable 0169
        [MonoTouch.Foundation.Connect("window")]
        private MonoTouch.UIKit.UIWindow window {
            get {
                this.__mt_window = ((MonoTouch.UIKit.UIWindow)(this.GetNativeField("window")));
                return this.__mt_window;
            }
            set {
                this.__mt_window = value;
                this.SetNativeField("window", value);
            }
        }
        
        [MonoTouch.Foundation.Connect("chatLog")]
        private MonoTouch.UIKit.UITextView chatLog {
            get {
                this.__mt_chatLog = ((MonoTouch.UIKit.UITextView)(this.GetNativeField("chatLog")));
                return this.__mt_chatLog;
            }
            set {
                this.__mt_chatLog = value;
                this.SetNativeField("chatLog", value);
            }
        }
        
        [MonoTouch.Foundation.Connect("chatText")]
        private MonoTouch.UIKit.UITextField chatText {
            get {
                this.__mt_chatText = ((MonoTouch.UIKit.UITextField)(this.GetNativeField("chatText")));
                return this.__mt_chatText;
            }
            set {
                this.__mt_chatText = value;
                this.SetNativeField("chatText", value);
            }
        }
        
        [MonoTouch.Foundation.Connect("joinButton")]
        private MonoTouch.UIKit.UIBarButtonItem joinButton {
            get {
                this.__mt_joinButton = ((MonoTouch.UIKit.UIBarButtonItem)(this.GetNativeField("joinButton")));
                return this.__mt_joinButton;
            }
            set {
                this.__mt_joinButton = value;
                this.SetNativeField("joinButton", value);
            }
        }
    }
}
