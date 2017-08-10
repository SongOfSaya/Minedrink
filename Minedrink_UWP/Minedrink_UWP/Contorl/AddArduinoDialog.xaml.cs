using Minedrink_UWP.Model;
using Minedrink_UWP.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Minedrink_UWP.Contorl
{
    public enum SignInResult
    {
        SignInOK,
        SignInFail,
        SignInCancel,
        Nothing
    }

    public sealed partial class AddArduinoDialog : ContentDialog
    {
        public SignInResult Result { get; private set; }
        public AddArduinoDialog()
        {
            this.InitializeComponent();
            Result = SignInResult.Nothing;
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            try
            {
                Windows.Networking.Sockets.StreamSocket clientSocket = new Windows.Networking.Sockets.StreamSocket();
                Windows.Networking.HostName serverHost = new Windows.Networking.HostName(arduinoIPTextBox.Text);

                string serverPort = arduinoPortTextBox.Text;
                await clientSocket.ConnectAsync(serverHost, serverPort);

                Stream streamOut = clientSocket.OutputStream.AsStreamForWrite();
                StreamWriter write = new StreamWriter(streamOut);
                

                Stream streamIn = clientSocket.InputStream.AsStreamForRead();
                StreamReader reader = new StreamReader(streamIn);


                string inStr = "";
                string outStr = "#TCPCONN";
;
                bool tcpDone = false;
                while (!tcpDone)
                {
                    if (outStr!=null)
                    {
                        await write.WriteLineAsync(outStr);
                        await write.FlushAsync();
                    }
                    

                    inStr = await reader.ReadLineAsync();
                    Debug.WriteLine("IN:" + inStr);
                    if (inStr.StartsWith("#"))
                    {
                        string codeStr = inStr.Substring(0, 8);
                        RXCommCode code = CommHandle.StringConvertToEnum(codeStr);

                        switch (code)
                        {
                            case RXCommCode.TcpDone:
                                Arduino arduino = new Arduino(clientSocket, write,reader);
                                ConfigPage.Current.Arduinos.Add(arduino);
                                tcpDone = true;
                                break;
                            case RXCommCode.ERROR:
                                Debug.WriteLine("错误的指令:" + codeStr);
                                break;
                            default:
                                break;
                        }
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Result = SignInResult.SignInCancel;
        }
    }
}
