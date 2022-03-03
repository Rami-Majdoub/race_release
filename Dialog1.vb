Imports System.Windows.Forms

Public Class Dialog1

    Dim msg As String
    Dim nb_v_check As Integer = 0
    Dim site = "https://docs.google.com/forms/d/1yI3U0D70XfemW3Ov3eoJhZ-zymRce9os4OTfx3903f0/viewform"
    Dim btn_id = "ss-submit"
    Dim body_id = "entry_1768524988"
    Dim title = "Car Racing"
    Dim title_sent = "Merci !"

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_NOCLOSE As Integer = &H200
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        msg = TextBox1.Text & " (" & My.Computer.Name & " " & Date.Now.ToString & ")" & vbCrLf & TextBox2.Text & vbCrLf
        msg &= "High Scores :" & vbCrLf
        msg &= "1) " & My.Settings.score1 & vbCrLf 
        msg &= "2) " & My.Settings.score2 & vbCrLf
        msg &= "3) " & My.Settings.score3 & vbCrLf
        msg &= "4) " & My.Settings.score4 & vbCrLf
        msg &= "5) " & My.Settings.score5 & vbCrLf
        'MsgBox(msg)
        My.Settings.My_Name = TextBox1.Text
        My.Settings.FB_ID = TextBox2.Text
        My.Settings.Save()

        If TextBox1.Text = "Your Name" Or TextBox1.Text = "" Or InStr(TextBox1.Text, "Your Name") Then
            Demo_Label.Text = "Write Your Name"
        ElseIf TextBox2.Text.ToUpper = "http://www.Facebook.com/".ToUpper Or TextBox2.Text = "" Or Not InStr(TextBox2.Text.ToUpper, "Http://www.Facebook.com/".ToUpper) = 1 Then
            Demo_Label.Text = "Write Your FB ID"

        Else
            If My.Computer.Network.IsAvailable Then
                Demo_Label.Text = "Sending 0%..."
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                OK_Button.Enabled = False
                WebBrowser1.Navigate(site)
            Else
                Demo_Label.Text = "No Internet!"
            End If
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        WebBrowser1.Stop()
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OK_Button.Select()
        nb_v_check = 0
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        OK_Button.Enabled = True
        Demo_Label.Text = ""
        TextBox1.Text = My.Settings.My_Name
        TextBox2.Text = My.Settings.FB_ID
        Left = Form1.Left + (Form1.Width - Me.Width) / 2
        Top = Form1.Top + (Form1.Height - Me.Height) / 2
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        If WebBrowser1.DocumentTitle = title Then
            WebBrowser1.Document.GetElementById(body_id).SetAttribute("value", msg)
            WebBrowser1.Document.GetElementById(btn_id).InvokeMember("click")
            nb_v_check += 1
            Demo_Label.Text = "Sending 50%..."

        ElseIf WebBrowser1.DocumentTitle = title_sent Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            OK_Button.Enabled = True
            Demo_Label.Text = "Scores Sent"
        Else
            If nb_v_check < 3 Then WebBrowser1.Navigate(site)
            If nb_v_check >= 3 Then Demo_Label.Text = "Internet Error"
        End If

    End Sub
End Class
