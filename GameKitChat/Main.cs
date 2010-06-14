
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.GameKit;

namespace GameKitChat
{
    public class Application
    {
        static void Main (string[] args)
        {
            UIApplication.Main (args);
        }
    }

    public partial class AppDelegate : UIApplicationDelegate
    {
        public GKSession GameKitSession { get; set; }

        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            chatLog.Editable = false;
            chatText.AutocorrectionType = UITextAutocorrectionType.No;
            chatText.AutocapitalizationType = UITextAutocapitalizationType.None;
            chatText.BecomeFirstResponder ();
            
            chatText.ShouldReturn += delegate {
                
                AddMessage (chatText.Text);
                GameKitSession.SendDataToAllPeers (chatText.Text, GKSendDataMode.Unreliable, IntPtr.Zero);
                chatText.Text = "";
                return true;
            };
            
            joinButton.Clicked += delegate { ShowPeerPicker (); };

            window.MakeKeyAndVisible ();
            return true;
        }

        void AddMessage (string text)
        {
            chatLog.Text += String.Format ("\r\n {0}", text);
            chatLog.ScrollToBottom ();
        }

        void ShowPeerPicker ()
        {
            
            GameKitSession = new GKSession ("com.mikebluestein.gamekitchat", UIDevice.CurrentDevice.Name, GKSessionMode.Peer);
            GameKitSession.ReceiveData += (s, e) => { AddMessage (NSString.FromData (e.Data, NSStringEncoding.UTF8).ToString ()); };
            GameKitSession.ConnectionRequest += (s, e) => { e.Session.AcceptConnection (e.PeerID, IntPtr.Zero); };
            
            GKPeerPickerController peerPickerController = new GKPeerPickerController ();
            peerPickerController.Delegate = new PeerPickerDelegate (this);
            peerPickerController.ConnectionTypesMask = GKPeerPickerConnectionType.Nearby;
            peerPickerController.Show ();
            
        }

        class PeerPickerDelegate : GKPeerPickerControllerDelegate
        {
            AppDelegate _controller;

            public PeerPickerDelegate (AppDelegate controller)
            {
                _controller = controller;
            }

            public override GKSession GetSession (GKPeerPickerController picker, GKPeerPickerConnectionType forType)
            {
                return _controller.GameKitSession;
            }

            public override void PeerConnected (GKPeerPickerController picker, string peerId, GKSession toSession)
            {
                _controller.GameKitSession = toSession;
                
                picker.Dismiss ();
                picker.Delegate = null;
                
                //just disabling once connection is made for simplicity
                _controller.joinButton.Title = "Connected";
                _controller.joinButton.Enabled = false;
            }

            public override void ControllerCancelled (GKPeerPickerController picker)
            {
                picker.Delegate = null;
            }
        }

        public override void OnActivated (UIApplication application)
        {
        }
    }

    public static class UITextViewExtension
    {
        public static void ScrollToBottom (this UITextView textView)
        {
            textView.ScrollRangeToVisible (new NSRange (textView.Text.Length - 1, 1));
        }
    }
}
